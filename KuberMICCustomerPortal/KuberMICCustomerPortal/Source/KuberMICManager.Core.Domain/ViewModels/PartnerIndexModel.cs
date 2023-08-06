using KuberMICManager.Core.Domain.Entities;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class PartnerIndexModel
    {
        public PssPartner Partner { get; set; }
        public string PoolAccount { get; set; }
        public decimal SharePrice { get; set; }
        public decimal RedeemedCertificateShareTotal { get; set; }
        public decimal TotalShares { get; set; }
        public decimal TotalInvestmentAmount { get; set; }
        public string SearchString { get; set; }
    }
}