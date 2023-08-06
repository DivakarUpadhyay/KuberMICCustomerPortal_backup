using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsCoBorrower
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string SortName { get; set; }
        public string ByLastName { get; set; }
        public string FullName { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string Mi { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneFax { get; set; }
        public int? PhoneMain { get; set; }
        public string Tin { get; set; }
        public string EmailAddress { get; set; }
        public int? EmailFormat { get; set; }
        public int? DeliveryOptions { get; set; }
        public bool? SendNotices { get; set; }
        public int? Relation { get; set; }
        public int? RecType { get; set; }
        public bool? CcrReport { get; set; }
        public DateTime? CcrDob { get; set; }
        public string CcrGenerationCode { get; set; }
        public string CcrAddressIndicator { get; set; }
        public string CcrResidenceCode { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
