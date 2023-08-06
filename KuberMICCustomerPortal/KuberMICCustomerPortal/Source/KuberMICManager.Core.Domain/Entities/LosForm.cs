using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosForm
    {
        public string RecId { get; set; }
        public string DocId { get; set; }
        public int? Sequence { get; set; }
        public bool? Active { get; set; }
        public string FormName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string LinkedDocument { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
