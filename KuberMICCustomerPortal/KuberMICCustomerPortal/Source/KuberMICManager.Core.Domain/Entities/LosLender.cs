using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosLender
    {
        public string RecId { get; set; }
        public string Account { get; set; }
        public string SortName { get; set; }
        public string ByLastName { get; set; }
        public string FullName { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string Mi { get; set; }
        public string LastName { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneFax { get; set; }
        public int? PhoneMain { get; set; }
        public string Tin { get; set; }
        public DateTime? Dob { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string EmailAddress { get; set; }
        public int? EmailFormat { get; set; }
        public int? DeliveryOptions { get; set; }
        public string LegalVesting { get; set; }
        public bool? MultipleSignators { get; set; }
        public DateTime? InvestorSuitabilitySent { get; set; }
        public DateTime? InvestorSuitabilityReceived { get; set; }
        public DateTime? InvestorSuitabilityApprovedOn { get; set; }
        public string InvestorSuitabilityApprovedBy { get; set; }
        public string InvestorSuitabilityRecId { get; set; }
        public bool? Institutional { get; set; }
        public bool? LoanTypeFixed { get; set; }
        public bool? LoanTypeAdjustable { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
