using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssMasterCertificate
    {
        public string RecId { get; set; }
        public string PartnershipRecId { get; set; }
        public string TrusteeRecId { get; set; }
        public string Number { get; set; }
        public DateTime? IssuedDate { get; set; }
        public decimal? OrigShares { get; set; }
        public decimal? Dripshares { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
