using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppReminder
    {
        public string RecId { get; set; }
        public int? OwnerType { get; set; }
        public string GroupRecId { get; set; }
        public string Notify { get; set; }
        public string Notes { get; set; }
        public int? EventType { get; set; }
        public DateTime? DateDue { get; set; }
        public string LinkTo { get; set; }
        public bool? Completed { get; set; }
        public DateTime? TimeDue { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
