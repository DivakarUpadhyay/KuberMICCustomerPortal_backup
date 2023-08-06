using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsInsurance
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string PropRecId { get; set; }
        public string Description { get; set; }
        public string InsuredName { get; set; }
        public string CompanyName { get; set; }
        public string PolicyNumber { get; set; }
        public string AgentName { get; set; }
        public string AgentAddress { get; set; }
        public string AgentPhone { get; set; }
        public string AgentFax { get; set; }
        public string AgentEmail { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal? Coverage { get; set; }
        public bool? Active { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
