using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class CmoDistribution
    {
        public string RecId { get; set; }
        public string PoolRecId { get; set; }
        public string TrustAccountRecId { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public decimal? PayAmount { get; set; }
        public decimal? Principal { get; set; }
        public decimal? Interest { get; set; }
        public decimal? Penalty { get; set; }
        public decimal? Other { get; set; }
        public decimal? Rollover { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
