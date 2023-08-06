using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppSmartView
    {
        public string RecId { get; set; }
        public string GroupId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Filter { get; set; }
        public string CatInc { get; set; }
        public string CatExc { get; set; }
        public string SortBy { get; set; }
        public string Sqlqry { get; set; }
        public bool? Active { get; set; }
        public int? Sequence { get; set; }
        public int? HideFilter { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
