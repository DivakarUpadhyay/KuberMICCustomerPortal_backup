using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosMcr
    {
        public string RecId { get; set; }
        public string State { get; set; }
        public int? PeriodYear { get; set; }
        public int? PeriodQuarter { get; set; }
        public string Status { get; set; }
        public string ReportType { get; set; }
        public string Xml { get; set; }
        public DateTime? LastExportDate { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
