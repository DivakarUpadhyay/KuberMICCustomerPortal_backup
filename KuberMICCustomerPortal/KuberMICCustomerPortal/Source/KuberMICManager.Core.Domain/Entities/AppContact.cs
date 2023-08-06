using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppContact
    {
        public string RecId { get; set; }
        public string Category { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string Mi { get; set; }
        public string LastName { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneFax { get; set; }
        public int? PhoneMain { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Tin { get; set; }
        public DateTime? Birthday { get; set; }
        public string Categories { get; set; }
        public string LicenseNumber { get; set; }
        public int? EmailFormat { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteUrl { get; set; }
        public int? RolodexFlag { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
