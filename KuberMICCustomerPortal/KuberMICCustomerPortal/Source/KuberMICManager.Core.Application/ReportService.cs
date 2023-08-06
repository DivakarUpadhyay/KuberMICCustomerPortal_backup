using KuberMICManager.Core.Application.HelperSerivces;
using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ReportModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Application
{
    public class ReportService : IReportService
    {
        // inject the dependencies
        private readonly ILogger<ReportService> _logger;
        private readonly ILoanService _loanService;
        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly IMemoryCache _cache;

        public ReportService(ILogger<ReportService> logger,
                             ILoanService loanService,
                             IPostalCodeRepository postalCodeRepository,
                             IMemoryCache cache)
        {
            _logger = logger;
            _loanService = loanService;
            _postalCodeRepository = postalCodeRepository;
            _cache = cache;
        }

        public async Task<StressTestReportModel> GetStressTestReportData(DateTime? endDate)
        {
            _logger.LogInformation($"Calling: ReportService.GetStressTestReportData(): End Date, {endDate}\n");

            IEnumerable<TdsLoan> Loans = await _loanService.GetActiveLoans(endDate); // Get all active closed loans
            IEnumerable<TdsProperty> propertyList = await _loanService.GetProperties();
            IEnumerable<TdsLien> lienList = await _loanService.GetLiens();
            IEnumerable<UdfValue> customFieldsValueList = await _loanService.GetUserDefinedFieldsByParentID();
            IEnumerable<string> outsideGTAPostCodes = (await _postalCodeRepository.FindAllAsync()).Where(p => p.MortgageRegion != MortgageRegion.GTA.ToDescription()).Select(p => p.County.Trim().ToLower());

            StressTestReportModel stressTestReportData = new StressTestReportModel()
            {
                Level1MarketDeclineLimit = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTLEVELONEMARKETDECLINELIMIT.ToString()),
                Level2MarketDeclineLimit = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTLEVELTWOMARKETDECLINELIMIT.ToString()),
                Level3MarketDeclineLimit = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTLEVELTHREEMARKETDECLINELIMIT.ToString()),
                LiquidationCostInCentsPerDollar = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTLIQUIDATIONCOSTINCENTSPERDOLLARFORVALUEATRISK.ToString()),
                ProjectedLoanLossReserve = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTPROJECTEDLOANLOSSRESERVE.ToString()),
                SubordinatedSharesValue = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTSUBORDINATEDSHARESVALUE.ToString()),
                AtRiskBeaconScoreThreshold = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTATRISKBEACONSCORETHRESHOLD.ToString()),
                AtRiskLTVThreshold = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTATRISKLTVTHRESHOLD.ToString()),
                Level4AppraisalDateLimit = GetSiteSettingDateTime(_cache, SiteSettingKey.STRESSTESTLEVEL4APPRAISALDATEUPPERLIMIT.ToString()),
            };

            Parallel.Invoke(() => stressTestReportData.Level1StressTestData = GetStressTestLevelData(Loans, StressTestLevel.LevelOne, stressTestReportData, propertyList, lienList, customFieldsValueList, outsideGTAPostCodes),
                            () => stressTestReportData.Level2StressTestData = GetStressTestLevelData(Loans, StressTestLevel.LevelTwo, stressTestReportData, propertyList, lienList, customFieldsValueList, outsideGTAPostCodes),
                            () => stressTestReportData.Level3StressTestData = GetStressTestLevelData(Loans, StressTestLevel.LevelThree, stressTestReportData, propertyList, lienList, customFieldsValueList, outsideGTAPostCodes),
                            () => stressTestReportData.Level4StressTestData = GetStressTestLevelData(Loans, StressTestLevel.LevelFour, stressTestReportData, propertyList, lienList, customFieldsValueList, outsideGTAPostCodes));

            return stressTestReportData;
        }

        private StressTestLevelDataModel GetStressTestLevelData(IEnumerable<TdsLoan> Loans, StressTestLevel stressTestLevel, StressTestReportModel stressTestReportData, IEnumerable<TdsProperty> propertyList, IEnumerable<TdsLien> lienList, IEnumerable<UdfValue> customFieldsValueList, IEnumerable<string> outsideGTAPostCodes)
        {
            LoanFilterType filterType0To80 = LoanFilterType.L10To80Mortgages;
            LoanFilterType filterType80To90 = LoanFilterType.L180To90Mortgages;
            LoanFilterType filterType90To95 = LoanFilterType.L190To95Mortgages;
            LoanFilterType filterType95To100 = LoanFilterType.L195To100Mortgages;
            LoanFilterType filterTypeAbove100 = LoanFilterType.L1Above100Mortgages;
            LoanFilterType filterTypeOverThresholdLTVBelowThreshodBeacon = LoanFilterType.L1OverThresholdLTVBelowThreshodBeaconScoreMortgages;
            LoanFilterType filterTypeOverThresholdLTVBelowThreshodBeaconOutsideGTA = LoanFilterType.L1OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages;

            if (stressTestLevel == StressTestLevel.LevelTwo)
            {
                filterType0To80 = LoanFilterType.L20To80Mortgages;
                filterType80To90 = LoanFilterType.L280To90Mortgages;
                filterType90To95 = LoanFilterType.L290To95Mortgages;
                filterType95To100 = LoanFilterType.L295To100Mortgages;
                filterTypeAbove100 = LoanFilterType.L2Above100Mortgages;
                filterTypeOverThresholdLTVBelowThreshodBeacon = LoanFilterType.L2OverThresholdLTVBelowThreshodBeaconScoreMortgages;
                filterTypeOverThresholdLTVBelowThreshodBeaconOutsideGTA = LoanFilterType.L2OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages;
            } 
            else if (stressTestLevel == StressTestLevel.LevelThree)
            {
                filterType0To80 = LoanFilterType.L30To80Mortgages;
                filterType80To90 = LoanFilterType.L380To90Mortgages;
                filterType90To95 = LoanFilterType.L390To95Mortgages;
                filterType95To100 = LoanFilterType.L395To100Mortgages;
                filterTypeAbove100 = LoanFilterType.L3Above100Mortgages;
                filterTypeOverThresholdLTVBelowThreshodBeacon = LoanFilterType.L3OverThresholdLTVBelowThreshodBeaconScoreMortgages;
                filterTypeOverThresholdLTVBelowThreshodBeaconOutsideGTA = LoanFilterType.L3OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages;
            }
            else if (stressTestLevel == StressTestLevel.LevelFour)
            {
                filterTypeOverThresholdLTVBelowThreshodBeacon = LoanFilterType.L4OverThresholdLTVBelowThreshodBeaconScoreMortgages;
                filterTypeOverThresholdLTVBelowThreshodBeaconOutsideGTA = LoanFilterType.L4OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages;
            }

            IEnumerable<TdsLoan> loanDataLTV0To80StressTest = null;
            IEnumerable<TdsLoan> loanDataLTV80To90StressTest = null;
            IEnumerable<TdsLoan> loanDataLTV90To95StressTest = null;
            IEnumerable<TdsLoan> loanDataLTV95To100StressTest = null;
            IEnumerable<TdsLoan> loanDataLTVAbove100StressTest = null;
            IEnumerable<TdsLoan> loanDataOverThresholdLTVBelowThreshodBeaconStressTest = null;
            IEnumerable<TdsLoan> loanDataOverThresholdLTVBelowThreshodBeaconOutsideGTAStressTest = null;

            List<Action> stressTestLevelDataActions = new List<Action>
            {
                () => loanDataOverThresholdLTVBelowThreshodBeaconStressTest = LoanFilterService.StressTestLoanFilter(Loans, filterTypeOverThresholdLTVBelowThreshodBeacon, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList, GetSiteSettingDateTime(_cache, SiteSettingKey.STRESSTESTLEVEL4APPRAISALDATEUPPERLIMIT.ToString())),
                () => loanDataOverThresholdLTVBelowThreshodBeaconOutsideGTAStressTest = LoanFilterService.StressTestLoanFilter(Loans, filterTypeOverThresholdLTVBelowThreshodBeaconOutsideGTA, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList, GetSiteSettingDateTime(_cache, SiteSettingKey.STRESSTESTLEVEL4APPRAISALDATEUPPERLIMIT.ToString()))
            };

            if (stressTestLevel != StressTestLevel.LevelFour) // L4StressTest does not have these
            {
                stressTestLevelDataActions.Add(() => loanDataLTV0To80StressTest = LoanFilterService.StressTestLoanFilter(Loans, filterType0To80, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList));
                stressTestLevelDataActions.Add(() => loanDataLTV80To90StressTest = LoanFilterService.StressTestLoanFilter(Loans, filterType80To90, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList));
                stressTestLevelDataActions.Add(() => loanDataLTV90To95StressTest = LoanFilterService.StressTestLoanFilter(Loans, filterType90To95, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList));
                stressTestLevelDataActions.Add(() => loanDataLTV95To100StressTest = LoanFilterService.StressTestLoanFilter(Loans, filterType95To100, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList));
                stressTestLevelDataActions.Add(() => loanDataLTVAbove100StressTest = LoanFilterService.StressTestLoanFilter(Loans, filterTypeAbove100, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList));
            }

            Parallel.Invoke(stressTestLevelDataActions.ToArray());

            decimal totalPrincipalValue = 0;
            decimal ltv0To80PrincipalBalance = 0;
            decimal ltv80To90PrincipalBalance = 0;
            decimal ltv90To95PrincipalBalance = 0;
            decimal ltv95To100PrincipalBalance = 0;
            decimal ltvAbove100PrincipalBalance = 0;
            decimal overThresholdLTVBelowThreshodBeaconPrincipalValue = 0;
            decimal overThresholdLTVBelowThreshodBeaconOutsideGTAPrincipalValue = 0;

            List<Action> stressTestLevelStatsActions = new List<Action>
            {
                () => totalPrincipalValue = (decimal)Loans.Sum(l => l.PrinBal),
                () => overThresholdLTVBelowThreshodBeaconPrincipalValue = (decimal)loanDataOverThresholdLTVBelowThreshodBeaconStressTest.Sum(l => l.PrinBal),
                () => overThresholdLTVBelowThreshodBeaconOutsideGTAPrincipalValue = (decimal)loanDataOverThresholdLTVBelowThreshodBeaconOutsideGTAStressTest.Sum(l => l.PrinBal)
            };

            if (stressTestLevel != StressTestLevel.LevelFour) // L4StressTest does not have these
            {
                stressTestLevelStatsActions.Add(() => ltv0To80PrincipalBalance = (decimal)loanDataLTV0To80StressTest.Sum(l => l.PrinBal));
                stressTestLevelStatsActions.Add(() => ltv80To90PrincipalBalance = (decimal)loanDataLTV80To90StressTest.Sum(l => l.PrinBal));
                stressTestLevelStatsActions.Add(() => ltv90To95PrincipalBalance = (decimal)loanDataLTV90To95StressTest.Sum(l => l.PrinBal));
                stressTestLevelStatsActions.Add(() => ltv95To100PrincipalBalance = (decimal)loanDataLTV95To100StressTest.Sum(l => l.PrinBal));
                stressTestLevelStatsActions.Add(() => ltvAbove100PrincipalBalance = (decimal)loanDataLTVAbove100StressTest.Sum(l => l.PrinBal));
            }

            Parallel.Invoke(stressTestLevelStatsActions.ToArray());

            int ltv0To80NumMortgages = 0;
            decimal ltv0To80WACreditScore = 0;
            decimal ltvPct0To80PortfolioValue = 0;

            int ltv80To90NumMortgages = 0;
            decimal ltv80To90WACreditScore = 0;
            decimal ltvPct80To90PortfolioValue = 0;

            int ltv90To95NumMortgages = 0;
            decimal ltv90To95WACreditScore = 0;
            decimal ltvPct90To95PortfolioValue = 0;

            int ltv95To100NumMortgages = 0;
            decimal ltv95To100WACreditScore = 0;
            decimal ltvPct95To100PortfolioValue = 0;

            int ltvAbove100NumMortgages = 0;
            decimal ltvAbove100WACreditScore = 0;
            decimal ltvPctAbove100PortfolioValue = 0;

            int overThresholdLTVBelowThreshodBeaconScoreNumMortgages = 0;
            decimal overThresholdLTVBelowThreshodBeaconScoreWACreditScore = 0;
            decimal overThresholdLTVBelowThreshodBeaconScorePrincipalBalance = 0;
            int overThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast = 0;
            decimal overThresholdLTVBelowThreshodBeaconScoreWACreditScorePast = 0;
            decimal overThresholdLTVBelowThreshodBeaconScorePrincipalBalancePast = 0;
            string overThresholdLTVBelowThreshodBeaconScoreLoanAccountNumbers = null;

            int overThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages = 0;
            decimal overThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore = 0;
            decimal overThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance = 0;
            int overThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast = 0;
            decimal overThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScorePast = 0;
            decimal overThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalancePast = 0;
            string overThresholdLTVBelowThreshodBeaconScoreOutsideGTALoanAccountNumbers = null;

            List<Action> stressTestLevelMoreStatsActions = new List<Action>
            {
                () => overThresholdLTVBelowThreshodBeaconScoreNumMortgages = loanDataOverThresholdLTVBelowThreshodBeaconStressTest.Count(),
                () => overThresholdLTVBelowThreshodBeaconScoreWACreditScore = (decimal)loanDataOverThresholdLTVBelowThreshodBeaconStressTest.Sum(l => LoanFilterService.GetAverageBeaconScore(l, customFieldsValueList) * (l.PrinBal / overThresholdLTVBelowThreshodBeaconPrincipalValue)),
                () => overThresholdLTVBelowThreshodBeaconScorePrincipalBalance = overThresholdLTVBelowThreshodBeaconPrincipalValue,
                () => overThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast = 0,
                () => overThresholdLTVBelowThreshodBeaconScoreWACreditScorePast = 0,
                () => overThresholdLTVBelowThreshodBeaconScorePrincipalBalancePast = 0,
                () => overThresholdLTVBelowThreshodBeaconScoreLoanAccountNumbers = String.Join(", ", loanDataOverThresholdLTVBelowThreshodBeaconStressTest.Select(l => l.Account)),

                () => overThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages = loanDataOverThresholdLTVBelowThreshodBeaconOutsideGTAStressTest.Count(),
                () => overThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore = (decimal)loanDataOverThresholdLTVBelowThreshodBeaconOutsideGTAStressTest.Sum(l => LoanFilterService.GetAverageBeaconScore(l, customFieldsValueList) * (l.PrinBal / overThresholdLTVBelowThreshodBeaconOutsideGTAPrincipalValue)),
                () => overThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance = overThresholdLTVBelowThreshodBeaconOutsideGTAPrincipalValue,
                () => overThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast = 0,
                () => overThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScorePast = 0,
                () => overThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalancePast = 0,
                () => overThresholdLTVBelowThreshodBeaconScoreOutsideGTALoanAccountNumbers = String.Join(", ", loanDataOverThresholdLTVBelowThreshodBeaconOutsideGTAStressTest.Select(l => l.Account))
            };

            if (stressTestLevel != StressTestLevel.LevelFour) // L4StressTest does not have these
            {
                stressTestLevelMoreStatsActions.Add(() => ltv0To80NumMortgages = loanDataLTV0To80StressTest.Count());
                stressTestLevelMoreStatsActions.Add(() => ltv0To80WACreditScore = (decimal) loanDataLTV0To80StressTest.Sum(l => LoanFilterService.GetAverageBeaconScore(l, customFieldsValueList)* (l.PrinBal / ltv0To80PrincipalBalance)));
                stressTestLevelMoreStatsActions.Add(() => ltvPct0To80PortfolioValue = ltv0To80PrincipalBalance / totalPrincipalValue* 100);

                stressTestLevelMoreStatsActions.Add(() => ltv80To90NumMortgages = loanDataLTV80To90StressTest.Count());
                stressTestLevelMoreStatsActions.Add(() => ltv80To90WACreditScore = (decimal) loanDataLTV80To90StressTest.Sum(l => LoanFilterService.GetAverageBeaconScore(l, customFieldsValueList)* (l.PrinBal / ltv80To90PrincipalBalance)));
                stressTestLevelMoreStatsActions.Add(() => ltvPct80To90PortfolioValue = ltv80To90PrincipalBalance / totalPrincipalValue* 100);

                stressTestLevelMoreStatsActions.Add(() => ltv90To95NumMortgages = loanDataLTV90To95StressTest.Count());
                stressTestLevelMoreStatsActions.Add(() => ltv90To95WACreditScore = (decimal) loanDataLTV90To95StressTest.Sum(l => LoanFilterService.GetAverageBeaconScore(l, customFieldsValueList)* (l.PrinBal / ltv90To95PrincipalBalance)));
                stressTestLevelMoreStatsActions.Add(() => ltvPct90To95PortfolioValue = ltv90To95PrincipalBalance / totalPrincipalValue* 100);

                stressTestLevelMoreStatsActions.Add(() => ltv95To100NumMortgages = loanDataLTV95To100StressTest.Count());
                stressTestLevelMoreStatsActions.Add(() => ltv95To100WACreditScore = (decimal) loanDataLTV95To100StressTest.Sum(l => LoanFilterService.GetAverageBeaconScore(l, customFieldsValueList)* (l.PrinBal / ltv95To100PrincipalBalance)));
                stressTestLevelMoreStatsActions.Add(() => ltvPct95To100PortfolioValue = ltv95To100PrincipalBalance / totalPrincipalValue* 100);

                stressTestLevelMoreStatsActions.Add(() => ltvAbove100NumMortgages = loanDataLTVAbove100StressTest.Count());
                stressTestLevelMoreStatsActions.Add(() => ltvAbove100WACreditScore = (decimal) loanDataLTVAbove100StressTest.Sum(l => LoanFilterService.GetAverageBeaconScore(l, customFieldsValueList)* (l.PrinBal / ltvAbove100PrincipalBalance)));
                stressTestLevelMoreStatsActions.Add(() => ltvPctAbove100PortfolioValue = ltvAbove100PrincipalBalance / totalPrincipalValue* 100);
            }

            Parallel.Invoke(stressTestLevelMoreStatsActions.ToArray());

            return new StressTestLevelDataModel()
            {
                LTV0To80NumMortgages = ltv0To80NumMortgages,
                LTV0To80WACreditScore = ltv0To80WACreditScore,
                LTV0To80PrincipalBalance = ltv0To80PrincipalBalance,
                LTVPct0To80PortfolioValue = ltvPct0To80PortfolioValue,

                LTV80To90NumMortgages = ltv80To90NumMortgages,
                LTV80To90WACreditScore = ltv80To90WACreditScore,
                LTV80To90PrincipalBalance = ltv80To90PrincipalBalance,
                LTVPct80To90PortfolioValue = ltvPct80To90PortfolioValue,

                LTV90To95NumMortgages = ltv90To95NumMortgages,
                LTV90To95WACreditScore = ltv90To95WACreditScore,
                LTV90To95PrincipalBalance = ltv90To95PrincipalBalance,
                LTVPct90To95PortfolioValue = ltvPct90To95PortfolioValue,

                LTV95To100NumMortgages = ltv95To100NumMortgages,
                LTV95To100WACreditScore = ltv95To100WACreditScore,
                LTV95To100PrincipalBalance = ltv95To100PrincipalBalance,
                LTVPct95To100PortfolioValue = ltvPct95To100PortfolioValue,

                LTVAbove100NumMortgages = ltvAbove100NumMortgages,
                LTVAbove100WACreditScore = ltvAbove100WACreditScore,
                LTVAbove100PrincipalBalance = ltvAbove100PrincipalBalance,
                LTVPctAbove100PortfolioValue = ltvPctAbove100PortfolioValue,

                OverThresholdLTVBelowThreshodBeaconScoreNumMortgages = overThresholdLTVBelowThreshodBeaconScoreNumMortgages,
                OverThresholdLTVBelowThreshodBeaconScoreWACreditScore = overThresholdLTVBelowThreshodBeaconScoreWACreditScore,
                OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance = overThresholdLTVBelowThreshodBeaconScorePrincipalBalance,
                OverThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast = overThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast,
                OverThresholdLTVBelowThreshodBeaconScoreWACreditScorePast = overThresholdLTVBelowThreshodBeaconScoreWACreditScorePast,
                OverThresholdLTVBelowThreshodBeaconScorePrincipalBalancePast = overThresholdLTVBelowThreshodBeaconScorePrincipalBalancePast,
                OverThresholdLTVBelowThreshodBeaconScoreLoanAccountNumbers = overThresholdLTVBelowThreshodBeaconScoreLoanAccountNumbers,

                OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages = overThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages,
                OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore = overThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore,
                OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance = overThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance,
                OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast = overThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast,
                OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScorePast = overThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScorePast,
                OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalancePast = overThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalancePast,
                OverThresholdLTVBelowThreshodBeaconScoreOutsideGTALoanAccountNumbers = overThresholdLTVBelowThreshodBeaconScoreOutsideGTALoanAccountNumbers,
            };
        }

        public async Task<BBCReportModel> GetLoanDetailsForBBCSummary(DateTime? endDate)
        {
            _logger.LogInformation($"Calling: ReportService.GetLoanDetailsForBBCSummary(): End Date, {endDate}\n");

            return await GetLoanDataForBBCExcelReportHelper(endDate);
        }

        public async Task<BBCReportModel> GetLoanDataForBBCExcelReport(DateTime? endDate)
        {
            _logger.LogInformation($"Calling: ReportService.GetLoanDataForBBCExcelReport(): End Date, {endDate}\n");

            return await GetLoanDataForBBCExcelReportHelper(endDate, excelExport: true);
        }

        private async Task<BBCReportModel> GetLoanDataForBBCExcelReportHelper(DateTime? endDate, bool excelExport = false)
        {
            IEnumerable<TdsLoan> Loans = await _loanService.GetActiveLoans(endDate); // Get all active closed loans
            IEnumerable<TdsCoBorrower> coBorrowerList = await _loanService.GetCoBorrowers();
            IEnumerable<TdsProperty> propertyList = await _loanService.GetProperties();
            IEnumerable<TdsLien> lienList = await _loanService.GetLiens();
            IEnumerable<UdfValue> customFieldsValueList = await _loanService.GetUserDefinedFieldsByParentID();
            IEnumerable<UdfValue> lessorAppraisedValueorPurchasePriceCustomFieldsValueList = customFieldsValueList.Where(v => v.ParentRecId == LessorAppraisedValueorPurchasePriceParentRecId);
            IEnumerable<TdsPostalCode> GTAPostalCodes = await _postalCodeRepository.FindAsync(p => p.MortgageRegion == MortgageRegion.GTA.ToDescription());

            IEnumerable<UdfValue> QualifiedAmountUDFValues = await _loanService.GetUserDefinedFieldsByParentID(QualifiedAmountParentRecId);
            
            BBCReportModel BBCReportData = new BBCReportModel();
            BBCReportData.PrincipalBalanceTotal = (decimal)Loans.Sum(l => l.PrinBal);

            List<Action> getLoansByCategoryActions = new List<Action>
            {
                () => BBCReportData.OwnerOccupied1stMortgagesLTVLessThan50GTA = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans,
                                                                                                                                                LoanFilterType.OwnerOccupied1stMortgagesLTVLessThan50GTA, endDate, null, GTAPostalCodes, propertyList, lienList, lessorAppraisedValueorPurchasePriceCustomFieldsValueList),
                                                                                                                                                coBorrowerList, propertyList, lienList, customFieldsValueList, true),
                () => BBCReportData.OwnerOccupied1stMortgagesOther = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans,
                                                                                                                                     LoanFilterType.OwnerOccupied1stMortgagesOther, endDate, null, GTAPostalCodes, propertyList, lienList, lessorAppraisedValueorPurchasePriceCustomFieldsValueList),
                                                                                                                                     coBorrowerList, propertyList, lienList, customFieldsValueList, true),
                () => BBCReportData.OwnerOccupied2ndMortgages = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.OwnerOccupied2ndMortgages, endDate), coBorrowerList, propertyList, lienList, customFieldsValueList),
                () => BBCReportData.NonOwnerOccupied1stMortgages = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.NonOwner1stMortgages, endDate), coBorrowerList, propertyList, lienList, customFieldsValueList, true),
                () => BBCReportData.Commercial1stMortgages = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.Commercial1stMortgages, endDate), coBorrowerList, propertyList, lienList, customFieldsValueList, true)
            };

            if (excelExport)
            {
                getLoansByCategoryActions.Add(() => BBCReportData.FirstMortgages = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.FirstMortgage, endDate), coBorrowerList, propertyList, lienList, customFieldsValueList));
                getLoansByCategoryActions.Add(() => BBCReportData.SecondMortgages = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.SecondMortgage, endDate), coBorrowerList, propertyList, lienList, customFieldsValueList));
                getLoansByCategoryActions.Add(() => BBCReportData.ThirdMortgages = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.ThirdMortgage, endDate), coBorrowerList, propertyList, lienList, customFieldsValueList));
                getLoansByCategoryActions.Add(() => BBCReportData.Arrears1stMortgages = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.Arrears1stMortgages, endDate), coBorrowerList, propertyList, lienList, customFieldsValueList));
                getLoansByCategoryActions.Add(() => BBCReportData.Arrears2ndMortgages = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.Arrears2ndMortgages, endDate), coBorrowerList, propertyList, lienList, customFieldsValueList));
                getLoansByCategoryActions.Add(() => BBCReportData.DelinquentMortgages = GetBBCExcelReportData(LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.DelinquentMortgages, endDate), coBorrowerList, propertyList, lienList, customFieldsValueList));
            }

            Parallel.Invoke(getLoansByCategoryActions.ToArray());

            decimal TotalPrincipalBalance = 0;
            decimal TotalQualifiedAmountForOwnerOccupied1stMortgagesLTVLessThan50GTA = 0;
            decimal TotalQualifiedAmountForOwnerOccupied1stMortgagesOther = 0;
            decimal TotalQualifiedAmountForOccupied2ndMortgages = 0;
            decimal TotalQualifiedAmountForNonOwnerOccupied1stMortgages = 0;
            decimal TotalQualifiedAmountForCommercialMortgages = 0;

            Parallel.Invoke(() => TotalPrincipalBalance = (decimal)Loans.Sum(l => l.PrinBal),
                            () => TotalQualifiedAmountForOwnerOccupied1stMortgagesLTVLessThan50GTA = GetTotalQualifiedAmount(BBCReportData.OwnerOccupied1stMortgagesLTVLessThan50GTA, QualifiedAmountUDFValues),
                            () => TotalQualifiedAmountForOwnerOccupied1stMortgagesOther = GetTotalQualifiedAmount(BBCReportData.OwnerOccupied1stMortgagesOther, QualifiedAmountUDFValues),
                            () => TotalQualifiedAmountForOccupied2ndMortgages = GetTotalQualifiedAmount(BBCReportData.OwnerOccupied2ndMortgages, QualifiedAmountUDFValues),
                            () => TotalQualifiedAmountForNonOwnerOccupied1stMortgages = GetTotalQualifiedAmount(BBCReportData.NonOwnerOccupied1stMortgages, QualifiedAmountUDFValues),
                            () => TotalQualifiedAmountForCommercialMortgages = GetTotalQualifiedAmount(BBCReportData.Commercial1stMortgages, QualifiedAmountUDFValues));

            int NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA = 0;
            int NoOfLoansOwnerOccupied1stMortgagesOther = 0;
            int NoOfLoansOwnerOccupied2ndMortgages = 0;
            int NoOfLoansNonOwnerOccupied1stMortgages = 0;
            int NoOfLoansCommercial1stMortgages = 0;

            decimal EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA = 0;
            decimal EligibleAmountOwnerOccupied1stMortgagesOther = 0;
            decimal EligibleAmountOwnerOccupied2ndMortgages = 0;
            decimal EligibleAmountNonOwnerOccupied1stMortgages = 0;
            decimal EligibleAmountCommercial1stMortgages = 0;

            decimal PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA = 0;
            decimal PctOfAUMOwnerOccupied1stMortgagesOther = 0;
            decimal PctOfAUMOwnerOccupied2ndMortgages = 0;
            decimal PctOfAUMNonOwnerOccupied1stMortgages = 0;
            decimal PctOfAUMCommercial1stMortgages = 0;

            decimal EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTAPercent = (decimal).80;
            decimal EligibleAmountOwnerOccupied2ndMortgagesPercent = (decimal).6;
            decimal EligibleAmount1stMortgagesPercent = (decimal).75;
            decimal EligibleAmountCommercial1stMortgagesPercent = (decimal).5;

            Parallel.Invoke(() => NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA = BBCReportData.OwnerOccupied1stMortgagesLTVLessThan50GTA.Count(),
                            () => NoOfLoansOwnerOccupied1stMortgagesOther = BBCReportData.OwnerOccupied1stMortgagesOther.Count(),
                            () => NoOfLoansOwnerOccupied2ndMortgages = BBCReportData.OwnerOccupied2ndMortgages.Count(),
                            () => NoOfLoansNonOwnerOccupied1stMortgages = BBCReportData.NonOwnerOccupied1stMortgages.Count(),
                            () => NoOfLoansCommercial1stMortgages = BBCReportData.Commercial1stMortgages.Count(),
                            
                            () => EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA = EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTAPercent * TotalQualifiedAmountForOwnerOccupied1stMortgagesLTVLessThan50GTA,
                            () => EligibleAmountOwnerOccupied1stMortgagesOther = EligibleAmount1stMortgagesPercent * TotalQualifiedAmountForOwnerOccupied1stMortgagesOther,
                            () => EligibleAmountOwnerOccupied2ndMortgages = Math.Min(GetSiteSetting(_cache, SiteSettingKey.BMOCREDITFACILITYLIMIT.ToString()) * (GetSiteSetting(_cache, SiteSettingKey.BMO2NDMORTGAGELIMITINPERCENT.ToString()) / 100), EligibleAmountOwnerOccupied2ndMortgagesPercent * TotalQualifiedAmountForOccupied2ndMortgages),
                            () => EligibleAmountNonOwnerOccupied1stMortgages = Math.Min(GetSiteSetting(_cache, SiteSettingKey.BMOCREDITFACILITYLIMIT.ToString()) * (GetSiteSetting(_cache, SiteSettingKey.BMONONOWNERMORTGAGELIMITINPERCENT.ToString()) / 100), EligibleAmount1stMortgagesPercent * TotalQualifiedAmountForNonOwnerOccupied1stMortgages),
                            () => EligibleAmountCommercial1stMortgages = Math.Min(GetSiteSetting(_cache, SiteSettingKey.BMOCREDITFACILITYLIMIT.ToString()) * (GetSiteSetting(_cache, SiteSettingKey.BMOCOMMERCIALMORTGAGELIMITINPERCENT.ToString()) / 100), EligibleAmountCommercial1stMortgagesPercent * TotalQualifiedAmountForCommercialMortgages),
                            
                            () => PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA = GetPct(TotalPrincipalBalance, TotalQualifiedAmountForOwnerOccupied1stMortgagesLTVLessThan50GTA),
                            () => PctOfAUMOwnerOccupied1stMortgagesOther = GetPct(TotalPrincipalBalance, TotalQualifiedAmountForOwnerOccupied1stMortgagesOther),
                            () => PctOfAUMOwnerOccupied2ndMortgages = GetPct(TotalPrincipalBalance, TotalQualifiedAmountForOccupied2ndMortgages),
                            () => PctOfAUMNonOwnerOccupied1stMortgages = GetPct(TotalPrincipalBalance, TotalQualifiedAmountForNonOwnerOccupied1stMortgages),
                            () => PctOfAUMCommercial1stMortgages = GetPct(TotalPrincipalBalance, TotalQualifiedAmountForCommercialMortgages));

            // *** BORROWING BASE CERTIFICATE ***
            // Owner Occupied - 1st Mortgages - LTV < 50% GTA
            BBCReportData.NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA = NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA;
            BBCReportData.EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA = EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA;
            BBCReportData.QualifiedAmountOwnerOccupied1stMortgagesLTVLessThan50GTA = TotalQualifiedAmountForOwnerOccupied1stMortgagesLTVLessThan50GTA;
            BBCReportData.PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA = PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA;

            // Owner Occupied - 1st Mortgages - Other
            BBCReportData.NoOfLoansOwnerOccupied1stMortgagesOther = NoOfLoansOwnerOccupied1stMortgagesOther;
            BBCReportData.EligibleAmountOwnerOccupied1stMortgagesOther = EligibleAmountOwnerOccupied1stMortgagesOther;
            BBCReportData.QualifiedAmountOwnerOccupied1stMortgagesOther = TotalQualifiedAmountForOwnerOccupied1stMortgagesOther;
            BBCReportData.PctOfAUMOwnerOccupied1stMortgagesOther = PctOfAUMOwnerOccupied1stMortgagesOther;

            // Owner Occupied - 2nd Mortgages
            BBCReportData.NoOfLoansOwnerOccupied2ndMortgages = NoOfLoansOwnerOccupied2ndMortgages;
            BBCReportData.EligibleAmountOwnerOccupied2ndMortgages = EligibleAmountOwnerOccupied2ndMortgages;
            BBCReportData.QualifiedAmountOwnerOccupied2ndMortgages = TotalQualifiedAmountForOccupied2ndMortgages;
            BBCReportData.PctOfAUMOwnerOccupied2ndMortgages = PctOfAUMOwnerOccupied2ndMortgages;

            // Non Owner Occupied - 1st Mortgages
            BBCReportData.NoOfLoansNonOwnerOccupied1stMortgages = NoOfLoansNonOwnerOccupied1stMortgages;
            BBCReportData.EligibleAmountNonOwnerOccupied1stMortgages = EligibleAmountNonOwnerOccupied1stMortgages;
            BBCReportData.QualifiedAmountNonOwnerOccupied1stMortgages = TotalQualifiedAmountForNonOwnerOccupied1stMortgages;
            BBCReportData.PctOfAUMNonOwnerOccupied1stMortgages = PctOfAUMNonOwnerOccupied1stMortgages;

            // Commercial Mortgages
            BBCReportData.NoOfLoansCommercial1stMortgages = NoOfLoansCommercial1stMortgages;
            BBCReportData.EligibleAmountCommercial1stMortgages = EligibleAmountCommercial1stMortgages;
            BBCReportData.QualifiedAmountCommercial1stMortgages = TotalQualifiedAmountForCommercialMortgages;
            BBCReportData.PctOfAUMCommercial1stMortgages = PctOfAUMCommercial1stMortgages;

            return BBCReportData;
        }

        private IEnumerable<BBCExcelExportLoanDataModel> GetBBCExcelReportData(IEnumerable<TdsLoan> loanList,
                                                                                     IEnumerable<TdsCoBorrower> coBorrowerList,
                                                                                     IEnumerable<TdsProperty> propertyList,
                                                                                     IEnumerable<TdsLien> lienList,
                                                                                     IEnumerable<UdfValue> customFieldsValueList,
                                                                                     bool BBCLTV = false)
        {
            IEnumerable<BBCExcelExportLoanDataModel> BBCExcelExportLoanDataList = from loan in loanList
                                                                                  from property in propertyList.Where(p => p.LoanRecId == loan.RecId && (bool)p.Primary)
                                                                                  select new BBCExcelExportLoanDataModel()
                                                                                  {
                                                                                      // Loan Data
                                                                                      RecId = loan.RecId,
                                                                                      Account = loan.Account,
                                                                                      FullName = loan.FullName,
                                                                                      OrigBal = loan.OrigBal,
                                                                                      PrinBal = loan.PrinBal,
                                                                                      NoteRate = loan.NoteRate,
                                                                                      ClosingDate = loan.ClosingDate,
                                                                                      MaturityDate = loan.MaturityDate,
                                                                                      Priority = loan.Priority,
                                                                                      Documentation = loan.Documentation,

                                                                                      // Co Borrowers
                                                                                      OtherBorrwers = String.Join(" & ", coBorrowerList.Where(cb => cb.LoanRecId == loan.RecId).Select(cb => cb.FullName)),

                                                                                      // Property Details
                                                                                      PropertyType = property.PropertyType,
                                                                                      PropertyOccupancy = property.Occupancy,
                                                                                      PropertyCounty = property.County,
                                                                                      PropertyCity = property.City,
                                                                                      PropertyAddress = String.Join(" & ", _loanService.GetActiveProperties(propertyList, loan).Select(p => p.Street + ", " + p.City + ", " + p.State + " " + p.ZipCode)),
                                                                                      AggregateAppraiserFmv = propertyList.Where(p => p.LoanRecId == loan.RecId).Sum(p => p.AppraiserFmv),
                                                                                      PropertyCategory = GetPropertyCategory(property.PropertyType),

                                                                                      // Liens
                                                                                      AggregateSeniorLiens = lienList.Where(l => l.LoanRecId == loan.RecId).Sum(l => l.Current),

                                                                                      // Custom Fields
                                                                                      CreditScore = _loanService.GetCustomValue(customFieldsValueList, loan, CreditScoreParentRecId),
                                                                                      LessorOfTheAppraisalValueorPurchasePrice = _loanService.GetCustomValue(customFieldsValueList, loan, LessorAppraisedValueorPurchasePriceParentRecId),
                                                                                      LoanTerms = _loanService.GetCustomValue(customFieldsValueList, loan, LoanTermsParentRecId),
                                                                                      RenewalOrRefinanceDate = _loanService.GetCustomValue(customFieldsValueList, loan, RenewalOrRefinanceDateParentRecId),
                                                                                      LegalDescription = _loanService.GetCustomValue(customFieldsValueList, loan, LegalDescriptionParentRecId),
                                                                                      PinNumber = _loanService.GetCustomValue(customFieldsValueList, loan, PINNumberParentRecId),

                                                                                     // Calculated
                                                                                     QualifiedAmount = _loanService.GetCalculatedQualifiedAmount(loan,
                                                                                                                _loanService.GetCustomValue(customFieldsValueList, loan, LessorAppraisedValueorPurchasePriceParentRecId),
                                                                                                                property,
                                                                                                                lienList.Where(l => l.LoanRecId == loan.RecId && l.PropRecId == property.RecId).FirstOrDefault(),
                                                                                                                _loanService.GetTotalQualifiedOfPreviousLoansForSameSIN(loan,loanList, customFieldsValueList.Where(v => v.ParentRecId == QualifiedAmountParentRecId), coBorrowerList)),
                                                                                     TermsLeft = LoanFilterService.GetTermsLeft(loan),
                                                                                     CalculatedLtv = LoanFilterService.GetCalculatedLTV(loan, propertyList.Where(p => p.LoanRecId == loan.RecId), lienList.Where(l => l.LoanRecId == loan.RecId), _loanService.GetCustomValue(customFieldsValueList, loan, LessorAppraisedValueorPurchasePriceParentRecId), BBCLTV)
                                                                                  };
            return BBCExcelExportLoanDataList;
        }
        
        private static decimal GetTotalQualifiedAmount(IEnumerable<BBCExcelExportLoanDataModel> LoansList, IEnumerable<UdfValue> QualifiedAmountUDFValuesList)
        {
            var joinedList = from loan in LoansList
                             join qualifiedAmount in QualifiedAmountUDFValuesList
                                  on loan.RecId equals qualifiedAmount.OwnerRecId
                             select new
                             {
                                loan.RecId,
                                loan.Documentation,
                                qualifiedAmount.Value
                             };

            return joinedList.Sum(v => v.Value.ToDecimal());
        }

        private PropertyCategory GetPropertyCategory(string propertyType)
        {
            PropertyCategory result;

            if (propertyType == PropertyType.SFRCMADetached.ToDescription() ||
                propertyType == PropertyType.SFRCADetached.ToDescription() ||
                propertyType == PropertyType.SFRCMASemiDetached.ToDescription() ||
                propertyType == PropertyType.SFRCMARowHousing.ToDescription() ||
                propertyType == PropertyType.SFRCARowHousing.ToDescription())
            {
                result = PropertyCategory.Residential;
            }
            else if (propertyType == PropertyType.SFRCMACondo.ToDescription())
            {
                result = PropertyCategory.Condo;
            }
            else if (propertyType == PropertyType.Land.ToDescription())
            {
                result = PropertyCategory.Land;
            }
            else if (propertyType == PropertyType.CACommercial.ToDescription() ||
                    propertyType == PropertyType.CMACommercial.ToDescription())
            {
                result = PropertyCategory.Commercial;
            }
            else if (propertyType == PropertyType.SFRCMAConstruction.ToDescription())
            {
                result = PropertyCategory.Construction;
            }
            else
            {
                result = PropertyCategory.Uncategorized;
            }

            return result;
        }

    }
}