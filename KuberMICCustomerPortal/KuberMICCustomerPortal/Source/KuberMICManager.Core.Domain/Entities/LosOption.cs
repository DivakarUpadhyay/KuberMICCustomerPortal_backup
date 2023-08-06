using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosOption
    {
        public string RecId { get; set; }
        public string TrustAccountRecId { get; set; }
        public bool? PrintCompanyOnCheck { get; set; }
        public int? CheckStyle { get; set; }
        public string CompanyName { get; set; }
        public string CompanyStreet { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyZip { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyEmail { get; set; }
        public string BrokerFirstName { get; set; }
        public string BrokerMi { get; set; }
        public string BrokerLastName { get; set; }
        public string BrokerLicense { get; set; }
        public int? BrokerLicenseType { get; set; }
        public string Xml { get; set; }
    }
}
