using System;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class LienIndexModel
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string PropRecId { get; set; }
        public int? Priority { get; set; }
        public string Holder { get; set; }
        public string AccountNo { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public decimal? Original { get; set; }
        public decimal? Current { get; set; }
        public decimal? Payment { get; set; }
        public DateTime? LastChecked { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public DateTime? SysCreatedDate { get; set; }
        public string LoanAccount { get; set; }
        public decimal? PrinBal { get; set; }
        public string PropertyAddress { get; set; }
        public bool EmailSent { get; set; }
        public string Notes { get; set; }
    }
}