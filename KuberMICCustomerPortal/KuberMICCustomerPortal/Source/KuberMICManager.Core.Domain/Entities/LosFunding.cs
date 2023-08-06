using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosFunding
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
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
        public string LegalVesting { get; set; }
        public bool? MultipleSignators { get; set; }
        public DateTime? DateDeposited { get; set; }
        public decimal? AmountFunded { get; set; }
        public string Xml { get; set; }
        public string SuitabilityReviewedBy { get; set; }
        public DateTime? SuitabilityReviewedOn { get; set; }
        public bool? Institutional { get; set; }
        public bool? LoanTypeFixed { get; set; }
        public bool? LoanTypeAdjustable { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
