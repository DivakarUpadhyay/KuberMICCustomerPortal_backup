using System;
using System.Collections.Generic;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class DashboardLoanViewModel
    {
        //-------Active Loans-------
        // Stats
        public int NoOfLoansWithValidationErrors { get; set; }
        public int NoOfLoansUpForRenewal { get; set; }
        public decimal TotalLoanFundedToDate { get; set; }
        public int AverageDaysSinceLastAppraisalForResidentialLoans { get; set; }

        // First
        public int NoOfLoansFirst { get; set; }
        public decimal AverageAppraisalFirst { get; set; }
        public decimal PrincipalBalanceFirst { get; set; }
        public decimal PctOfAUMFirst { get; set; }
        // Second
        public int NoOfLoansSecond { get; set; }
        public decimal AverageAppraisalSecond { get; set; }
        public decimal PrincipalBalanceSecond { get; set; }
        public decimal PctOfAUMSecond { get; set; }
        // Third
        public int NoOfLoansThird { get; set; }
        public decimal AverageAppraisalThird { get; set; }
        
        public decimal PrincipalBalanceThird { get; set; }
        public decimal PctOfAUMThird { get; set; }
        //Total
        public decimal AverageAppraisalTotal { get; set; }

        // ***Weighted Average***
        // Calculated Weighted LTV
        public decimal TotalWeightedLTV { get; set; }
        public decimal FirstWeightedLTV { get; set; }
        public decimal SecondlWeightedLTV { get; set; }

        // Weighted Becon Score
        public decimal TotalWeightedBeaconScore { get; set; }
        public decimal FirstWeightedBeaconScore { get; set; }
        public decimal SecondlWeightedBeaconScore { get; set; }

        // Weighted Becon Score (in months)
        public decimal TotalWeightedMaturityDateInMonths { get; set; }
        public decimal FirstWeightedMaturityDateInMonths { get; set; }
        public decimal SecondlWeightedMaturityDateInMonths { get; set; }

        // Weighted Interest
        public decimal TotalWeightedInterestRate { get; set; }
        public decimal FirstWeightedInterestRate { get; set; }
        public decimal SecondlWeightedInterestRate { get; set; }

        // ***Loan Summary by Loan Type***
        // Residential
        public int NoOfLoansResidential { get; set; }
        public decimal PrincipalBalanceResidential { get; set; }
        public decimal PctOfAUMResidential { get; set; }

        // Commercial
        public int NoOfLoansCommercial { get; set; }
        public decimal PrincipalBalanceCommercial { get; set; }
        public decimal PctOfAUMCommercial { get; set; }

        // Land
        public int NoOfLoansLand { get; set; }
        public decimal PrincipalBalanceLand { get; set; }
        public decimal PctOfAUMLand { get; set; }

        // Construction
        public int NoOfLoansConstruction { get; set; }
        public decimal PrincipalBalanceConstruction { get; set; }
        public decimal PctOfAUMConstruction { get; set; }

        // Uncategorized
        public int NoOfLoansUncategorized { get; set; }
        public decimal PrincipalBalanceUncategorized { get; set; }
        public decimal PctOfAUMUncategorized { get; set; }

        // *** Late Payment Summary ***
        // 0 to 30 days late
        public int TotoalNoOfLoans0To30DaysLate { get; set; }
        public decimal TotalPrincipalBalance0To30DaysLate { get; set; }
        public decimal TotalPctOfAUM0To30DaysLate { get; set; }

        // 31 to 90 days late
        public int TotoalNoOfLoans31To90DaysLate { get; set; }
        public decimal TotalPrincipalBalance31To90DaysLate { get; set; }
        public decimal TotalPctOfAUM31To90DaysLate { get; set; }

        // 91 to 270 days late
        public int TotoalNoOfLoans91To270DaysLate { get; set; }
        public decimal TotalPrincipalBalance91To270DaysLate { get; set; }
        public decimal TotalPctOfAUM91To270DaysLate { get; set; }

        // > 270 days late
        public int TotoalNoOfLoansMoreThan270DaysLate { get; set; }
        public decimal TotalPrincipalBalanceMoreThan270DaysLate { get; set; }
        public decimal TotalPctOfAUMMoreThan270DaysLate { get; set; }

        // *** Postal Code Summary ***
        // GTA
        public int NoOfLoansByPostalCodeInGTA { get; set; }
        public decimal WeightedLTVByPostalCodeInGTA { get; set; }
        public decimal WeightedBeaconScoreByPostalCodeInGTA { get; set; }
        public decimal PrincipalBalanceByPostalCodeInGTA { get; set; }
        public decimal PctOfAUMByPostalCodeInGTA { get; set; }
        // Ottawa
        public int NoOfLoansByPostalCodeInOttawa { get; set; }
        public decimal WeightedLTVByPostalCodeInOttawa { get; set; }
        public decimal WeightedBeaconScoreByPostalCodeInOttawa { get; set; }
        public decimal PrincipalBalanceByPostalCodeInOttawa { get; set; }
        public decimal PctOfAUMByPostalCodeInOttawa { get; set; }
        // Golden Horseshoe
        public int NoOfLoansByPostalCodeInGoldenHorseshoe { get; set; }
        public decimal WeightedLTVByPostalCodeInGoldenHorseshoe { get; set; }
        public decimal WeightedBeaconScoreByPostalCodeInGoldenHorseshoe { get; set; }
        public decimal PrincipalBalanceByPostalCodeInGoldenHorseshoe { get; set; }
        public decimal PctOfAUMByPostalCodeInGoldenHorseshoe { get; set; }
        // Other Major Urban Areas
        public int NoOfLoansByPostalCodeInOtherMajorUrbanAreas { get; set; }
        public decimal WeightedLTVByPostalCodeInOtherMajorUrbanAreas { get; set; }
        public decimal WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas { get; set; }
        public decimal PrincipalBalanceByPostalCodeInOtherMajorUrbanAreas { get; set; }
        public decimal PctOfAUMByPostalCodeInOtherMajorUrbanAreas { get; set; }

        // *** Price per Square Foot Summary ***
        // GTA
        public decimal DetachedPricePerSquareFootInGTA { get; set; }
        public decimal SemiDetachedPricePerSquareFootInGTA { get; set; }
        public decimal RowHousingPricePerSquareFootInGTA { get; set; }
        public decimal CondoPricePerSquareFootInGTA { get; set; }
        public decimal TotalPricePerSquareFootInGTA { get; set; }

        public int NoOfLoansDetachedInGTA { get; set; }
        public int NoOfLoansSemiDetachedInGTA { get; set; }
        public int NoOfLoansRowHousingInGTA { get; set; }
        public int NoOfLoansCondoInGTA { get; set; }

        // Ottawa
        public decimal DetachedPricePerSquareFootInOttawa { get; set; }
        public decimal SemiDetachedPricePerSquareFootInOttawa { get; set; }
        public decimal RowHousingPricePerSquareFootInOttawa { get; set; }
        public decimal CondoPricePerSquareFootInOttawa { get; set; }
        public decimal TotalPricePerSquareFootInOttawa { get; set; }

        public int NoOfLoansDetachedInOttawa { get; set; }
        public int NoOfLoansSemiDetachedInOttawa { get; set; }
        public int NoOfLoansRowHousingInOttawa { get; set; }
        public int NoOfLoansCondoInOttawa { get; set; }

        // Golden Horseshoe
        public decimal DetachedPricePerSquareFootInGoldenHorseshoe { get; set; }
        public decimal SemiDetachedPricePerSquareFootInGoldenHorseshoe { get; set; }
        public decimal RowHousingPricePerSquareFootInGoldenHorseshoe { get; set; }
        public decimal CondoPricePerSquareFootInGoldenHorseshoe { get; set; }
        public decimal TotalPricePerSquareFootInGoldenHorseshoe { get; set; }

        public int NoOfLoansDetachedInGoldenHorseshoe { get; set; }
        public int NoOfLoansSemiDetachedInGoldenHorseshoe { get; set; }
        public int NoOfLoansRowHousingInGoldenHorseshoe { get; set; }
        public int NoOfLoansCondoInGoldenHorseshoe { get; set; }

        // Other Major Urban Areas
        public decimal DetachedPricePerSquareFootInOtherMajorUrbanAreas { get; set; }
        public decimal SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas { get; set; }
        public decimal RowHousingPricePerSquareFootInOtherMajorUrbanAreas { get; set; }
        public decimal CondoPricePerSquareFootInOtherMajorUrbanAreas { get; set; }
        public decimal TotalPricePerSquareFootInOtherMajorUrbanAreas { get; set; }

        public int NoOfLoansDetachedInOtherMajorUrbanAreas { get; set; }
        public int NoOfLoansSemiDetachedInOtherMajorUrbanAreas { get; set; }
        public int NoOfLoansRowHousingInOtherMajorUrbanAreas { get; set; }
        public int NoOfLoansCondoInOtherMajorUrbanAreas { get; set; }

        // Total
        public decimal DetachedPricePerSquareFootForAllRegions { get; set; }
        public decimal SemiDetachedPricePerSquareFootForAllRegions { get; set; }
        public decimal RowHousingPricePerSquareFootForAllRegions { get; set; }
        public decimal CondoPricePerSquareFootForAllRegions { get; set; }
        public decimal TotalPricePerSquareFootForAllRegions { get; set; }

        public int NoOfLoansDetachedInAllRegions { get; set; }
        public int NoOfLoansSemiDetachedInAllRegions { get; set; }
        public int NoOfLoansRowHousingInAllRegions { get; set; }
        public int NoOfLoansCondoInAllRegions { get; set; }

        // *** Remaining Term to Maturity Summary ***
        // <= 6
        public int NoOfLoansRemainingTermtoMaturityLessEqual6 { get; set; }
        public decimal PrincipalBalanceRemainingTermtoMaturityLessEqual6 { get; set; }
        public decimal PctOfAUMRemainingTermtoMaturityLessEqual6 { get; set; }
        // > 6 - 9
        public int NoOfLoansRemainingTermtoMaturity6To9 { get; set; }
        public decimal PrincipalBalanceRemainingTermtoMaturity6To9 { get; set; }
        public decimal PctOfAUMRemainingTermtoMaturity6To9 { get; set; }
        // > 9 - 12
        public int NoOfLoansRemainingTermtoMaturity9To12 { get; set; }
        public decimal PrincipalBalanceRemainingTermtoMaturity9To12 { get; set; }
        public decimal PctOfAUMRemainingTermtoMaturity9To12 { get; set; }
        // > 12
        public int NoOfLoansRemainingTermtoMaturityMoreThan12 { get; set; }
        public decimal PrincipalBalanceRemainingTermtoMaturityMoreThan12 { get; set; }
        public decimal PctOfAUMRemainingTermtoMaturityMoreThan12 { get; set; }

        // *** Portfolio Summary by LTV ***
        // > 80%
        public int NoOfLoansPortfolioByLTVMoreThan80 { get; set; }
        public decimal PrincipalBalancePortfolioByLTVMoreThan80 { get; set; }
        public decimal PctOfAUMPortfolioByLTVMoreThan80 { get; set; }
        // > 75% - 80%
        public int NoOfLoansPortfolioByLTV75To80 { get; set; }
        public decimal PrincipalBalancePortfolioByLTV75To80 { get; set; }
        public decimal PctOfAUMPortfolioByLTV75To80 { get; set; }
        // > 65% - 75%
        public int NoOfLoansPortfolioByLTV65To75 { get; set; }
        public decimal PrincipalBalancePortfolioByLTV65To75 { get; set; }
        public decimal PctOfAUMPortfolioByLTV65To75 { get; set; }
        // ≤ 65%
        public int NoOfLoansPortfolioByLTVLessEqual65 { get; set; }
        public decimal PrincipalBalancePortfolioByLTVLessEqual65 { get; set; }
        public decimal PctOfAUMPortfolioByLTVLessEqual65 { get; set; }

        public List<UserData> userDatas { get; set; }
        // Price per Square Foot
        public int GetNoOfLoansTotalInGTA()
        {
            return NoOfLoansDetachedInGTA + NoOfLoansSemiDetachedInGTA + NoOfLoansRowHousingInGTA + NoOfLoansCondoInGTA;
        }

        public int GetNoOfLoansTotalInOttawa()
        {
            return NoOfLoansDetachedInOttawa + NoOfLoansSemiDetachedInOttawa + NoOfLoansRowHousingInOttawa + NoOfLoansCondoInOttawa;
        }

        public int GetNoOfLoansTotalInGoldenHorseshoe()
        {
            return NoOfLoansDetachedInGoldenHorseshoe + NoOfLoansSemiDetachedInGoldenHorseshoe + NoOfLoansRowHousingInGoldenHorseshoe + NoOfLoansCondoInGoldenHorseshoe;
        }

        public int GetNoOfLoansTotalInOtherMajorUrbanAreas()
        {
            return NoOfLoansDetachedInOtherMajorUrbanAreas + NoOfLoansSemiDetachedInOtherMajorUrbanAreas + NoOfLoansRowHousingInOtherMajorUrbanAreas + NoOfLoansCondoInOtherMajorUrbanAreas;
        }

        public int GetNoOfLoansTotalInAllRegions()
        {
            return NoOfLoansDetachedInAllRegions + NoOfLoansSemiDetachedInAllRegions + NoOfLoansRowHousingInAllRegions + NoOfLoansCondoInAllRegions;
        }

        // Portfolio by LTV
        public int GetTotalNoOfLoansPortfolioByLTV()
        {
            return NoOfLoansPortfolioByLTVMoreThan80 + NoOfLoansPortfolioByLTV75To80 + NoOfLoansPortfolioByLTV65To75 + NoOfLoansPortfolioByLTVLessEqual65;
        }

        public decimal GetTotalPrincipalBalancePortfolioByLTV()
        {
            return PrincipalBalancePortfolioByLTVMoreThan80 + PrincipalBalancePortfolioByLTV75To80 + PrincipalBalancePortfolioByLTV65To75 + PrincipalBalancePortfolioByLTVLessEqual65;
        }

        public decimal GetTotalPctOfAUMPortfolioByLTV()
        {
            return PctOfAUMPortfolioByLTVMoreThan80 + PctOfAUMPortfolioByLTV75To80 + PctOfAUMPortfolioByLTV65To75 + PctOfAUMPortfolioByLTVLessEqual65;
        }

        public int GetTotalNoOfLoansRemainingTermtoMaturity()
        {
            return NoOfLoansRemainingTermtoMaturityLessEqual6 + NoOfLoansRemainingTermtoMaturity6To9 + NoOfLoansRemainingTermtoMaturity9To12 + NoOfLoansRemainingTermtoMaturityMoreThan12;
        }

        public decimal GetTotalPrincipalBalanceRemainingTermtoMaturity()
        {
            return PrincipalBalanceRemainingTermtoMaturityLessEqual6 + PrincipalBalanceRemainingTermtoMaturity6To9 + PrincipalBalanceRemainingTermtoMaturity9To12 + PrincipalBalanceRemainingTermtoMaturityMoreThan12;
        }

        public decimal GetTotalPctOfAUMRemainingTermtoMaturity()
        {
            return PctOfAUMRemainingTermtoMaturityLessEqual6 + PctOfAUMRemainingTermtoMaturity6To9 + PctOfAUMRemainingTermtoMaturity9To12 + PctOfAUMRemainingTermtoMaturityMoreThan12;
        }

        public int GetTotalNoOfLoansByPriority()
        {
            return NoOfLoansFirst +
                   NoOfLoansSecond +
                   NoOfLoansThird;
        }

        public decimal GetTotalPrincipalBalanceByPriority()
        {
            return PrincipalBalanceFirst +
                   PrincipalBalanceSecond +
                   PrincipalBalanceThird;
        }

        public decimal GetAverageLoanAmountTotal()
        {
            return GetTotalPrincipalBalanceByPriority() / GetTotalNoOfLoansByPriority();
        }
        
        public decimal GetAverageLoanAmountFirst()
        {
            return PrincipalBalanceFirst / NoOfLoansFirst;
        }

        public decimal GetAverageLoanAmountSecond()
        {
            return PrincipalBalanceSecond / NoOfLoansSecond;
        }

        public decimal GetAverageLoanAmountThird()
        {
            return PrincipalBalanceThird / NoOfLoansThird;
        }

        public decimal GetTotalPctOfAUMByPriority()
        {
            return Math.Round(PctOfAUMFirst +
                              PctOfAUMSecond +
                              PctOfAUMThird, 2);
        }

        public int GetTotalNoOfLoansPropertyType()
        {
            return NoOfLoansResidential +
                   NoOfLoansCommercial +
                   NoOfLoansLand +
                   NoOfLoansConstruction +
                   NoOfLoansUncategorized;
        }
            
         public decimal GetTotalPrincipalBalancePropertyType()
        {
            return PrincipalBalanceResidential +
                   PrincipalBalanceCommercial +
                   PrincipalBalanceLand +
                   PrincipalBalanceConstruction +
                   PrincipalBalanceUncategorized;
        }

        public decimal GetTotalPctOfAUMPropertyType()
        {
            return Math.Round(PctOfAUMResidential +
                              PctOfAUMCommercial +
                              PctOfAUMLand +
                              PctOfAUMConstruction +
                              PctOfAUMUncategorized, 2);
        }

        public int GetTotalNoOfLoansByMortgageRegion()
        {
            return NoOfLoansByPostalCodeInGTA +
                   NoOfLoansByPostalCodeInOttawa +
                   NoOfLoansByPostalCodeInGoldenHorseshoe +
                   NoOfLoansByPostalCodeInOtherMajorUrbanAreas;
        }

        public decimal GetTotalPrincipalBalanceByMortgageRegion()
        {
            return PrincipalBalanceByPostalCodeInGTA +
                   PrincipalBalanceByPostalCodeInOttawa +
                   PrincipalBalanceByPostalCodeInGoldenHorseshoe +
                   PrincipalBalanceByPostalCodeInOtherMajorUrbanAreas;
        }

        public decimal GetTotalPctOfAUMByMortgageRegion()
        {
            return Math.Round(PctOfAUMByPostalCodeInGTA +
                              PctOfAUMByPostalCodeInOttawa +
                              PctOfAUMByPostalCodeInGoldenHorseshoe +
                              PctOfAUMByPostalCodeInOtherMajorUrbanAreas, 2);
        }
    }

    public class UserData
    {
        public string Type { get; set; }
        public string Account { get; set; }
        public string LoanAccount { get; set; }
        public string PartnerAccount { get; set; }
        public string EmailAddress { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneCell { get; set; }
        public string IsBothTypeOfUser { get; set; }
    }
}