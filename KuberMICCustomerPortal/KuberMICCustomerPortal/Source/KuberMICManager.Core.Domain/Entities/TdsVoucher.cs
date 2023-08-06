using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsVoucher
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string PayeeRecId { get; set; }
        public DateTime? PayDate { get; set; }
        public decimal? Amount { get; set; }
        public int? Frequency { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public bool? IsHold { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsDiscretionary { get; set; }
        public int? PayeeType { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
