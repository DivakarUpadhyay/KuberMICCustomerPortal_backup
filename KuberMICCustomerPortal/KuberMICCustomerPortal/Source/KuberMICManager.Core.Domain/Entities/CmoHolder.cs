using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class CmoHolder
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
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneFax { get; set; }
        public int? PhoneMain { get; set; }
        public string Tin { get; set; }
        public int? Tintype { get; set; }
        public bool? Send1099 { get; set; }
        public bool? Erisa { get; set; }
        public string Payee { get; set; }
        public bool? UsePayee { get; set; }
        public string Vesting { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? RolodexFlag { get; set; }
        public int? PrintStatementFor { get; set; }
        public string Categories { get; set; }
        public int? DeliveryOptions { get; set; }
        public int? EmailFormat { get; set; }
        public string EmailAddress { get; set; }
        public int? AchSendDepositNotificationFlag { get; set; }
        public string AchBankName { get; set; }
        public string AchBankAddress { get; set; }
        public string AchRoutingNumber { get; set; }
        public string AchAccountNumber { get; set; }
        public string AchIndividualId { get; set; }
        public string AchIndividualName { get; set; }
        public int? AchAccountType { get; set; }
        public int? AchServiceStatus { get; set; }
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
