using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class WpcOnlinePayment
    {
        public string RecId { get; set; }
        public string ConfirmationNumber { get; set; }
        public string Account { get; set; }
        public int? TransactionType { get; set; }
        public string PayorFirstName { get; set; }
        public string PayorLastName { get; set; }
        public string PayorStreet { get; set; }
        public string PayorCity { get; set; }
        public string PayorState { get; set; }
        public string PayorZipCode { get; set; }
        public DateTime? DateDownloaded { get; set; }
        public DateTime? DateApplied { get; set; }
        public int? AppliedStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public decimal? ConvenienceFee { get; set; }
        public decimal? CustomerFee { get; set; }
        public string CreditCard { get; set; }
        public string CcMonth { get; set; }
        public string CcYear { get; set; }
        public string CcCvv { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
        public bool? Deleted { get; set; }
    }
}
