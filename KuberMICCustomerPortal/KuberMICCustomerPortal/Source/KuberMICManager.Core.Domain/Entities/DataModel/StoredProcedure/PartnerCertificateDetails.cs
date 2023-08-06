using System.ComponentModel.DataAnnotations;

namespace KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure
{
    public class PartnerCertificateDetails
    {
        [Key]
        public string RecId { get; set; }
        public string PartnershipRecId { get; set; }
        public string PartnerRecId { get; set; }
        public string Number { get; set; }
        public int? Status { get; set; }
        public decimal? SharePrice { get; set; }
        public decimal? TotalShares { get; set; }
        public decimal? TotalInvestmentAmount { get; set; }
        public decimal? RedeemedCertificateShareTotal { get; set; }
    }
}
