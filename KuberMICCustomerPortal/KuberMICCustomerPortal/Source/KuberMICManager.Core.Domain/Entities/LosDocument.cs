using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosDocument
    {
        public string RecId { get; set; }
        public string DocId { get; set; }
        public int? Sequence { get; set; }
        public bool? Active { get; set; }
        public string Description { get; set; }
        public string TemplateName { get; set; }
        public int? Copies { get; set; }
        public string Notes { get; set; }
        public int? Technology { get; set; }
        public int? ShowDialog { get; set; }
        public bool? IsGroup { get; set; }
        public string Xml { get; set; }
        public bool? SystemCreated { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
