using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppNotification
    {
        public string RecId { get; set; }
        public string UserRecId { get; set; }
        public int? NotificationType { get; set; }
        public bool? Email { get; set; }
        public bool? Sms { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
