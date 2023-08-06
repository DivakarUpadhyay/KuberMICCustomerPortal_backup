using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class UdfField
    {
        public string RecId { get; set; }
        public string TabRecId { get; set; }
        public int? OwnerType { get; set; }
        public string Name { get; set; }
        public int? DataType { get; set; }
        public string Format { get; set; }
        public string PickList { get; set; }
        public int? Sequence { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
