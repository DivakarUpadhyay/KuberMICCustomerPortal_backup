using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppConversation
    {
        public string RecId { get; set; }
        public string ParentRecId { get; set; }
        public int? ParentType { get; set; }
        public DateTime? CallDate { get; set; }
        public int? CallType { get; set; }
        public string CallPerson { get; set; }
        public string Subject { get; set; }
        public string MemoText { get; set; }
        public bool? FollowUp { get; set; }
        public string FollowUpName { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public bool? Completed { get; set; }
        public string CompletedName { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreatedName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ChangedName { get; set; }
        public DateTime? ChangedLast { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
        public bool? Publish { get; set; }
    }
}
