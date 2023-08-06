using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TfaTransaction
    {
        public string RecId { get; set; }
        public string AccountRecId { get; set; }
        public int? EntryType { get; set; }
        public decimal? Amount { get; set; }
        public string Reference { get; set; }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateDeposited { get; set; }
        public string Memo { get; set; }
        public string ClearStatus { get; set; }
        public string PayAccount { get; set; }
        public string PayRecId { get; set; }
        public string PayName { get; set; }
        public string PayAddress { get; set; }
        public string StubMemo { get; set; }
        public string PayeeBox { get; set; }
        public int? SourceApp { get; set; }
        public string SourceRef { get; set; }
        public string SourceGrp { get; set; }
        public string DepositGrp { get; set; }
        public string LinkedRecId { get; set; }
        public string ReconRecId { get; set; }
        public string SortField { get; set; }
        public bool? IsAch { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
