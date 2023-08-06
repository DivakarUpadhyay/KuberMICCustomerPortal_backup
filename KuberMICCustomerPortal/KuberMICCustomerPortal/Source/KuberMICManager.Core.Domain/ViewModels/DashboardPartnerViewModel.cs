namespace KuberMICManager.Core.Domain.ViewModels
{
    public class DashboardPartnerViewModel
    {
        public int NoOfPartnersWithValidationErrors { get; set; }
        public int NoOfUniqueActiveInvestors { get; set; }
        public decimal TotalInvestmentAmount { get; set; }

        // Account Type
        public int NoOfPartnersGrowth { get; set; }
        public decimal NoOfSharesGrowth { get; set; }
        public decimal InvestmentAmountGrowth { get; set; }
        public decimal PctGrowth { get; set; }

        public int NoOfPartnersIncome { get; set; }
        public decimal NoOfSharesIncome { get; set; }
        public decimal InvestmentAmountIncome { get; set; }
        public decimal PctIncome { get; set; }

        // Investment Type
        // TFSA
        public int NoOfPartnersTFSA { get; set; }
        public decimal NoOfSharesTFSA { get; set; }
        public decimal InvestmentAmountTFSA { get; set; }
        public decimal PctTFSA { get; set; }

        // RRSP
        public int NoOfPartnersRRSP { get; set; }
        public decimal NoOfSharesRRSP { get; set; }
        public decimal InvestmentAmountRRSP { get; set; }
        public decimal PctRRSP { get; set; }

        // RRSPSpousal
        public int NoOfPartnersRRSPSpousal { get; set; }
        public decimal NoOfSharesRRSPSpousal { get; set; }
        public decimal InvestmentAmountRRSPSpousal { get; set; }
        public decimal PctRRSPSpousal { get; set; }

        // LIRA
        public int NoOfPartnersLIRA { get; set; }
        public decimal NoOfSharesLIRA { get; set; }
        public decimal InvestmentAmountLIRA { get; set; }
        public decimal PctLIRA { get; set; }

        // LRSP
        public int NoOfPartnersLRSP { get; set; }
        public decimal NoOfSharesLRSP { get; set; }
        public decimal InvestmentAmountLRSP { get; set; }
        public decimal PctLRSP { get; set; }

        // RESPFamily
        public int NoOfPartnersRESPFamily { get; set; }
        public decimal NoOfSharesRESPFamily { get; set; }
        public decimal InvestmentAmountRESPFamily { get; set; }
        public decimal PctRESPFamily { get; set; }

        // RLSP
        public int NoOfPartnersRLSP { get; set; }
        public decimal NoOfSharesRLSP { get; set; }
        public decimal InvestmentAmountRLSP { get; set; }
        public decimal PctRLSP { get; set; }

        // LIF
        public int NoOfPartnersLIF { get; set; }
        public decimal NoOfSharesLIF { get; set; }
        public decimal InvestmentAmountLIF { get; set; }
        public decimal PctLIF { get; set; }

        // NewLIF
        public int NoOfPartnersNewLIF { get; set; }
        public decimal NoOfSharesNewLIF { get; set; }
        public decimal InvestmentAmountNewLIF { get; set; }
        public decimal PctNewLIF { get; set; }

        // RLIF
        public int NoOfPartnersRLIF { get; set; }
        public decimal NoOfSharesRLIF { get; set; }
        public decimal InvestmentAmountRLIF { get; set; }
        public decimal PctRLIF { get; set; }

        // RRIF
        public int NoOfPartnersRRIF { get; set; }
        public decimal NoOfSharesRRIF { get; set; }
        public decimal InvestmentAmountRRIF { get; set; }
        public decimal PctRRIF { get; set; }

        // RRIFSpousal
        public int NoOfPartnersRRIFSpousal { get; set; }
        public decimal NoOfSharesRRIFSpousal { get; set; }
        public decimal InvestmentAmountRRIFSpousal { get; set; }
        public decimal PctRRIFSpousal { get; set; }

        // NonRegisteredIndividual
        public int NoOfPartnersNonRegisteredIndividual { get; set; }
        public decimal NoOfSharesNonRegisteredIndividual { get; set; }
        public decimal InvestmentAmountNonRegisteredIndividual { get; set; }
        public decimal PctNonRegisteredIndividual { get; set; }

        // NonRegisteredCompany
        public int NoOfPartnersNonRegisteredCompany { get; set; }
        public decimal NoOfSharesNonRegisteredCompany { get; set; }
        public decimal InvestmentAmountNonRegisteredCompany { get; set; }
        public decimal PctNonRegisteredCompany { get; set; }

        // NonRegisteredJTWROS
        public int NoOfPartnersNonRegisteredJTWROS { get; set; }
        public decimal NoOfSharesNonRegisteredJTWROS { get; set; }
        public decimal InvestmentAmountNonRegisteredJTWROS { get; set; }
        public decimal PctNonRegisteredJTWROS { get; set; }

        public int GetTotalNoOfPartnersForAccountType()
        {
            return NoOfPartnersGrowth + NoOfPartnersIncome;
        }

        public decimal GetTotalNoOfSharesForAccountType()
        {
            return NoOfSharesGrowth + NoOfSharesIncome;
        }

        public decimal GetTotalInvestmentAmountForAccountType()
        {
            return InvestmentAmountGrowth + InvestmentAmountIncome;
        }

        public decimal GetTotalPctForAccountType()
        {
            return PctGrowth + PctIncome;
        }

        public int GetTotalNoOfPartnersForInvestmentType()
        {
            return NoOfPartnersTFSA +
                   NoOfPartnersRRSP +
                   NoOfPartnersRRSPSpousal +
                   NoOfPartnersLIRA +
                   NoOfPartnersLRSP +
                   NoOfPartnersRESPFamily +
                   NoOfPartnersRLSP +
                   NoOfPartnersLIF +
                   NoOfPartnersNewLIF +
                   NoOfPartnersRLIF +
                   NoOfPartnersRRIF +
                   NoOfPartnersRRIFSpousal +
                   NoOfPartnersNonRegisteredIndividual +
                   NoOfPartnersNonRegisteredCompany +
                   NoOfPartnersNonRegisteredJTWROS;
        }

        public decimal GetTotalNoOfSharesForInvestmentType()
        {
            return NoOfSharesTFSA +
                   NoOfSharesRRSP +
                   NoOfSharesRRSPSpousal +
                   NoOfSharesLIRA +
                   NoOfSharesLRSP +
                   NoOfSharesRESPFamily +
                   NoOfSharesRLSP +
                   NoOfSharesLIF +
                   NoOfSharesNewLIF +
                   NoOfSharesRLIF +
                   NoOfSharesRRIF +
                   NoOfSharesRRIFSpousal +
                   NoOfSharesNonRegisteredIndividual +
                   NoOfSharesNonRegisteredCompany +
                   NoOfSharesNonRegisteredJTWROS;
        }

        public decimal GetTotalInvestmentAmountForInvestmentType()
        {
            return InvestmentAmountTFSA +
                   InvestmentAmountRRSP +
                   InvestmentAmountRRSPSpousal +
                   InvestmentAmountLIRA +
                   InvestmentAmountLRSP +
                   InvestmentAmountRESPFamily +
                   InvestmentAmountRLSP +
                   InvestmentAmountLIF +
                   InvestmentAmountNewLIF +
                   InvestmentAmountRLIF +
                   InvestmentAmountRRIF +
                   InvestmentAmountRRIFSpousal +
                   InvestmentAmountNonRegisteredIndividual +
                   InvestmentAmountNonRegisteredCompany +
                   InvestmentAmountNonRegisteredJTWROS;
        }

        public decimal GetTotalPctForInvestmentType()
        {
            return PctTFSA +
                   PctRRSP +
                   PctRRSPSpousal +
                   PctLIRA +
                   PctLRSP +
                   PctRESPFamily +
                   PctRLSP +
                   PctLIF +
                   PctNewLIF +
                   PctRLIF +
                   PctRRIF +
                   PctRRIFSpousal +
                   PctNonRegisteredIndividual +
                   PctNonRegisteredCompany +
                   PctNonRegisteredJTWROS;
        }
    }
}