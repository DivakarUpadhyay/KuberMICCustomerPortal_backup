using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class LosEncumbrance
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string PropRecId { get; set; }
        public string BeneName { get; set; }
        public string BeneStreet { get; set; }
        public string BeneCity { get; set; }
        public string BeneState { get; set; }
        public string BeneZipCode { get; set; }
        public string BenePhone { get; set; }
        public string LoanNumber { get; set; }
        public int? PriorityNow { get; set; }
        public int? PriorityAfter { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? OrigAmount { get; set; }
        public decimal? BalanceNow { get; set; }
        public decimal? RegularPayment { get; set; }
        public DateTime? MaturityDate { get; set; }
        public decimal? BalloonPayment { get; set; }
        public string NatureOfLien { get; set; }
        public int? FutureStatus { get; set; }
        public decimal? BalanceAfter { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
