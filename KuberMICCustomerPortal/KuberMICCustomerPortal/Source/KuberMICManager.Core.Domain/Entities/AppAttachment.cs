using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppAttachment
    {
        public string RecId { get; set; }
        public string OwnerRecId { get; set; }
        public int? OwnerType { get; set; }
        public string TabRecId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public bool? ReadOnly { get; set; }
        public int? DocType { get; set; }
        public bool? Publish { get; set; }
        public int? PublishMonth { get; set; }
        public int? PublishYear { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
