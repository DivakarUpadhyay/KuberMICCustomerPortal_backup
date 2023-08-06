using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosField
    {
        public string RecId { get; set; }
        public string Fid { get; set; }
        public string Description { get; set; }
        public int? DataType { get; set; }
        public int? MaxLength { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public string MatchString { get; set; }
        public int? AcceptOnly { get; set; }
        public int? TextCase { get; set; }
        public string DisplayMask { get; set; }
        public int? DecimalPlaces { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
