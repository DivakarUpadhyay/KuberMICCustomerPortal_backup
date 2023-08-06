using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppMailingLabel
    {
        public string RecId { get; set; }
        public string Name { get; set; }
        public int? UnitOfMeasure { get; set; }
        public int? LabelType { get; set; }
        public int? Orientation { get; set; }
        public int? NumberAcross { get; set; }
        public int? NumberDown { get; set; }
        public string FontName { get; set; }
        public decimal? FontSize { get; set; }
        public bool? FontItalic { get; set; }
        public bool? FontBold { get; set; }
        public bool? UpperCase { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? TopMargin { get; set; }
        public decimal? LeftMargin { get; set; }
        public decimal? RightMargin { get; set; }
        public decimal? TextTopMargin { get; set; }
        public decimal? TextLeftMargin { get; set; }
        public decimal? GapHorizontal { get; set; }
        public decimal? GapVertical { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
