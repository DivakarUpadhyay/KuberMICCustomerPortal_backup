using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppCompany
    {
        public string RecId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string FederalTin { get; set; }
        public string StateTin { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteUrl { get; set; }
        public string BrokerName { get; set; }
        public string BrokerLicense { get; set; }
        public string LicenseType { get; set; }
        public string WpcPublishId { get; set; }
        public string WpcPublishName { get; set; }
        public string WpcBorrowerAnnouncement { get; set; }
        public string WpcLenderAnnouncement { get; set; }
        public string WpcHolderAnnouncement { get; set; }
        public string WpcPartnerAnnouncement { get; set; }
        public string WpcContactNameAddress { get; set; }
        public string WpcContactPhone { get; set; }
        public string WpcContactFax { get; set; }
        public string WpcContactEmail { get; set; }
        public DateTime? WpcLastPublished { get; set; }
        public string WpcPublishLog { get; set; }
        public int? WpcBatchSize { get; set; }
        public int? WpcTimeOut { get; set; }
        public bool? WpcPublishOutstandingLenderChecks { get; set; }
        public bool? WpcPublishLenderTrustFundBalance { get; set; }
        public string WpcAboutUs { get; set; }
        public string WpcRemoteServerUrl { get; set; }
        public string EmailDisplayName { get; set; }
        public string EmailFromAddress { get; set; }
        public string EmailReplyAddress { get; set; }
        public bool? EmailAlwaysSendBcc { get; set; }
        public string EmailBccAddress { get; set; }
        public string EmailSmtpHostName { get; set; }
        public string EmailSmtpUserName { get; set; }
        public string EmailSmtpPassword { get; set; }
        public int? EmailSmtpPortNumber { get; set; }
        public bool? EmailSmtpRequiresAuthentication { get; set; }
        public int? EmailSmtpSecureProtocol { get; set; }
        public string EmailPop3HostName { get; set; }
        public string EmailPop3UserName { get; set; }
        public string EmailPop3Password { get; set; }
        public int? EmailPop3PortNumber { get; set; }
        public bool? EmailUseSignature { get; set; }
        public string AttachmentsPath { get; set; }
        public string Xml { get; set; }
        public string Dotpath { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
