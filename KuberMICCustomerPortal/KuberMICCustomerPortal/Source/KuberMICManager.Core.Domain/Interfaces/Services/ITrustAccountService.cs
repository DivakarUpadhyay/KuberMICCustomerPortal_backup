using KuberMICManager.Core.Domain.ViewModels;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.Interfaces.Services
{
    public interface ITrustAccountService
    {
        Task<TrustAccountIndexModel> GetTrustAccountDetailsAsync(int PageIndex, string SearchFor, LedgerType LedgerType, string AccountType);
    }
}