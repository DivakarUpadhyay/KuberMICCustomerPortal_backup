using KuberMICManager.Core.Domain.ReportModels;
using KuberMICManager.Core.Domain.ViewModels;
using System;
using System.IO;
using System.Text;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Client.WebUI.Utility
{
    public static class TemplateGenerator
    {
        public static string GetMortgageRateCalculationHTMLString(MortgageRateCalculatorModel mortgageRateCalculatorModel)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"<html>
                                <head>
                                    <style>{0}</style>
                                </head>
                                <body>
                                    <main>
                                        <div class='container'>
                                            <div class='page-title-container'>
                                                <div class='row'>
                                                    <div class='col-12'>
                                                        <h1 class='display-4'><br>Kuber MIC - Mortgage Rate Calculator</h1>
                                                    </div>
                                                </div>
                                            </div>", File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\css", "template-styles.css")));

            sb.Append(GetRateCalculatorTables(mortgageRateCalculatorModel));

            sb.Append(@"
                                        </div>
                                    </main>
                                </body>
                            </html>");

            return sb.ToString();
        }

        private static string GetRateCalculatorTables(MortgageRateCalculatorModel mortgageRateCalculatorModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<div class='row'>");

            sb.AppendFormat(@"<table>
                                <thead>
                                    <tr>
                                        <th class='text-left'>BMO Residential Maximum Limit per Loan</th>
                                        <th class='text-left'>BMO Qualified Amount LTV Limit</th>
                                        <th class='text-end'>BMO Rate Prime Rate</th> 
                                        <th class='text-end'>Spread </th>
                                        <th class='text-end'>BBC Rate</th>
                                        <th class='text-end'>Class A - Preferred Shares Target Rate</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class='text-left'>{0}</td>
                                        <td class='text-end'>{1}</td>
                                        <td class='text-end'>{2}</td>
                                        <td class='text-end'>{3}</td>
                                        <td class='text-end'>{4}</td>
                                        <td class='text-end'>{5}</td>
                                    </tr>
                                </tbody>
                            </table><br>",
                            String.Format("${0:n2}", mortgageRateCalculatorModel.BMOResidentialLMaxLimitPerLoan),
                            String.Format("{0:n2}%", mortgageRateCalculatorModel.BMOQualifiedAmountLTVLimitInPercent),
                            String.Format("{0:n2}%", mortgageRateCalculatorModel.BMOPrimeInterstRate), 
                            String.Format("{0:n2}%", mortgageRateCalculatorModel.BMOSpread),
                            String.Format("{0:n2}%", mortgageRateCalculatorModel.GetBBCRate()),
                            String.Format("{0:n2}%", mortgageRateCalculatorModel.PreferredSharesTargetRateClassA));


            sb.Append(@" </div>");

            sb.AppendFormat(@"<table>
                                <thead>
                                    <tr>
                                        <th class='text-left'>Description</th>
                                        <th class='text-end'>Value</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class='text-left'>Mortgage Type</td>
                                        <td class='text-end'>{0}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>Purchase Price</td>
                                        <td class='text-end'>{1}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>Appraisal Value</td>
                                        <td class='text-end'>{2}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>LTV </td>
                                        <td class='text-end'>{3}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>Mortgage Amount</td>
                                        <td class='text-end'>{4}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>Qualified Mortgage Amount</td>
                                        <td class='text-end'>{5}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>Eligible Mortgage Amount</td>
                                        <td class='text-end'>{6}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>Ineligible Mortgage Amount</td>
                                        <td class='text-end'>{7}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>Effective Cost of Capital</td>
                                        <td class='text-end'>{8}</td>
                                    </tr>
                                </tbody>
                            </table>",
                            mortgageRateCalculatorModel.MortgageIsPurchase ? "Purchase" : "Refinance",
                            mortgageRateCalculatorModel.MortgageIsPurchase ? String.Format("${0:n2}", mortgageRateCalculatorModel.PurchasePrice) : "N/A",
                            String.Format("${0:n2}", mortgageRateCalculatorModel.AppraisalValue),
                            String.Format("{0:n0}%", mortgageRateCalculatorModel.LTV),
                            String.Format("${0:n2}", mortgageRateCalculatorModel.GetActualMortgageAmount()),
                            String.Format("${0:n2}", mortgageRateCalculatorModel.GetQualifiedMortgageAmount()),
                            String.Format("${0:n2}", mortgageRateCalculatorModel.GetEligibleMortgageAmount()),
                            String.Format("${0:n2}", mortgageRateCalculatorModel.GetIneligibleMortgageAmount()),
                            String.Format("{0:n3}%", mortgageRateCalculatorModel.GetEffectiveCostOfCapital()));

            sb.Append(@" </div>");

            return sb.ToString();
        }

        public static string GetStressTestHTMLString(StressTestReportModel stressTestReportModel)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"<html>
                                <head>
                                    <style>{0}</style>
                                </head>
                                <body>
                                    <main>
                                        <div class='container'>
                                            <div class='page-title-container'>
                                                <div class='row'>
                                                    <div class='col-12'>
                                                        <h1 class='display-4'><br>Kuber MIC - Portfolio Stress Test Report</h1>
                                                    </div>
                                                </div>
                                            </div>", File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\css", "template-styles.css")));

            sb.Append(GetStressTestLevelTable(stressTestReportModel, StressTestLevel.LevelOne));
            sb.Append(GetStressTestLevelTable(stressTestReportModel, StressTestLevel.LevelTwo));
            sb.Append(@"<br><br><br>");
            sb.Append(GetStressTestLevelTable(stressTestReportModel, StressTestLevel.LevelThree));
            sb.Append(GetStressTestLevelTable(stressTestReportModel, StressTestLevel.LevelFour));

            sb.Append(@"
                                    </div>
                                </main>
                            </body>
                        </html>");

            return sb.ToString();
        }

        private static string GetStressTestLevelTable(StressTestReportModel stressTestReportModel, StressTestLevel stressTestLevel)
        {
            StringBuilder sb = new StringBuilder();
            StressTestLevelDataModel stressTestLevelData = null;
            sb.Append(@"<div class='row'>");

            if (stressTestLevel == StressTestLevel.LevelOne)
            {
                stressTestLevelData = stressTestReportModel.Level1StressTestData;
                sb.AppendFormat(@"<h2 class='small-title'>Level 1 - Market Decline of by {0}%</h2>", stressTestReportModel.Level1MarketDeclineLimit);
            }
            else if (stressTestLevel == StressTestLevel.LevelTwo)
            {
                stressTestLevelData = stressTestReportModel.Level2StressTestData;
                sb.AppendFormat(@"<h2 class='small-title'>Level 2 - Market Decline of by {0}%</h2>", stressTestReportModel.Level2MarketDeclineLimit);
            }
            else if (stressTestLevel == StressTestLevel.LevelThree)
            {
                stressTestLevelData = stressTestReportModel.Level3StressTestData;
                sb.AppendFormat(@"<h2 class='small-title'>Level 3 - Market Decline of by {0}%</h2>", stressTestReportModel.Level3MarketDeclineLimit);
            }
            else if (stressTestLevel == StressTestLevel.LevelFour)
            {
                stressTestLevelData = stressTestReportModel.Level4StressTestData;
                sb.AppendFormat(@"<h2 class='small-title'>Level 4 - Market Decline of by {0}% (Appraisals are aged as of {1})</h2>", stressTestReportModel.Level3MarketDeclineLimit, @String.Format("{0:MMM dd, yyyy}", stressTestReportModel.Level4AppraisalDateLimit));
            }

            if (stressTestLevel != StressTestLevel.LevelFour) // L4StressTest does not have these
            {
                sb.AppendFormat(@"<table>
                                <thead>
                                    <tr>
                                        <th class='text-left'>LTV after Correction</th>
                                        <th>No of Mortgages</th>
                                        <th>Weighted Beacon Score</th>
                                        <th class='text-end'>Average Loan Amount</th> 
                                        <th class='text-end'>Principal Balance</th>
                                        <th class='text-end'>Value of Portfolio</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class='text-left'>0% - 80%</td>
                                        <td>{0}</td>
                                        <td>{1}</td>
                                        <td class='text-end'>{2}</td>
                                        <td class='text-end'>{3}</td>
                                        <td class='text-end'>{4}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>80% - 90%</td>
                                        <td>{5}</td>
                                        <td>{6}</td>
                                        <td class='text-end'>{7}</td>
                                        <td class='text-end'>{8}</td>
                                        <td class='text-end'>{9}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>90% - 95%</td>
                                        <td>{10}</td>
                                        <td>{11}</td>
                                        <td class='text-end'>{12}</td>
                                        <td class='text-end'>{13}</td>
                                        <td class='text-end'>{14}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>95% - 100%</td>
                                        <td>{15}</td>
                                        <td>{16}</td>
                                        <td class='text-end'>{17}</td>
                                        <td class='text-end'>{18}</td>
                                        <td class='text-end'>{19}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>Above 100%</td>
                                        <td>{20}</td>
                                        <td>{21}</td>
                                        <td class='text-end'>{22}</td>
                                        <td class='text-end'>{23}</td>
                                        <td class='text-end'>{24}</td>
                                    </tr>
                                    <tr>
                                        <td class='text-left'>Total</td>
                                        <td>{25}</td>
                                        <td>-</td>
                                        <td class='text-end'>-</td>
                                        <td class='text-end'>{26}</td>
                                        <td class='text-end'>{27}</td>
                                    </tr>
                                </tbody>
                            </table>",
                            stressTestLevelData.LTV0To80NumMortgages,
                            String.Format("{0:n2}", stressTestLevelData.LTV0To80WACreditScore),
                            @String.Format("${0:n2}", stressTestLevelData.GetAverageLoanAmount(stressTestLevelData.LTV0To80PrincipalBalance, stressTestLevelData.LTV0To80NumMortgages)),
                            @String.Format("${0:n2}", stressTestLevelData.LTV0To80PrincipalBalance),
                            @String.Format("{0:n2}%", stressTestLevelData.LTVPct0To80PortfolioValue),

                            stressTestLevelData.LTV80To90NumMortgages,
                            @String.Format("{0:n2}", stressTestLevelData.LTV80To90WACreditScore),
                            @String.Format("${0:n2}", stressTestLevelData.GetAverageLoanAmount(stressTestLevelData.LTV80To90PrincipalBalance, stressTestLevelData.LTV80To90NumMortgages)),
                            @String.Format("${0:n2}", stressTestLevelData.LTV80To90PrincipalBalance),
                            @String.Format("{0:n2}%", stressTestLevelData.LTVPct80To90PortfolioValue),

                            stressTestLevelData.LTV90To95NumMortgages,
                            @String.Format("{0:n2}", stressTestLevelData.LTV90To95WACreditScore),
                            @String.Format("${0:n2}", stressTestLevelData.GetAverageLoanAmount(stressTestLevelData.LTV90To95PrincipalBalance, stressTestLevelData.LTV90To95NumMortgages)),
                            @String.Format("${0:n2}", stressTestLevelData.LTV90To95PrincipalBalance),
                            @String.Format("{0:n2}%", stressTestLevelData.LTVPct90To95PortfolioValue),

                            stressTestLevelData.LTV95To100NumMortgages,
                            @String.Format("{0:n2}", stressTestLevelData.LTV95To100WACreditScore),
                            @String.Format("${0:n2}", stressTestLevelData.GetAverageLoanAmount(stressTestLevelData.LTV95To100PrincipalBalance, stressTestLevelData.LTV95To100NumMortgages)),
                            @String.Format("${0:n2}", stressTestLevelData.LTV95To100PrincipalBalance),
                            @String.Format("{0:n2}%", stressTestLevelData.LTVPct95To100PortfolioValue),

                            stressTestLevelData.LTVAbove100NumMortgages,
                            @String.Format("{0:n2}", stressTestLevelData.LTVAbove100WACreditScore),
                            @String.Format("${0:n2}", stressTestLevelData.GetAverageLoanAmount(stressTestLevelData.LTVAbove100PrincipalBalance, stressTestLevelData.LTVAbove100NumMortgages)),
                            @String.Format("${0:n2}", stressTestLevelData.LTVAbove100PrincipalBalance),
                            @String.Format("{0:n2}%", stressTestLevelData.LTVPctAbove100PortfolioValue),

                            stressTestLevelData.GetTotalNumMortgages(),
                            @String.Format("${0:n2}", stressTestLevelData.GetTotalPrincipalBalance()),
                            @String.Format("{0:n2}%", stressTestLevelData.GetTotalPctPortfolioValue()));
            }

            // Risk Analysis Start
            if(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgages > 0 || stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages > 0)
            {
                sb.AppendFormat(@"<h3 class='small-title'>Risk Analysis - Over {0}% LTV, Below {1} Beacon Score</h3>", stressTestReportModel.AtRiskLTVThreshold, stressTestReportModel.AtRiskBeaconScoreThreshold);
                sb.Append(@"<h4 class=""text-muted small-title"">All Regions</h4>");

                decimal over100Below650AveragePrincipalBalance = stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgages > 0 ? stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance / stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgages : 0;
                decimal over100Below650AveragePrincipalBalancePast = stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast > 0 ? stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalancePast / stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast : 0;

                sb.AppendFormat(@"
                                <table>
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th class='text-end'>Current</th>
                                            <th class='text-end'>% Change</th>
                                            <th class='text-end'>Last Month</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class='text-left'>Number of Loans</td>
                                            <td class='text-end'>{0}</td>
                                            <td class='text-end'>{1}</td>
                                            <td class='text-end'>{2}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Total Balance</td>
                                            <td class='text-end'>{3}</td>
                                            <td class='text-end'>{4}</td>
                                            <td class='text-end'>{5}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Average Loan Amount</td>
                                            <td class='text-end'>{6}</td>
                                            <td class='text-end'>{7}</td>
                                            <td class='text-end'>{8}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Weighted Average Beacon Score</td>
                                            <td class='text-end'>{9}</td>
                                            <td class='text-end'>{10}</td>
                                            <td class='text-end'>{11}</td>
                                        </tr>
                                    </tbody>
                                </table>",
                                stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgages,
                                String.Format("{0:n2}%", stressTestReportModel.GetPCTChange(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgages, stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast)),
                                stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreNumMortgagesPast,

                                String.Format("${0:n2}", stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance),
                                String.Format("{0:n2}%", stressTestReportModel.GetPCTChange(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance, stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalancePast)),
                                String.Format("${0:n2}", stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalancePast),

                                String.Format("${0:n2}", over100Below650AveragePrincipalBalance),
                                String.Format("{0:n2}%", stressTestReportModel.GetPCTChange(over100Below650AveragePrincipalBalance, over100Below650AveragePrincipalBalancePast)),
                                String.Format("${0:n2}", over100Below650AveragePrincipalBalancePast),

                                String.Format("{0:n2}", stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreWACreditScore),
                                String.Format("{0:n2}%", stressTestReportModel.GetPCTChange(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreWACreditScore, stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreWACreditScorePast)),
                                String.Format("{0:n2}", stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreWACreditScorePast));

                decimal over100Below650OutsideGTAAveragePrincipalBalance = stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages > 0 ? stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance / stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages : 0;
                decimal over100Below650OutsideGTAAveragePrincipalBalancePast = stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast > 0 ? stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalancePast / stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast : 0;

                sb.Append(@"<h4 class=""text-muted small-title"">Outside GTA</h4>");
                sb.AppendFormat(@"
                                <table>
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th class='text-end'>Current</th>
                                            <th class='text-end'>% Change</th>
                                            <th class='text-end'>Last Month</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class='text-left'>Number of Loans</td>
                                            <td class='text-end'>{0}</td>
                                            <td class='text-end'>{1}</td>
                                            <td class='text-end'>{2}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Total Balance</td>
                                            <td class='text-end'>{3}</td>
                                            <td class='text-end'>{4}</td>
                                            <td class='text-end'>{5}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Average Loan Amount</td>
                                            <td class='text-end'>{6}</td>
                                            <td class='text-end'>{7}</td>
                                            <td class='text-end'>{8}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Weighted Average Beacon Score</td>
                                            <td class='text-end'>{9}</td>
                                            <td class='text-end'>{10}</td>
                                            <td class='text-end'>{11}</td>
                                        </tr>
                                    </tbody>
                                </table>",
                                stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages,
                                String.Format("{0:n2}%", stressTestReportModel.GetPCTChange(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgages, stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast)),
                                stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTANumMortgagesPast,

                                String.Format("${0:n2}", stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance),
                                String.Format("{0:n2}%", stressTestReportModel.GetPCTChange(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalance, stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalancePast)),
                                String.Format("${0:n2}", stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAPrincipalBalancePast),

                                String.Format("${0:n2}", over100Below650OutsideGTAAveragePrincipalBalance),
                                String.Format("{0:n2}%", stressTestReportModel.GetPCTChange(over100Below650OutsideGTAAveragePrincipalBalance, over100Below650OutsideGTAAveragePrincipalBalancePast)),
                                String.Format("${0:n2}", over100Below650OutsideGTAAveragePrincipalBalancePast),

                                String.Format("{0:n2}", stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore),
                                String.Format("{0:n2}%", stressTestReportModel.GetPCTChange(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScore, stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScorePast)),
                                String.Format("{0:n2}", stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAWACreditScorePast));

                decimal? portfolioExposure = stressTestReportModel.GetPortfolioExposure(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance);

                sb.Append(@"<h4 class=""text-muted small-title"">Value at Risk Liquidation</h4>");
                sb.AppendFormat(@"
                                <table>
                                    <tbody>
                                        <tr>
                                            <td class='text-left'>Value at Risk</td>
                                            <td class='text-end'>{0}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Liquidation - {1}c/$</td>
                                            <td class='text-end'>{2}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Projected Loss</td>
                                            <td class='text-end'>{3}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Projected Loan Loss Reserve</td>
                                            <td class='text-end'>{4}</td>
                                        </tr>
                                        <tr>
                                            <td class='text-left'>Subordinated Share Loss</td>
                                            <td class='text-end'>{5}</td>
                                        </tr>
                                        <tr  class='{6}'>
                                            <td class='text-left'>Portfolio Exposure</td>
                                            <td class='text-end'>{7}</td>
                                        </tr>
                                    </tbody>
                                </table>",
                                String.Format("${0:n2}", stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance),
                                stressTestReportModel.LiquidationCostInCentsPerDollar,
                                String.Format("${0:n2}", stressTestReportModel.GetLiquidationValue(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance)),
                                String.Format("${0:n2}", stressTestReportModel.GetProjectedLossAmount(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance)),
                                String.Format("${0:n2}", stressTestReportModel.ProjectedLoanLossReserve),
                                String.Format("${0:n2}", stressTestReportModel.GetSubordinatedShareLoss(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance)),
                                portfolioExposure == null ? "bg-success" : "bg-danger",
                                portfolioExposure == null ? "Nil" : @String.Format("${0:n2}", stressTestReportModel.GetPortfolioExposure(stressTestLevelData.OverThresholdLTVBelowThreshodBeaconScorePrincipalBalance)));

            }

            sb.Append(@"</div>
                        <br>");

            return sb.ToString();
        }

        public static string GetDashboardHTMLString(DashboardLoanViewModel dashboardViewModel)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <head>
                                <style>{0}</style>
                            </head>
                            <body> 
                                <main>
                                    <div class='container'>
                                        <div class='page-title-container'>
                                            <div class='row'>
                                                <div class='col-12'>
                                                    <h1 class='display-4'><br>Dashboard</h1>
                                                </div>
                                            </div>
                                        </div>", File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\css", "template-styles.css")));

            sb.Append(GetLoanSummaryByPriorityTable(dashboardViewModel));
            sb.Append(GetWeightedAverageTable(dashboardViewModel));
            sb.Append(GetLoanSummaryByPostalCode(dashboardViewModel));
            sb.Append(GetLoanSummaryByLatePayment(dashboardViewModel));

            sb.Append(GetLoanSummaryByMortgageType(dashboardViewModel));
            sb.Append("<br>");
            sb.Append(GetRemainingTermToMaturitySummaryTable(dashboardViewModel));
            sb.Append(GetPortfolioSummaryByLTV(dashboardViewModel));
            sb.Append(GetPricePerSFByRegion(dashboardViewModel));

            sb.Append(@"
                                        
                                    </div>
                                </main>
                            </body>
                        </html>");

            return sb.ToString();
        }

        private static string GetLoanSummaryByPriorityTable(DashboardLoanViewModel dashboardViewModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                @"<div>
                   <h2 class='small-title'>Mortgage Summary by Mortgage Priority</h2>
                   <table>
                       <thead>
                           <tr>
                               <th class='text-left'>Priority</th>
                               <th>No of Mortgages</th>
                               <th class='text-end'>Average Appraisal</th>
                               <th class='text-end'>Average Loan Amount</th> 
                               <th class='text-end'>Principal Balance</th>
                               <th class='text-end'>% of AUM</th>
                           </tr>
                       </thead>
                       <tbody>
                            <tr>
                                <td class='text-left'>First</td>
                                <td>{0}</td>
                                <td class='text-end'>${1}</td>
                                <td class='text-end'>${2}</td>
                                <td class='text-end'>${3}</td>
                                <td class='text-end'>{4}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Second</td>
                                <td>{5}</td>
                                <td class='text-end'>${6}</td>
                                <td class='text-end'>${7}</td>
                                <td class='text-end'>${8}</td>
                                <td class='text-end'>{9}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Third</td>
                                <td>{10}</td>
                                <td class='text-end'>${11}</td>
                                <td class='text-end'>${12}</td>
                                <td class='text-end'>${13}</td>
                                <td class='text-end'>{14}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Entire Portfolio</td>
                                <td>{15}</td>
                                <td class='text-end'>${16}</td>
                                <td class='text-end'>${17}</td>
                                <td class='text-end'>${18}</td>
                                <td class='text-end'>{19}%</td>
                            </tr>
                       </tbody>
                   </table>
                </div>", 
                dashboardViewModel.NoOfLoansFirst, 
                String.Format("{0:n2}", dashboardViewModel.AverageAppraisalFirst),
                String.Format("{0:n2}", dashboardViewModel.GetAverageLoanAmountFirst()),
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceFirst), 
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMFirst),

                dashboardViewModel.NoOfLoansSecond,
                String.Format("{0:n2}", dashboardViewModel.AverageAppraisalSecond),
                String.Format("{0:n2}", dashboardViewModel.GetAverageLoanAmountSecond()),
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceSecond),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMSecond),

                dashboardViewModel.NoOfLoansThird,
                String.Format("{0:n2}", dashboardViewModel.AverageAppraisalThird),
                String.Format("{0:n2}", dashboardViewModel.GetAverageLoanAmountThird()),
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceThird),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMThird),

                dashboardViewModel.GetTotalNoOfLoansByPriority(),
                String.Format("{0:n2}", dashboardViewModel.AverageAppraisalTotal),
                String.Format("{0:n2}", dashboardViewModel.GetAverageLoanAmountTotal()),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPrincipalBalanceByPriority()),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPctOfAUMByPriority())
            );

            return sb.ToString();
        }

        private static string GetWeightedAverageTable(DashboardLoanViewModel dashboardViewModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                @"<div>
                   <h2 class='small-title'><br>Weighted Average</h2>
                   <table>
                       <thead>
                           <tr>
                               <th class='text-left'>Weighted Average</th>
                               <th class='text-end'>All Mortgages</th>
                               <th class='text-end'>First Mortgages</th>
                               <th class='text-end'>Second Mortgages</th>
                           </tr>
                       </thead>
                       <tbody>
                            <tr>
                                <td class='text-left'>LTV</td>
                                <td class='text-end'>{0}%</td>
                                <td class='text-end'>{1}%</td>
                                <td class='text-end'>{2}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Maturity Months</td>
                                <td class='text-end'>{3}</td>
                                <td class='text-end'>{4}</td>
                                <td class='text-end'>{5}</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Beacon Score</td>
                                <td class='text-end'>{6}</td>
                                <td class='text-end'>{7}</td>
                                <td class='text-end'>{8}</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Interest Rate</td>
                                <td class='text-end'>{9}%</td>
                                <td class='text-end'>{10}%</td>
                                <td class='text-end'>{11}%</td>
                            </tr>
                        </tbody>
                   </table>
                </div>",
                String.Format("{0:n2}", dashboardViewModel.TotalWeightedLTV),
                String.Format("{0:n2}", dashboardViewModel.FirstWeightedLTV),
                String.Format("{0:n2}", dashboardViewModel.SecondlWeightedLTV),

                String.Format("{0:n2}", dashboardViewModel.TotalWeightedMaturityDateInMonths),
                String.Format("{0:n2}", dashboardViewModel.FirstWeightedMaturityDateInMonths),
                String.Format("{0:n2}", dashboardViewModel.SecondlWeightedMaturityDateInMonths),

                String.Format("{0:n2}", dashboardViewModel.TotalWeightedBeaconScore),
                String.Format("{0:n2}", dashboardViewModel.FirstWeightedBeaconScore),
                String.Format("{0:n2}", dashboardViewModel.SecondlWeightedBeaconScore),

                String.Format("{0:n2}", dashboardViewModel.TotalWeightedInterestRate),
                String.Format("{0:n2}", dashboardViewModel.FirstWeightedInterestRate),
                String.Format("{0:n2}", dashboardViewModel.SecondlWeightedInterestRate)
            );

            return sb.ToString();
        }

        private static string GetLoanSummaryByPostalCode(DashboardLoanViewModel dashboardViewModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                @"<div>
                   <h2 class='small-title'><br>Mortgage Summary by Postal Code</h2>
                   <table>
                       <thead>
                           <tr>
                               <th class='text-left'>Mortgage Region</th>
                               <th>No of Mortgages</th>
                               <th class='text-end'>Weighted LTV</th>
                               <th class='text-end'>Weighted Beacon Score</th>
                               <th class='text-end'>Principal Balance</th>
                               <th class='text-end'>% of AUM</th>
                           </tr>
                       </thead>
                       <tbody>
                            <tr>
                                <td class='text-left'>GTA</td>
                                <td>{0}</td>
                                <td class='text-end'>{1}%
                                <td class='text-end'>${2}</td>
                                <td class='text-end'>${3}</td>
                                <td class='text-end'>{4}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Ottawa</td>
                                <td>{5}</td>
                                <td class='text-end'>{6}%
                                <td class='text-end'>${7}</td>
                                <td class='text-end'>${8}</td>
                                <td class='text-end'>{9}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Golden Horseshoe</td>
                                <td>{10}</td>
                                <td class='text-end'>{11}%
                                <td class='text-end'>${12}</td>
                                <td class='text-end'>${13}</td>
                                <td class='text-end'>{14}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Other Major Urban Areas</td>
                                <td>{15}</td>
                                <td class='text-end'>{16}%
                                <td class='text-end'>${17}</td>
                                <td class='text-end'>${18}</td>
                                <td class='text-end'>{19}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Entire Portfolio</td>
                                <td>{20}</td>
                                <td class='text-end'>{21}%
                                <td class='text-end'>${22}</td>
                                <td class='text-end'>${23}</td>
                                <td class='text-end'>{24}%</td>
                            </tr>
                        </tbody>
                   </table>
                </div>",
                dashboardViewModel.NoOfLoansByPostalCodeInGTA,
                String.Format("{0:n2}", dashboardViewModel.WeightedLTVByPostalCodeInGTA),
                String.Format("{0:n2}", dashboardViewModel.WeightedBeaconScoreByPostalCodeInGTA),
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceByPostalCodeInGTA),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMByPostalCodeInGTA),

                dashboardViewModel.NoOfLoansByPostalCodeInOttawa,
                String.Format("{0:n2}", dashboardViewModel.WeightedLTVByPostalCodeInOttawa),
                String.Format("{0:n2}", dashboardViewModel.WeightedBeaconScoreByPostalCodeInOttawa),
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceByPostalCodeInOttawa),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMByPostalCodeInOttawa),

                dashboardViewModel.NoOfLoansByPostalCodeInGoldenHorseshoe,
                String.Format("{0:n2}", dashboardViewModel.WeightedLTVByPostalCodeInGoldenHorseshoe),
                String.Format("{0:n2}", dashboardViewModel.WeightedBeaconScoreByPostalCodeInGoldenHorseshoe),
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceByPostalCodeInGoldenHorseshoe),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMByPostalCodeInGoldenHorseshoe),

                dashboardViewModel.NoOfLoansByPostalCodeInOtherMajorUrbanAreas,
                String.Format("{0:n2}", dashboardViewModel.WeightedLTVByPostalCodeInOtherMajorUrbanAreas),
                String.Format("{0:n2}", dashboardViewModel.WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas),
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceByPostalCodeInOtherMajorUrbanAreas),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMByPostalCodeInOtherMajorUrbanAreas),

                dashboardViewModel.GetTotalNoOfLoansByMortgageRegion(),
                String.Format("{0:n2}", dashboardViewModel.TotalWeightedLTV),
                String.Format("{0:n2}", dashboardViewModel.TotalWeightedBeaconScore),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPrincipalBalanceByMortgageRegion()),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPctOfAUMByMortgageRegion())
            );

            return sb.ToString();
        }

        private static string GetPricePerSFByRegion(DashboardLoanViewModel dashboardViewModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                @"<div>
                   <h2 class='small-title'><br>Price per Square Foot by Region</h2>
                   <table>
                       <thead>
                           <tr>
                               <th class='text-left'>Mortgage Region</th>
                               <th class='text-end'>Detached</th>
                               <th class='text-end'>Semi Detached</th>
                               <th class='text-end'>Row Housing</th>
                               <th class='text-end'>Condo</th>
                               <th class='text-end'>All Property Types</th>
                           </tr>
                       </thead>
                       <tbody>
                            <tr>
                                <td class='text-left'>GTA</td>
                                <td class='text-end'><small>({25})</small> {0}</td>
                                <td class='text-end'><small>({26})</small> {1}</td>
                                <td class='text-end'><small>({27})</small> {2}</td>
                                <td class='text-end'><small>({28})</small> {3}</td>
                                <td class='text-end'><small>({29})</small> {4}</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Ottawa</td>
                                <td class='text-end'><small>({30})</small> {5}</td>
                                <td class='text-end'><small>({31})</small> {6}</td>
                                <td class='text-end'><small>({32})</small> {7}</td>
                                <td class='text-end'><small>({33})</small> {8}</td>
                                <td class='text-end'><small>({34})</small> {9}</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Golden Horseshoe</td>
                                <td class='text-end'><small>({35})</small> {10}</td>
                                <td class='text-end'><small>({36})</small> {11}</td>
                                <td class='text-end'><small>({37})</small> {12}</td>
                                <td class='text-end'><small>({38})</small> {13}</td>
                                <td class='text-end'><small>({39})</small> {14}</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Other Major Urban Areas</td>
                                <td class='text-end'><small>({40})</small> {15}</td>
                                <td class='text-end'><small>({41})</small> {16}</td>
                                <td class='text-end'><small>({42})</small> {17}</td>
                                <td class='text-end'><small>({43})</small> {18}</td>
                                <td class='text-end'><small>({44})</small> {19}</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Entire Portfolio</td>
                                <td class='text-end'><small>({45})</small> {20}</td>
                                <td class='text-end'><small>({46})</small> {21}</td>
                                <td class='text-end'><small>({47})</small> {22}</td>
                                <td class='text-end'><small>({48})</small> {23}</td>
                                <td class='text-end'><small>({49})</small> {24}</td>
                            </tr>
                        </tbody>
                   </table>
                </div>",
                String.Format("${0:n2}", dashboardViewModel.DetachedPricePerSquareFootInGTA),
                String.Format("${0:n2}", dashboardViewModel.SemiDetachedPricePerSquareFootInGTA),
                String.Format("${0:n2}", dashboardViewModel.RowHousingPricePerSquareFootInGTA),
                String.Format("${0:n2}", dashboardViewModel.CondoPricePerSquareFootInGTA),
                String.Format("${0:n2}", dashboardViewModel.TotalPricePerSquareFootInGTA),

                String.Format("${0:n2}", dashboardViewModel.DetachedPricePerSquareFootInOttawa),
                String.Format("${0:n2}", dashboardViewModel.SemiDetachedPricePerSquareFootInOttawa),
                String.Format("${0:n2}", dashboardViewModel.RowHousingPricePerSquareFootInOttawa),
                String.Format("${0:n2}", dashboardViewModel.CondoPricePerSquareFootInOttawa),
                String.Format("${0:n2}", dashboardViewModel.TotalPricePerSquareFootInOttawa),

                String.Format("${0:n2}", dashboardViewModel.DetachedPricePerSquareFootInGoldenHorseshoe),
                String.Format("${0:n2}", dashboardViewModel.SemiDetachedPricePerSquareFootInGoldenHorseshoe),
                String.Format("${0:n2}", dashboardViewModel.RowHousingPricePerSquareFootInGoldenHorseshoe),
                String.Format("${0:n2}", dashboardViewModel.CondoPricePerSquareFootInGoldenHorseshoe),
                String.Format("${0:n2}", dashboardViewModel.TotalPricePerSquareFootInGoldenHorseshoe),

                String.Format("${0:n2}", dashboardViewModel.DetachedPricePerSquareFootInOtherMajorUrbanAreas),
                String.Format("${0:n2}", dashboardViewModel.SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas),
                String.Format("${0:n2}", dashboardViewModel.RowHousingPricePerSquareFootInOtherMajorUrbanAreas),
                String.Format("${0:n2}", dashboardViewModel.CondoPricePerSquareFootInOtherMajorUrbanAreas),
                String.Format("${0:n2}", dashboardViewModel.TotalPricePerSquareFootInOtherMajorUrbanAreas),

                String.Format("${0:n2}", dashboardViewModel.DetachedPricePerSquareFootForAllRegions),
                String.Format("${0:n2}", dashboardViewModel.SemiDetachedPricePerSquareFootForAllRegions),
                String.Format("${0:n2}", dashboardViewModel.RowHousingPricePerSquareFootForAllRegions),
                String.Format("${0:n2}", dashboardViewModel.CondoPricePerSquareFootForAllRegions),
                String.Format("${0:n2}", dashboardViewModel.TotalPricePerSquareFootForAllRegions),

                dashboardViewModel.NoOfLoansDetachedInGTA,
                dashboardViewModel.NoOfLoansSemiDetachedInGTA,
                dashboardViewModel.NoOfLoansRowHousingInGTA,
                dashboardViewModel.NoOfLoansCondoInGTA,
                dashboardViewModel.GetNoOfLoansTotalInGTA(),

                dashboardViewModel.NoOfLoansDetachedInOttawa,
                dashboardViewModel.NoOfLoansSemiDetachedInOttawa,
                dashboardViewModel.NoOfLoansRowHousingInOttawa,
                dashboardViewModel.NoOfLoansCondoInOttawa,
                dashboardViewModel.GetNoOfLoansTotalInOttawa(),

                dashboardViewModel.NoOfLoansDetachedInGoldenHorseshoe,
                dashboardViewModel.NoOfLoansSemiDetachedInGoldenHorseshoe,
                dashboardViewModel.NoOfLoansRowHousingInGoldenHorseshoe,
                dashboardViewModel.NoOfLoansCondoInGoldenHorseshoe,
                dashboardViewModel.GetNoOfLoansTotalInGoldenHorseshoe(),

                dashboardViewModel.NoOfLoansDetachedInOtherMajorUrbanAreas,
                dashboardViewModel.NoOfLoansSemiDetachedInOtherMajorUrbanAreas,
                dashboardViewModel.NoOfLoansRowHousingInOtherMajorUrbanAreas,
                dashboardViewModel.NoOfLoansCondoInOtherMajorUrbanAreas,
                dashboardViewModel.GetNoOfLoansTotalInOtherMajorUrbanAreas(),

                dashboardViewModel.NoOfLoansDetachedInAllRegions,
                dashboardViewModel.NoOfLoansSemiDetachedInAllRegions,
                dashboardViewModel.NoOfLoansRowHousingInAllRegions,
                dashboardViewModel.NoOfLoansCondoInAllRegions,
                dashboardViewModel.GetNoOfLoansTotalInAllRegions()
            );

            return sb.ToString();
        }

        private static string GetLoanSummaryByLatePayment(DashboardLoanViewModel dashboardViewModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                @"<div>
                   <h2 class='small-title'><br>Mortgage Summary by Late Payment</h2>
                   <table>
                       <thead>
                           <tr>
                               <th class='text-left'>Days Late</th>
                               <th>No of Mortgages</th>
                               <th class='text-end'>Principal Balance</th>
                               <th class='text-end'>% of AUM</th>
                           </tr>
                       </thead>
                       <tbody>
                            <tr>
                                <td class='text-left'>> 0 Days</td>
                                <td>{0}</td>
                                <td class='text-end'>${1}</td>
                                <td class='text-end'>{2}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>31 to 90 Days</td>
                                <td>{3}</td>
                                <td class='text-end'>${4}</td>
                                <td class='text-end'>{5}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>91 to 270 Days</td>
                                <td>{6}</td>
                                <td class='text-end'>${7}</td>
                                <td class='text-end'>{8}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>> 270 Days</td>
                                <td>{9}</td>
                                <td class='text-end'>${10}</td>
                                <td class='text-end'>{11}%</td>
                            </tr>
                        </tbody>
                   </table>
                </div>",
                dashboardViewModel.TotoalNoOfLoans0To30DaysLate,
                String.Format("{0:n2}", dashboardViewModel.TotalPrincipalBalance0To30DaysLate),
                String.Format("{0:n2}", dashboardViewModel.TotalPctOfAUM0To30DaysLate),

                dashboardViewModel.TotoalNoOfLoans31To90DaysLate,
                String.Format("{0:n2}", dashboardViewModel.TotalPrincipalBalance31To90DaysLate),
                String.Format("{0:n2}", dashboardViewModel.TotalPctOfAUM31To90DaysLate),

                dashboardViewModel.TotoalNoOfLoans91To270DaysLate,
                String.Format("{0:n2}", dashboardViewModel.TotalPrincipalBalance91To270DaysLate),
                String.Format("{0:n2}", dashboardViewModel.TotalPctOfAUM91To270DaysLate),

                dashboardViewModel.TotoalNoOfLoansMoreThan270DaysLate,
                String.Format("{0:n2}", dashboardViewModel.TotalPrincipalBalanceMoreThan270DaysLate),
                String.Format("{0:n2}", dashboardViewModel.TotalPctOfAUMMoreThan270DaysLate)
            );

            return sb.ToString();
        }

        private static string GetLoanSummaryByMortgageType(DashboardLoanViewModel dashboardViewModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                @"<div>
                   <h2 class='small-title'><br>Mortgage Summary by Mortgage Type</h2>
                   <table>
                       <thead>
                           <tr>
                               <th class='text-left'>Loan Type</th>
                               <th>No of Mortgages</th>
                               <th class='text-end'>Principal Balance</th>
                               <th class='text-end'>% of AUM</th>
                           </tr>
                       </thead>
                       <tbody>
                            <tr>
                                <td class='text-left'>Residential</td>
                                <td>{0}</td>
                                <td class='text-end'>${1}</td>
                                <td class='text-end'>{2}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Commercial</td>
                                <td>{3}</td>
                                <td class='text-end'>${4}</td>
                                <td class='text-end'>{5}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Land</td>
                                <td>{6}</td>
                                <td class='text-end'>${7}</td>
                                <td class='text-end'>{8}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Construction</td>
                                <td>{9}</td>
                                <td class='text-end'>${10}</td>
                                <td class='text-end'>{11}%</td>
                            </tr>
                                <tr>
                                <td class='text-left'>Uncategorized</td>
                                <td>{12}</td>
                                <td class='text-end'>${13}</td>
                                <td class='text-end'>{14}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>Total</td>
                                <td>{15}</td>
                                <td class='text-end'>${16}</td>
                                <td class='text-end'>{17}%</td>
                            </tr>
                        </tbody>
                   </table>
                </div>",
                dashboardViewModel.NoOfLoansResidential,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceResidential),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMResidential),

                dashboardViewModel.NoOfLoansCommercial,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceCommercial),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMCommercial),

                dashboardViewModel.NoOfLoansLand,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceLand),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMLand),

                dashboardViewModel.NoOfLoansConstruction,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceConstruction),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMConstruction),

                dashboardViewModel.NoOfLoansUncategorized,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceUncategorized),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMUncategorized),

                dashboardViewModel.GetTotalNoOfLoansPropertyType(),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPrincipalBalancePropertyType()),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPctOfAUMPropertyType())
            );

            return sb.ToString();
        }

        private static string GetRemainingTermToMaturitySummaryTable(DashboardLoanViewModel dashboardViewModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                @"<div>
                   <h2 class='small-title'><br>Remaining Term to Maturity Summary</h2>
                   <table>
                       <thead>
                           <tr>
                               <th class='text-left'>MATURITY IN MONTHS</th>
                               <th>No of Mortgages</th>
                               <th class='text-end'>Principal Balance</th>
                               <th class='text-end'>% of AUM</th>
                           </tr>
                       </thead>
                       <tbody>
                            <tr>
                                <td class='text-left'>≤ 6</td>
                                <td>{0}</td>
                                <td class='text-end'>${1}</td>
                                <td class='text-end'>{2}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>> 6 - 9</td>
                                <td>{3}</td>
                                <td class='text-end'>${4}</td>
                                <td class='text-end'>{5}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>> 9 - 12</td>
                                <td>{6}</td>
                                <td class='text-end'>${7}</td>
                                <td class='text-end'>{8}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>> 12</td>
                                <td>{9}</td>
                                <td class='text-end'>${10}</td>
                                <td class='text-end'>{11}%</td>
                            <tr>
                                <td class='text-left'>Total</td>
                                <td>{12}</td>
                                <td class='text-end'>${13}</td>
                                <td class='text-end'>{14}%</td>
                            </tr>
                        </tbody>
                   </table>
                </div>",
                dashboardViewModel.NoOfLoansRemainingTermtoMaturityLessEqual6,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceRemainingTermtoMaturityLessEqual6),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMRemainingTermtoMaturityLessEqual6),

                dashboardViewModel.NoOfLoansRemainingTermtoMaturity6To9,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceRemainingTermtoMaturity6To9),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMRemainingTermtoMaturity6To9),

                dashboardViewModel.NoOfLoansRemainingTermtoMaturity9To12,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceRemainingTermtoMaturity9To12),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMRemainingTermtoMaturity9To12),

                dashboardViewModel.NoOfLoansRemainingTermtoMaturityMoreThan12,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalanceRemainingTermtoMaturityMoreThan12),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMRemainingTermtoMaturityMoreThan12),

                dashboardViewModel.GetTotalNoOfLoansRemainingTermtoMaturity(),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPrincipalBalanceRemainingTermtoMaturity()),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPctOfAUMRemainingTermtoMaturity())
            );

            return sb.ToString();
        }

        private static string GetPortfolioSummaryByLTV(DashboardLoanViewModel dashboardViewModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                @"<div>
                   <h2 class='small-title'><br>Portfolio Summary by LTV</h2>
                   <table>
                       <thead>
                           <tr>
                               <th class='text-left'>LTV RANGE</th>
                               <th>No of Mortgages</th>
                               <th class='text-end'>Principal Balance</th>
                               <th class='text-end'>% of AUM</th>
                           </tr>
                       </thead>
                       <tbody>
                            <tr>
                                <td class='text-left'>> 80%</td>
                                <td>{0}</td>
                                <td class='text-end'>${1}</td>
                                <td class='text-end'>{2}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>> 75% - 80%</td>
                                <td>{3}</td>
                                <td class='text-end'>${4}</td>
                                <td class='text-end'>{5}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>> 65% - 75%</td>
                                <td>{6}</td>
                                <td class='text-end'>${7}</td>
                                <td class='text-end'>{8}%</td>
                            </tr>
                            <tr>
                                <td class='text-left'>&#8804; 65%</td>
                                <td>{9}</td>
                                <td class='text-end'>${10}</td>
                                <td class='text-end'>{11}%</td>
                            <tr>
                                <td class='text-left'>Total</td>
                                <td>{12}</td>
                                <td class='text-end'>${13}</td>
                                <td class='text-end'>{14}%</td>
                            </tr>
                        </tbody>
                   </table>
                </div>",
                dashboardViewModel.NoOfLoansPortfolioByLTVMoreThan80,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalancePortfolioByLTVMoreThan80),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMPortfolioByLTVMoreThan80),

                dashboardViewModel.NoOfLoansPortfolioByLTV75To80,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalancePortfolioByLTV75To80),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMPortfolioByLTV75To80),

                dashboardViewModel.NoOfLoansPortfolioByLTV65To75,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalancePortfolioByLTV65To75),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMPortfolioByLTV65To75),

                dashboardViewModel.NoOfLoansPortfolioByLTVLessEqual65,
                String.Format("{0:n2}", dashboardViewModel.PrincipalBalancePortfolioByLTVLessEqual65),
                String.Format("{0:n2}", dashboardViewModel.PctOfAUMPortfolioByLTVLessEqual65),

                dashboardViewModel.GetTotalNoOfLoansPortfolioByLTV(),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPrincipalBalancePortfolioByLTV()),
                String.Format("{0:n2}", dashboardViewModel.GetTotalPctOfAUMPortfolioByLTV())
            );

            return sb.ToString();
        }
    }
}