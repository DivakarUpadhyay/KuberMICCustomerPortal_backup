using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class ConInspection
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string VendorRecId { get; set; }
        public DateTime? DateTime { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int? Status { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
