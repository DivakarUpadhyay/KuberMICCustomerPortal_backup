using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class RptLetter
    {
        public string RecId { get; set; }
        public int? Category { get; set; }
        public string Description { get; set; }
        public string TemplateName { get; set; }
        public string UserName { get; set; }
        public string Author { get; set; }
        public string Company { get; set; }
        public string Comments { get; set; }
        public int? Technology { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
