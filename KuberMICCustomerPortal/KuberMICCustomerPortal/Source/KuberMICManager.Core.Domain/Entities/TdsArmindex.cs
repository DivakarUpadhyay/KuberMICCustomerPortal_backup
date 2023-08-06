using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsArmindex
    {
        public string RecId { get; set; }
        public string Name { get; set; }
        public string PublishFrequency { get; set; }
        public string SourceOfInformation { get; set; }
        public string OtherAdjustments { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool? LinkedIndex { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
