using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class WpcLoanApplication
    {
        public string RecId { get; set; }
        public string Xml { get; set; }
        public int? ReferenceNumber { get; set; }
        public DateTime? DateApplied { get; set; }
        public int? Status { get; set; }
        public string OnlineStatus { get; set; }
        public DateTime? StatusDate { get; set; }
        public string Notes { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? LastMessageCheckDate { get; set; }
    }
}
