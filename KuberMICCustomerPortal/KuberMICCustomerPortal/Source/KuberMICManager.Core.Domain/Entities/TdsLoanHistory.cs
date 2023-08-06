using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsLoanHistory
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string GroupRecId { get; set; }
        public string NsfsourceRecId { get; set; }
        public string ElectronicPaymentRecId { get; set; }
        public int? PayMethod { get; set; }
        public string Reference { get; set; }
        public DateTime? DateRec { get; set; }
        public DateTime? DateDue { get; set; }
        public DateTime? PaidTo { get; set; }
        public decimal? ToInterest { get; set; }
        public decimal? ToPrincipal { get; set; }
        public decimal? ToReserve { get; set; }
        public decimal? ToImpound { get; set; }
        public decimal? ToLateCharge { get; set; }
        public decimal? ToChargesPrin { get; set; }
        public decimal? ToChargesInt { get; set; }
        public decimal? ToPrepay { get; set; }
        public decimal? ToUnpaidInterest { get; set; }
        public decimal? ToUnearnedDiscount { get; set; }
        public decimal? ToBrokerFee { get; set; }
        public decimal? ToLenderFee { get; set; }
        public decimal? ToOtherPayments { get; set; }
        public decimal? ToOtherTaxable { get; set; }
        public decimal? ToOtherTaxFree { get; set; }
        public decimal? ToDefaultInterest { get; set; }
        public decimal? ToPastDue { get; set; }
        public decimal? ToCurrentBill { get; set; }
        public decimal? LateCharge { get; set; }
        public decimal? LoanBalance { get; set; }
        public string Notes { get; set; }
        public string SourceTyp { get; set; }
        public string SourceApp { get; set; }
        public DateTime? AchTransmissionDateTime { get; set; }
        public string AchTransNumber { get; set; }
        public string AchBatchNumber { get; set; }
        public string AchTraceNumber { get; set; }
        public bool? IsProrate { get; set; }
        public DateTime? OldPaidToDate { get; set; }
        public DateTime? OldNextDueDate { get; set; }
        public DateTime? OldPaidOffDate { get; set; }
        public DateTime? OldAchNextDebitDate { get; set; }
        public DateTime? OldCcrdateClose { get; set; }
        public string OldCcraccountStatus { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
