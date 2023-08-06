using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class ConBudgetLoan
    {
        public string RecId { get; set; }
        public string AccountRecId { get; set; }
        public string LoanRecId { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? HoldBackAmount { get; set; }
        public decimal? PctCompleted { get; set; }
        public bool? IsHold { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
        public string Notes { get; set; }
    }
}
