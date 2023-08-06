using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class WpcMessage
    {
        public string RecId { get; set; }
        public int? RecipientType { get; set; }
        public int? OriginatorType { get; set; }
        public string Account { get; set; }
        public string RecipientName { get; set; }
        public string OriginatorName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int? Importance { get; set; }
        public DateTime? SentDateTime { get; set; }
        public DateTime? ReceivedDateTime { get; set; }
        public DateTime? ReadDateTime { get; set; }
        public DateTime? RepliedDateTime { get; set; }
        public string RepliedBy { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
