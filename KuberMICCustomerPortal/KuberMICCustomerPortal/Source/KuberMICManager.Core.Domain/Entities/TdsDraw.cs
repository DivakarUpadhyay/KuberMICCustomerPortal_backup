using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsDraw
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string LenderRecId { get; set; }
        public string FundingRecId { get; set; }
        public string GroupRecId { get; set; }
        public int? DrawType { get; set; }
        public DateTime? TransDate { get; set; }
        public string Reference { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Fee { get; set; }
        public string Notes { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
