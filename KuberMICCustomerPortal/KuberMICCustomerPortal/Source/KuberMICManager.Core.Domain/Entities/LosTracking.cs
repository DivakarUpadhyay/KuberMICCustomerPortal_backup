using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosTracking
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string DocumentName { get; set; }
        public string RequestedFrom { get; set; }
        public string Comments { get; set; }
        public DateTime? DateOrdered { get; set; }
        public DateTime? DateExpected { get; set; }
        public DateTime? DateReceived { get; set; }
        public int? Sequence { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
