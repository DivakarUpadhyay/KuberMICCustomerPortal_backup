using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TfaAccount
    {
        public string RecId { get; set; }
        public bool? Active { get; set; }
        public string AccountName { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string BankRoutingNumber { get; set; }
        public int? BankAccountType { get; set; }
        public string CurrencyCode { get; set; }
        public bool? IsInterest { get; set; }
        public decimal? PayIntRate { get; set; }
        public int? DailyBasis { get; set; }
        public int? CalcMethod { get; set; }
        public int? CheckStyle { get; set; }
        public int? NextCheckNumber { get; set; }
        public bool? AchUse { get; set; }
        public string Xml { get; set; }
        public decimal? ReconOpeningBalance { get; set; }
        public decimal? ReconClosingBalance { get; set; }
        public DateTime? ReconOpeningDate { get; set; }
        public DateTime? ReconClosingDate { get; set; }
        public DateTime? ReconDate { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
