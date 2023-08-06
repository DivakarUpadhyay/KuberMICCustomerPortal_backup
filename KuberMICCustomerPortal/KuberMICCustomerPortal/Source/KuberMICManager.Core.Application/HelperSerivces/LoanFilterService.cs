using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Application.HelperSerivces
{
    public static class LoanFilterService
    {
        public static IEnumerable<TdsLoan> RenewalLoanFilter(IEnumerable<TdsLoan> Loans, double numOfDaysLoansUpForRenewal)
        {
            return Loans.Where(loan => loan.PrinBal > 0 && DateTime.Today > loan.MaturityDate.Value.AddDays(-numOfDaysLoansUpForRenewal));
        }

        public static IEnumerable<TdsLoan> StressTestLoanFilter(IEnumerable<TdsLoan> Loans, LoanFilterType? FilterType, StressTestReportModel stressTestReportData, IEnumerable<TdsProperty> propertyList, IEnumerable<UdfValue> customFieldsValueList, IEnumerable<string> outsideGTAPostCodes, IEnumerable<TdsLien> lienList, DateTime? L4StressTestAppraisalLimitDate = null)
        {
            IEnumerable<TdsLoan> filteredLoans = null;

            switch (FilterType)
            {
                #region Stress Test
                // Level 1 Stress Test: Start
                #region Stress Test: Level 1
                case LoanFilterType.L10To80Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) > 0 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) <= 80;
                        });
                        break;
                    }

                case LoanFilterType.L180To90Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) > 80 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) <= 90;
                        });
                        break;
                    }

                case LoanFilterType.L190To95Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) > 90 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) <= 95;
                        });
                        break;
                    }

                case LoanFilterType.L195To100Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) > 95 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) <= 100;
                        });
                        break;
                    }

                case LoanFilterType.L1Above100Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) > 100;
                        });
                        break;
                    }

                case LoanFilterType.L1OverThresholdLTVBelowThreshodBeaconScoreMortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) > stressTestReportData.AtRiskLTVThreshold &&
                                   GetAverageBeaconScore(loan, customFieldsValueList) < stressTestReportData.AtRiskBeaconScoreThreshold;
                        });
                        break;
                    }

                case LoanFilterType.L1OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level1MarketDeclineLimit) > stressTestReportData.AtRiskLTVThreshold &&
                                   GetAverageBeaconScore(loan, customFieldsValueList) < stressTestReportData.AtRiskBeaconScoreThreshold &&
                                   outsideGTAPostCodes.Contains(LoanFilterService.GetMortgageRegionCode(loan.RecId, propertyList));
                        });
                        break;
                    }
                #endregion
                // Level 1 Stress Test: End

                // Level 2 Stress Test: Start
                #region Stress Test: Level 2
                case LoanFilterType.L20To80Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) > 0 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) <= 80;
                        });
                        break;
                    }

                case LoanFilterType.L280To90Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) > 80 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) <= 90;
                        });
                        break;
                    }

                case LoanFilterType.L290To95Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) > 90 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) <= 95;
                        });
                        break;
                    }

                case LoanFilterType.L295To100Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) > 95 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) <= 100;
                        });
                        break;
                    }

                case LoanFilterType.L2Above100Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) > 100;
                        });
                        break;
                    }

                case LoanFilterType.L2OverThresholdLTVBelowThreshodBeaconScoreMortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) > stressTestReportData.AtRiskLTVThreshold &&
                                   GetAverageBeaconScore(loan, customFieldsValueList) < stressTestReportData.AtRiskBeaconScoreThreshold;
                        });
                        break;
                    }

                case LoanFilterType.L2OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level2MarketDeclineLimit) > stressTestReportData.AtRiskLTVThreshold &&
                                   GetAverageBeaconScore(loan, customFieldsValueList) < stressTestReportData.AtRiskBeaconScoreThreshold &&
                                   outsideGTAPostCodes.Contains(LoanFilterService.GetMortgageRegionCode(loan.RecId, propertyList));
                        });
                        break;
                    }
                #endregion
                // Level 2 Stress Test: End

                // Level 3 Stress Test: Start
                #region Stress Test: Level 3
                case LoanFilterType.L30To80Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) > 0 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) <= 80;
                        });
                        break;
                    }

                case LoanFilterType.L380To90Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) > 80 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) <= 90;
                        });
                        break;
                    }

                case LoanFilterType.L390To95Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) > 90 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) <= 95;
                        });
                        break;
                    }

                case LoanFilterType.L395To100Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) > 95 &&
                                   GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) <= 100;
                        });
                        break;
                    }

                case LoanFilterType.L3Above100Mortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) > 100;
                        });
                        break;
                    }

                case LoanFilterType.L3OverThresholdLTVBelowThreshodBeaconScoreMortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) > stressTestReportData.AtRiskLTVThreshold &&
                                   GetAverageBeaconScore(loan, customFieldsValueList) < stressTestReportData.AtRiskBeaconScoreThreshold;
                        });
                        break;
                    }

                case LoanFilterType.L3OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages:
                    {
                        filteredLoans = Loans.Where(loan => {
                            return GetLTVAfterCorrection(loan, lienList, propertyList, stressTestReportData.Level3MarketDeclineLimit) > stressTestReportData.AtRiskLTVThreshold &&
                                   GetAverageBeaconScore(loan, customFieldsValueList) < stressTestReportData.AtRiskBeaconScoreThreshold &&
                                   outsideGTAPostCodes.Contains(LoanFilterService.GetMortgageRegionCode(loan.RecId, propertyList));
                        });
                        break;
                    }
                case LoanFilterType.L4OverThresholdLTVBelowThreshodBeaconScoreMortgages:
                    {
                        // L4 Stress Test is for L3 Loans with primary property that has apprasial reports as of STRESSTESTLEVEL4APPRAISALDATEUPPERLIMIT date (including)
                        IEnumerable<TdsLoan> L3FilteredLoans = StressTestLoanFilter(Loans, LoanFilterType.L3OverThresholdLTVBelowThreshodBeaconScoreMortgages, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList);
                        filteredLoans = L3FilteredLoans.Where(l => propertyList.Any(p => p.LoanRecId == l.RecId && (bool)p.Primary && p.AppraisalDate.HasValue && p.AppraisalDate.Value.Date <= L4StressTestAppraisalLimitDate.Value.Date));

                        break;
                    }
                case LoanFilterType.L4OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages:
                    {
                        // L4 Stress Test is for L3 Loans with primary property that has apprasial reports as of STRESSTESTLEVEL4APPRAISALDATEUPPERLIMIT date (including)
                        IEnumerable<TdsLoan> L3FilteredLoans = StressTestLoanFilter(Loans, LoanFilterType.L3OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList);
                        filteredLoans = L3FilteredLoans.Where(l => propertyList.Any(p => p.LoanRecId == l.RecId && (bool)p.Primary && p.AppraisalDate.HasValue && p.AppraisalDate.Value.Date <= L4StressTestAppraisalLimitDate.Value.Date));
                        break;
                    }
                #endregion
                // Level 3 Stress Test: End
                #endregion

                default:
                    {
                        filteredLoans = Loans;
                        break;
                    }
            }

            return filteredLoans.ToList(); // Use ToList() to force to compiler to reify the results right away
        }

        public static IEnumerable<TdsLoan> FilterLoansByPropertyType(IEnumerable<TdsLoan> Loans, LoanFilterType? FilterType, IEnumerable<TdsProperty> propertyList, IEnumerable<UdfValue> SubjectPropertySquareFootageUDFValuesList)
        {
            IEnumerable<TdsLoan> filteredLoans = null;

            switch (FilterType)
            {
                case LoanFilterType.Detached:
                    {
                        filteredLoans = Loans.Where(loan => SubjectPropertySquareFootageUDFValuesList.FirstOrDefault(p => p.OwnerRecId == loan.RecId)?.Value.ToDecimal() > 0 &&
                                                            (propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId).PropertyType == LoanTypeList.SFRCMADetached.ToDescription() ||
                                                             propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId).PropertyType == LoanTypeList.SFRCADetached.ToDescription()));
                        break;
                    }

                case LoanFilterType.SemiDetached:
                    {
                        filteredLoans = Loans.Where(loan => SubjectPropertySquareFootageUDFValuesList.FirstOrDefault(p => p.OwnerRecId == loan.RecId)?.Value.ToDecimal() > 0 && 
                                                            (propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId).PropertyType == LoanTypeList.SFRCMASemiDetached.ToDescription() ||
                                                             propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId).PropertyType == LoanTypeList.SFRCASemiDetached.ToDescription()));
                        break;
                    }

                case LoanFilterType.RowHousing:
                    {
                        filteredLoans = Loans.Where(loan => SubjectPropertySquareFootageUDFValuesList.FirstOrDefault(p => p.OwnerRecId == loan.RecId)?.Value.ToDecimal() > 0 &&
                                                            (propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId).PropertyType == LoanTypeList.SFRCMARowHousing.ToDescription() ||
                                                             propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId).PropertyType == LoanTypeList.SFRCARowHousing.ToDescription()));
                        break;
                    }

                case LoanFilterType.Condo:
                    {
                        filteredLoans = Loans.Where(loan => SubjectPropertySquareFootageUDFValuesList.FirstOrDefault(p => p.OwnerRecId == loan.RecId)?.Value.ToDecimal() > 0 &&
                                                            (propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId).PropertyType == LoanTypeList.SFRCMACondo.ToDescription() ||
                                                             propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId).PropertyType == LoanTypeList.SFRCACondo.ToDescription()));
                        break;
                    }

                default:
                    {
                        filteredLoans = Loans.Where(loan => SubjectPropertySquareFootageUDFValuesList.FirstOrDefault(p => p.OwnerRecId == loan.RecId)?.Value.ToDecimal() > 0);
                        break;
                    }
            }

            return filteredLoans.ToList(); // Use ToList() to force to compiler to reify the results right away
        }

        public static IEnumerable<TdsLoan> FilterLoansByFilterType(IEnumerable<TdsLoan> Loans, LoanFilterType? FilterType, DateTime? EndDate = null, List<string> releatedLoanList = null, IEnumerable<TdsPostalCode> postalCodes = null, IEnumerable<TdsProperty> propertyList = null, IEnumerable<TdsLien> lienList = null, IEnumerable<UdfValue> customFieldsValueList = null)
        {
            IEnumerable<TdsLoan> filteredLoans = null;

            switch (FilterType)
            {
                case LoanFilterType.DaysLate0To30:
                    {
                        filteredLoans = Loans.Where(loan => DateTime.Today.Date > loan.NextDueDate.Value.Date &&
                                                            DateTime.Today.Date <= loan.NextDueDate.Value.Date.AddDays(30));
                        break;
                    }

                case LoanFilterType.DaysLate31To90:
                    {
                        filteredLoans = Loans.Where(loan => DateTime.Today.Date > loan.NextDueDate.Value.Date.AddDays(30) &&
                                                            DateTime.Today.Date <= loan.NextDueDate.Value.Date.AddDays(90));
                        break;
                    }

                case LoanFilterType.DaysLate91To270:
                    {
                        filteredLoans = Loans.Where(loan => DateTime.Today.Date > loan.NextDueDate.Value.Date.AddDays(90) &&
                                                            DateTime.Today.Date <= loan.NextDueDate.Value.Date.AddDays(270));
                        break;
                    }

                case LoanFilterType.DaysLateGtrThan270:
                    {
                        filteredLoans = Loans.Where(loan => DateTime.Today.Date > loan.NextDueDate.Value.Date.AddDays(270));
                        break;
                    }

                case LoanFilterType.FirstMortgage:
                    {
                        filteredLoans = Loans.Where(loan => loan.Priority == (int)LoanPriority.First);
                        break;
                    }

                case LoanFilterType.SecondMortgage:
                    {
                        filteredLoans = Loans.Where(loan => loan.Priority == (int)LoanPriority.Second);
                        break;
                    }

                case LoanFilterType.ThirdMortgage:
                    {
                        filteredLoans = Loans.Where(loan => loan.Priority == (int)LoanPriority.Third);
                        break;
                    }

                case LoanFilterType.Residential:
                    {
                        filteredLoans = Loans.Where(loan => loan.Documentation == LoanTypeList.SFRCANonOwner.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.SFRCAOwner.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.SFRCMAOwnerOccIneligible3Plus.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.SFRCMAOwnerOccIneligible.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.SFRCMAOwner.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.SFRCMANonOwner.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.SFRCMANonOwnerIneligible3Plus.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.SFRCMANonOwnerIneligible.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.QualifiedNotBorrowingBase.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.SFRAutoRenewal.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.SFRCANonOwnerQA.ToDescription() || 
                                                            loan.Documentation == LoanTypeList.SFRCAOwnerQA.ToDescription());
                        break;
                    }

                case LoanFilterType.Commercial:
                    {
                        filteredLoans = Loans.Where(loan => loan.Documentation == LoanTypeList.CACommercial.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.CMACommercial.ToDescription() ||
                                                            loan.Documentation == LoanTypeList.CMACommercialIneligible.ToDescription());
                        break;
                    }

                case LoanFilterType.Land:
                    {
                        filteredLoans = Loans.Where(loan => loan.Documentation == LoanTypeList.Land.ToDescription());
                        break;
                    }

                case LoanFilterType.Construction:
                    {
                        filteredLoans = Loans.Where(loan => loan.Documentation == LoanTypeList.SFRCAConstruction.ToDescription() ||
                                                    loan.Documentation == LoanTypeList.SFRCMAConstruction.ToDescription());
                        break;
                    }

                case LoanFilterType.Uncategorized:
                    {
                        filteredLoans = Loans.Where(loan => loan.Documentation != LoanTypeList.SFRCANonOwner.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCAOwner.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCMAOwnerOccIneligible3Plus.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCMAOwnerOccIneligible.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCMAOwner.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCMANonOwner.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCMANonOwnerIneligible3Plus.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCMANonOwnerIneligible.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.QualifiedNotBorrowingBase.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRAutoRenewal.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCANonOwnerQA.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCAOwnerQA.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.CACommercial.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.CMACommercial.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.CMACommercialIneligible.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.Land.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCAConstruction.ToDescription() &&
                                                    loan.Documentation != LoanTypeList.SFRCMAConstruction.ToDescription());
                        break;
                    }

                case LoanFilterType.Qualified:
                    {
                        filteredLoans = Loans.Where(loan => (!EndDate.HasValue || IsValidDates(EndDate, loan)) && 
                                                            IsQualifiedLoan(loan.Documentation));
                        break;
                    }

                case LoanFilterType.Ineligible:
                    {
                        filteredLoans = Loans.Where(loan => IsIneligibleLoan(loan.Documentation));
                        break;
                    }

                case LoanFilterType.OwnerOccupied1stMortgages:
                    {
                        filteredLoans = Loans.Where(loan => loan.Priority == (int)LoanPriority.First &&
                                                            (!EndDate.HasValue || IsValidDates(EndDate, loan)) &&
                                                            (loan.Documentation == LoanTypeList.SFRCMAOwner.ToDescription() ||
                                                             loan.Documentation == LoanTypeList.SFRCAOwnerQA.ToDescription()));
                        break;
                    }

                case LoanFilterType.OwnerOccupied1stMortgagesLTVLessThan50GTA:
                    {
                        IEnumerable<TdsLoan> ownerOccupied1stLoanList = FilterLoansByFilterType(Loans, LoanFilterType.OwnerOccupied1stMortgages, EndDate);
                        IEnumerable<TdsLoan> ownerOccupied1stGtaLoanList = FilterLoansByFilterType(ownerOccupied1stLoanList, LoanFilterType.GTAMortgages, EndDate, null, postalCodes, propertyList);
                        filteredLoans = ownerOccupied1stGtaLoanList.Where(l => GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId), customFieldsValueList.Where(v => v.OwnerRecId == l.RecId && v.ParentRecId == LessorAppraisedValueorPurchasePriceParentRecId).FirstOrDefault()?.Value, true) < 50);
                        break;
                    }

                case LoanFilterType.OwnerOccupied1stMortgagesOther:
                    {
                        IEnumerable<TdsLoan> ownerOccupied1stLoanList = FilterLoansByFilterType(Loans, LoanFilterType.OwnerOccupied1stMortgages, EndDate);
                        IEnumerable<TdsLoan> ownerOccupied1stLoanLTVLessThan50GTAList = FilterLoansByFilterType(ownerOccupied1stLoanList, LoanFilterType.OwnerOccupied1stMortgagesLTVLessThan50GTA, EndDate, null, postalCodes, propertyList, lienList, customFieldsValueList);

                        filteredLoans = ownerOccupied1stLoanList.Except(ownerOccupied1stLoanLTVLessThan50GTAList);
                        break;
                    }

                case LoanFilterType.OwnerOccupied2ndMortgages:
                    {
                        filteredLoans = Loans.Where(loan => loan.Priority == (int)LoanPriority.Second &&
                                                            (!EndDate.HasValue || IsValidDates(EndDate, loan)) &&
                                                            (loan.Documentation == LoanTypeList.SFRCMAOwner.ToDescription() ||
                                                             loan.Documentation == LoanTypeList.SFRCMANonOwner.ToDescription() ||
                                                             loan.Documentation == LoanTypeList.SFRCAOwnerQA.ToDescription() ||
                                                             loan.Documentation == LoanTypeList.SFRCANonOwnerQA.ToDescription()));
                        break;
                    }

                case LoanFilterType.NonOwner1stMortgages:
                    {
                        filteredLoans = Loans.Where(loan => loan.Priority == (int)LoanPriority.First &&
                                                            (!EndDate.HasValue || IsValidDates(EndDate, loan)) &&
                                                            (loan.Documentation == LoanTypeList.SFRCMANonOwner.ToDescription() ||
                                                             loan.Documentation == LoanTypeList.SFRCANonOwnerQA.ToDescription()));
                        break;
                    }

                case LoanFilterType.Commercial1stMortgages:
                    {
                        filteredLoans = Loans.Where(loan => loan.Priority == (int)LoanPriority.First &&
                                                            (!EndDate.HasValue || IsValidDates(EndDate, loan)) &&
                                                            loan.Documentation == LoanTypeList.CMACommercial.ToDescription());
                        break;
                    }
                case LoanFilterType.SameSINMortgages:
                    {
                        filteredLoans = Loans.Where(loan => releatedLoanList.Contains(loan.Account));
                        break;
                    }

                case LoanFilterType.Arrears1stMortgages:
                    {
                        filteredLoans = Loans.Where(loan => loan.Priority == (int)LoanPriority.First &&
                                                            (!EndDate.HasValue || LoanIsOverDue(EndDate, loan, AllowedArrearsInDays)));
                        break;
                    }

                case LoanFilterType.Arrears2ndMortgages:
                    {
                        filteredLoans = Loans.Where(loan => loan.Priority == (int)LoanPriority.Second &&
                                                            (!EndDate.HasValue || LoanIsOverDue(EndDate, loan, AllowedArrearsInDays)));
                        break;
                    }

                case LoanFilterType.DelinquentMortgages:
                    {
                        filteredLoans = Loans.Where(loan => !EndDate.HasValue || LoanIsOverDue(EndDate, loan, DelinquentPeriodInDays));
                        break;
                    }

                case LoanFilterType.GTAMortgages:
                    {
                        IEnumerable<string> GTAPostCodes = postalCodes.Where(p => p.MortgageRegion == MortgageRegion.GTA.ToDescription()).Select(p => p.County.Trim().ToLower());
                        filteredLoans = Loans.Where(l => GTAPostCodes.Contains(GetMortgageRegionCode(l.RecId, propertyList)));
                        break;
                    }

                case LoanFilterType.OttawaMortgages:
                    {
                        IEnumerable<string> OttawaPostCodes = postalCodes.Where(p => p.MortgageRegion == MortgageRegion.Ottawa.ToDescription()).Select(p => p.County.Trim().ToLower());
                        filteredLoans = Loans.Where(l => OttawaPostCodes.Contains(GetMortgageRegionCode(l.RecId, propertyList)));
                        break;
                    }

                case LoanFilterType.GoldenHorseshoeMortgages:
                    {
                        IEnumerable<string> GoldenHorseshoePostCodes = postalCodes.Where(p => p.MortgageRegion == MortgageRegion.GoldenHorseshoe.ToDescription()).Select(p => p.County.Trim().ToLower());
                        filteredLoans = Loans.Where(l => GoldenHorseshoePostCodes.Contains(GetMortgageRegionCode(l.RecId, propertyList)));
                        break;
                    }

                case LoanFilterType.OtherMajorUrbanAreasMortgages:
                    {
                        IEnumerable<string> OtherMajorUrbanAreasPostCodes = postalCodes.Where(p => p.MortgageRegion == MortgageRegion.OtherMajorUrbanAreas.ToDescription()).Select(p => p.County.Trim().ToLower());
                        filteredLoans = Loans.Where(l => OtherMajorUrbanAreasPostCodes.Contains(GetMortgageRegionCode(l.RecId, propertyList)));
                        break;
                    }

                case LoanFilterType.RemainingTermToMaturityLessEqual6:
                    {
                        filteredLoans = Loans.Where(l => GetTermsLeft(l) <= 6);
                        break;
                    }
                case LoanFilterType.RemainingTermToMaturity6To9:
                    {
                        filteredLoans = Loans.Where(l => GetTermsLeft(l) > 6 && GetTermsLeft(l) <= 9);
                        break;
                    }
                case LoanFilterType.RemainingTermToMaturity9To12:
                    {
                        filteredLoans = Loans.Where(l => GetTermsLeft(l) > 9 && GetTermsLeft(l) <= 12);
                        break;
                    }
                case LoanFilterType.RemainingTermToMaturityMoreThan12:
                    {
                        filteredLoans = Loans.Where(l => GetTermsLeft(l) > 12);
                        break;
                    }

                case LoanFilterType.PortfolioByLTVMoreThan80:
                    {
                        filteredLoans = Loans.Where(l => GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) > 80);
                        break;
                    }
                case LoanFilterType.PortfolioByLTV75To80:
                    {
                        filteredLoans = Loans.Where(l => GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) > 75 && GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) <= 80);
                        break;
                    }
                case LoanFilterType.PortfolioByLTV65To75:
                    {
                        filteredLoans = Loans.Where(l => GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) > 65 && GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) <= 75);
                        break;
                    }
                case LoanFilterType.PortfolioByLTVLessEqual65:
                    {
                        filteredLoans = Loans.Where(l => GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) <= 65);
                        break;
                    }

                default:
                    {
                        filteredLoans = Loans;
                        break;
                    }
            }

            return filteredLoans.ToList(); // Use ToList() to force to compiler to reify the results right away
        }

        /// <summary>
        /// Validates if loan payment is overdue
        /// </summary>
        /// <param name="EndDate">Report Date</param>
        /// <param name="loan">Loan to validate</param>
        /// <param name="daysOverDueBy">Number of days overdue by</param>
        /// <returns>Returns True is loan is over due. False otherwise.</returns>
        private static bool LoanIsOverDue(DateTime? EndDate, TdsLoan loan, int daysOverDueBy)
        {
            return loan.NextDueDate.Value.Date < EndDate.Value.Date.AddDays(-daysOverDueBy);
        }

        /// <summary>
        /// Validates the following condidtions:
        ///     - Maturity date is not more then AllowedMaturedDays days from endDate
        ///     - Loan closed date is not more then QualifiedLoansLengthLimitInMonths months from endDate
        ///     - Loan is closed as of endDate
        /// </summary>
        /// <param name="endDate">Report Date</param>
        /// <param name="loan">Loan to validate</param>
        /// <returns>True if conditions satisfied. False otherwise.</returns>
        private static bool IsValidDates(DateTime? endDate, TdsLoan loan)
        {
            return !endDate.HasValue || ((endDate.Value.Date - loan.MaturityDate.Value.Date).TotalDays <= AllowedMaturedDays &&                             // don't include loans matured for more than AllowedMaturedDays days
                                         (endDate.Value.Date - loan.ClosingDate.Value.AddMonths(QualifiedLoansLengthLimitInMonths).Date).TotalDays <= 0 &&  // don't include loans closed for more than 3 years (36 months)
                                         loan.ClosingDate.Value.Date <= endDate.Value.Date);                                                                // don't include loans not closed yet;
        }

        public static int GetTermsLeft(TdsLoan loan)
        {
            if (loan.MaturityDate != null)
            {
                DateTime newPaidToDate = DateTime.Now;

                return (loan.MaturityDate.Value.Year - newPaidToDate.Year) * 12 +
                       (loan.MaturityDate.Value.Month - newPaidToDate.Month);
            }

            return 0;
        }

        public static decimal GetCalculatedLTV(TdsLoan loan, IEnumerable<TdsProperty> properyList, IEnumerable<TdsLien> lienList, string LessorAppraisedValueorPurchasePrice = null, bool BBCLTV = false)
        {
            decimal totalLoanValue = (decimal)loan.PrinBal;
            decimal totalAppraisedValue = 0;

            foreach (TdsProperty property in properyList)
            {
                // Do not use a property LTV calculation if AppraiserFmv does not exist
                if (property.AppraiserFmv != null)
                {
                    decimal totalLienCurrentValue = (decimal)(from l in lienList
                                                              where l.PropRecId == property.RecId
                                                              select l.Current).Sum();
                    totalLoanValue += totalLienCurrentValue;
                    if ((bool)property.Primary && BBCLTV)
                    {
                        // User lessor of appraised or purchase for bbc qualified loans
                        totalAppraisedValue += LessorAppraisedValueorPurchasePrice.ToDecimal();
                    }
                    else
                    {
                        totalAppraisedValue += (decimal)property.AppraiserFmv;
                    }
                }
            }

            if (totalAppraisedValue > 0)
                return (totalLoanValue / totalAppraisedValue) * 100;

            return 0;
        }


        public static decimal GetAverageBeaconScore(TdsLoan loan, IEnumerable<UdfValue> customFieldsValueList)
        {
            string avgBeaconScroe = customFieldsValueList.Where(v => v.OwnerRecId == loan.RecId && v.ParentRecId == AverageCreditScoreParentRecId).FirstOrDefault()?.Value;
            return String.IsNullOrEmpty(avgBeaconScroe) ? 0 : avgBeaconScroe.ToDecimal();
        }

        private static decimal GetLTVAfterCorrection(TdsLoan loan, IEnumerable<TdsLien> lienList, IEnumerable<TdsProperty> propertyList, int pctCorrection)
        {
            // (PrinBal + AggregateSeniorLiens) / (AggregateAppraiserFmv * (100-pctCorrection) / 100);
            return (decimal)((loan.PrinBal + lienList.Where(l => l.LoanRecId == loan.RecId).Sum(l => l.Current)) / (propertyList.Where(p => p.LoanRecId == loan.RecId).Sum(p => p.AppraiserFmv) * (100 - pctCorrection) / 100)) * 100;
        }

        public static IEnumerable<TdsLoan> FilterLoansByLoanContent(string SearchFor, IEnumerable<TdsLoan> Loans)
        {
            return Loans.Where(l => (!String.IsNullOrEmpty(l.Account) && l.Account.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.FullName) && l.FullName.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.FirstName) && l.FirstName.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.LastName) && l.LastName.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.EmailAddress) && l.EmailAddress.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.LoanOfficer) && l.LoanOfficer.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.LoanCode) && l.LoanCode.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.Categories) && l.Categories.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.LoanPurpose) && l.LoanPurpose.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.Documentation) && l.Documentation.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.AchBankName) && l.AchBankName.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.AchBankAddress) && l.AchBankAddress.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.AchIndividualName) && l.AchIndividualName.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.PhoneHome) && l.PhoneHome.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.PhoneWork) && l.PhoneWork.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.PhoneCell) && l.PhoneCell.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.PhoneFax) && l.PhoneFax.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                    (!String.IsNullOrEmpty(l.Tin) && l.Tin.Replace(" ", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)));
        }

        public static IEnumerable<TdsLoan> FilterLoansByMailingAddress(string SearchFor, IEnumerable<TdsLoan> Loans, IEnumerable<TdsLoan> AllLoanList)
        {
            return from loan in AllLoanList.Where(l => (!String.IsNullOrEmpty(l.Street) && l.Street.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                       (!String.IsNullOrEmpty(l.City) && l.City.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                       (!String.IsNullOrEmpty(l.State) && l.State.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                       (!String.IsNullOrEmpty(l.ZipCode) && l.ZipCode.Replace(" ", string.Empty).Contains(SearchFor.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase)))
                   where !Loans.Any(l => l.RecId == loan.RecId) // Only unique loans
                   select loan;
        }

        public static IEnumerable<TdsLoan> FilterLoansByProperties(string SearchFor, IEnumerable<TdsProperty> propertyList, IEnumerable<TdsLoan> Loans, IEnumerable<TdsLoan> AllLoanList)
        {
            return from loan in AllLoanList
                   from property in propertyList.Where(p => (!String.IsNullOrEmpty(p.Street) && p.Street.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                            (!String.IsNullOrEmpty(p.City) && p.City.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                            (!String.IsNullOrEmpty(p.State) && p.State.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                            (!String.IsNullOrEmpty(p.ZipCode) && p.ZipCode.Replace(" ", string.Empty).Contains(SearchFor.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                                            (!String.IsNullOrEmpty(p.County) && p.County.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                            (!String.IsNullOrEmpty(p.Description) && p.Description.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                            (!String.IsNullOrEmpty(p.PropertyType) && p.PropertyType.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                            (!String.IsNullOrEmpty(p.Occupancy) && p.Occupancy.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)))
                   where property.LoanRecId == loan.RecId && !Loans.Any(l => l.RecId == loan.RecId) // Only unique loans
                   select loan;
        }

        public static IEnumerable<TdsLoan> FilterLoansByLiens(string SearchFor, IEnumerable<TdsLien> lienList, IEnumerable<TdsLoan> Loans, IEnumerable<TdsLoan> AllLoanList)
        {
            return from loan in AllLoanList
                   from lien in lienList.Where(l => (!String.IsNullOrEmpty(l.Holder) && l.Holder.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                    (!String.IsNullOrEmpty(l.AccountNo) && l.AccountNo.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)))
                   where lien.LoanRecId == loan.RecId && !Loans.Any(l => l.RecId == lien.LoanRecId) // Only unique loans
                   select loan;
        }

        public static IEnumerable<TdsLoan> FilterLoansByUDFValues(string SearchFor, IEnumerable<UdfValue> UdfValues, IEnumerable<TdsLoan> Loans, IEnumerable<TdsLoan> AllLoanList)
        {
            return from loan in AllLoanList
                   from udf in UdfValues.Where(udf => (!String.IsNullOrEmpty(udf.Value) && udf.Value.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)))
                   where udf.OwnerRecId == loan.RecId && !Loans.Any(l => l.RecId == udf.OwnerRecId) // Only unique loans
                   select loan;
        }

        public static IEnumerable<TdsLoan> FilterLoansByCoBorrowers(string SearchFor, IEnumerable<TdsCoBorrower> coborrowers, IEnumerable<TdsLoan> Loans, IEnumerable<TdsLoan> AllLoanList)
        {
            return from loan in AllLoanList
                   from coborrower in coborrowers.Where(c => (!String.IsNullOrEmpty(c.FullName) && c.FullName.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.FirstName) && c.FirstName.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.LastName) && c.LastName.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.Street) && c.Street.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.City) && c.City.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.State) && c.State.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.ZipCode) && c.ZipCode.Replace(" ", string.Empty).Contains(SearchFor.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.PhoneHome) && c.PhoneHome.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.PhoneWork) && c.PhoneWork.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.PhoneCell) && c.PhoneCell.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.PhoneFax) && c.PhoneFax.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.Tin) && c.Tin.Replace(" ", string.Empty).Replace("-", string.Empty).Contains(SearchFor.Replace(" ", string.Empty).Replace("-", string.Empty), StringComparison.OrdinalIgnoreCase)) ||
                                                             (!String.IsNullOrEmpty(c.EmailAddress) && c.EmailAddress.Contains(SearchFor, StringComparison.OrdinalIgnoreCase)))
                   where coborrower.LoanRecId == loan.RecId && !Loans.Any(l => l.RecId == coborrower.LoanRecId) // Only unique loans
                   select loan;
        }

        public static string GetMortgageRegionCode(string loanRecId, IEnumerable<TdsProperty> properyList)
        {
            TdsProperty primaryProperty = properyList.FirstOrDefault(p => p.LoanRecId == loanRecId && (bool)p.Primary);
            return String.IsNullOrEmpty(primaryProperty.ZipCode) ? null : primaryProperty?.County.Trim().ToLower();
        }
    }
}