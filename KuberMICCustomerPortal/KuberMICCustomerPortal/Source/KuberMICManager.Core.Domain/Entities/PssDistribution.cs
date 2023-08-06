using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssDistribution
    {
        public string RecId { get; set; }
        public string PartnershipRecId { get; set; }
        public string TrustAccountRecId { get; set; }
        public DateTime? PeriodBeg { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public decimal? SharesBeg { get; set; }
        public decimal? SharesEnd { get; set; }
        public bool? IsProrateDistribution { get; set; }
        public bool? IsFixedShare { get; set; }
        public bool? IsWholeShares { get; set; }
        public decimal? MinReinvestment { get; set; }
        public decimal? ShareValueBeg { get; set; }
        public decimal? ShareValueEnd { get; set; }
        public decimal? AmountPerShare { get; set; }
        public decimal? GrossDistribution { get; set; }
        public decimal? Holdback { get; set; }
        public decimal? Reinvested { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Adjustment { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
