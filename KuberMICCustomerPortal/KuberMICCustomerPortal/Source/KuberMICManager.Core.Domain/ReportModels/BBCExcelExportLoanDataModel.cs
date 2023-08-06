using System;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

#nullable disable

namespace KuberMICManager.Core.Domain.ReportModels
{
    public partial class BBCExcelExportLoanDataModel
    {
        // Loan Data
        public string RecId { get; set; }
        public string Account { get; set; }
        public string FullName { get; set; }
        public decimal? OrigBal { get; set; }
        public decimal? PrinBal { get; set; }
        public decimal? NoteRate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? MaturityDate { get; set; }
        public int? Priority { get; set; }
        public string Documentation { get; set; }

        // Co Borrowers
        public string OtherBorrwers { get; set; }

        // Property Details
        public string PropertyType { get; set; }
        public string PropertyOccupancy { get; set; }
        public string PropertyCounty { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyAddress { get; set; }
        public decimal? AggregateAppraiserFmv { get; set; }
        public PropertyCategory PropertyCategory { get; set; }

        // Liens
        public decimal? AggregateSeniorLiens { get; set; }

        // Custom Fields
        public string CreditScore { get; set; }
        public string LessorOfTheAppraisalValueorPurchasePrice { get; set; }
        public string LoanTerms { get; set; }
        public string RenewalOrRefinanceDate { get; set; }
        public string LegalDescription { get; set; }
        public string PinNumber { get; set; }


        // Calculated
        public decimal QualifiedAmount { get; set; }
        public int? TermsLeft { get; set; }
        public decimal? CalculatedLtv { get; set; }
    }
}
