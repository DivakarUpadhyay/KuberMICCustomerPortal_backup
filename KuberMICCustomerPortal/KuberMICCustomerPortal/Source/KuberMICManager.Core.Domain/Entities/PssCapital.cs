using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssCapital
    {
        public string RecId { get; set; }
        public string PartnerRecId { get; set; }
        public string PartnershipRecId { get; set; }
        public int? TaxYear { get; set; }
        public decimal? BegCapital { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
