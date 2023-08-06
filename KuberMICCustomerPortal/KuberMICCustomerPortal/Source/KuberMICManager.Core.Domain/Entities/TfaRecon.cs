using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TfaRecon
    {
        public string RecId { get; set; }
        public string AccountRecId { get; set; }
        public decimal? AccountBalance { get; set; }
        public DateTime? ReconDate { get; set; }
        public DateTime? BankOpeningDate { get; set; }
        public DateTime? BankClosingDate { get; set; }
        public decimal? BankOpeningBalance { get; set; }
        public decimal? BankClosingBalance { get; set; }
        public decimal? OutstandingDeposits { get; set; }
        public decimal? OutstandingChecks { get; set; }
        public int? OutstandingDepositsCount { get; set; }
        public int? OutstandingChecksCount { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
