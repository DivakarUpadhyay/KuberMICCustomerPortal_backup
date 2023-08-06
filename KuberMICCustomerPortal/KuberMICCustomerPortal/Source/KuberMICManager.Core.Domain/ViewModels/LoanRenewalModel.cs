using System;
using System.Linq;
using System.Text.Json;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class LoanRenewalModel
    {
        public string RecId { get; set; }
        public string Account { get; set; }
        public string FullName { get; set; }
        public string PrimaryFirstLastName { get; set; }
        public string CoBorrowersList { get; set; }
        public string DirectorsList { get; set; }
        public string ConscentingSpouse { get; set; }
        public decimal? PrinBal { get; set; }
        public decimal? PrinPaydown { get; set; }
        public decimal? NewPrinBal { get; set; }
        public decimal? PmtPi { get; set; }
        public LoanPriority? Priority { get; set; }
        public decimal? NoteRate { get; set; }
        public decimal? SoldRate { get; set; }
        public DateTime? PaidToDate { get; set; }
        public string PropertyAddresses { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Notes { get; set; }
        public DateTime? MaturityDate { get; set; }
        public MortgageRenewalStatus RenewalStatus { get; set; }
        public MortgageRenewalTerms RenewalTerms { get; set; }
        public MortgageType MortgageType { get; set; }

        public decimal? PrimeInterestRate { get; set; }
        public decimal? RenewalIR { get; set; }
        public bool? RenewalIRIsVariable { get; set; }

        public decimal? RenewalFee { get; set; }
        public bool? RenewalFeeIsDollar { get; set; }
        public bool AddRenewalFeeToPrinBal { get; set; }

        public decimal? LenderFee { get; set; }
        public bool? LenderFeeIsDollar { get; set; }
        public bool AddLenderFeeToPrinBal { get; set; }

        public decimal? BrokerFee { get; set; }
        public bool? BrokerFeeIsDollar { get; set; }
        public bool AddBrokerFeeToPrinBal { get; set; }

        public decimal? AdminFee { get; set; }
        public bool AddAdminFeeToPrinBal { get; set; }

        public decimal? AppraisalFee { get; set; }
        public bool AddAppraisalFeeToPrinBal { get; set; }

        public string OtherFees { get; set; }

        public bool IDExpired { get; set; }
        public bool FireInsuranceExpired { get; set; }

        // Dynamic
        public int DaysLeft { get; set; }
        public int PastRenewalCount { get; set; }

        public decimal GetPrimeInterestRate()
        {
            return Math.Round((decimal)PrimeInterestRate, 2);
        }

        public decimal GetPrinPaydown()
        {
            return Math.Round(PrinPaydown ?? 0, 2);
        }

        public bool RenewalIsActive(MortgageRenewalStatus renewalStatus)
        {
            return renewalStatus != MortgageRenewalStatus.Completed && renewalStatus != MortgageRenewalStatus.PaidOff;
        }

        public decimal? GetNewRegularPayment()
        {
            return GetNewPrincipalBalance() * GetRenewalIR() / (100 * 12);
        }

        public decimal? GetNewPrincipalBalance()
        {
            decimal? newPrinBal = (PrinBal ?? 0) - (PrinPaydown ?? 0);

            if ((bool)AddRenewalFeeToPrinBal)
                newPrinBal += GetRenewalFee();

            if ((bool)AddBrokerFeeToPrinBal)
                newPrinBal += GetBrokerFee();

            if ((bool)AddLenderFeeToPrinBal)
                newPrinBal += GetLenderFee();

            if ((bool)AddAdminFeeToPrinBal)
                newPrinBal += AdminFee;

            if ((bool)AddAppraisalFeeToPrinBal)
                newPrinBal += AppraisalFee;

            using JsonDocument doc = JsonDocument.Parse(OtherFees);

            foreach (var fee in doc.RootElement.EnumerateArray())
            {
                if (fee.GetProperty("AddToPrincipal").GetBoolean())
                {
                    string value = fee.GetProperty("Value").ToString();
                    newPrinBal += decimal.Parse(value);
                }
            }

            return newPrinBal;
        }

        public bool IsNewPrincipalBalance()
        {
            return decimal.Compare(PrinBal ?? 0, GetNewPrincipalBalance() ?? 0) != 0;
        }

        public decimal GetBrokerFee()
        {
            decimal brokerFee = BrokerFee ?? 0;

            if (!(bool)BrokerFeeIsDollar)
                brokerFee = (PrinBal ?? 0) * (BrokerFee ?? 0) / 100;

            return Math.Round(brokerFee);
        }

        public decimal GetLenderFee()
        {
            decimal lenderFee = LenderFee ?? 0;

            if (!(bool)LenderFeeIsDollar)
                lenderFee = (PrinBal ?? 0) * (LenderFee ?? 0) / 100;

            return Math.Round(lenderFee);
        }

        public decimal GetRenewalFee()
        {
            decimal renewalFee = RenewalFee ?? 0;

            if (!(bool)RenewalFeeIsDollar)
                renewalFee = (PrinBal ?? 0) * (RenewalFee ?? 0) / 100;

            return Math.Round(renewalFee);
        }

        public decimal GetOtherTotalFee()
        {
            if (string.IsNullOrEmpty(OtherFees) || OtherFees == "0")
                return 0;

            decimal otherTotalFee = 0;

            using JsonDocument doc = JsonDocument.Parse(OtherFees);

            foreach (var fee in doc.RootElement.EnumerateArray())
            {
                string value = fee.GetProperty("Value").ToString();
                otherTotalFee += decimal.Parse(value);
            }

            return otherTotalFee;
        }

        public decimal GetRenewalIR()
        {
            return (bool)RenewalIRIsVariable ? ((decimal)RenewalIR + (PrimeInterestRate ?? 0)) : (decimal)RenewalIR;
        }

        public decimal GetIncreasedRenewalIR()
        {
            return GetRenewalIR() + (decimal)2.5;
        }

        public decimal GetIncreasedLenderFee()
        {
            return GetLenderFee() + (GetNewPrincipalBalance() ?? 0) / 100;
        }

        public DateTime? GetRenewalTermEndDate()
        {
            DateTime? renewalTermEndDate = MaturityDate.Value.AddYears(1);

            if (RenewalTerms == MortgageRenewalTerms.ThreeMonths)
                renewalTermEndDate = MaturityDate.Value.AddMonths(3);
            else if (RenewalTerms == MortgageRenewalTerms.SixMonths)
                renewalTermEndDate = MaturityDate.Value.AddMonths(6);

            return renewalTermEndDate;
        }

        public DateTime? GetPaymentDate()
        {
            return MaturityDate.Value.AddMonths(1);
        }

        public DateTime? GetAppraisalDeadlineDate()
        {
            return MaturityDate.Value.AddMonths(-1);
        }

        private decimal? GetTotalFees()
        {
            return GetBrokerFee() + GetLenderFee() + GetRenewalFee() + AdminFee + AppraisalFee + GetOtherTotalFee();
        }

        public decimal? GetCostOfBorrowing()
        {
            return Math.Round((decimal)GetNewRegularPayment(), 2) * (int)RenewalTerms + GetTotalFees();
        }

        public decimal? GetPercentAPR()
        {
            if (GetNewPrincipalBalance() == 0)
                return 0;

            return GetCostOfBorrowing() * 12 * 100 / ((int)RenewalTerms * GetNewPrincipalBalance()) ;
        }

        public string GetBorrowersNameList()
        {
            string nameList = FullName;
            if (!String.IsNullOrEmpty(CoBorrowersList))
            {
                nameList += ", " + CoBorrowersList?.Replace(",", ", ");
                var lastComma = nameList.LastIndexOf(',');
                if (lastComma != -1) nameList = nameList.Remove(lastComma, 1).Insert(lastComma, " &amp;");
            }

            return nameList;
        }
    }
}