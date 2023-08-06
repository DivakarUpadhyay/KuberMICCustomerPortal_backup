using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AsiTransaction
    {
        public string RecId { get; set; }
        public string ParentRecId { get; set; }
        public string OrigRecId { get; set; }
        public int? TransType { get; set; }
        public DateTime? TransDate { get; set; }
        public string TransMemo { get; set; }
        public string ExportGrp { get; set; }
        public DateTime? ExportDate { get; set; }
        public int? Sequence { get; set; }
        public string Reference { get; set; }
        public DateTime? DateRec { get; set; }
        public DateTime? DateDue { get; set; }
        public decimal? Interest { get; set; }
        public decimal? Principal { get; set; }
        public decimal? Reserve { get; set; }
        public decimal? Impound { get; set; }
        public decimal? LateCharge { get; set; }
        public decimal? Charges { get; set; }
        public decimal? Prepay { get; set; }
        public decimal? UnpaidInt { get; set; }
        public decimal? Other { get; set; }
        public decimal? ServFee { get; set; }
        public decimal? Gst { get; set; }
        public decimal? UnearnedDisc { get; set; }
        public decimal? LateChargeAdd { get; set; }
        public decimal? LenderPayable { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
