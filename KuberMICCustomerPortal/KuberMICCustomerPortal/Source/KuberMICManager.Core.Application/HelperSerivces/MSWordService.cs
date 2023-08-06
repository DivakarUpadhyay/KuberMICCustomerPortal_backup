using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ViewModels;
using System;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Application.HelperSerivces
{
    public class MSWordService : IMSWordService
    {
        // To search and replace content in a document part.
        public void GetMortgageRenewalAgreementFromTemplate(string templateDocPath, string destDocPath, LoanRenewalModel loanRenewalData)
        {
            using (var mainDoc = WordprocessingDocument.Open(templateDocPath, false))
            using (var resultDoc = WordprocessingDocument.Create(destDocPath, WordprocessingDocumentType.Document))
            {
                // copy parts from source document to new document to be modified and downloaded
                foreach (var part in mainDoc.Parts)
                    resultDoc.AddPart(part.OpenXmlPart, part.RelationshipId);

                // Read the main content
                string docText = null;
                using (StreamReader sr = new StreamReader(mainDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                // Replace tags with info
                docText = Regex.Replace(docText, @"LetterDate", String.Format("{0:MM/dd/yyyy}", DateTime.Today));
                docText = Regex.Replace(docText, @"LoanAccount", loanRenewalData.Account);
                docText = Regex.Replace(docText, @"FullName", loanRenewalData.GetBorrowersNameList());
                docText = Regex.Replace(docText, @"PropertyAddress", loanRenewalData.PropertyAddresses);
                docText = Regex.Replace(docText, @"MaturityDate", String.Format("{0:MM/dd/yyyy}", loanRenewalData.MaturityDate));
                docText = Regex.Replace(docText, @"RenewalTerms", loanRenewalData.RenewalTerms.ToDescription());
                docText = Regex.Replace(docText, @"RenewalTermStartDate", String.Format("{0:MMM dd, yyyy}", loanRenewalData.MaturityDate));
                docText = Regex.Replace(docText, @"RenewalTermEndDate", String.Format("{0:MMM dd, yyyy}", loanRenewalData.GetRenewalTermEndDate()));
                docText = Regex.Replace(docText, @"RenewalMaturingDate", String.Format("{0:MM/dd/yyyy}", loanRenewalData.GetRenewalTermEndDate()));

                string mortgageType = loanRenewalData.MortgageType.ToString();
                if (loanRenewalData.MortgageType == MortgageType.Closed)
                {
                    mortgageType += $" (Early payment of the mortgage will be subject to a {((loanRenewalData.RenewalTerms == MortgageRenewalTerms.TwelveMonths) ? 2 : 1)}-month pre-payment charge plus a 30-day notice period.  Partial payments are not accepted).";
                }
                docText = Regex.Replace(docText, @"MortgageType", mortgageType);

                docText = Regex.Replace(docText, @"IncreasedRenewalIR", String.Format("{0:n2}%", loanRenewalData.GetIncreasedRenewalIR()));
                docText = Regex.Replace(docText, @"IncreasedLenderFee", String.Format("${0:n2}", loanRenewalData.GetIncreasedLenderFee()));
                string principalBal = "Principal Balance";
                if (loanRenewalData.PrinBal == loanRenewalData.GetNewPrincipalBalance()) // No change in principal balance
                {
                    principalBal += $": {String.Format("${0:n2}", loanRenewalData.GetNewPrincipalBalance())}";

                    if (loanRenewalData.PrinPaydown > 0)
                    {
                        principalBal += $"Principal Paydown at Maturity: {String.Format("${0:n2}", loanRenewalData.PrinPaydown)}<w:br/><w:br/>";
                        principalBal += $"Principal Balance after Renewal: {String.Format("${0:n2}", loanRenewalData.GetNewPrincipalBalance())}";
                    }
                }
                else // Fees added to principal balance
                {
                    principalBal += $" at Maturity: {String.Format("${0:n2}", loanRenewalData.PrinBal)}<w:br/><w:br/>";

                    if (loanRenewalData.PrinPaydown > 0)
                    {
                        principalBal += $"Principal Paydown at Maturity: {String.Format("${0:n2}", loanRenewalData.PrinPaydown)}<w:br/><w:br/>";
                    }

                    principalBal += $"Principal Balance after Renewal: {String.Format("${0:n2}", loanRenewalData.GetNewPrincipalBalance())}";
                }

                docText = Regex.Replace(docText, @"PrinBal", principalBal);
                docText = Regex.Replace(docText, @"LoanPriority", loanRenewalData.Priority.ToDescription());

                string interestRate = String.Format("{0:n2}", loanRenewalData.GetRenewalIR());
                string interestRateText = $"{interestRate}% per annum (The present annual interest rate is {interestRate}%  per year calculated monthly, not in advance)"; ;
                if ((bool)loanRenewalData.RenewalIRIsVariable)
                {
                    interestRateText = $"{interestRate}% variable, per annum calculated monthly, not in advance. " +
                                       "The interest rate is a variable interest rate which is equal to the BMO prime commercial rate (the \"Prime Rate\") " +
                                       $"plus {String.Format("{0:n2}", loanRenewalData.RenewalIR)}%. The Interest rate is subject to change upward whenever " +
                                       "the Prime Rate increases by the amount of such increase plus 0.50%. The interest rate will be adjusted on the date the " +
                                       "change in the Prime Rate comes into effect. As of the date of this mortgage commitment, the Prime Rate is " +
                                       $"{String.Format("{0:n2}", loanRenewalData.PrimeInterestRate)}%. For greater certainty, the " +
                                       "interest rate will never be adjusted downward, but only adjusted upward when the Prime Rate increases.";
                }
                docText = Regex.Replace(docText, @"InterestRate", interestRateText);

                string AllRenewalFees = "";
                if (loanRenewalData.GetRenewalFee() != 0)
                {
                    AllRenewalFees += $"Renewal Fee: ${String.Format("{0:n2}", loanRenewalData.GetRenewalFee())}<w:br/><w:br/>";
                }

                if (loanRenewalData.GetBrokerFee() != 0)
                {
                    AllRenewalFees += $"Broker Fee: ${String.Format("{0:n2}", loanRenewalData.GetBrokerFee())}<w:br/><w:br/>";
                }

                if (loanRenewalData.GetLenderFee() != 0)
                {
                    AllRenewalFees += $"Lender Fee: ${String.Format("{0:n2}", loanRenewalData.GetLenderFee())}<w:br/><w:br/>";
                }

                if ((loanRenewalData.AdminFee ?? 0) != 0)
                {
                    AllRenewalFees += $"Administration  Fee: ${String.Format("{0:n2}", loanRenewalData.AdminFee)}<w:br/><w:br/>";
                }

                if (!string.IsNullOrEmpty(loanRenewalData.OtherFees) && loanRenewalData.GetOtherTotalFee() != 0)
                {
                    using JsonDocument doc = JsonDocument.Parse(loanRenewalData.OtherFees);

                    foreach (var fee in doc.RootElement.EnumerateArray())
                    {
                        decimal value = decimal.Parse(fee.GetProperty("Value").ToString());
                        if (value > 0)
                        {
                            AllRenewalFees += $"{fee.GetProperty("Name").ToString()}: ${String.Format("{0:n2}", value)}<w:br/><w:br/>";
                        }
                    }
                }

                if ((loanRenewalData.AppraisalFee ?? 0) != 0)
                {
                    AllRenewalFees += $"Appraisal Cost: ${String.Format("{0:n2}", loanRenewalData.AppraisalFee)}<w:br/><w:br/>";
                }

                if (!String.IsNullOrEmpty(AllRenewalFees)) {
                    AllRenewalFees = AllRenewalFees.Substring(0, AllRenewalFees.LastIndexOf("<w:br/><w:br/>"));
                }

                docText = Regex.Replace(docText, @"AllRenewalFees", AllRenewalFees);

                docText = Regex.Replace(docText, @"PaymentDate", String.Format("{0:MM/dd/yyyy}", loanRenewalData.GetPaymentDate()));
                docText = Regex.Replace(docText, @"PaymentAmount", String.Format("{0:n2}", loanRenewalData.GetNewRegularPayment()));
                docText = Regex.Replace(docText, @"CostOfBorrowing", String.Format("{0:n2}", loanRenewalData.GetCostOfBorrowing()));
                docText = Regex.Replace(docText, @"PercentAPR", String.Format("{0:n3}", loanRenewalData.GetPercentAPR()));
                docText = Regex.Replace(docText, @"AppraisalDeadlineDate", String.Format("{0:MM/dd/yyyy}", loanRenewalData.GetAppraisalDeadlineDate()));
                docText = Regex.Replace(docText, @"ConditionsList", GetConditionsList(loanRenewalData));
                docText = Regex.Replace(docText, @"AllSignatures", GetSignatures(loanRenewalData));

                // Save the modified content to the download doc
                using (StreamWriter sw = new StreamWriter(resultDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }

        private static string GetSignatures(LoanRenewalModel loanRenewalData)
        {
            string calibriLight10Paragraph = "<w:p></w:p><w:p><w:r><w:rPr><w:rFonts w:asciiTheme='majorHAnsi' w:cstheme='majorHAnsi' w:eastAsia='Calibri' w:hAnsiTheme='majorHAnsi'/><w:sz w:val='20'/></w:rPr><w:t>ReplaceText</w:t></w:r></w:p>";
            string borrowerSignature = Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "Accepted by:") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "------------------------------------------------------------") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "Signature of BorrowerSignature");

            // CoBorrowers Signature
            string signatures = "";

            // Primary Borrower signature
            signatures += Regex.Replace(borrowerSignature, @"BorrowerSignature", loanRenewalData.PrimaryFirstLastName);

            // Add coborrowers
            if (!String.IsNullOrEmpty(loanRenewalData.CoBorrowersList))
            {
                foreach (string coBorrower in loanRenewalData.CoBorrowersList?.Split(','))
                {
                    signatures += Regex.Replace(borrowerSignature, @"BorrowerSignature", coBorrower);
                }
            }

            // Conscenting Spouse Signature
            if (!string.IsNullOrEmpty(loanRenewalData.ConscentingSpouse))
            {
                signatures += Regex.Replace(borrowerSignature, @"BorrowerSignature", loanRenewalData.ConscentingSpouse);
            }

            // Directors Signature
            string directorSignature = Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "FullName") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "------------------------------------------------------------") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "Name: DirectorName") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "Title: Director") +
                                       Regex.Replace(calibriLight10Paragraph, @"ReplaceText", "I have the authority to bind the corporation.");

            if (!String.IsNullOrEmpty(loanRenewalData.DirectorsList))
            {
                foreach (string director in loanRenewalData.DirectorsList?.Split(','))
                {
                    signatures += Regex.Replace(directorSignature, @"FullName", loanRenewalData.FullName).Replace(@"DirectorName", director);
                }
            }

            return signatures;
        }

        private static string GetConditionsList(LoanRenewalModel loanRenewalData)
        {
            string calibriLight10BulletPoints = "<w:p><w:pPr><w:numPr><w:ilvl w:val='0'/><w:numId w:val='1'/></w:numPr><w:spacing w:after='160' w:line='259' w:lineRule='auto'/>" +
                                                "<w:ind w:hanging='360' w:left='720'/><w:rPr><w:rFonts w:asciiTheme='majorHAnsi' w:cstheme='majorHAnsi' w:eastAsia='Calibri' w:hAnsiTheme='majorHAnsi'/><w:sz w:val='20'/></w:rPr></w:pPr>" +
                                                "<w:r><w:rPr><w:rFonts w:asciiTheme='majorHAnsi' w:cstheme='majorHAnsi' w:eastAsia='Calibri' w:hAnsiTheme='majorHAnsi'/><w:sz w:val='20'/></w:rPr><w:t xml:space='preserve'>ReplaceText</w:t></w:r></w:p>";
            string propertyTaxCondition = "Copy of current property tax bill and confirmation that all taxes are up to date;";
            string homeInsuranceCondition = "Copy of valid home insurance policy containing the standard mortgage clause";
            string fireInsuranceCondition = "Copy of fire insurance policy";
            string identificationCondition = "Copy of a valid government issued ID";

            string conditionsList = null;
            if (!loanRenewalData.IDExpired) 
            {
                if (!loanRenewalData.FireInsuranceExpired)
                {
                    conditionsList = Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{propertyTaxCondition} and") +
                                     Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{homeInsuranceCondition}.");
                }
                else
                {
                    conditionsList = Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{propertyTaxCondition}") +
                                     Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{homeInsuranceCondition}; and") +
                                     Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{fireInsuranceCondition}.");
                }
            }
            else
            {
                conditionsList = Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{propertyTaxCondition}");
                if (!loanRenewalData.FireInsuranceExpired)
                {
                    conditionsList += Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{homeInsuranceCondition}; and") +
                                      Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{identificationCondition}.");
                }
                else
                {
                    conditionsList += Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{homeInsuranceCondition};") +
                                     Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{fireInsuranceCondition}; and") +
                                     Regex.Replace(calibriLight10BulletPoints, @"ReplaceText", $"{identificationCondition}.");
                }
            }

            return conditionsList;
        }
    }
}