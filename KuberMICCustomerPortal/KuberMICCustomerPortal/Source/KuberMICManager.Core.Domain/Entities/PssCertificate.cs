using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssCertificate
    {
        public string RecId { get; set; }
        public string PartnershipRecId { get; set; }
        public string PartnerRecId { get; set; }
        public string TransferRecId { get; set; }
        public string MasterCertRecId { get; set; }
        public string DistributionRecId { get; set; }
        public string Number { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? TransferDate { get; set; }
        public decimal? GrowthPct { get; set; }
        public DateTime? Maturity { get; set; }
        public int? Status { get; set; }
        public int? SourceType { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
