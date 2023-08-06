using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Application
{
    public class TrustAccountService : ITrustAccountService
    {
        // inject the dependencies
        private readonly ILogger<LoanService> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly ITrustAccountUnitOfWork _trustAccountUnitOfWork;

        public TrustAccountService(ILogger<LoanService> logger,
                                   IOptions<AppSettings> appSettings,
                                   ITrustAccountUnitOfWork trustAccountUnitOfWork)
        {
            _logger = logger;
            _appSettings = appSettings;
            _trustAccountUnitOfWork = trustAccountUnitOfWork;
        }

        public async Task<TrustAccountIndexModel> GetTrustAccountDetailsAsync(int PageIndex, string SearchFor, LedgerType LedgerType, string AccountType)
        {
            _logger.LogInformation($"Calling: TrustAccountService.GetTrustAccountDetailsAsync(): PageIndex: {PageIndex}, SearchFor, {SearchFor}, AccountType: {AccountType}");


            TrustAccountIndexModel trustAccountViewModel = new TrustAccountIndexModel();

            trustAccountViewModel.TrustAccounts = await _trustAccountUnitOfWork.TAccountRepository.FindAllAsync();

            if (LedgerType == LedgerType.All)
            {
                trustAccountViewModel.TrustAccountTransactions = await _trustAccountUnitOfWork.TATransactionRepository.FindAsync(t => t.AccountRecId == AccountType &&
                                                                                                                      (string.IsNullOrEmpty(SearchFor) ||
                                                                                                                      t.Reference.Contains(SearchFor) ||
                                                                                                                      t.PayName.Contains(SearchFor) ||
                                                                                                                      t.Memo.Contains(SearchFor) ||
                                                                                                                      t.Amount.ToString().Contains(SearchFor)),
                                                                                                                 t => t.DateReceived, OrderDirection.Descending, PageIndex, _appSettings.Value.PageSize);

            }
            else
            {
                trustAccountViewModel.TrustAccountTransactions = await _trustAccountUnitOfWork.TATransactionRepository.FindAsync(t => t.AccountRecId == AccountType &&
                                                                                                                      t.PayAccount == LedgerType.ToString() &&
                                                                                                                      (string.IsNullOrEmpty(SearchFor) ||
                                                                                                                      t.Reference.Contains(SearchFor) ||
                                                                                                                      t.PayName.Contains(SearchFor) ||
                                                                                                                      t.Memo.Contains(SearchFor) ||
                                                                                                                      t.Amount.ToString().Contains(SearchFor)),
                                                                                                                 t => t.DateReceived, OrderDirection.Descending, PageIndex, _appSettings.Value.PageSize);

            }

            return trustAccountViewModel;
        }
    }
}