using DocumentFormat.OpenXml.Wordprocessing;
using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ReportModels;
using KuberMICManager.Core.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Application
{
    public class PortfolioHistoryService : IPortfolioHistoryService
    {
        // inject the dependencies
        private readonly ILogger<DashboardService> _logger;
        private readonly IDashboardService _dashboardService;
        private readonly IReportService _reportService;
        private readonly IMICPortfolioHistoryRepository _portfolioHistoryRepository;

        public PortfolioHistoryService(ILogger<DashboardService> logger,
                                       IDashboardService dashboardService,
                                       IReportService reportService,
                                       IMICPortfolioHistoryRepository portfolioHistoryRepository)
        {
            _logger = logger;
            _dashboardService = dashboardService;
            _reportService = reportService;
            _portfolioHistoryRepository = portfolioHistoryRepository;
        }

        public async Task<ResultType> SavePortfolioSnapshot(DateTime endDate)
        {
            var portfolioHistorList = await _portfolioHistoryRepository.FindAsync(h => (h.Category == MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority ||
                                                                                        h.Category == MICPortfolioHistoryCategory.LoanWeightedAverage ||
                                                                                        h.Category == MICPortfolioHistoryCategory.LoanSummaryByPostalCode ||
                                                                                        h.Category == MICPortfolioHistoryCategory.LoanSummaryByMortgageType ||
                                                                                        h.Category == MICPortfolioHistoryCategory.LoanSummaryByLatePayment ||
                                                                                        h.Category == MICPortfolioHistoryCategory.RemainingTermToMaturitySummary ||
                                                                                        h.Category == MICPortfolioHistoryCategory.PortfolioSummaryByLTV) &&
                                                                                       h.CreatedDate != null &&
                                                                                       h.CreatedDate.Value.Date == endDate.Date);
            if (portfolioHistorList.Any())
            {
                return ResultType.SnapshotExists;
            }

            _logger.LogInformation($"Calling: PortfolioHistoryService.SavePortfolioSnapshot(): Timestamp - {endDate}\n");

            DashboardLoanViewModel DashboardViewModel = await _dashboardService.GetLoanSummaryForDashboard(endDate);

            List<MICPortfolioHistory> portfolioHistory = new List<MICPortfolioHistory>();

            // Loan Summary by Mortgage Type
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansFirst", Value = DashboardViewModel.NoOfLoansFirst, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansSecond", Value = DashboardViewModel.NoOfLoansSecond, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansThird", Value = DashboardViewModel.NoOfLoansThird, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "AverageAppraisalFirst", Value = DashboardViewModel.AverageAppraisalFirst, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "AverageAppraisalSecond", Value = DashboardViewModel.AverageAppraisalSecond, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "AverageAppraisalThird", Value = DashboardViewModel.AverageAppraisalThird, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "AverageAppraisalTotal", Value = DashboardViewModel.AverageAppraisalTotal, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceFirst", Value = DashboardViewModel.PrincipalBalanceFirst, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceSecond", Value = DashboardViewModel.PrincipalBalanceSecond, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceThird", Value = DashboardViewModel.PrincipalBalanceThird, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMFirst", Value = DashboardViewModel.PctOfAUMFirst, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMSecond", Value = DashboardViewModel.PctOfAUMSecond, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMThird", Value = DashboardViewModel.PctOfAUMThird, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority, CreatedDate = endDate });

            // Weighted Average
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalWeightedLTV", Value = DashboardViewModel.TotalWeightedLTV, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalWeightedMaturityDateInMonths", Value = DashboardViewModel.TotalWeightedMaturityDateInMonths, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalWeightedBeaconScore", Value = DashboardViewModel.TotalWeightedBeaconScore, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalWeightedInterestRate", Value = DashboardViewModel.TotalWeightedInterestRate, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "FirstWeightedLTV", Value = DashboardViewModel.FirstWeightedLTV, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "FirstWeightedMaturityDateInMonths", Value = DashboardViewModel.FirstWeightedMaturityDateInMonths, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "FirstWeightedBeaconScore", Value = DashboardViewModel.FirstWeightedBeaconScore, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "FirstWeightedInterestRate", Value = DashboardViewModel.FirstWeightedInterestRate, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "SecondlWeightedLTV", Value = DashboardViewModel.SecondlWeightedLTV, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "SecondlWeightedMaturityDateInMonths", Value = DashboardViewModel.SecondlWeightedMaturityDateInMonths, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "SecondlWeightedBeaconScore", Value = DashboardViewModel.SecondlWeightedBeaconScore, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "SecondlWeightedInterestRate", Value = DashboardViewModel.SecondlWeightedInterestRate, Category = MICPortfolioHistoryCategory.LoanWeightedAverage, CreatedDate = endDate });

            // Postal Code
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansByPostalCodeInGTA", Value = DashboardViewModel.NoOfLoansByPostalCodeInGTA, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansByPostalCodeInOttawa", Value = DashboardViewModel.NoOfLoansByPostalCodeInOttawa, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansByPostalCodeInGoldenHorseshoe", Value = DashboardViewModel.NoOfLoansByPostalCodeInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansByPostalCodeInOtherMajorUrbanAreas", Value = DashboardViewModel.NoOfLoansByPostalCodeInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "WeightedLTVByPostalCodeInGTA", Value = DashboardViewModel.WeightedLTVByPostalCodeInGTA, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "WeightedLTVByPostalCodeInOttawa", Value = DashboardViewModel.WeightedLTVByPostalCodeInOttawa, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "WeightedLTVByPostalCodeInGoldenHorseshoe", Value = DashboardViewModel.WeightedLTVByPostalCodeInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "WeightedLTVByPostalCodeInOtherMajorUrbanAreas", Value = DashboardViewModel.WeightedLTVByPostalCodeInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalWeightedLTV", Value = DashboardViewModel.TotalWeightedLTV, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "WeightedBeaconScoreByPostalCodeInGTA", Value = DashboardViewModel.WeightedBeaconScoreByPostalCodeInGTA, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "WeightedBeaconScoreByPostalCodeInOttawa", Value = DashboardViewModel.WeightedBeaconScoreByPostalCodeInOttawa, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "WeightedBeaconScoreByPostalCodeInGoldenHorseshoe", Value = DashboardViewModel.WeightedBeaconScoreByPostalCodeInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas", Value = DashboardViewModel.WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalWeightedBeaconScore", Value = DashboardViewModel.TotalWeightedBeaconScore, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceByPostalCodeInGTA", Value = DashboardViewModel.PrincipalBalanceByPostalCodeInGTA, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceByPostalCodeInOttawa", Value = DashboardViewModel.PrincipalBalanceByPostalCodeInOttawa, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceByPostalCodeInGoldenHorseshoe", Value = DashboardViewModel.PrincipalBalanceByPostalCodeInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceByPostalCodeInOtherMajorUrbanAreas", Value = DashboardViewModel.PrincipalBalanceByPostalCodeInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMByPostalCodeInGTA", Value = DashboardViewModel.PctOfAUMByPostalCodeInGTA, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMByPostalCodeInOttawa", Value = DashboardViewModel.PctOfAUMByPostalCodeInOttawa, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMByPostalCodeInGoldenHorseshoe", Value = DashboardViewModel.PctOfAUMByPostalCodeInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMByPostalCodeInOtherMajorUrbanAreas", Value = DashboardViewModel.PctOfAUMByPostalCodeInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.LoanSummaryByPostalCode, CreatedDate = endDate });

            // Loan Summary by Mortgage Type
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansResidential", Value = DashboardViewModel.NoOfLoansResidential, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansCommercial", Value = DashboardViewModel.NoOfLoansCommercial, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansLand", Value = DashboardViewModel.NoOfLoansLand, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansConstruction", Value = DashboardViewModel.NoOfLoansConstruction, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceResidential", Value = DashboardViewModel.PrincipalBalanceResidential, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceCommercial", Value = DashboardViewModel.PrincipalBalanceCommercial, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceLand", Value = DashboardViewModel.PrincipalBalanceLand, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceConstruction", Value = DashboardViewModel.PrincipalBalanceConstruction, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMResidential", Value = DashboardViewModel.PctOfAUMResidential, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMCommercial", Value = DashboardViewModel.PctOfAUMCommercial, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMLand", Value = DashboardViewModel.PctOfAUMLand, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMConstruction", Value = DashboardViewModel.PctOfAUMConstruction, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });

            if (DashboardViewModel.NoOfLoansUncategorized > 0)
            {
                portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansUncategorized", Value = DashboardViewModel.NoOfLoansUncategorized, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
                portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceUncategorized", Value = DashboardViewModel.PrincipalBalanceUncategorized, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
                portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMUncategorized", Value = DashboardViewModel.PctOfAUMUncategorized, Category = MICPortfolioHistoryCategory.LoanSummaryByMortgageType, CreatedDate = endDate });
            }

            // Loan Summary by Late Payment
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotoalNoOfLoans0To30DaysLate", Value = DashboardViewModel.TotoalNoOfLoans0To30DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotoalNoOfLoans31To90DaysLate", Value = DashboardViewModel.TotoalNoOfLoans31To90DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotoalNoOfLoans91To270DaysLate", Value = DashboardViewModel.TotoalNoOfLoans91To270DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotoalNoOfLoansMoreThan270DaysLate", Value = DashboardViewModel.TotoalNoOfLoansMoreThan270DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPrincipalBalance0To30DaysLate", Value = DashboardViewModel.TotalPrincipalBalance0To30DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPrincipalBalance31To90DaysLate", Value = DashboardViewModel.TotalPrincipalBalance31To90DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPrincipalBalance91To270DaysLate", Value = DashboardViewModel.TotalPrincipalBalance91To270DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPrincipalBalanceMoreThan270DaysLate", Value = DashboardViewModel.TotalPrincipalBalanceMoreThan270DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPctOfAUM0To30DaysLate", Value = DashboardViewModel.TotalPctOfAUM0To30DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPctOfAUM31To90DaysLate", Value = DashboardViewModel.TotalPctOfAUM31To90DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPctOfAUM91To270DaysLate", Value = DashboardViewModel.TotalPctOfAUM91To270DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPctOfAUMMoreThan270DaysLate", Value = DashboardViewModel.TotalPctOfAUMMoreThan270DaysLate, Category = MICPortfolioHistoryCategory.LoanSummaryByLatePayment, CreatedDate = endDate });

            // Remaining Term to Maturity Summary
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRemainingTermtoMaturityLessEqual6", Value = DashboardViewModel.NoOfLoansRemainingTermtoMaturityLessEqual6, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRemainingTermtoMaturity6To9", Value = DashboardViewModel.NoOfLoansRemainingTermtoMaturity6To9, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRemainingTermtoMaturity9To12", Value = DashboardViewModel.NoOfLoansRemainingTermtoMaturity9To12, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRemainingTermtoMaturityMoreThan12", Value = DashboardViewModel.NoOfLoansRemainingTermtoMaturityMoreThan12, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceRemainingTermtoMaturityLessEqual6", Value = DashboardViewModel.PrincipalBalanceRemainingTermtoMaturityLessEqual6, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceRemainingTermtoMaturity6To9", Value = DashboardViewModel.PrincipalBalanceRemainingTermtoMaturity6To9, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceRemainingTermtoMaturity9To12", Value = DashboardViewModel.PrincipalBalanceRemainingTermtoMaturity9To12, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalanceRemainingTermtoMaturityMoreThan12", Value = DashboardViewModel.PrincipalBalanceRemainingTermtoMaturityMoreThan12, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMRemainingTermtoMaturityLessEqual6", Value = DashboardViewModel.PctOfAUMRemainingTermtoMaturityLessEqual6, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMRemainingTermtoMaturity6To9", Value = DashboardViewModel.PctOfAUMRemainingTermtoMaturity6To9, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMRemainingTermtoMaturity9To12", Value = DashboardViewModel.PctOfAUMRemainingTermtoMaturity9To12, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMRemainingTermtoMaturityMoreThan12", Value = DashboardViewModel.PctOfAUMRemainingTermtoMaturityMoreThan12, Category = MICPortfolioHistoryCategory.RemainingTermToMaturitySummary, CreatedDate = endDate });

            // Portfolio Summary by LTV
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansPortfolioByLTVMoreThan80", Value = DashboardViewModel.NoOfLoansPortfolioByLTVMoreThan80, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansPortfolioByLTV75To80", Value = DashboardViewModel.NoOfLoansPortfolioByLTV75To80, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansPortfolioByLTV65To75", Value = DashboardViewModel.NoOfLoansPortfolioByLTV65To75, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansPortfolioByLTVLessEqual65", Value = DashboardViewModel.NoOfLoansPortfolioByLTVLessEqual65, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalancePortfolioByLTVMoreThan80", Value = DashboardViewModel.PrincipalBalancePortfolioByLTVMoreThan80, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalancePortfolioByLTV75To80", Value = DashboardViewModel.PrincipalBalancePortfolioByLTV75To80, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalancePortfolioByLTV65To75", Value = DashboardViewModel.PrincipalBalancePortfolioByLTV65To75, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PrincipalBalancePortfolioByLTVLessEqual65", Value = DashboardViewModel.PrincipalBalancePortfolioByLTVLessEqual65, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMPortfolioByLTVMoreThan80", Value = DashboardViewModel.PctOfAUMPortfolioByLTVMoreThan80, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMPortfolioByLTV75To80", Value = DashboardViewModel.PctOfAUMPortfolioByLTV75To80, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMPortfolioByLTV65To75", Value = DashboardViewModel.PctOfAUMPortfolioByLTV65To75, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMPortfolioByLTVLessEqual65", Value = DashboardViewModel.PctOfAUMPortfolioByLTVLessEqual65, Category = MICPortfolioHistoryCategory.PortfolioSummaryByLTV, CreatedDate = endDate });

            // *** Price per Square Foot Summary ***
            // GTA
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "DetachedPricePerSquareFootInGTA", Value = DashboardViewModel.DetachedPricePerSquareFootInGTA, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "SemiDetachedPricePerSquareFootInGTA", Value = DashboardViewModel.SemiDetachedPricePerSquareFootInGTA, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "RowHousingPricePerSquareFootInGTA", Value = DashboardViewModel.RowHousingPricePerSquareFootInGTA, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "CondoPricePerSquareFootInGTA", Value = DashboardViewModel.CondoPricePerSquareFootInGTA, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPricePerSquareFootInGTA", Value = DashboardViewModel.TotalPricePerSquareFootInGTA, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansDetachedInGTA", Value = DashboardViewModel.NoOfLoansDetachedInGTA, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansSemiDetachedInGTA", Value = DashboardViewModel.NoOfLoansSemiDetachedInGTA, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRowHousingInGTA", Value = DashboardViewModel.NoOfLoansRowHousingInGTA, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansCondoInGTA", Value = DashboardViewModel.NoOfLoansCondoInGTA, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            // Ottawa
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "DetachedPricePerSquareFootInOttawa", Value = DashboardViewModel.DetachedPricePerSquareFootInOttawa, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "SemiDetachedPricePerSquareFootInOttawa", Value = DashboardViewModel.SemiDetachedPricePerSquareFootInOttawa, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "RowHousingPricePerSquareFootInOttawa", Value = DashboardViewModel.RowHousingPricePerSquareFootInOttawa, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "CondoPricePerSquareFootInOttawa", Value = DashboardViewModel.CondoPricePerSquareFootInOttawa, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPricePerSquareFootInOttawa", Value = DashboardViewModel.TotalPricePerSquareFootInOttawa, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansDetachedInOttawa", Value = DashboardViewModel.NoOfLoansDetachedInOttawa, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansSemiDetachedInOttawa", Value = DashboardViewModel.NoOfLoansSemiDetachedInOttawa, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRowHousingInOttawa", Value = DashboardViewModel.NoOfLoansRowHousingInOttawa, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansCondoInOttawa", Value = DashboardViewModel.NoOfLoansCondoInOttawa, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            // Golden Horseshoe
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "DetachedPricePerSquareFootInGoldenHorseshoe", Value = DashboardViewModel.DetachedPricePerSquareFootInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "SemiDetachedPricePerSquareFootInGoldenHorseshoe", Value = DashboardViewModel.SemiDetachedPricePerSquareFootInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "RowHousingPricePerSquareFootInGoldenHorseshoe", Value = DashboardViewModel.RowHousingPricePerSquareFootInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "CondoPricePerSquareFootInGoldenHorseshoe", Value = DashboardViewModel.CondoPricePerSquareFootInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPricePerSquareFootInGoldenHorseshoe", Value = DashboardViewModel.TotalPricePerSquareFootInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansDetachedInGoldenHorseshoe", Value = DashboardViewModel.NoOfLoansDetachedInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansSemiDetachedInGoldenHorseshoe", Value = DashboardViewModel.NoOfLoansSemiDetachedInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRowHousingInGoldenHorseshoe", Value = DashboardViewModel.NoOfLoansRowHousingInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansCondoInGoldenHorseshoe", Value = DashboardViewModel.NoOfLoansCondoInGoldenHorseshoe, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            // Other Major Urban Areas
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "DetachedPricePerSquareFootInOtherMajorUrbanAreas", Value = DashboardViewModel.DetachedPricePerSquareFootInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas", Value = DashboardViewModel.SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "RowHousingPricePerSquareFootInOtherMajorUrbanAreas", Value = DashboardViewModel.RowHousingPricePerSquareFootInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "CondoPricePerSquareFootInOtherMajorUrbanAreas", Value = DashboardViewModel.CondoPricePerSquareFootInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPricePerSquareFootInOtherMajorUrbanAreas", Value = DashboardViewModel.TotalPricePerSquareFootInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansDetachedInOtherMajorUrbanAreas", Value = DashboardViewModel.NoOfLoansDetachedInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansSemiDetachedInOtherMajorUrbanAreas", Value = DashboardViewModel.NoOfLoansSemiDetachedInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRowHousingInOtherMajorUrbanAreas", Value = DashboardViewModel.NoOfLoansRowHousingInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansCondoInOtherMajorUrbanAreas", Value = DashboardViewModel.NoOfLoansCondoInOtherMajorUrbanAreas, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            // Total
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "DetachedPricePerSquareFootForAllRegions", Value = DashboardViewModel.DetachedPricePerSquareFootForAllRegions, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "SemiDetachedPricePerSquareFootForAllRegions", Value = DashboardViewModel.SemiDetachedPricePerSquareFootForAllRegions, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "RowHousingPricePerSquareFootForAllRegions", Value = DashboardViewModel.RowHousingPricePerSquareFootForAllRegions, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "CondoPricePerSquareFootForAllRegions", Value = DashboardViewModel.CondoPricePerSquareFootForAllRegions, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "TotalPricePerSquareFootForAllRegions", Value = DashboardViewModel.TotalPricePerSquareFootForAllRegions, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansDetachedInAllRegions", Value = DashboardViewModel.NoOfLoansDetachedInAllRegions, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansSemiDetachedInAllRegions", Value = DashboardViewModel.NoOfLoansSemiDetachedInAllRegions, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRowHousingInAllRegions", Value = DashboardViewModel.NoOfLoansRowHousingInAllRegions, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansCondoInAllRegions", Value = DashboardViewModel.NoOfLoansCondoInAllRegions, Category = MICPortfolioHistoryCategory.PricePerSquareFootSummary, CreatedDate = endDate });

            await _portfolioHistoryRepository.AddRangeAsync(portfolioHistory);

            return ResultType.PortfolioSnapshotSuccess;
        }

        public async Task<ResultType> SaveBBCSnapshot(DateTime endDate)
        {
            var BBCHistorList = await _portfolioHistoryRepository.FindAsync(h => h.Category == MICPortfolioHistoryCategory.BBC &&
                                                                                 h.CreatedDate != null &&
                                                                                 h.CreatedDate.Value.Date == endDate.Date);
            if (BBCHistorList.Any())
            {
                return ResultType.SnapshotExists;
            }

            _logger.LogInformation($"Calling: PortfolioHistoryService.SaveBBCSnapshot(): End Date - {endDate}\n");

            BBCReportModel ReportsViewModel = await _reportService.GetLoanDetailsForBBCSummary(endDate);

            List<MICPortfolioHistory> portfolioHistory = new List<MICPortfolioHistory>();

            //portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansOwnerOccupied1stMortgages", Value = ReportsViewModel.NoOfLoansOwnerOccupied1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate }); // Replaced with LTV < 50% GTA & Other
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA", Value = ReportsViewModel.NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansOwnerOccupied1stMortgagesOther", Value = ReportsViewModel.NoOfLoansOwnerOccupied1stMortgagesOther, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansOwnerOccupied2ndMortgages", Value = ReportsViewModel.NoOfLoansOwnerOccupied2ndMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansRental1stMortgages", Value = ReportsViewModel.NoOfLoansNonOwnerOccupied1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "NoOfLoansCommercial1stMortgages", Value = ReportsViewModel.NoOfLoansCommercial1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });

            //portfolioHistory.Add(new MICPortfolioHistory() { Key = "EligibleAmountOwnerOccupied1stMortgages", Value = ReportsViewModel.EligibleAmountOwnerOccupied1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate }); // Replaced with LTV < 50% GTA & Other
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA", Value = ReportsViewModel.EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "EligibleAmountOwnerOccupied1stMortgagesOther", Value = ReportsViewModel.EligibleAmountOwnerOccupied1stMortgagesOther, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "EligibleAmountOwnerOccupied2ndMortgages", Value = ReportsViewModel.EligibleAmountOwnerOccupied2ndMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "EligibleAmountRental1stMortgages", Value = ReportsViewModel.EligibleAmountNonOwnerOccupied1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "EligibleAmountCommercial1stMortgages", Value = ReportsViewModel.EligibleAmountCommercial1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });

            //portfolioHistory.Add(new MICPortfolioHistory() { Key = "QualifiedAmountOwnerOccupied1stMortgages", Value = ReportsViewModel.QualifiedAmountOwnerOccupied1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate }); // Replaced with LTV < 50% GTA & Other
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "QualifiedAmountOwnerOccupied1stMortgagesLTVLessThan50GTA", Value = ReportsViewModel.QualifiedAmountOwnerOccupied1stMortgagesLTVLessThan50GTA, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "QualifiedAmountOwnerOccupied1stMortgagesOther", Value = ReportsViewModel.QualifiedAmountOwnerOccupied1stMortgagesOther, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "QualifiedAmountOwnerOccupied2ndMortgages", Value = ReportsViewModel.QualifiedAmountOwnerOccupied2ndMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "QualifiedAmountRental1stMortgages", Value = ReportsViewModel.QualifiedAmountNonOwnerOccupied1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "QualifiedAmountCommercial1stMortgages", Value = ReportsViewModel.QualifiedAmountCommercial1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });

            //portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMOwnerOccupied1stMortgages", Value = ReportsViewModel.PctOfAUMOwnerOccupied1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate }); // Replaced with LTV < 50% GTA & Other
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA", Value = ReportsViewModel.PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMOwnerOccupied1stMortgagesOther", Value = ReportsViewModel.PctOfAUMOwnerOccupied1stMortgagesOther, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMOwnerOccupied2ndMortgages", Value = ReportsViewModel.PctOfAUMOwnerOccupied2ndMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMNonOwnerOccupied1stMortgages", Value = ReportsViewModel.PctOfAUMNonOwnerOccupied1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });
            portfolioHistory.Add(new MICPortfolioHistory() { Key = "PctOfAUMCommercial1stMortgages", Value = ReportsViewModel.PctOfAUMCommercial1stMortgages, Category = MICPortfolioHistoryCategory.BBC, CreatedDate = endDate });

            await _portfolioHistoryRepository.AddRangeAsync(portfolioHistory);

            return ResultType.BBCSnapshotSuccess;
        }

        public async Task<ResultType> SaveStressTestSnapshot(DateTime endDate)
        {
            var StreeTestHistorList = await _portfolioHistoryRepository.FindAsync(h => (h.Category == MICPortfolioHistoryCategory.StressTestParameters ||
                                                                                        h.Category == MICPortfolioHistoryCategory.L1StressTest ||
                                                                                        h.Category == MICPortfolioHistoryCategory.L2StressTest ||
                                                                                        h.Category == MICPortfolioHistoryCategory.L3StressTest ||
                                                                                        h.Category == MICPortfolioHistoryCategory.L4StressTest) &&
                                                                                        h.CreatedDate != null &&
                                                                                        h.CreatedDate.Value.Date == endDate.Date);
            if (StreeTestHistorList.Any())
            {
                return ResultType.SnapshotExists;
            }

            _logger.LogInformation($"Calling: PortfolioHistoryService.SaveStressTestSnapshot(): End Date - {endDate}\n");

            StressTestReportModel stressTestReport = await _reportService.GetStressTestReportData(endDate);

            List<MICPortfolioHistory> portfolioHistoryList = new List<MICPortfolioHistory>();

            // Site Settings
            portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "Level1MarketDeclineLimit", Value = stressTestReport.Level1MarketDeclineLimit, Category = MICPortfolioHistoryCategory.StressTestParameters, CreatedDate = endDate });
            portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "Level2MarketDeclineLimit", Value = stressTestReport.Level2MarketDeclineLimit, Category = MICPortfolioHistoryCategory.StressTestParameters, CreatedDate = endDate });
            portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "Level3MarketDeclineLimit", Value = stressTestReport.Level3MarketDeclineLimit, Category = MICPortfolioHistoryCategory.StressTestParameters, CreatedDate = endDate });
            portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LiquidationCostInCentsPerDollar", Value = stressTestReport.LiquidationCostInCentsPerDollar, Category = MICPortfolioHistoryCategory.StressTestParameters, CreatedDate = endDate });
            portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "ProjectedLoanLossReserve", Value = stressTestReport.ProjectedLoanLossReserve, Category = MICPortfolioHistoryCategory.StressTestParameters, CreatedDate = endDate });
            portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "SubordinatedSharesValue", Value = stressTestReport.SubordinatedSharesValue, Category = MICPortfolioHistoryCategory.StressTestParameters, CreatedDate = endDate });
            portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "AtRiskBeaconScoreThreshold", Value = stressTestReport.AtRiskBeaconScoreThreshold, Category = MICPortfolioHistoryCategory.StressTestParameters, CreatedDate = endDate });
            portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "AtRiskLTVThreshold", Value = stressTestReport.AtRiskLTVThreshold, Category = MICPortfolioHistoryCategory.StressTestParameters, CreatedDate = endDate });
            portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "Level4AppraisalDateLimit", Value = stressTestReport.Level4AppraisalDateLimit.Date.Ticks / 100000000, Category = MICPortfolioHistoryCategory.StressTestParameters, CreatedDate = endDate }); // decimal 18, 8 - divid by 100000000 to make it fit

            portfolioHistoryList = portfolioHistoryList.Concat(AddStressTestLevelData(endDate, stressTestReport.Level1StressTestData, MICPortfolioHistoryCategory.L1StressTest)).ToList(); // L1
            portfolioHistoryList = portfolioHistoryList.Concat(AddStressTestLevelData(endDate, stressTestReport.Level2StressTestData, MICPortfolioHistoryCategory.L2StressTest)).ToList(); // L2
            portfolioHistoryList = portfolioHistoryList.Concat(AddStressTestLevelData(endDate, stressTestReport.Level3StressTestData, MICPortfolioHistoryCategory.L3StressTest)).ToList(); // L3
            portfolioHistoryList = portfolioHistoryList.Concat(AddStressTestLevelData(endDate, stressTestReport.Level4StressTestData, MICPortfolioHistoryCategory.L4StressTest)).ToList(); // L4

            await _portfolioHistoryRepository.AddRangeAsync(portfolioHistoryList);

            return ResultType.StressTestSnapshotSuccess;
        }

        private static List<MICPortfolioHistory> AddStressTestLevelData(DateTime endDate, StressTestLevelDataModel levelData, MICPortfolioHistoryCategory portfolioHistoryCategory)
        {
            List<MICPortfolioHistory> portfolioHistoryList = new List<MICPortfolioHistory>();

            if (portfolioHistoryCategory != MICPortfolioHistoryCategory.L4StressTest) // L4StressTest does not have these
            {
                // # of Mortgages
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV0To80NumMortgages", Value = levelData.LTV0To80NumMortgages, Category = portfolioHistoryCategory, CreatedDate = endDate }); // 0% - 80%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV80To90NumMortgages", Value = levelData.LTV80To90NumMortgages, Category = portfolioHistoryCategory, CreatedDate = endDate }); // 80% - 90%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV90To95NumMortgages", Value = levelData.LTV90To95NumMortgages, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 90% - 95%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV95To100NumMortgages", Value = levelData.LTV95To100NumMortgages, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 95% - 100%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTVAbove100NumMortgages", Value = levelData.LTVAbove100NumMortgages, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 100%

                // Weighted Aaverage Credit Score
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV0To80WACreditScore", Value = levelData.LTV0To80WACreditScore, Category = portfolioHistoryCategory, CreatedDate = endDate }); // 0.0% - 80%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV80To90WACreditScore", Value = levelData.LTV80To90WACreditScore, Category = portfolioHistoryCategory, CreatedDate = endDate }); // 80.1% - 90%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV90To95WACreditScore", Value = levelData.LTV90To95WACreditScore, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 90.1% - 95%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV95To100WACreditScore", Value = levelData.LTV95To100WACreditScore, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 95.1% - 100%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTVAbove100WACreditScore", Value = levelData.LTVAbove100WACreditScore, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 100%

                // Value of Portfolio (%)
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTVPct0To80PortfolioValue", Value = levelData.LTVPct0To80PortfolioValue, Category = portfolioHistoryCategory, CreatedDate = endDate }); // 0.0% - 80%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTVPct80To90PortfolioValue", Value = levelData.LTVPct80To90PortfolioValue, Category = portfolioHistoryCategory, CreatedDate = endDate }); // 80.1% - 90%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTVPct90To95PortfolioValue", Value = levelData.LTVPct90To95PortfolioValue, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 90.1% - 95%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTVPct95To100PortfolioValue", Value = levelData.LTVPct95To100PortfolioValue, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 95.1% - 100%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTVPctAbove100PortfolioValue", Value = levelData.LTVPctAbove100PortfolioValue, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 100%

                // Principal Balance ($)
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV0To80PrincipalBalance", Value = levelData.LTV0To80PrincipalBalance, Category = portfolioHistoryCategory, CreatedDate = endDate }); // 0.0% - 80%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV80To90PrincipalBalance", Value = levelData.LTV80To90PrincipalBalance, Category = portfolioHistoryCategory, CreatedDate = endDate }); // 80.1% - 90%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV90To95PrincipalBalance", Value = levelData.LTV90To95PrincipalBalance, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 90.1% - 95%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTV95To100PrincipalBalance", Value = levelData.LTV95To100PrincipalBalance, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 95.1% - 100%
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "LTVAbove100PrincipalBalance", Value = levelData.LTVAbove100PrincipalBalance, Category = portfolioHistoryCategory, CreatedDate = endDate }); // Above 100%
            }

            // *** Analysis *** //
            // Over Threshold LTV and Below Threshod Beacon Score
            if (levelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgages > 0)
            {
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "OverThresholdLTVBelowThreshodBeaconScoreNumMortgages", Value = levelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgages, Category = portfolioHistoryCategory, CreatedDate = endDate });
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance", Value = levelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance, Category = portfolioHistoryCategory, CreatedDate = endDate });
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "OverThresholdLTVBelowThreshodBeaconScoreWACreditScore", Value = levelData.OverThresholdLTVBelowThreshodBeaconScoreWACreditScore, Category = portfolioHistoryCategory, CreatedDate = endDate });

            }                
            // Over Threshold LTV, Below Threshod Beacon Score and Outside GTA 
            if (levelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages > 0)
            {
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages", Value = levelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages, Category = portfolioHistoryCategory, CreatedDate = endDate });
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance", Value = levelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance, Category = portfolioHistoryCategory, CreatedDate = endDate });
                portfolioHistoryList.Add(new MICPortfolioHistory() { Key = "OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore", Value = levelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore, Category = portfolioHistoryCategory, CreatedDate = endDate });
            }

            return portfolioHistoryList;
        }

        public async Task<PortfolioHistoryViewModel> GetMICPortfolioHistory(DateTime? historyDate)
        {
            PortfolioHistoryViewModel portfolioHistoryViewModel = new PortfolioHistoryViewModel();
            var portfolioHistorList = await _portfolioHistoryRepository.FindAllAsync();

            if (portfolioHistorList.Any())
            {
                portfolioHistoryViewModel.DateList = portfolioHistorList
                                                    .GroupBy(h => h.CreatedDate)
                                                    .Select(d => (DateTime)d.OrderBy(y => y.CreatedDate.Value).First().CreatedDate)
                                                    .ToList();
            }

            if (!historyDate.HasValue)
                historyDate = portfolioHistoryViewModel.DateList?.FirstOrDefault();

            if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC))
            {
                portfolioHistoryViewModel.ReportsViewModel = new BBCReportModel();

                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "NoOfLoansOwnerOccupied1stMortgages"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.NoOfLoansOwnerOccupied1stMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansOwnerOccupied1stMortgages").Value;
                }
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA").Value;
                }
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "NoOfLoansOwnerOccupied1stMortgagesOther"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.NoOfLoansOwnerOccupied1stMortgagesOther = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansOwnerOccupied1stMortgagesOther").Value;
                }
                portfolioHistoryViewModel.ReportsViewModel.NoOfLoansOwnerOccupied2ndMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansOwnerOccupied2ndMortgages").Value;
                portfolioHistoryViewModel.ReportsViewModel.NoOfLoansNonOwnerOccupied1stMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRental1stMortgages").Value;
                portfolioHistoryViewModel.ReportsViewModel.NoOfLoansCommercial1stMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansCommercial1stMortgages").Value;

                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "EligibleAmountOwnerOccupied1stMortgages"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.EligibleAmountOwnerOccupied1stMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "EligibleAmountOwnerOccupied1stMortgages").Value;
                }
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA").Value;
                }
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "EligibleAmountOwnerOccupied1stMortgagesOther"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.EligibleAmountOwnerOccupied1stMortgagesOther = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "EligibleAmountOwnerOccupied1stMortgagesOther").Value;
                }
                portfolioHistoryViewModel.ReportsViewModel.EligibleAmountOwnerOccupied2ndMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "EligibleAmountOwnerOccupied2ndMortgages").Value;
                portfolioHistoryViewModel.ReportsViewModel.EligibleAmountNonOwnerOccupied1stMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "EligibleAmountRental1stMortgages").Value;
                portfolioHistoryViewModel.ReportsViewModel.EligibleAmountCommercial1stMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "EligibleAmountCommercial1stMortgages").Value;

                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "QualifiedAmountOwnerOccupied1stMortgages"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.QualifiedAmountOwnerOccupied1stMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "QualifiedAmountOwnerOccupied1stMortgages").Value;
                }
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "QualifiedAmountOwnerOccupied1stMortgagesLTVLessThan50GTA"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.QualifiedAmountOwnerOccupied1stMortgagesLTVLessThan50GTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "QualifiedAmountOwnerOccupied1stMortgagesLTVLessThan50GTA").Value;
                }
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "QualifiedAmountOwnerOccupied1stMortgagesOther"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.QualifiedAmountOwnerOccupied1stMortgagesOther = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "QualifiedAmountOwnerOccupied1stMortgagesOther").Value;
                }
                portfolioHistoryViewModel.ReportsViewModel.QualifiedAmountOwnerOccupied2ndMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "QualifiedAmountOwnerOccupied2ndMortgages").Value;
                portfolioHistoryViewModel.ReportsViewModel.QualifiedAmountNonOwnerOccupied1stMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "QualifiedAmountRental1stMortgages").Value;
                portfolioHistoryViewModel.ReportsViewModel.QualifiedAmountCommercial1stMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "QualifiedAmountCommercial1stMortgages").Value;

                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "PctOfAUMOwnerOccupied1stMortgages"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.PctOfAUMOwnerOccupied1stMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMOwnerOccupied1stMortgages").Value;
                }
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA").Value;
                }
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.BBC && h.Key == "PctOfAUMOwnerOccupied1stMortgagesOther"))
                {
                    portfolioHistoryViewModel.ReportsViewModel.PctOfAUMOwnerOccupied1stMortgagesOther = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMOwnerOccupied1stMortgagesOther").Value;
                }
                portfolioHistoryViewModel.ReportsViewModel.PctOfAUMOwnerOccupied2ndMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMOwnerOccupied2ndMortgages").Value;
                portfolioHistoryViewModel.ReportsViewModel.PctOfAUMNonOwnerOccupied1stMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMNonOwnerOccupied1stMortgages").Value;
                portfolioHistoryViewModel.ReportsViewModel.PctOfAUMCommercial1stMortgages = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMCommercial1stMortgages").Value;

            }

            if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.LoanSummaryByMortgagePriority))
            {
                portfolioHistoryViewModel.DashboardViewModel = new DashboardLoanViewModel();

                // Loan Summary by Mortgage Type
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansFirst = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansFirst").Value;
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansSecond = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansSecond").Value;
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansThird = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansThird").Value;

                portfolioHistoryViewModel.DashboardViewModel.AverageAppraisalFirst = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "AverageAppraisalFirst").Value;
                portfolioHistoryViewModel.DashboardViewModel.AverageAppraisalSecond = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "AverageAppraisalSecond").Value;
                portfolioHistoryViewModel.DashboardViewModel.AverageAppraisalThird = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "AverageAppraisalThird").Value;
                portfolioHistoryViewModel.DashboardViewModel.AverageAppraisalTotal = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "AverageAppraisalTotal").Value;

                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceFirst = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceFirst").Value;
                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceSecond = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceSecond").Value;
                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceThird = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceThird").Value;

                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMFirst = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMFirst").Value;
                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMSecond = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMSecond").Value;
                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMThird = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMThird").Value;

                // Weighted Average
                portfolioHistoryViewModel.DashboardViewModel.TotalWeightedLTV = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalWeightedLTV").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalWeightedMaturityDateInMonths = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalWeightedMaturityDateInMonths").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalWeightedBeaconScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalWeightedBeaconScore").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalWeightedInterestRate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalWeightedInterestRate").Value;

                portfolioHistoryViewModel.DashboardViewModel.FirstWeightedLTV = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "FirstWeightedLTV").Value;
                portfolioHistoryViewModel.DashboardViewModel.FirstWeightedMaturityDateInMonths = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "FirstWeightedMaturityDateInMonths").Value;
                portfolioHistoryViewModel.DashboardViewModel.FirstWeightedBeaconScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "FirstWeightedBeaconScore").Value;
                portfolioHistoryViewModel.DashboardViewModel.FirstWeightedInterestRate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "FirstWeightedInterestRate").Value;

                portfolioHistoryViewModel.DashboardViewModel.SecondlWeightedLTV = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SecondlWeightedLTV").Value;
                portfolioHistoryViewModel.DashboardViewModel.SecondlWeightedMaturityDateInMonths = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SecondlWeightedMaturityDateInMonths").Value;
                portfolioHistoryViewModel.DashboardViewModel.SecondlWeightedBeaconScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SecondlWeightedBeaconScore").Value;
                portfolioHistoryViewModel.DashboardViewModel.SecondlWeightedInterestRate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SecondlWeightedInterestRate").Value;

                // Postal Code
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansByPostalCodeInGTA = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansByPostalCodeInGTA").Value;
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansByPostalCodeInOttawa = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansByPostalCodeInOttawa").Value;
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansByPostalCodeInGoldenHorseshoe = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansByPostalCodeInGoldenHorseshoe").Value;
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansByPostalCodeInOtherMajorUrbanAreas = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansByPostalCodeInOtherMajorUrbanAreas").Value;

                portfolioHistoryViewModel.DashboardViewModel.WeightedLTVByPostalCodeInGTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "WeightedLTVByPostalCodeInGTA").Value;
                portfolioHistoryViewModel.DashboardViewModel.WeightedLTVByPostalCodeInOttawa = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "WeightedLTVByPostalCodeInOttawa").Value;
                portfolioHistoryViewModel.DashboardViewModel.WeightedLTVByPostalCodeInGoldenHorseshoe = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "WeightedLTVByPostalCodeInGoldenHorseshoe").Value;
                portfolioHistoryViewModel.DashboardViewModel.WeightedLTVByPostalCodeInOtherMajorUrbanAreas = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "WeightedLTVByPostalCodeInOtherMajorUrbanAreas").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalWeightedLTV = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalWeightedLTV").Value;

                portfolioHistoryViewModel.DashboardViewModel.WeightedBeaconScoreByPostalCodeInGTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "WeightedBeaconScoreByPostalCodeInGTA").Value;
                portfolioHistoryViewModel.DashboardViewModel.WeightedBeaconScoreByPostalCodeInOttawa = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "WeightedBeaconScoreByPostalCodeInOttawa").Value;
                portfolioHistoryViewModel.DashboardViewModel.WeightedBeaconScoreByPostalCodeInGoldenHorseshoe = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "WeightedBeaconScoreByPostalCodeInGoldenHorseshoe").Value;
                portfolioHistoryViewModel.DashboardViewModel.WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalWeightedBeaconScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalWeightedBeaconScore").Value;

                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceByPostalCodeInGTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceByPostalCodeInGTA").Value;
                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceByPostalCodeInOttawa = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceByPostalCodeInOttawa").Value;
                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceByPostalCodeInGoldenHorseshoe = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceByPostalCodeInGoldenHorseshoe").Value;
                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceByPostalCodeInOtherMajorUrbanAreas = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceByPostalCodeInOtherMajorUrbanAreas").Value;

                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMByPostalCodeInGTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMByPostalCodeInGTA").Value;
                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMByPostalCodeInOttawa = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMByPostalCodeInOttawa").Value;
                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMByPostalCodeInGoldenHorseshoe = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMByPostalCodeInGoldenHorseshoe").Value;
                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMByPostalCodeInOtherMajorUrbanAreas = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMByPostalCodeInOtherMajorUrbanAreas").Value;

                // Loan Summary by Mortgage Type
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansResidential = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansResidential").Value;
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansCommercial = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansCommercial").Value;
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansLand = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansLand").Value;
                portfolioHistoryViewModel.DashboardViewModel.NoOfLoansConstruction = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansConstruction").Value;

                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceResidential = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceResidential").Value;
                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceCommercial = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceCommercial").Value;
                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceLand = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceLand").Value;
                portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceConstruction = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceConstruction").Value;

                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMResidential = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMResidential").Value;
                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMCommercial = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMCommercial").Value;
                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMLand = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMLand").Value;
                portfolioHistoryViewModel.DashboardViewModel.PctOfAUMConstruction = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMConstruction").Value;

                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansUncategorized"))
                {
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansUncategorized = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansUncategorized").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceUncategorized = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceUncategorized").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PctOfAUMUncategorized = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMUncategorized").Value;
                }

                // Loan Summary by Late Payment
                portfolioHistoryViewModel.DashboardViewModel.TotoalNoOfLoans0To30DaysLate = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotoalNoOfLoans0To30DaysLate").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotoalNoOfLoans31To90DaysLate = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotoalNoOfLoans31To90DaysLate").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotoalNoOfLoans91To270DaysLate = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotoalNoOfLoans91To270DaysLate").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotoalNoOfLoansMoreThan270DaysLate = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotoalNoOfLoansMoreThan270DaysLate").Value;

                portfolioHistoryViewModel.DashboardViewModel.TotalPrincipalBalance0To30DaysLate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPrincipalBalance0To30DaysLate").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalPrincipalBalance31To90DaysLate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPrincipalBalance31To90DaysLate").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalPrincipalBalance91To270DaysLate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPrincipalBalance91To270DaysLate").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalPrincipalBalanceMoreThan270DaysLate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPrincipalBalanceMoreThan270DaysLate").Value;

                portfolioHistoryViewModel.DashboardViewModel.TotalPctOfAUM0To30DaysLate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPctOfAUM0To30DaysLate").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalPctOfAUM31To90DaysLate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPctOfAUM31To90DaysLate").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalPctOfAUM91To270DaysLate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPctOfAUM91To270DaysLate").Value;
                portfolioHistoryViewModel.DashboardViewModel.TotalPctOfAUMMoreThan270DaysLate = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPctOfAUMMoreThan270DaysLate").Value;

                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.RemainingTermToMaturitySummary))
                {
                    // Remaining Term to Maturity Summary
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansRemainingTermtoMaturityLessEqual6 = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRemainingTermtoMaturityLessEqual6").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansRemainingTermtoMaturity6To9 = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRemainingTermtoMaturity6To9").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansRemainingTermtoMaturity9To12 = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRemainingTermtoMaturity9To12").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansRemainingTermtoMaturityMoreThan12 = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRemainingTermtoMaturityMoreThan12").Value;

                    portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceRemainingTermtoMaturityLessEqual6 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceRemainingTermtoMaturityLessEqual6").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceRemainingTermtoMaturity6To9 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceRemainingTermtoMaturity6To9").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceRemainingTermtoMaturity9To12 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceRemainingTermtoMaturity9To12").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PrincipalBalanceRemainingTermtoMaturityMoreThan12 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalanceRemainingTermtoMaturityMoreThan12").Value;

                    portfolioHistoryViewModel.DashboardViewModel.PctOfAUMRemainingTermtoMaturityLessEqual6 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMRemainingTermtoMaturityLessEqual6").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PctOfAUMRemainingTermtoMaturity6To9 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMRemainingTermtoMaturity6To9").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PctOfAUMRemainingTermtoMaturity9To12 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMRemainingTermtoMaturity9To12").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PctOfAUMRemainingTermtoMaturityMoreThan12 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMRemainingTermtoMaturityMoreThan12").Value;

                    // Portfolio Summary by LTV
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansPortfolioByLTVMoreThan80 = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansPortfolioByLTVMoreThan80").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansPortfolioByLTV75To80 = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansPortfolioByLTV75To80").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansPortfolioByLTV65To75 = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansPortfolioByLTV65To75").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansPortfolioByLTVLessEqual65 = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansPortfolioByLTVLessEqual65").Value;

                    portfolioHistoryViewModel.DashboardViewModel.PrincipalBalancePortfolioByLTVMoreThan80 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalancePortfolioByLTVMoreThan80").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PrincipalBalancePortfolioByLTV75To80 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalancePortfolioByLTV75To80").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PrincipalBalancePortfolioByLTV65To75 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalancePortfolioByLTV65To75").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PrincipalBalancePortfolioByLTVLessEqual65 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PrincipalBalancePortfolioByLTVLessEqual65").Value;

                    portfolioHistoryViewModel.DashboardViewModel.PctOfAUMPortfolioByLTVMoreThan80 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMPortfolioByLTVMoreThan80").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PctOfAUMPortfolioByLTV75To80 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMPortfolioByLTV75To80").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PctOfAUMPortfolioByLTV65To75 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMPortfolioByLTV65To75").Value;
                    portfolioHistoryViewModel.DashboardViewModel.PctOfAUMPortfolioByLTVLessEqual65 = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "PctOfAUMPortfolioByLTVLessEqual65").Value;
                }

                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.PricePerSquareFootSummary))
                {
                    // *** Price per Square Foot Summary ***
                    // GTA
                    portfolioHistoryViewModel.DashboardViewModel.DetachedPricePerSquareFootInGTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "DetachedPricePerSquareFootInGTA").Value;
                    portfolioHistoryViewModel.DashboardViewModel.SemiDetachedPricePerSquareFootInGTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SemiDetachedPricePerSquareFootInGTA").Value;
                    portfolioHistoryViewModel.DashboardViewModel.RowHousingPricePerSquareFootInGTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "RowHousingPricePerSquareFootInGTA").Value;
                    portfolioHistoryViewModel.DashboardViewModel.CondoPricePerSquareFootInGTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "CondoPricePerSquareFootInGTA").Value;
                    portfolioHistoryViewModel.DashboardViewModel.TotalPricePerSquareFootInGTA = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPricePerSquareFootInGTA").Value;

                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansDetachedInGTA = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansDetachedInGTA").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansSemiDetachedInGTA = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansSemiDetachedInGTA").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansRowHousingInGTA = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRowHousingInGTA").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansCondoInGTA = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansCondoInGTA").Value;

                    // Ottawa
                    portfolioHistoryViewModel.DashboardViewModel.DetachedPricePerSquareFootInOttawa = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "DetachedPricePerSquareFootInOttawa").Value;
                    portfolioHistoryViewModel.DashboardViewModel.SemiDetachedPricePerSquareFootInOttawa = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SemiDetachedPricePerSquareFootInOttawa").Value;
                    portfolioHistoryViewModel.DashboardViewModel.RowHousingPricePerSquareFootInOttawa = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "RowHousingPricePerSquareFootInOttawa").Value;
                    portfolioHistoryViewModel.DashboardViewModel.CondoPricePerSquareFootInOttawa = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "CondoPricePerSquareFootInOttawa").Value;
                    portfolioHistoryViewModel.DashboardViewModel.TotalPricePerSquareFootInOttawa = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPricePerSquareFootInOttawa").Value;

                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansDetachedInOttawa = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansDetachedInOttawa").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansSemiDetachedInOttawa = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansSemiDetachedInOttawa").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansRowHousingInOttawa = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRowHousingInOttawa").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansCondoInOttawa = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansCondoInOttawa").Value;

                    // Golden Horseshoe
                    portfolioHistoryViewModel.DashboardViewModel.DetachedPricePerSquareFootInGoldenHorseshoe = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "DetachedPricePerSquareFootInGoldenHorseshoe").Value;
                    portfolioHistoryViewModel.DashboardViewModel.SemiDetachedPricePerSquareFootInGoldenHorseshoe = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SemiDetachedPricePerSquareFootInGoldenHorseshoe").Value;
                    portfolioHistoryViewModel.DashboardViewModel.RowHousingPricePerSquareFootInGoldenHorseshoe = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "RowHousingPricePerSquareFootInGoldenHorseshoe").Value;
                    portfolioHistoryViewModel.DashboardViewModel.CondoPricePerSquareFootInGoldenHorseshoe = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "CondoPricePerSquareFootInGoldenHorseshoe").Value;
                    portfolioHistoryViewModel.DashboardViewModel.TotalPricePerSquareFootInGoldenHorseshoe = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPricePerSquareFootInGoldenHorseshoe").Value;

                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansDetachedInGoldenHorseshoe = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansDetachedInGoldenHorseshoe").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansSemiDetachedInGoldenHorseshoe = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansSemiDetachedInGoldenHorseshoe").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansRowHousingInGoldenHorseshoe = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRowHousingInGoldenHorseshoe").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansCondoInGoldenHorseshoe = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansCondoInGoldenHorseshoe").Value;

                    // Other Major Urban Areas
                    portfolioHistoryViewModel.DashboardViewModel.DetachedPricePerSquareFootInOtherMajorUrbanAreas = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "DetachedPricePerSquareFootInOtherMajorUrbanAreas").Value;
                    portfolioHistoryViewModel.DashboardViewModel.SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas").Value;
                    portfolioHistoryViewModel.DashboardViewModel.RowHousingPricePerSquareFootInOtherMajorUrbanAreas = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "RowHousingPricePerSquareFootInOtherMajorUrbanAreas").Value;
                    portfolioHistoryViewModel.DashboardViewModel.CondoPricePerSquareFootInOtherMajorUrbanAreas = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "CondoPricePerSquareFootInOtherMajorUrbanAreas").Value;
                    portfolioHistoryViewModel.DashboardViewModel.TotalPricePerSquareFootInOtherMajorUrbanAreas = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPricePerSquareFootInOtherMajorUrbanAreas").Value;

                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansDetachedInOtherMajorUrbanAreas = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansDetachedInOtherMajorUrbanAreas").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansSemiDetachedInOtherMajorUrbanAreas = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansSemiDetachedInOtherMajorUrbanAreas").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansRowHousingInOtherMajorUrbanAreas = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRowHousingInOtherMajorUrbanAreas").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansCondoInOtherMajorUrbanAreas = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansCondoInOtherMajorUrbanAreas").Value;

                    // Total
                    portfolioHistoryViewModel.DashboardViewModel.DetachedPricePerSquareFootForAllRegions = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "DetachedPricePerSquareFootForAllRegions").Value;
                    portfolioHistoryViewModel.DashboardViewModel.SemiDetachedPricePerSquareFootForAllRegions = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SemiDetachedPricePerSquareFootForAllRegions").Value;
                    portfolioHistoryViewModel.DashboardViewModel.RowHousingPricePerSquareFootForAllRegions = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "RowHousingPricePerSquareFootForAllRegions").Value;
                    portfolioHistoryViewModel.DashboardViewModel.CondoPricePerSquareFootForAllRegions = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "CondoPricePerSquareFootForAllRegions").Value;
                    portfolioHistoryViewModel.DashboardViewModel.TotalPricePerSquareFootForAllRegions = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "TotalPricePerSquareFootForAllRegions").Value;

                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansDetachedInAllRegions = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansDetachedInAllRegions").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansSemiDetachedInAllRegions = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansSemiDetachedInAllRegions").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansRowHousingInAllRegions = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansRowHousingInAllRegions").Value;
                    portfolioHistoryViewModel.DashboardViewModel.NoOfLoansCondoInAllRegions = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "NoOfLoansCondoInAllRegions").Value;
                }
            }

            if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == MICPortfolioHistoryCategory.StressTestParameters))
            {
                portfolioHistoryViewModel.StressTestReportViewModel = new StressTestReportModel();

                // Stress Test Data
                // Site Settings
                portfolioHistoryViewModel.StressTestReportViewModel.Level1MarketDeclineLimit = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "Level1MarketDeclineLimit" && h.Category == MICPortfolioHistoryCategory.StressTestParameters).Value;
                portfolioHistoryViewModel.StressTestReportViewModel.Level2MarketDeclineLimit = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "Level2MarketDeclineLimit" && h.Category == MICPortfolioHistoryCategory.StressTestParameters).Value;
                portfolioHistoryViewModel.StressTestReportViewModel.Level3MarketDeclineLimit = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "Level3MarketDeclineLimit" && h.Category == MICPortfolioHistoryCategory.StressTestParameters).Value;
                portfolioHistoryViewModel.StressTestReportViewModel.LiquidationCostInCentsPerDollar = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LiquidationCostInCentsPerDollar" && h.Category == MICPortfolioHistoryCategory.StressTestParameters).Value;
                portfolioHistoryViewModel.StressTestReportViewModel.ProjectedLoanLossReserve = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "ProjectedLoanLossReserve" && h.Category == MICPortfolioHistoryCategory.StressTestParameters).Value;
                portfolioHistoryViewModel.StressTestReportViewModel.SubordinatedSharesValue = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "SubordinatedSharesValue" && h.Category == MICPortfolioHistoryCategory.StressTestParameters).Value;
                portfolioHistoryViewModel.StressTestReportViewModel.AtRiskBeaconScoreThreshold = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "AtRiskBeaconScoreThreshold" && h.Category == MICPortfolioHistoryCategory.StressTestParameters).Value;
                portfolioHistoryViewModel.StressTestReportViewModel.AtRiskLTVThreshold = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "AtRiskLTVThreshold" && h.Category == MICPortfolioHistoryCategory.StressTestParameters).Value;
                portfolioHistoryViewModel.StressTestReportViewModel.Level4AppraisalDateLimit = new DateTime((long)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "Level4AppraisalDateLimit" && h.Category == MICPortfolioHistoryCategory.StressTestParameters).Value * 100000000); // decimal 18, 8 - divided by 100000000 to make it fit

                portfolioHistoryViewModel.StressTestReportViewModel.Level1StressTestData = GetStressTestLevelData(historyDate, portfolioHistorList, MICPortfolioHistoryCategory.L1StressTest); // L1
                portfolioHistoryViewModel.StressTestReportViewModel.Level2StressTestData = GetStressTestLevelData(historyDate, portfolioHistorList, MICPortfolioHistoryCategory.L2StressTest); // L2
                portfolioHistoryViewModel.StressTestReportViewModel.Level3StressTestData = GetStressTestLevelData(historyDate, portfolioHistorList, MICPortfolioHistoryCategory.L3StressTest); // L3
                portfolioHistoryViewModel.StressTestReportViewModel.Level4StressTestData = GetStressTestLevelData(historyDate, portfolioHistorList, MICPortfolioHistoryCategory.L4StressTest); // L4
            }

            return portfolioHistoryViewModel;
        }

        private static StressTestLevelDataModel GetStressTestLevelData(DateTime? historyDate, IEnumerable<MICPortfolioHistory> portfolioHistorList, MICPortfolioHistoryCategory stressTestCategory)
        {
            StressTestLevelDataModel stressTestLevelData = new StressTestLevelDataModel();

            if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Category == stressTestCategory))
            {
                if (stressTestCategory != MICPortfolioHistoryCategory.L4StressTest) // L4StressTest does not have these
                {
                    // *** Level Stats *** //
                    // # of Mortgages
                    stressTestLevelData.LTV0To80NumMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV0To80NumMortgages" && h.Category == stressTestCategory).Value; // 0% - 80%
                    stressTestLevelData.LTV80To90NumMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV80To90NumMortgages" && h.Category == stressTestCategory).Value; // 80% - 90%
                    stressTestLevelData.LTV90To95NumMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV90To95NumMortgages" && h.Category == stressTestCategory).Value; // Above 90% - 95%
                    stressTestLevelData.LTV95To100NumMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV95To100NumMortgages" && h.Category == stressTestCategory).Value; // Above 95% - 100%
                    stressTestLevelData.LTVAbove100NumMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTVAbove100NumMortgages" && h.Category == stressTestCategory).Value; // Above 100%

                    // Weighted Aaverage Credit Score
                    stressTestLevelData.LTV0To80WACreditScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV0To80WACreditScore" && h.Category == stressTestCategory).Value; // 0.0% - 80%
                    stressTestLevelData.LTV80To90WACreditScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV80To90WACreditScore" && h.Category == stressTestCategory).Value; // 80.1% - 90%
                    stressTestLevelData.LTV90To95WACreditScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV90To95WACreditScore" && h.Category == stressTestCategory).Value; // Above 90.1% - 95%
                    stressTestLevelData.LTV95To100WACreditScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV95To100WACreditScore" && h.Category == stressTestCategory).Value; // Above 95.1% - 100%
                    stressTestLevelData.LTVAbove100WACreditScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTVAbove100WACreditScore" && h.Category == stressTestCategory).Value; // Above 100%

                    // Value of Portfolio (%)
                    stressTestLevelData.LTVPct0To80PortfolioValue = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTVPct0To80PortfolioValue" && h.Category == stressTestCategory).Value; // 0.0% - 80%
                    stressTestLevelData.LTVPct80To90PortfolioValue = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTVPct80To90PortfolioValue" && h.Category == stressTestCategory).Value; // 80.1% - 90%
                    stressTestLevelData.LTVPct90To95PortfolioValue = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTVPct90To95PortfolioValue" && h.Category == stressTestCategory).Value; // Above 90.1% - 95%
                    stressTestLevelData.LTVPct95To100PortfolioValue = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTVPct95To100PortfolioValue" && h.Category == stressTestCategory).Value; // Above 95.1% - 100%
                    stressTestLevelData.LTVPctAbove100PortfolioValue = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTVPctAbove100PortfolioValue" && h.Category == stressTestCategory).Value; // Above 100%

                    // Principal Balance ($)
                    stressTestLevelData.LTV0To80PrincipalBalance = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV0To80PrincipalBalance" && h.Category == stressTestCategory).Value; // 0.0% - 80%
                    stressTestLevelData.LTV80To90PrincipalBalance = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV80To90PrincipalBalance" && h.Category == stressTestCategory).Value; // 80.1% - 90%
                    stressTestLevelData.LTV90To95PrincipalBalance = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV90To95PrincipalBalance" && h.Category == stressTestCategory).Value; // Above 90.1% - 95%
                    stressTestLevelData.LTV95To100PrincipalBalance = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTV95To100PrincipalBalance" && h.Category == stressTestCategory).Value; // Above 95.1% - 100%
                    stressTestLevelData.LTVAbove100PrincipalBalance = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "LTVAbove100PrincipalBalance" && h.Category == stressTestCategory).Value; // Above 100%
                }

                // *** Analysis *** //
                // Over Threshold LTV and Below Threshod Beacon Score
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Key == "OverThresholdLTVBelowThreshodBeaconScoreNumMortgages" && h.Category == stressTestCategory))
                {
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "OverThresholdLTVBelowThreshodBeaconScoreNumMortgages" && h.Category == stressTestCategory).Value;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance" && h.Category == stressTestCategory).Value;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreWACreditScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "OverThresholdLTVBelowThreshodBeaconScoreWACreditScore" && h.Category == stressTestCategory).Value;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast = 0;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalancePast = 0;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreWACreditScorePast = 0;
                }

                // Over Threshold LTV, Below Threshod Beacon Score and Outside GTA 
                if (portfolioHistorList.Any(h => h.CreatedDate == historyDate && h.Key == "OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages" && h.Category == stressTestCategory))
                {
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages = (int)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages" && h.Category == stressTestCategory).Value;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance" && h.Category == stressTestCategory).Value;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore = (decimal)portfolioHistorList.FirstOrDefault(h => h.CreatedDate == historyDate && h.Key == "OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore" && h.Category == stressTestCategory).Value;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast = 0;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalancePast = 0;
                    stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScorePast = 0;
                }
            }

            return stressTestLevelData;
        }
    }
}