using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class ConVoucher
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string LoanHistRecId { get; set; }
        public string VendorRecId { get; set; }
        public string VendorHistRecId { get; set; }
        public string ReversalRecId { get; set; }
        public string GroupRecId { get; set; }
        public DateTime? PayDate { get; set; }
        public string Reference { get; set; }
        public string Memo { get; set; }
        public string Notes { get; set; }
        public bool? IsHold { get; set; }
        public bool? IsVoid { get; set; }
        public bool? IsJointCheck { get; set; }
        public bool? IsPaidByOther { get; set; }
        public DateTime? AchTransmissionDateTime { get; set; }
        public string AchTransNumber { get; set; }
        public string AchBatchNumber { get; set; }
        public string AchTraceNumber { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
