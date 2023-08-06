using KuberMICManager.Core.Domain.ViewModels;

namespace KuberMICManager.Core.Domain.Interfaces.Services
{
    public interface IMSWordService
    {
        void GetMortgageRenewalAgreementFromTemplate(string templateDocPath, string destDocPath, LoanRenewalModel loanRenewalData);
    }
}