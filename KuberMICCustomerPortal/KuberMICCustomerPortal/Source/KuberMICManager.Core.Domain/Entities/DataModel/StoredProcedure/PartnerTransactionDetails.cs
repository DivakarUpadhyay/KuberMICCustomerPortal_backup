using System;
using System.ComponentModel.DataAnnotations;

namespace KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure
{
    public class PartnerTransactionDetails
    {
        [Key]
        public string RecId { get; set; }
        public string PartnershipRecId { get; set; }
        public string PoolAccount { get; set; }
        public string PartnerRecId { get; set; }
        public string PartnerAccount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string SIN { get; set; }
        public string BusinessName { get; set; }
        public string JointPartnerNames { get; set; }
        public int? AccountType { get; set; }
        public string TrusteeAccountType { get; set; }
        public string CertificateRecId { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime? RecDate { get; set; }
        public DateTime? DepDate { get; set; }
        public string Reference { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Shares { get; set; }
        public int? Code { get; set; }
        public string Memo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Notes { get; set; }
        public bool? Drip { get; set; }
        public int? Sequence { get; set; }
        public DateTime? AchTransmissionDateTime { get; set; }
    }
}