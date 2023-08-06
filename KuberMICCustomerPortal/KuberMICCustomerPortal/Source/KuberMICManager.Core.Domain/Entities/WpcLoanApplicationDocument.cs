using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class WpcLoanApplicationDocument
    {
        public string RecId { get; set; }
        public string FileName { get; set; }
        public DateTime? Date { get; set; }
        public byte[] Document { get; set; }
        public string LoanApplicationRecId { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
