using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsCharge
    {
        public string RecId { get; set; }
        public string ParentRecId { get; set; }
        public string OwedToRecId { get; set; }
        public string OwedByRecId { get; set; }
        public string GroupRecId { get; set; }
        public DateTime? ChargeDate { get; set; }
        public string Reference { get; set; }
        public decimal? OrigAmt { get; set; }
        public decimal? OwedToBal { get; set; }
        public decimal? OwedByBal { get; set; }
        public decimal? IntRate { get; set; }
        public DateTime? IntFrom { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public bool? Deferred { get; set; }
        public bool? AssessFinanceCharges { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
