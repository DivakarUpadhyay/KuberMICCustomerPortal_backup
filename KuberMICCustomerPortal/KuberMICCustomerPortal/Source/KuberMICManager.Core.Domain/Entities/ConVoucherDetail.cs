using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class ConVoucherDetail
    {
        public string RecId { get; set; }
        public string VoucherRecId { get; set; }
        public string BudgetRecId { get; set; }
        public decimal? Amount { get; set; }
        public string Notes { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
