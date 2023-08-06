using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsModification
    {
        public string RecId { get; set; }
        public string ParentRecId { get; set; }
        public string IndexRecId { get; set; }
        public string GroupId { get; set; }
        public int? Sequence { get; set; }
        public int? EntryStatus { get; set; }
        public int? EntrySource { get; set; }
        public int? EntryType { get; set; }
        public DateTime? AdjustmentDate { get; set; }
        public DateTime? RateChangeDate { get; set; }
        public DateTime? PaymentAdjDate { get; set; }
        public DateTime? AppliedDate { get; set; }
        public int? AppliedFrom { get; set; }
        public bool? NotifyBorrower { get; set; }
        public DateTime? LetterSentDate { get; set; }
        public decimal? ProjectedBalance { get; set; }
        public decimal? FullyAmortizedPi { get; set; }
        public decimal? InterestOnlyPi { get; set; }
        public bool? IsInterestOnly { get; set; }
        public bool? PaymentWasRecasted { get; set; }
        public int? MonthsToMaturity { get; set; }
        public bool? DefaultRateStatus { get; set; }
        public decimal? NewCarryover { get; set; }
        public decimal? NewIndexRate { get; set; }
        public decimal? NewNoteRate { get; set; }
        public decimal? NewSoldRate { get; set; }
        public decimal? NewPaymentPi { get; set; }
        public decimal? NewPaymentReserve { get; set; }
        public decimal? NewPaymentImpound { get; set; }
        public decimal? NewPaymentAmount { get; set; }
        public DateTime? NewNextRateChange { get; set; }
        public DateTime? NewNextPaymentAdj { get; set; }
        public DateTime? NewNextRecastDate { get; set; }
        public int? OldAmortType { get; set; }
        public decimal? OldNoteRate { get; set; }
        public decimal? OldSoldRate { get; set; }
        public bool? OldUseSoldRate { get; set; }
        public decimal? OldPaymentAmount { get; set; }
        public decimal? OldPaymentPi { get; set; }
        public decimal? OldPaymentReserve { get; set; }
        public decimal? OldPaymentImpound { get; set; }
        public decimal? OldOriginalBalance { get; set; }
        public decimal? OldPrincipalBalance { get; set; }
        public DateTime? OldMaturityDate { get; set; }
        public decimal? OldIndexRate { get; set; }
        public decimal? OldMargin { get; set; }
        public decimal? OldCeiling { get; set; }
        public decimal? OldFloor { get; set; }
        public bool? OldRateFirstChgActive { get; set; }
        public decimal? OldRateMinCap { get; set; }
        public decimal? OldRateMaxCap { get; set; }
        public int? OldRateChangeFreq { get; set; }
        public DateTime? OldRateChangeNext { get; set; }
        public decimal? OldRateRoundFactor { get; set; }
        public int? OldRateRounding { get; set; }
        public bool? OldSendRateChangeNotice { get; set; }
        public int? OldNoticeLeadDays { get; set; }
        public bool? OldCarryoverEnabled { get; set; }
        public decimal? OldCarryoverAmount { get; set; }
        public int? OldLookBackDays { get; set; }
        public bool? OldPaymentAdjustment { get; set; }
        public decimal? OldPaymentCap { get; set; }
        public int? OldPaymentChangeFreq { get; set; }
        public DateTime? OldPaymentChangeNext { get; set; }
        public decimal? OldNegAmortCap { get; set; }
        public bool? OldRecastPayment { get; set; }
        public int? OldRecastFreq { get; set; }
        public DateTime? OldRecastStopDate { get; set; }
        public DateTime? OldRecastNextDate { get; set; }
        public DateTime? OldRecastToDate { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
