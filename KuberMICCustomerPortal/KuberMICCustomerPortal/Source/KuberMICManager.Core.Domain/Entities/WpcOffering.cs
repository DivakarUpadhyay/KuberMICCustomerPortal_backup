using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class WpcOffering
    {
        public string RecId { get; set; }
        public string Reference { get; set; }
        public int? Priority { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? NoteRate { get; set; }
        public decimal? SoldRate { get; set; }
        public decimal? RegularPayment { get; set; }
        public int? PaymentsPerYear { get; set; }
        public DateTime? MaturityDate { get; set; }
        public decimal? BalloonPayment { get; set; }
        public decimal? SeniorLiens { get; set; }
        public int? Amortization { get; set; }
        public bool? IsPrepaymentPenalty { get; set; }
        public bool? IsPaymentsCurrent { get; set; }
        public int? PropertyType { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyState { get; set; }
        public string PropertyZipCode { get; set; }
        public decimal? PropertyAnnualTaxes { get; set; }
        public decimal? PropertyUnpaidTaxes { get; set; }
        public decimal? FairMarketValue { get; set; }
        public DateTime? AppraisalDate { get; set; }
        public decimal? LoanToValue { get; set; }
        public bool? IsOwnerOccupied { get; set; }
        public bool? IsIncomeProperty { get; set; }
        public decimal? GrossAnnualIncome { get; set; }
        public decimal? NetAnnualIncome { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public string SalesPersonName { get; set; }
        public string SalesPersonEmail { get; set; }
        public string SalesPersonPhone { get; set; }
        public string SalesPersonFax { get; set; }
        public int? BorrowerCreditRating { get; set; }
        public DateTime? DateFirstPublished { get; set; }
        public DateTime? DateLastPublished { get; set; }
        public bool? IsPublish { get; set; }
        public bool? IsPrivate { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
