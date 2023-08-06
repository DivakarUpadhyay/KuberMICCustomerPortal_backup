using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsLocbilling
    {
        public string RecId { get; set; }
        public string ParentRecId { get; set; }
        public string GroupId { get; set; }
        public DateTime? BillBegDate { get; set; }
        public DateTime? BillEndDate { get; set; }
        public int? BillDays { get; set; }
        public int? BillType { get; set; }
        public int? BillMethod { get; set; }
        public decimal? DailyRate { get; set; }
        public decimal? Apr { get; set; }
        public decimal? BalanceBeg { get; set; }
        public decimal? BalanceEnd { get; set; }
        public decimal? TotalCharges { get; set; }
        public decimal? TotalCredits { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public decimal? PastDuePayment { get; set; }
        public decimal? ReservePayment { get; set; }
        public decimal? ImpoundPayment { get; set; }
        public decimal? OtherPayment { get; set; }
        public decimal? AutoPayFromReserve { get; set; }
        public decimal? CurrentPayment { get; set; }
        public decimal? DeferredAmount { get; set; }
        public decimal? FinanceCharge { get; set; }
        public decimal? AverageDailyBalance { get; set; }
        public decimal? HighestDailyBalance { get; set; }
        public decimal? LowestDailyBalance { get; set; }
        public decimal? MaintenanceFeeAmount { get; set; }
        public decimal? LateChargeAmount { get; set; }
        public decimal? PaymentPi { get; set; }
        public decimal? AdditionalDailyAmount { get; set; }
        public bool? DefaultRateUsed { get; set; }
        public decimal? NextBillDefaultInterestAdj { get; set; }
        public decimal? ThisBillDefaultInterestAdj { get; set; }
        public string ThisBillDefaultInterestAdjRecId { get; set; }
        public string LateChargeRecId { get; set; }
        public string FinanceChargeRecId { get; set; }
        public string ChargesGroupRecId { get; set; }
        public decimal? OldPmtPi { get; set; }
        public decimal? OldAchDebitAmount { get; set; }
        public DateTime? OldPaidToDate { get; set; }
        public DateTime? OldNextDueDate { get; set; }
        public DateTime? OldLocbilledToDate { get; set; }
        public DateTime? OldLocmaintenanceFeeNextDue { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
