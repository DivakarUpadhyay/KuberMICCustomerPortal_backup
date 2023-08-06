using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class ConCommitment
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string LenderRecId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateExpected { get; set; }
        public DateTime? DateReceived { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
