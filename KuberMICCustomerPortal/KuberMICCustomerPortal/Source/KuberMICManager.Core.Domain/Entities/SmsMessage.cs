using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class SmsMessage
    {
        public string RecId { get; set; }
        public string RecipientRecId { get; set; }
        public int? RecipientType { get; set; }
        public int? AlertType { get; set; }
        public string PhoneNumber { get; set; }
        public string TextMessage { get; set; }
        public string Sid { get; set; }
        public string Status { get; set; }
        public string ErrorText { get; set; }
        public int? ErrorCode { get; set; }
        public string ToNumber { get; set; }
        public string FromNumber { get; set; }
        public int? Segments { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? LastFetch { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
