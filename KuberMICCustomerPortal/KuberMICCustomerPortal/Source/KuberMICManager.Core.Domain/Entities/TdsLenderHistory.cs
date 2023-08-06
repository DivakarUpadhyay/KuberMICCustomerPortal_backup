using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsLenderHistory
    {
        public string RecId { get; set; }
        public string LenderRecId { get; set; }
        public string LoanRecId { get; set; }
        public string FundingRecId { get; set; }
        public string PmtGroupRecId { get; set; }
        public string ChkGroupRecId { get; set; }
        public string PmtCode { get; set; }
        public DateTime? PmtDateRec { get; set; }
        public DateTime? PmtDateDue { get; set; }
        public DateTime? CheckDate { get; set; }
        public string CheckNo { get; set; }
        public string CheckMemo { get; set; }
        public decimal? ToInterest { get; set; }
        public decimal? ToPrincipal { get; set; }
        public decimal? ToServiceFee { get; set; }
        public decimal? ToGst { get; set; }
        public decimal? ToLateCharge { get; set; }
        public decimal? ToChargesPrin { get; set; }
        public decimal? ToChargesInt { get; set; }
        public decimal? ToPrepay { get; set; }
        public decimal? ToTrust { get; set; }
        public decimal? ToOtherPayments { get; set; }
        public decimal? ToOtherTaxable { get; set; }
        public decimal? ToOtherTaxFree { get; set; }
        public decimal? ToDefaultInterest { get; set; }
        public decimal? LoanBalance { get; set; }
        public string Notes { get; set; }
        public bool? PrintNote { get; set; }
        public string SourceTyp { get; set; }
        public string SourceApp { get; set; }
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
