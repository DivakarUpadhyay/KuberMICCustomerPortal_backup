using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsFundingDisb
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string LenderRecId { get; set; }
        public string FundingRecId { get; set; }
        public string PayeeRecId { get; set; }
        public bool? Active { get; set; }
        public decimal? FeePct { get; set; }
        public decimal? FeeAmt { get; set; }
        public decimal? FeeMin { get; set; }
        public int? Source { get; set; }
        public bool? IsServicingFee { get; set; }
        public string Description { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
