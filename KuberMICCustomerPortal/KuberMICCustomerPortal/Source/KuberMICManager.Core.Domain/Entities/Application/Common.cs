using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// This file should contain common method, constants and enumerations
/// </summary>
namespace KuberMICManager.Core.Domain.Entities.Application
{
    /// <summary>
    /// Convert from Enum to Another type and vice-versa
    /// </summary>
    public static class Common
    {
        public const string DefaultTimeZoneStandardName = "Eastern Standard Time";

        public const string QualifiedAmountParentRecId = "384281018804456D928FD25012C34104";
        public const string TitleInsuranceAmountParentRecId = "F63139F1044746F582330EA2938B5E85";
        public const string FireInsuranceAmountParentRecId = "47916A0D83E343679ED85E65205698FD";
        public const string AverageCreditScoreParentRecId = "8E4D2285D41C4475BA0D5AD6BF8846BA";
        public const string LessorAppraisedValueorPurchasePriceParentRecId = "0AA82D2E54AE49DCA385B0210B63112B";
        public const string CreditScoreParentRecId = "F3AF2ECCAAB444CD865B2E324EBD3685";
        public const string LoanTermsParentRecId = "E426993A1A1B4FAE9AF8B358093E10C6";
        public const string RenewalOrRefinanceDateParentRecId = "616BBD2D07E34C90926BFA73614AF670";
        public const string LegalDescriptionParentRecId = "E3ECA31268024A419BB1772FDB46F06D";
        public const string PINNumberParentRecId = "C8276B1C5BD34AC0B15BA9233171B7A0";
        public const string ConsentingSpouseParentRecId = "0E23D88826844435B0C5A6EE71767FDA";
        public const string IneligibleReasonParentRecId = "DEA646AAFA144A8595FE36B229354C69";
        public const string SubjectPropertySquareFootageParentRecId = "4BCB95EF33354630B1A8919CEF1332FC";

        public const string JointPartnerNamesParentRecId = "1DDC29349E3143229C9758662F6FCEE5";
        public const string BusinessNumberParentRecId = "A42592CD5087475BB615A61D31082443";

        public const string BMOTabRecID = "EB69F73A1E474E979FFB3C3881C86FD9";
        public const string MITabRecID = "0A208BB71EC54944AB8FFCFA723B74D5";

        public const string KuberFundingAccountRecID = "3BAAD24F6CE746EEAAD943C9595D9FDA";
        public const string KuberFundingOperatingRecID = "72B2D7574E8E4D31B0BD5FD1FE07E71C";
        public const string SquareCapitalAccountRecID = "B276059EE07248D4BAB56027E42843D8";

        public const int QualifiedLoansLengthLimitInMonths = 36;
        public const int AllowedMaturedDays = 30;
        public const int AllowedArrearsInDays = 60;
        public const int DelinquentPeriodInDays = 90;

        /// <summary>
        /// Context Type for Excel
        /// </summary>
        public const string CONTENT_TYPE_EXCEL = "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet";
        /// <summary>
        /// Context Type for MS Word
        /// </summary>
        public const string CONTENT_TYPE_MSWORD = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        /// <summary>
        /// Set the default reporting time zone
        /// </summary>
        public static TimeZoneInfo DefaultReportingTimeZone => TimeZoneInfo.FindSystemTimeZoneById(DefaultTimeZoneStandardName);

        /// <summary>
        /// Extension method that converts enum to string with the attribute [Description("String Value")]
        /// You can then type: CountryCodes.Canada.ToDescription();
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            var da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return da.Length > 0 ? da[0].Description : value.ToString();
        }

        public static string TrimEnd(this string source, string value)
        {
            if (!source.EndsWith(value))
                return source;

            return source.Remove(source.LastIndexOf(value));
        }

