using KuberMICManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class LoanIndexModel
    {
        public string RecId { get; set; }
        public bool? PlaceOnHold { get; set; }
        public int? AchServiceStatus { get; set; }
        public string Account { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? PrinBal { get; set; }
        public int? Priority { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? PaidToDate { get; set; }
        public DateTime? NextDueDate { get; set; }
        public DateTime? MaturityDate { get; set; }
        public string PmtFreq { get; set; }
        public decimal? PmtPi { get; set; }
        public decimal? NoteRate { get; set; }
        public decimal? SoldRate { get; set; }
        public IEnumerable<TdsProperty> LoanProperties { get; set; }
        public decimal StoredLTV { get; set; }
        public List<string> ReleatedLoanList { get; set; }

        // From Custom Fields
        public string QualifiedAmount { get; set; }
        public string TitleInsuranceAmount { get; set; }
        public string FireInsuranceAmount { get; set; }

        // Notes
        public AppNote Notes { get; set; }

        // Dynamic
        public decimal CalculatedQualifiedAmount { get; set; }
        public decimal CalculatedLTV { get; set; }
        public int TermsLeft { get; set; }
    }
}