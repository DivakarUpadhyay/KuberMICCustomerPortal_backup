using System;

namespace KuberMICManager.Core.Domain.ReportModels
{
    public class StressTestReportModel
    {
        // Site Settings
        public int Level1MarketDeclineLimit { get; set; }
        public int Level2MarketDeclineLimit { get; set; }
        public int Level3MarketDeclineLimit { get; set; }
        public int LiquidationCostInCentsPerDollar { get; set; }
        public int ProjectedLoanLossReserve { get; set; }
        public int SubordinatedSharesValue { get; set; }
        public int AtRiskBeaconScoreThreshold { get; set; }
        public int AtRiskLTVThreshold { get; set; }
        public DateTime Level4AppraisalDateLimit { get; set; }

        // Level Data
        public StressTestLevelDataModel Level1StressTestData { get; set; }
        public StressTestLevelDataModel Level2StressTestData { get; set; }
        public StressTestLevelDataModel Level3StressTestData { get; set; }
        public StressTestLevelDataModel Level4StressTestData { get; set; }

        // *** Value at Risk Liquidation *** //
        public decimal GetPCTChange(decimal current, decimal past)
        {
            decimal pctChange = 0;

            if (past > 0)
                pctChange = current / past - 1;

            return pctChange;
        }

        public decimal GetLiquidationValue(decimal OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance)
        {
            return OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance * LiquidationCostInCentsPerDollar / 100;
        }

        public decimal GetProjectedLossAmount(decimal OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance)
        {
            return GetLiquidationValue(OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance) - OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance;
        }

        public decimal GetSubordinatedShareLoss(decimal OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance)
        {
            decimal subordinatedShareLoss = -1 * GetProjectedLossAmount(OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance) - ProjectedLoanLossReserve;

            return subordinatedShareLoss > SubordinatedSharesValue ? SubordinatedSharesValue : subordinatedShareLoss;
        }

        public decimal? GetPortfolioExposure(decimal OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance)
        {
            decimal GetPortfolioExposure = -1 * GetProjectedLossAmount(OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance) - ProjectedLoanLossReserve - GetSubordinatedShareLoss(OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance);

            if (GetPortfolioExposure > 0)
                return GetPortfolioExposure;
            else
                return null;
        }
    }
}