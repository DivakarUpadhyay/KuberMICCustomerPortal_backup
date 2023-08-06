using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosLoan
    {
        public string RecId { get; set; }
        public string DocId { get; set; }
        public string UserAccess { get; set; }
        public string LoanNumber { get; set; }
        public string EscrowNumber { get; set; }
        public string ShortName { get; set; }
        public string LoanStatus { get; set; }
        public DateTime? DateLoanCreated { get; set; }
        public DateTime? DateLoanClosed { get; set; }
        public DateTime? ExpectedClosingDate { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string LoanOfficer { get; set; }
        public string Categories { get; set; }
        public decimal? LoanAmount { get; set; }
        public int? Ppy { get; set; }
        public int? AmortType { get; set; }
        public int? AmortTerm { get; set; }
        public int? Term { get; set; }
        public DateTime? FundingDate { get; set; }
        public DateTime? FirstPaymentDate { get; set; }
        public DateTime? MaturityDate { get; set; }
        public bool? IsStepRate { get; set; }
        public decimal? NoteRate { get; set; }
        public decimal? SoldRate { get; set; }
        public int? PrepaidPayments { get; set; }
        public int? OddFirstPeriodHandling { get; set; }
        public int? DailyRateBasis { get; set; }
        public decimal? BrokerFeePct { get; set; }
        public decimal? BrokerFeeFlat { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsTemplate { get; set; }
        public bool? CalculateFinalPayment { get; set; }
        public int? FinalActionTaken { get; set; }
        public DateTime? FinalActionDate { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
