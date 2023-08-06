using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsFunding
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string LenderRecId { get; set; }
        public decimal? FundControl { get; set; }
        public decimal? DrawControl { get; set; }
        public decimal? BrokerFeePct { get; set; }
        public decimal? BrokerFeeFlat { get; set; }
        public decimal? BrokerFeeMin { get; set; }
        public string VendorRecId { get; set; }
        public decimal? VendorFeePct { get; set; }
        public decimal? VendorFeeFlat { get; set; }
        public decimal? VendorFeeMin { get; set; }
        public bool? PennyError { get; set; }
        public int? EffRateType { get; set; }
        public decimal? EffRateValue { get; set; }
        public bool? Gstuse { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
