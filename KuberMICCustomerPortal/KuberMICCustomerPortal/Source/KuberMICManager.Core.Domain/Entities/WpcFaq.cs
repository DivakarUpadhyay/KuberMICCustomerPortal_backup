using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class WpcFaq
    {
        public string RecId { get; set; }
        public string Question { get; set; }
        public string BriefAnswer { get; set; }
        public string FullAnswer { get; set; }
        public int? Sequence { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
