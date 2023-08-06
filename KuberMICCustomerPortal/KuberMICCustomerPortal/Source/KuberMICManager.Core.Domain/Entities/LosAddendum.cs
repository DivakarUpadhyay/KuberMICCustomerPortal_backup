using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosAddendum
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public int? Sequence { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
