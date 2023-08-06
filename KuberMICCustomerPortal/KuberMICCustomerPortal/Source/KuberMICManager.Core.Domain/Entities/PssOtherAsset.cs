using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssOtherAsset
    {
        public string RecId { get; set; }
        public string PartnershipRecId { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public decimal? AssetValue { get; set; }
        public decimal? AppreciationRate { get; set; }
        public DateTime? DateLastEvaluated { get; set; }
        public int? AssetType { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
