namespace KuberMICManager.Core.Domain.ViewModels
{
    public class MortgageRateCalculatorModel
    {
        public decimal BMOPrimeInterstRate { get; set; }
        public decimal BMOSpread { get; set; }
        public decimal BMOResidentialLMaxLimitPerLoan { get; set; }
        public int BMOQualifiedAmountLTVLimitInPercent { get; set; }
        public decimal PreferredSharesTargetRateClassA { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal AppraisalValue { get; set; }
        public bool MortgageIsPurchase { get; set; }
        public bool MortgageAmountIsPurchasePrice { get; set; }
        public int LTV { get; set; }

        public decimal GetBBCRate()
        {
            return BMOPrimeInterstRate + BMOSpread;
        }

        public decimal GetActualMortgageAmount()
        {
            decimal price = AppraisalValue;
            if (MortgageAmountIsPurchasePrice && MortgageIsPurchase)
                price = PurchasePrice;

            return price * LTV / 100;
        }

        public decimal GetMortgageAmount()
        {
            decimal lowerPrice = AppraisalValue;
            if (MortgageIsPurchase && AppraisalValue > PurchasePrice)
                lowerPrice = PurchasePrice;

            return lowerPrice * BMOQualifiedAmountLTVLimitInPercent / 100;
        }

        public decimal GetEligibleMortgageAmount()
        {
            // LTV <= 50, eligible amount is 80% of qualified mortgage amount
            // All else, 75% of qualified mortgage amount

            decimal eligiblePercent = LTV <= 50 ? (decimal)0.8 : (decimal)0.75;

            decimal eligibleMortgageAmount = GetQualifiedMortgageAmount() * eligiblePercent;

            if (GetMortgageAmount() < eligibleMortgageAmount)
                eligibleMortgageAmount = GetMortgageAmount();

            return eligibleMortgageAmount;
        }

        public decimal GetIneligibleMortgageAmount()
        {
            return GetActualMortgageAmount() - GetEligibleMortgageAmount();
        }

        public decimal GetQualifiedMortgageAmount()
        {
            return (GetMortgageAmount() < BMOResidentialLMaxLimitPerLoan) ? GetMortgageAmount() : BMOResidentialLMaxLimitPerLoan;
        }

        public decimal GetEffectiveCostOfCapital()
        {
            return (GetActualMortgageAmount() > 0 ? (GetEligibleMortgageAmount() / GetActualMortgageAmount()) * GetBBCRate() / 100 + (GetIneligibleMortgageAmount() / GetActualMortgageAmount()) * PreferredSharesTargetRateClassA / 100 : 0) * 100;
        }
    }
}