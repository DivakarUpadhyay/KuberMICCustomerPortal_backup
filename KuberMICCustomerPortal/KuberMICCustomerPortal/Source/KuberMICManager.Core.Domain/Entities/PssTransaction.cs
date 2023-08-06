using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssTransaction
    {
        public string RecId { get; set; }
        public string PartnershipRecId { get; set; }
        public string PartnerRecId { get; set; }
        public string TrustAccountRecId { get; set; }
        public string CertificateRecId { get; set; }
        public string ReversalRecId { get; set; }
        public string TransferRecId { get; set; }
        public string GroupRecId { get; set; }
        public string DistributionRecId { get; set; }
        public string RedeemImportRecId { get; set; }
        public string TdsgroupRecId { get; set; }
        public DateTime? RecDate { get; set; }
        public DateTime? DepDate { get; set; }
        public string Reference { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Penalty { get; set; }
        public decimal? Holdback { get; set; }
        public decimal? Shares { get; set; }
        public decimal? SharePrice { get; set; }
        public decimal? ShareCost { get; set; }
        public int? Code { get; set; }
        public string Memo { get; set; }
        public string PayRecId { get; set; }
        public string PayAcct { get; set; }
        public string PayName { get; set; }
        public string PayAddress { get; set; }
        public string Notes { get; set; }
        public bool? Drip { get; set; }
        public int? Sequence { get; set; }
        public DateTime? AchTransmissionDateTime { get; set; }
        public string AchTransNumber { get; set; }
        public string AchBatchNumber { get; set; }
        public string AchTraceNumber { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
