using KuberMICManager.Core.Domain.Entities;
using System.Collections.Generic;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class LoanViewModel
    {
        public TdsLoan Loan { get; set; }
        public IEnumerable<TdsLender> lenders { get; set; }
        public IEnumerable<TdsLoanHistory> LoanHistories { get; set; }
        public IEnumerable<TdsLien> Liens { get; set; }
        public IEnumerable<TdsCharge> Charges { get; set; }
        public IEnumerable<TdsChargesDetail> ChargesDetails { get; set; }
        public IEnumerable<TdsCoBorrower> CoBorrowers { get; set; }
        public IEnumerable<TdsFunding> Fundings { get; set; }
        public IEnumerable<TdsInsurance> Insurances { get; set; }
        public IEnumerable<TdsProperty> Properties { get; set; }

        // Shared
        public IEnumerable<AppAttachment> Attachments { get; set; }
        public AppNote Notes { get; set; }
        public IEnumerable<UdfField> UDFFields { get; set; }
        public IEnumerable<UdfValue> UDFValues { get; set; }
        public IEnumerable<UdfTab> UDFTabs { get; set; }
    }
}