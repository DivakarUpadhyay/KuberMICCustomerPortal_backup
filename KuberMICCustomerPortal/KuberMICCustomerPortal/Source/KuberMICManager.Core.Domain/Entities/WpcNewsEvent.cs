using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class WpcNewsEvent
    {
        public string RecId { get; set; }
        public DateTime? DatePublished { get; set; }
        public string Heading { get; set; }
        public string Subject { get; set; }
        public string Article { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
