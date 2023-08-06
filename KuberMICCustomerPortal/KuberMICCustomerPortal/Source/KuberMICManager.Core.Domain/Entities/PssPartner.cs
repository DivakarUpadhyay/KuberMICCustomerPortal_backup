using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssPartner
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
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool? HomeAddrEnabled { get; set; }
        public string HomeStreet { get; set; }
        public string HomeCity { get; set; }
        public string HomeState { get; set; }
        public string HomeZipCode { get; set; }
        public string RegisteredShareholderName { get; set; }
        public string RegisteredShareholderStreet { get; set; }
        public string RegisteredShareholderCity { get; set; }
        public string RegisteredShareholderState { get; set; }
        public string RegisteredShareholderZipCode { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneFax { get; set; }
        public int? PhoneMain { get; set; }
        public string Tin { get; set; }
        public int? Tintype { get; set; }
        public bool? Erisa { get; set; }
        public string Payee { get; set; }
        public bool? UsePayee { get; set; }
        public int? AccountType { get; set; }
        public bool? NonResident { get; set; }
        public decimal? GrowthPct { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? RolodexFlag { get; set; }
        public int? PrintStatementFor { get; set; }
        public string Categories { get; set; }
        public int? DeliveryOptions { get; set; }
        public int? EmailFormat { get; set; }
        public string EmailAddress { get; set; }
        public bool? HoldbackUse { get; set; }
        public decimal? HoldbackPct { get; set; }
        public string HoldbackRecId { get; set; }
        public string HoldbackRef { get; set; }
        public int? AchSendDepositNotificationFlag { get; set; }
        public string AchBankName { get; set; }
        public string AchBankAddress { get; set; }
        public string AchRoutingNumber { get; set; }
        public string AchAccountNumber { get; set; }
        public string AchIndividualId { get; set; }
        public string AchIndividualName { get; set; }
        public int? AchAccountType { get; set; }
        public int? AchServiceStatus { get; set; }
        public string TrusteeRecId { get; set; }
        public string TrusteeAccountRef { get; set; }
        public string TrusteeAccountType { get; set; }
        public string SecurityHeldBy { get; set; }
        public string WpcPin { get; set; }
        public bool? WpcPublish { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
        public int? AchSeccode { get; set; }
        public bool? AchUseAddendaRecord { get; set; }
        public string AchAddendaRecord { get; set; }
    }
}
