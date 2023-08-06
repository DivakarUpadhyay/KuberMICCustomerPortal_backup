using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsIdd
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string VendorRecId { get; set; }
        public decimal? PctOwn { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
