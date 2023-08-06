using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssBankAccount
    {
        public string RecId { get; set; }
        public string PartnershipRecId { get; set; }
        public string TrustAccountRecId { get; set; }
        public bool? IsPrimary { get; set; }
        public string Notes { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
