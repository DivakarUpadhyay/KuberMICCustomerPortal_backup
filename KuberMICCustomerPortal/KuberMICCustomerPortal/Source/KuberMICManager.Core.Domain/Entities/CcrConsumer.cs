using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class CcrConsumer
    {
        public string RecId { get; set; }
        public string ParentRecId { get; set; }
        public bool? Report { get; set; }
        public bool? AutoSynch { get; set; }
        public string CycleIdentifier { get; set; }
        public string PortfolioType { get; set; }
        public string AccountType { get; set; }
        public string AccountStatus { get; set; }
        public string ComplianceCode { get; set; }
        public string TransactionType { get; set; }
        public string ConsumerIndicator { get; set; }
        public string Ecoa { get; set; }
        public string SpecialComment { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateClose { get; set; }
        public bool? Primary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string GenerationCode { get; set; }
        public string Ssn { get; set; }
        public DateTime? Dob { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string AddressIndicator { get; set; }
        public string ResidenceCode { get; set; }
        public bool? EmploymentReport { get; set; }
        public string EmployerName { get; set; }
        public string EmployerAddr1 { get; set; }
        public string EmployerAddr2 { get; set; }
        public string EmployerCity { get; set; }
        public string EmployerState { get; set; }
        public string EmployerZipCode { get; set; }
        public string EmployerOccupation { get; set; }
        public string PaymentRating { get; set; }
        public string PaymentProfile { get; set; }
        public decimal? OriginalChargeOffAmount { get; set; }
        public DateTime? DateFirstDelinquency { get; set; }
        public DateTime? DateLastReportRun { get; set; }
        public DateTime? DateLastReported { get; set; }
        public string OrigCreditor { get; set; }
        public string OrigCreditorClassification { get; set; }
        public string L1OldAccount { get; set; }
        public DateTime? L1AccountDateChanged { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
