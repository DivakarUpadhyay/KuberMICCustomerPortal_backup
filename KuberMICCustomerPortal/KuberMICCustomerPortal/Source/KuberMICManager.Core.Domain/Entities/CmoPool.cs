using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class CmoPool
    {
        public string RecId { get; set; }
        public string LenderRecId { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
        public int? BusinessModel { get; set; }
        public DateTime? InceptionDate { get; set; }
        public string Tin { get; set; }
        public decimal? ContributionLimit { get; set; }
        public int? TermLimit { get; set; }
        public decimal? ErisaMaxPct { get; set; }
        public string CertPrefix { get; set; }
        public int? CertNumber { get; set; }
        public string CertSuffix { get; set; }
        public int? CertDigits { get; set; }
        public bool? CertZeroFill { get; set; }
        public string CertTemplate { get; set; }
        public bool? CertPrepayUse { get; set; }
        public int? CertPrepayMon { get; set; }
        public decimal? CertPrepayPct { get; set; }
        public decimal? CertPrepayFee { get; set; }
        public decimal? CertPrepayMin { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
