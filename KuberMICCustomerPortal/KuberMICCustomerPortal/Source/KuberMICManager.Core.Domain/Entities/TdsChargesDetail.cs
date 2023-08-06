using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsChargesDetail
    {
        public string RecId { get; set; }
        public string ParentRecId { get; set; }
        public string LoanRecId { get; set; }
        public string PaidByRecId { get; set; }
        public string PmtGroupRecId { get; set; }
        public int? TransType { get; set; }
        public DateTime? TransDate { get; set; }
        public string Reference { get; set; }
        public decimal? PaidOwedToBal { get; set; }
        public decimal? PaidOwedToInt { get; set; }
        public decimal? PaidOwedByBal { get; set; }
        public decimal? PaidOwedByInt { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
