using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosTbill
    {
        public string RecId { get; set; }
        public DateTime? DatePublished { get; set; }
        public decimal? Year1 { get; set; }
        public decimal? Year2 { get; set; }
        public decimal? Year3 { get; set; }
        public decimal? Year5 { get; set; }
        public decimal? Year7 { get; set; }
        public decimal? Year10 { get; set; }
        public decimal? Year20 { get; set; }
        public decimal? Year30 { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