        public static decimal ToDecimal(this string value)
        {
            return String.IsNullOrEmpty(value) ? 0 : Decimal.Parse(value, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
        }

        public static decimal ToInt(this string value)
        {
            return Int32.Parse(value);
        }

        public static string Ordinal(this int number)
        {
            var work = number.ToString();
            if ((number % 100) == 11 || (number % 100) == 12 || (number % 100) == 13)
                return work + "th";
            switch (number % 10)
            {
                case 1: work += "st"; break;
                case 2: work += "nd"; break;
                case 3: work += "rd"; break;
                default: work += "th"; break;
            }
            return work;
        }

        public static DateTime GetEndOfLastFifteenth()
        {
            var now = DateTime.Now;
            var firstDayCurrentMonth = new DateTime(now.Year, now.Month, 1);

            return firstDayCurrentMonth.AddDays(14).Date;
        }

        public static DateTime GetLastDayOfLastMonth()
        {
            var now = DateTime.Now;
            var firstDayCurrentMonth = new DateTime(now.Year, now.Month, 1);

            return firstDayCurrentMonth.AddDays(-1).Date;
        }

        public static decimal GetPct(decimal Total, decimal Partial)
        {
            return (Partial / Total) * 100;
        }

        public static decimal GetSiteSetting(IMemoryCache cache, string sitSettingKey)
        {
            IEnumerable<SiteSetting> siteSettings = (IEnumerable<SiteSetting>)cache.Get("siteSettings");

            return siteSettings.FirstOrDefault(s => s.Key == sitSettingKey).SettingValue.ToDecimal();
        }

        public static DateTime GetSiteSettingDateTime(IMemoryCache cache, string sitSettingKey)
        {
            IEnumerable<SiteSetting> siteSettings = (IEnumerable<SiteSetting>)cache.Get("siteSettings");

            // Expected format MM/dd/yyyy
            return DateTime.ParseExact(siteSettings.FirstOrDefault(s => s.Key == sitSettingKey).SettingValue.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

        public static string GetReturnLink(ReturnToPage ReturnToPage)
        {
            switch (ReturnToPage)
            {
                case ReturnToPage.LienList:
                    return "/Liens/Index";
                case ReturnToPage.RenewalList:
                    return "/Tools/Renewals/Index";
                case ReturnToPage.ValidationListAll:
                    return $"/Tools/Validator?filtertype={(int)ValidationAccountType.All}";
                case ReturnToPage.ValidationListLoan:
                    return $"/Tools/Validator?filtertype={(int)ValidationAccountType.Loan}";
                case ReturnToPage.ValidationListPartner:
                    return $"/Tools/Validator?filtertype={(int)ValidationAccountType.Partner}";
                case ReturnToPage.PartnerTransactionList:
                    return $"/More/PartnerTransactions/Index";
                case ReturnToPage.ModifiedPropertiesList:
                    return $"/More/ModifiedProperties/Index";
                default:
                    return "./Index";
            }
        }

        public static bool IsQualifiedLoan(string loanCategory)
        {
            if (loanCategory == LoanTypeList.SFRCMAOwner.ToDescription() ||
                loanCategory == LoanTypeList.SFRCAOwnerQA.ToDescription() ||
                loanCategory == LoanTypeList.SFRCMANonOwner.ToDescription() ||
                loanCategory == LoanTypeList.SFRCANonOwnerQA.ToDescription() ||
                loanCategory == LoanTypeList.CMACommercial.ToDescription())
            {
                return true;
            }

            return false;
        }

        public static bool IsIneligibleLoan(string loanCategory)
        {
            if (loanCategory == LoanTypeList.SFRCMAOwnerOccIneligible.ToDescription() ||
                loanCategory == LoanTypeList.SFRCMAOwnerOccIneligible3Plus.ToDescription() ||
                loanCategory == LoanTypeList.SFRCMANonOwnerIneligible.ToDescription() ||
                loanCategory == LoanTypeList.SFRCMANonOwnerIneligible3Plus.ToDescription() ||
                loanCategory == LoanTypeList.CMACommercialIneligible.ToDescription() ||
                loanCategory == LoanTypeList.SFRCAOwner.ToDescription() ||
                loanCategory == LoanTypeList.SFRCANonOwner.ToDescription() ||
                loanCategory == LoanTypeList.CACommercial.ToDescription() ||
                loanCategory == LoanTypeList.SFRAutoRenewal.ToDescription())
            {
                return true;
            }

            return false;
        }

        public enum SiteSettingKey
        {
            [Description("Number Of Days Loans Up For Renewal")]
            NOOFDAYSLOANSUPFORRENEWAL = 200,
            [Description("Weighted LTV Threshold")]
            WEIGHTEDLTVTHRESHOLD = 201,
            [Description("Weighted Beacon Score Threshold")]
            WEIGHTEDBEACONSCORETHRESHOLD = 202,
            [Description("Weighted Maturity Date In Months Threshold")]
            WEIGHTEDMATURITYDATEINMONTHSTHRESHOLD = 203,
            [Description("Default Average Credit Score Threshold")]
            DEFAULTAVERAGECREDITSCORE = 204,
            [Description("Preferred Shares Target Rate - Class A")]
            PREFERREDSHARESTARGETRATECLASSA = 205,

            // BMO
            [Description("BMO - Credit Facility Limit")]
            BMOCREDITFACILITYLIMIT = 300,
            [Description("BMO - 2nd Mortgage Limit In Percent")]
            BMO2NDMORTGAGELIMITINPERCENT = 301,
            [Description("BMO - Non Owner Mortgage Limit In Percent")]
            BMONONOWNERMORTGAGELIMITINPERCENT = 302,
            [Description("BMO - Commercial Mortgage Limit In Percent")]
            BMOCOMMERCIALMORTGAGELIMITINPERCENT = 303,
            [Description("BMO - Residential Maximum Mortgage Limit Per Loan")]
            BMORESIDENTIALMAXLIMITPERLOAN = 304,
            [Description("BMO - Commercial Maximum Mortgage Limit Per Loan")]
            BMOCOMMERCIALMAXLIMITPERLOAN = 305,
            [Description("BMO - Aggragate Maximum Mortgage Limit Per SIN")]
            BMOAGGRAGATEMAXLIMITPERSIN = 306,
            [Description("BMO - Prime Interest Rate")]
            BMOPRIMEINTERESTRATE = 307,
            [Description("BMO - Spread")]
            BMOSPREAD = 308,
            [Description("BMO - Qualified Amount LTV Limit In Percent")]
            BMOQUALIFIEDAMOUNTLTVLIMITINPERCENT = 309,

            // Stress Test
            [Description("Stress Test - Liquidation cost for Value at Risk")]
            STRESSTESTLIQUIDATIONCOSTINCENTSPERDOLLARFORVALUEATRISK = 400,
            [Description("Stress Test - Level 1 Market Decline Limit")]
            STRESSTESTLEVELONEMARKETDECLINELIMIT = 401,
            [Description("Stress Test - Level 2 Market Decline Limit")]
            STRESSTESTLEVELTWOMARKETDECLINELIMIT = 402,
            [Description("Stress Test - Level 3 Market Decline Limit")]
            STRESSTESTLEVELTHREEMARKETDECLINELIMIT = 403,
            [Description("Stress Test - Projected Loan Loss Reserve")]
            STRESSTESTPROJECTEDLOANLOSSRESERVE = 404,
            [Description("Stress Test - Subordinated Share Value")]
            STRESSTESTSUBORDINATEDSHARESVALUE = 405,
            [Description("Stress Test - At Risk Beacon Score Threshold")]
            STRESSTESTATRISKBEACONSCORETHRESHOLD = 406,
            [Description("Stress Test - At Risk LTV Threshold")]
            STRESSTESTATRISKLTVTHRESHOLD = 407,
            [Description("Stress Test - Level 4 Appraisal Date Upper Limit (MM/dd/yyyy)")]
            STRESSTESTLEVEL4APPRAISALDATEUPPERLIMIT = 408,
        }

        public enum StressTestLevel
        {
            LevelOne = 1,
            LevelTwo = 2,
            // Level 3 and 4 are same except the loan list. Level four only includes loans that has appraisal done within a date
            LevelThree = 3,
            LevelFour = 4
        }

        public enum SettingsCategory
        {
            Global = 0,
            Admin = 100,

            // Mortgage
            Mortgage = 200,
            [Description("Mortgage: BBC")]
            MortgageBBC = 300,
            [Description("Mortgage: Stress Test")]
            MortgageStressTest = 400,

            // Investment
            Investment = 500
        }

        /// <summary>
        /// User Site Claims
        /// 
        /// NOTE: If you modify this list, updated the Startup Claim sections
        /// </summary>
        public enum UserClaimType
        {
            CanAdmin = 0,
            CanViewLoans = 1,
            CanViewInvestments = 2,
            CanViewUserProfile = 3
        }

        /// <summary>
        /// Defines each area of the site - used for logging on events
        /// </summary>
        public enum AreaType
        {
            SiteAccess = 100,
            UserManagement = 200,
            Administrative = 300,
            Reports = 400,
            LoanManagement = 500,
            PartnerManagement = 600,
            TrustAccountManagement = 700,
            Tools = 800,
            Dashboard = 900,
            PortfolioHistory = 1000
        }

        /// <summary>
        /// Event types per Area
        /// </summary>
        public enum EventType
        {
            Undefined = 0,

            // Common Events for any AreaType
            [Description("Exception Error")]
            ExceptionError = 1,

            // For AreaType.SiteAccess
            Login = 101,
            Logout = 102,
            [Description("Web User Login")]
            WebUserLogin = 103,
            Lockout = 104,

            // For AreaType.UserManagement
            [Description("New User")]
            NewUser = 201,
            [Description("Delete User")]
            DeleteUser = 202,
            [Description("Change Password")]
            ChangePassword = 203,
            [Description("Update User Info")]
            UpdateUserInfo = 204,

            // For AreaType.Administrative
            GetSiteOptionsSetting = 301,
            NewSiteOptionsSetting = 302,
            UpdateSiteOptionsSetting = 303,
            GetLogs = 304,
            GetPostalCode = 305,

            // For AreaType.Reporting
            Reports = 401,
            ViewBBCReport = 402,
            DownloandBBCExcelReport = 403,
            ViewStressTestReport = 404,
            DownloandStressTestReport = 405,

            // For AreaType.LoanManagement
            [Description("Get Loans")]
            GetLoans = 501,
            [Description("View Loan Details")]
            ViewLoanDetails = 502,
            [Description("Get Loan Attachment")]
            GetLoanAttachment = 503,
            [Description("Get Liens")]
            GetLiens = 504,
            [Description("Get Renewal History")]
            GetRenewalHistory = 505,
            [Description("Get Modified Properties")]
            GetModifiedProperties = 506,

            [Description("Update Notes")]
            UpdateNotes = 550,

            // For AreaType.PartnerManagement
            [Description("Get Partners")]
            GetPartners = 601,
            [Description("View Partner Details")]
            ViewPartnerDetails = 602,
            [Description("Get Partner Attachment")]
            GetPartnerAttachment = 603,
            [Description("Get Unique Active Investors")]
            GetUniqueActiveInvestors = 604,
            [Description("Get Partner Transactions")]
            GetPartnerTransactions = 605,

            // For AreaType.TrustAccountManagement
            [Description("View Trust Accounts")]
            ViewTrustAccounts = 701,

            // For AreaType.Tools
            GetRenewals = 801,
            LoanValidation = 802,
            UpdateRenewals = 803,
            DownloadRenewalDocument = 804,
            GetMortgageRateCalculator = 805,
            DownloadMortgageRateCalculatorDocument = 806,

            // For AreaType.Dashboard
            DownloanDashboardPortfolioSummary = 901,

            // For AreaType.Snapshot
            StoreDashboardPortfolioSnapshot = 1001,
            StoreBBCSnapshot = 1002,
            StoreIntervalSnapshot = 1003,
            ViewPortfolioHistory = 1004
        }

        public enum LienFilterType
        {
            [Description("All Liens")]
            All = 0,
            [Description("Prin Bal > 0")]
            PrincipalBalanceGreaterThanZero = 1
        }

        public enum LoanFilterType
        {
            [Description("All Mortgages")]
            All = 0,
            [Description("ACH Active")]
            ACHActive = 1,
            [Description("Prin Bal > 0")]
            PrincipalBalanceGreaterThanZero = 2,
            [Description("> 0 Days Late")]
            DaysLate0To30 = 3,
            [Description("31 To 90 Days Late")]
            DaysLate31To90 = 4,
            [Description("91 - 270 Days Late")]
            DaysLate91To270 = 5,
            [Description("> 270 Days Late")]
            DaysLateGtrThan270 = 6,
            [Description("1st Mortgages")]
            FirstMortgage = 7,
            [Description("2nd Mortgages")]
            SecondMortgage = 8,
            [Description("3rd Mortgages")]
            ThirdMortgage = 9,
            [Description("Residential")]
            Residential = 10,
            [Description("Commercial")]
            Commercial = 11,
            [Description("Land")]
            Land = 12,
            [Description("Construction")]
            Construction = 13,
            [Description("Uncategorized")]
            Uncategorized = 14,
            [Description("GTA Mortgages")]
            GTAMortgages = 15,
            [Description("Ottawa Mortgages")]
            OttawaMortgages = 16,
            [Description("Golden Horseshoe Mortgages")]
            GoldenHorseshoeMortgages = 17,
            [Description("Other Major Urban Area Mortgages")]
            OtherMajorUrbanAreasMortgages = 18,

            [Description("Qualified 1st Owner Occupied")] // All
            OwnerOccupied1stMortgages = 20,
            [Description("Qualified 1st Owner Occupied - LTV < 50% GTA")] // LTV < 50% GTA
            OwnerOccupied1stMortgagesLTVLessThan50GTA = 21,
            [Description("Qualified 1st Owner Occupied (Excluding LTV < 50% GTA)")] // All - LTV < 50% GTA
            OwnerOccupied1stMortgagesOther = 22,
            [Description("Qualified 2nd")]
            OwnerOccupied2ndMortgages = 23,
            [Description("Qualified 1st Non-Owner Occupied")]
            NonOwner1stMortgages = 24,
            [Description("Qualified 1st Commercial")]
            Commercial1stMortgages = 25,
            [Description("Same SIN Mortgages")]
            SameSINMortgages = 26,
            [Description("Arrears 1st")]
            Arrears1stMortgages = 27,
            [Description("Arrears 2nd")]
            Arrears2ndMortgages = 28,
            [Description("Delinquent Mortgages")]
            DelinquentMortgages = 29,

            [Description("Level 1 Stress Test: 0% - 80% LTV Mortgages")]
            L10To80Mortgages = 31,
            [Description("Level 1 Stress Test: 80% - 90% LTV Mortgages")]
            L180To90Mortgages = 32,
            [Description("Level 1 Stress Test: 90% - 95% LTV Mortgages")]
            L190To95Mortgages = 33,
            [Description("Level 1 Stress Test: 95% - 100% LTV Mortgages")]
            L195To100Mortgages = 34,
            [Description("Level 1 Stress Test: Above 100% LTV Mortgages")]
            L1Above100Mortgages = 35,

            [Description("Level 1 Stress Test: Above xx% LTV and Below xxx Beacon Score Mortgages")]
            L1OverThresholdLTVBelowThreshodBeaconScoreMortgages = 36,
            [Description("Level 1 Stress Test: Above xx% LTV, Below xxx Beacon Score and Outside GTA Mortgages")]
            L1OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages = 37,

            [Description("Level 2 Stress Test: 0% - 80% LTV Mortgages")]
            L20To80Mortgages = 38,
            [Description("Level 2 Stress Test: 80% - 90% LTV Mortgages")]
            L280To90Mortgages = 39,
            [Description("Level 2 Stress Test: 90% - 95% LTV Mortgages")]
            L290To95Mortgages = 40,
            [Description("Level 2 Stress Test: 95% - 100% LTV Mortgages")]
            L295To100Mortgages = 41,
            [Description("Level 2 Stress Test: Above 100% LTV Mortgages")]
            L2Above100Mortgages = 42,

            [Description("Level 2 Stress Test: Above xx% LTV and Below xxx Beacon Score Mortgages")]
            L2OverThresholdLTVBelowThreshodBeaconScoreMortgages = 43,
            [Description("Level 2 Stress Test: Above xx% LTV, Below xxx Beacon Score and Outside GTA Mortgages")]
            L2OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages = 44,

            [Description("Level 3 Stress Test: 0% - 80% LTV Mortgages")]
            L30To80Mortgages = 45,
            [Description("Level 3 Stress Test: 80% - 90% LTV Mortgages")]
            L380To90Mortgages = 46,
            [Description("Level 3 Stress Test: 90% - 95% LTV Mortgages")]
            L390To95Mortgages = 47,
            [Description("Level 3 Stress Test: 95% - 100% LTV Mortgages")]
            L395To100Mortgages = 48,
            [Description("Level 3 Stress Test: Above 100% LTV Mortgages")]
            L3Above100Mortgages = 49,

            [Description("Level 3 Stress Test: Above xx% LTV and Below xxx Beacon Score Mortgages")]
            L3OverThresholdLTVBelowThreshodBeaconScoreMortgages = 50,
            [Description("Level 3 Stress Test: Above xx% LTV, Below xxx Beacon Score and Outside GTA Mortgages")]
            L3OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages = 51,

            [Description("Level 4 Stress Test: Above xx% LTV and Below xxx Beacon Score Mortgages")]
            L4OverThresholdLTVBelowThreshodBeaconScoreMortgages = 57, // Don't change the number - stress test partial view depends on the spacing
            [Description("Level 4 Stress Test: Above xx% LTV, Below xxx Beacon Score and Outside GTA Mortgages")]
            L4OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages = 58, // Don't change the number - stress test partial view depends on the spacing

            [Description("Remaining Term to Maturity - ≤ 6")]
            RemainingTermToMaturityLessEqual6 = 59,
            [Description("Remaining Term to Maturity - > 6 - 9")]
            RemainingTermToMaturity6To9 = 60,
            [Description("Remaining Term to Maturity - > 9 - 12")]
            RemainingTermToMaturity9To12 = 61,
            [Description("Remaining Term to Maturity - > 12")]
            RemainingTermToMaturityMoreThan12 = 62,

            [Description("Portfolio by LTV - > 80%")]
            PortfolioByLTVMoreThan80 = 63,
            [Description("Portfolio by LTV - > 75% - 80%")]
            PortfolioByLTV75To80 = 64,
            [Description("Portfolio by LTV - > 65% - 75%")]
            PortfolioByLTV65To75 = 65,
            [Description("Portfolio by LTV - ≤ 65%")]
            PortfolioByLTVLessEqual65 = 66,

            [Description("Detached")]
            Detached = 67,
            [Description("Semi Detached")]
            SemiDetached = 68,
            [Description("Row Housing")]
            RowHousing = 69,
            [Description("Condo")]
            Condo = 70,

            [Description("Qualified")]
            Qualified = 71,
            [Description("Non-Qualified")]
            Ineligible = 72,
        }

        public enum MortgageRenewalTerms
        {
            [Description("3 Months")]
            ThreeMonths = 3,
            [Description("6 Months")]
            SixMonths = 6,
            [Description("12 Months")]
            TwelveMonths = 12
        }

        public enum MortgageType
        {
            Closed = 0,
            Open = 1
        }

        public enum MortgageRenewalStatus
        {
            [Description("None")]
            None = 0,
            [Description("Payout Requested")]
            PayoutRequested = 1,
            [Description("New Conditions Specified")]
            NewConditionsSpecified = 2,
            [Description("Documents Sent")]
            DocumentsSent = 3,
            [Description("Pending Documents")]
            PendingDocuments = 4,
            [Description("Conditions Met")]
            ConditionsMet = 5,
            [Description("Completed")]
            Completed = 6,
            [Description("Paid Off")]
            PaidOff = 7
        }

        public enum MICHistoryKey
        {

        }

        public enum MortgageRegion
        {
            [Description("GTA")]
            GTA = 0,
            [Description("Ottawa")]
            Ottawa = 1,
            [Description("Golden Horseshoe")]
            GoldenHorseshoe = 2,
            [Description("Other Major Urban Areas")]
            OtherMajorUrbanAreas = 3
        }
        
        public enum ReturnToPage
        {
            LoanList = 0,
            LienList = 1,
            RenewalList = 2,
            ValidationListAll = 3,
            ValidationListLoan = 4,
            ValidationListPartner = 5,
            PartnerList = 6,
            PartnerTransactionList = 7,
            ModifiedPropertiesList = 8
        }

        public enum LedgerType
        {
            [Description("All")]
            All = 0,
            [Description("Kuber A Pool")]
            KUBERA = 1,
            [Description("Kuber C Pool")]
            KUBERC = 2
        }

        public enum LoanPriority
        {
            [Description("First Mortgage")]
            First = 1,
            [Description("Second Mortgage")]
            Second = 2,
            [Description("Third Mortgage")]
            Third = 3
        }
        public enum PartnerAccountType
        {
            Growth = 0,
            Income = 1
        }

        public enum SystemStatus
        {
            None= 0,
            Info = 1,
            Warning = 2,
            Error
        }

        public enum PartnerFilterType
        {
            [Description("All Partners")]
            All = 0,
            [Description("Active")]
            Active = 1,
            [Description("ACH Active")]
            ACHActive = 2,
            [Description("Growth")]
            Growth = 3,
            [Description("Income")]
            Income = 4,
            [Description("DataCore")]
            DateCore = 5,
            [Description("Management")]
            Management = 6,
            [Description("Non-Reg - Individual")]
            NonRegisteredIndividual = 7,
            [Description("TFSA")]
            TFSA = 8,
            [Description("RRSP")]
            RRSP = 9,
            [Description("RRSP Spousal")]
            RRSPSpousal = 10,
            [Description("LIRA")]
            LIRA = 11,
            [Description("LRSP")]
            LRSP = 12,
            [Description("RESP Family")]
            RESPFamily = 13,
            [Description("RLSP")]
            RLSP = 14,
            [Description("LIF")]
            LIF = 15,
            [Description("New LIF")]
            NewLIF = 16,
            [Description("RLIF")]
            RLIF = 17,
            [Description("RRIF")]
            RRIF = 18,
            [Description("RRIF Spousal")]
            RRIFSpousal = 19,
            [Description("Share Balance > 0")]
            ShareBalanceGreaterThanZero = 20,
            [Description("Non-Reg - Company")]
            NonRegisteredCompany = 21,
            [Description("Non-Reg - JTWROS")]
            NonRegisteredJTWROS = 22,
            [Description("Registered")]
            Registered = 23,
        }

        /// <summary>
        /// Indicates if the Search / Email was successful or failed
        /// </summary>
        public enum ResultType
        {
            Undefined = 0,

            // searching
            //SearchStarted = 100,
            //SearchFlightsFound = 101,
            //SearchNoFlightsFound = 102,
            //SearchNotEnoughSeats = 103,
            //SearchError = 104,

            // email
            //EmailSuccess = 200,
            //EmailFailed = 201,

            // general
            [Description("SUCCESS")]
            Success = 300,
            [Description("FAILURE")]
            Failure = 301,
            [Description("Not Found")]
            NotFound = 302,

            // Snapshot
            [Description("Portfolio Snapshot Success")]
            PortfolioSnapshotSuccess = 400,
            [Description("BBC Snapshot Success")]
            BBCSnapshotSuccess = 401,
            [Description("Snapshot Exists")]
            SnapshotExists = 402,
            [Description("Stress Test Snapshot Success")]
            StressTestSnapshotSuccess = 403,
        }

        public enum OrderDirection
        {
            Asending,
            Descending
        }

        public enum DeliveryOptions
        {
            None = 0,
            Print = 1,
            Email = 2,
            PrintAndEmail = 3,
            Text = 4,
            PrintAndText = 5,
            EmailAndText = 6
        }

        public enum AchServiceStatus
        {
            None = 0,
            Active = 1,
            Cancelled = 2,
            Hold = 3
        }

        public enum ACHAccountType
        {
            Checking = 0,
            Saving = 1,
            [Description("GL Withdrawal (Debit)")]
            GLWithdrawalDebit = 2
        }

        public enum ACHApplyDebitAs
        {
            [Description("Regular Payment")]
            RegularPayment = 0,
            [Description("To Trust")]
            Saving = 1
        }

        public enum ACHDebitFrequency
        {
            [Description("Once Only")]
            OnceOnly = 0,
            [Description("Monthly")]
            Monthly = 1,
            [Description("Quarterly")]
            Quarterly = 2,
            [Description("Bi-Monthly")]
            BiMonthly = 3,
            [Description("Bi-Weekly")]
            BiWeekly = 4,
            [Description("Weekly")]
            Weekly = 5,
            [Description("Every 15 Days")]
            Every15Days = 6,
            [Description("Twice A Month")]
            TwiceAMonth = 7,
            [Description("15th and EOM")]
            EOMAnd15th = 8,
            [Description("Semi-Yearly")]
            SemiYearly = 9,
            [Description("Yearly")]
            Yearly = 10
        }

        public enum ValidationAccountType
        {
            [Display(Name = "Account Validator")]
            All = 0,
            [Display(Name = "Loan Validator")]
            Loan = 1,
            [Display(Name = "Partner Validator")]
            Partner = 2
        }

        public enum LoanSearchGroup
        {
            [Display(Name = "Loan")]
            Loan = 0,
            [Display(Name = "Properties")]
            Properties = 1,
            [Display(Name = "Liens")]
            Liens = 2,
            [Display(Name = "Custom Fields")]
            CustomFields = 3,
            [Display(Name = "Co-Borrowers")]
            CoBorrowers = 4
        }

        public enum LoanType
        {
            Uncategorized = 0,
            Residential = 1,
            Commercial = 2,
            Land = 3,
            Construction = 4
        }

        public enum PropertyType
        {
            [Description("Undefined")]
            Undefined = 0,
            [Description("Land")]
            Land = 1,
            [Description("SFR-CMA-Construction")]
            SFRCMAConstruction = 2,
            [Description("CMA-Commercial")]
            CMACommercial = 3,
            [Description("CA-Commercial")]
            CACommercial = 4,
            [Description("SFR-CMA-Condo")]
            SFRCMACondo = 5,
            [Description("SFR-CMA-Detached")]
            SFRCMADetached = 6,
            [Description("SFR-CA-Detached")]
            SFRCADetached = 7,
            [Description("SFR-CMA–Semi Detached")]
            SFRCMASemiDetached = 8,
            [Description("SFR-CMA-Row Housing")]
            SFRCMARowHousing = 9,
            [Description("SFR-CA-Row Housing")]
            SFRCARowHousing = 10
        }

        public enum PropertyCategory
        {
            Uncategorized = 0,
            Residential = 1,
            Condo = 2,
            Commercial = 3,
            Construction = 4,
            Land = 5
        }

        public enum BBCCategory
        {
            [Description("Undefined")]
            Undefined = 0,
            [Description("Qual 1st Owner Occ")]
            OwnerOccupied1stMortgages = 1,
            [Description("Qualified 2nd")]
            OwnerOccupied2ndMortgages = 2,
            [Description("Qual 1st Non-Owner Occ")]
            NonOwner1stMortgages = 3,
            [Description("Qual 1st Commercial")]
            Commercial1stMortgages = 4,
            [Description("Delinquent")]
            DelinquentMortgages = 5,
            [Description("1st Mortgages")]
            FirstMortgage = 6,
            [Description("2nd Mortgages")]
            SecondMortgage = 7,
            [Description("3rd Mortgages")]
            ThirdMortgage = 8,
            [Description("Qual 1st Own Occ - LTV < 50 GTA")]
            OwnerOccupied1stMortgagesLTVLessThan50GTA = 9,
            [Description("Qual 1st Owner Occ - Other")]
            OwnerOccupied1stMortgagesOther = 10,
            [Description("Arrears 1st")]
            Arrears1stMortgages = 11,
            [Description("Arrears 2nd")]
            Arrears2ndMortgages = 12,
        }

        public enum LoanTypeList
        {
            Uncategorized = 0,
            [Description("CA-Commercial")]
            CACommercial = 1,
            [Description("CMA-Commercial")]
            CMACommercial = 2,
            [Description("CMA-Commercial-Ineligible")]
            CMACommercialIneligible = 3,
            [Description("Land")]
            Land = 4,
            [Description("Qualified- Not Borrowing Base")]
            QualifiedNotBorrowingBase = 5,
            [Description("SFR–CA–Non-Owner")]
            SFRCANonOwner = 6,
            [Description("SFR-CA-Construction")]
            SFRCAConstruction = 7,
            [Description("SFR-CA-Owner")]
            SFRCAOwner = 8,
            [Description("SFR-CMA-Construction")]
            SFRCMAConstruction = 9,
            [Description("SFR-CMA-Owner-Ineligibl-3+")]
            SFRCMAOwnerOccIneligible3Plus = 10,
            [Description("SFR-CMA-Owner-Ineligible")]
            SFRCMAOwnerOccIneligible = 11,
            [Description("SFR-CMA-Owner")]
            SFRCMAOwner = 12,
            [Description("SFR–CMA–Non-Owner")]
            SFRCMANonOwner = 13,
            [Description("SFR–CMA–Non-Owner-Ineligibl-3+")]
            SFRCMANonOwnerIneligible3Plus = 14,
            [Description("SFR–CMA–Non-Owner-Ineligible")]
            SFRCMANonOwnerIneligible = 15,
            [Description("SFR-Auto Renewal")]
            SFRAutoRenewal = 16,

            [Description("SFR-CMA-Detached")]
            SFRCMADetached = 17,
            [Description("SFR-CA-Detached")]
            SFRCADetached = 18,
            [Description("SFR-CMA–Semi Detached")]
            SFRCMASemiDetached = 19,
            [Description("SFR-CA–Semi Detached")]
            SFRCASemiDetached = 20,
            [Description("SFR-CMA-Row Housing")]
            SFRCMARowHousing = 21,
            [Description("SFR-CA-Row Housing")]
            SFRCARowHousing = 22,
            [Description("SFR-CMA-Condo")]
            SFRCMACondo = 23,
            [Description("SFR-CA-Condo")]
            SFRCACondo = 24,

            [Description("SFR–CA–Non-Owner-QA")]
            SFRCANonOwnerQA = 25,
            [Description("SFR-CA-Owner-QA")]
            SFRCAOwnerQA = 26,
        }

        public enum CoBorrowerRelation
        {
            [Description("None")]
            None = 0,
            [Description("Spouse of Borrower")]
            SpouseOfCoBorrower = 1
        }

        public enum CoBorrowerType
        {
            [Description("Co-Borrower")]
            CoBorrower = 1,
            [Description("Co-Signer")]
            CoSigner = 2,
            [Description("Guarantor")]
            Guarantor = 3,
            [Description("Other")]
            Other = 99
        }

        public enum UDFFieldOwnerType
        {
            Loan = 0,
            Partner = 7
        }

        public enum CertificateStatus
        {
            Active = 0,
            Redeemed = 1
        }

        public enum PartnerTransactionCode
        {
            Pur = 5,    // Purchase Certificate, Reinvestment
            Sal = 6,    // Redeem Certificate
            Dis = 7,    // Distribution
            Xfr = 9     // Redeem Certificate
        }

        public enum MICPortfolioHistoryCategory
        {
            [Description("Mortgage Summary by Mortgage Priority")]
            LoanSummaryByMortgagePriority = 0,
            [Description("Mortgage Weighted Average")]
            LoanWeightedAverage = 1,
            [Description("Mortgage Summary by Postal Code")]
            LoanSummaryByPostalCode = 2,
            [Description("Mortgage Summary by Mortgage Type")]
            LoanSummaryByMortgageType = 3,
            [Description("Mortgage Summary by Late Payment")]
            LoanSummaryByLatePayment = 4,
            [Description("Borrowing Base Certificate")]
            BBC = 5,
            [Description("Stress Test Parameters")]
            StressTestParameters = 6,
            [Description("Level 1 Stress Test")]
            L1StressTest = 7,
            [Description("Level 2 Stress Test")]
            L2StressTest = 8,
            [Description("Level 3 Stress Test")]
            L3StressTest = 9,

            [Description("Remaining Term to Maturity Summary")]
            RemainingTermToMaturitySummary = 10,
            [Description("Portfolio Summary by LTV")]
            PortfolioSummaryByLTV = 11,
            [Description("Price per Square Foot Summary")]
            PricePerSquareFootSummary = 12,

            [Description("Level 4 Stress Test")]
            L4StressTest = 13,

        }
    }
}