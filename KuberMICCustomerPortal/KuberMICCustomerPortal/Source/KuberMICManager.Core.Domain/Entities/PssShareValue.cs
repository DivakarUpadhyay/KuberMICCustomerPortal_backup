using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssShareValue
    {
        public string RecId { get; set; }
        public string PartnershipRecId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public decimal? OutstandingShares { get; set; }
        public decimal? ActualPrincipalBalance { get; set; }
        public decimal? ActualInterest { get; set; }
        public decimal? ActualLateCharges { get; set; }
        public decimal? ActualChargesPayable { get; set; }
        public decimal? ActualChargesReceivable { get; set; }
        public decimal? ActualOtherAssets { get; set; }
        public decimal? ActualOtherLiabilities { get; set; }
        public decimal? ActualServicingTrustBalance { get; set; }
        public decimal? ActualCashOnHand { get; set; }
        public decimal? AdjustmentPrincipalBalance { get; set; }
        public decimal? AdjustmentInterest { get; set; }
        public decimal? AdjustmentLateCharges { get; set; }
        public decimal? AdjustmentChargesPayable { get; set; }
        public decimal? AdjustmentChargesReceivable { get; set; }
        public decimal? AdjustmentOtherAssets { get; set; }
        public decimal? AdjustmentOtherLiabilities { get; set; }
        public decimal? AdjustmentServicingTrustBalance { get; set; }
        public decimal? AdjustmentCashOnHand { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
