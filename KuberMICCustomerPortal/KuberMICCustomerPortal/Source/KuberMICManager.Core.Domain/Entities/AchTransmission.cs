using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AchTransmission
    {
        public string RecId { get; set; }
        public string TransNumber { get; set; }
        public int? FileType { get; set; }
        public int? FileFormat { get; set; }
        public string FileText { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? TransmissionDate { get; set; }
        public int? TransmissionMode { get; set; }
        public decimal? TotalDebits { get; set; }
        public decimal? TotalCredits { get; set; }
        public int? BatchCount { get; set; }
        public int? EntryCount { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
        public string TrustAccountRecId { get; set; }
    }
}
