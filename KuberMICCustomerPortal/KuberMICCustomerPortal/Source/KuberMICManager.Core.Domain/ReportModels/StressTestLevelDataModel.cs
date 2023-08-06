namespace KuberMICManager.Core.Domain.ReportModels
{
    public class StressTestLevelDataModel
    {
        // *** Level Stats *** //
        // # of Mortgages
        public int LTV0To80NumMortgages { get; set; } // 0% - 80%
        public int LTV80To90NumMortgages { get; set; } // 80% - 90%
        public int LTV90To95NumMortgages { get; set; } // Above 90% - 95%
        public int LTV95To100NumMortgages { get; set; } // Above 95% - 100%
        public int LTVAbove100NumMortgages { get; set; } // Above 100%

        // Weighted Aaverage Credit Score
        public decimal LTV0To80WACreditScore { get; set; } // 0.0% - 80%
        public decimal LTV80To90WACreditScore { get; set; } // 80.1% - 90%
        public decimal LTV90To95WACreditScore { get; set; } // Above 90.1% - 95%
        public decimal LTV95To100WACreditScore { get; set; } // Above 95.1% - 100%
        public decimal LTVAbove100WACreditScore { get; set; } // Above 100%

        // Value of Portfolio (%)
        public decimal LTVPct0To80PortfolioValue { get; set; } // 0.0% - 80%
        public decimal LTVPct80To90PortfolioValue { get; set; } // 80.1% - 90%
        public decimal LTVPct90To95PortfolioValue { get; set; } // Above 90.1% - 95%
        public decimal LTVPct95To100PortfolioValue { get; set; } // Above 95.1% - 100%
        public decimal LTVPctAbove100PortfolioValue { get; set; } // Above 100%

        // Principal Balance ($)
        public decimal LTV0To80PrincipalBalance { get; set; } // 0.0% - 80%
        public decimal LTV80To90PrincipalBalance { get; set; } // 80.1% - 90%
        public decimal LTV90To95PrincipalBalance { get; set; } // Above 90.1% - 95%
        public decimal LTV95To100PrincipalBalance { get; set; } // Above 95.1% - 100%
        public decimal LTVAbove100PrincipalBalance { get; set; } // Above 100%

        // *** Analysis *** //
        // Over Threshold LTV and Below Threshod Beacon Score
        public int OverThresholdLTVBelowThreshodBeaconScoreNumMortgages { get; set; }
        public decimal OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance { get; set; }
        public decimal OverThresholdLTVBelowThreshodBeaconScoreWACreditScore { get; set; }
        public int OverThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast { get; set; }
        public decimal OverThresholdLTVBelowThreshodBeaconScorePrincipalBalancePast { get; set; }
        public decimal OverThresholdLTVBelowThreshodBeaconScoreWACreditScorePast { get; set; }
        public string OverThresholdLTVBelowThreshodBeaconScoreLoanAccountNumbers { get; set; }

        // Over Threshold LTV, Below Threshod Beacon Score and Outside GTA 
        public int OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages { get; set; }
        public decimal OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance { get; set; }
        public decimal OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore { get; set; }
        public int OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast { get; set; }
        public decimal OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalancePast { get; set; }
        public decimal OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScorePast { get; set; }
        public string OverThresholdLTVBelowThreshodBeaconScoreOutsideGTALoanAccountNumbers { get; set; }

        public int GetTotalNumMortgages()
        {
            return LTV0To80NumMortgages + LTV80To90NumMortgages + LTV90To95NumMortgages + LTV95To100NumMortgages + LTVAbove100NumMortgages;
        }

        public decimal GetTotalPctPortfolioValue()
        {
            return LTVPct0To80PortfolioValue + LTVPct80To90PortfolioValue + LTVPct90To95PortfolioValue + LTVPct95To100PortfolioValue + LTVPctAbove100PortfolioValue;
        }

        public decimal GetTotalPrincipalBalance() {
            return LTV0To80PrincipalBalance + LTV80To90PrincipalBalance + LTV90To95PrincipalBalance + LTV95To100PrincipalBalance + LTVAbove100PrincipalBalance;
        }

        public decimal GetAverageLoanAmount(decimal PrincipalBalance, int NumMortgages)
        {
            decimal averageLoanAmount = 0;

            if (NumMortgages > 0)
                averageLoanAmount = PrincipalBalance / NumMortgages;

            return averageLoanAmount;
        }
    }
}