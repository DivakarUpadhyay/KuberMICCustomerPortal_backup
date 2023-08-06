using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class CmoPayable
    {
        public string RecId { get; set; }
        public string PoolRecId { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public decimal? PrinBalance { get; set; }
        public decimal? IntRate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public int? PaymentFrequency { get; set; }
        public DateTime? PaymentNextDue { get; set; }
        public DateTime? MaturityDate { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
