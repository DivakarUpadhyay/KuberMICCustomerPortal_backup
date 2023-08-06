using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class CmoTransaction
    {
        public string RecId { get; set; }
        public string PoolRecId { get; set; }
        public string HolderRecId { get; set; }
        public string CertificateRecId { get; set; }
        public string TrustAccountRecId { get; set; }
        public string GroupRecId { get; set; }
        public string DistributionRecId { get; set; }
        public string ReversalRecId { get; set; }
        public DateTime? TransDate { get; set; }
        public int? Code { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public decimal? Interest { get; set; }
        public decimal? Principal { get; set; }
        public decimal? Other { get; set; }
        public decimal? Penalty { get; set; }
        public string PayRecId { get; set; }
        public string PayAcct { get; set; }
        public string PayName { get; set; }
        public string PayAddress { get; set; }
        public string Notes { get; set; }
        public int? Sequence { get; set; }
        public bool? Rollover { get; set; }
        public decimal? OldSoldRate { get; set; }
        public DateTime? OldMaturity { get; set; }
        public DateTime? OldPaidTo { get; set; }
        public decimal? OldRolloverRate { get; set; }
        public int? OldRolloverTerm { get; set; }
        public DateTime? AchTransmissionDateTime { get; set; }
        public string AchTransNumber { get; set; }
        public string AchBatchNumber { get; set; }
        public string AchTraceNumber { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
