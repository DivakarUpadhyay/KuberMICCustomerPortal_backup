using KuberMICManager.Core.Domain.ViewModels;
using System;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.Interfaces.Services
{
    public interface IPortfolioHistoryService
    {
        Task<ResultType> SavePortfolioSnapshot(DateTime endDate);
        Task<ResultType> SaveBBCSnapshot(DateTime endDate);
        Task<ResultType> SaveStressTestSnapshot(DateTime endDate);
        Task<PortfolioHistoryViewModel> GetMICPortfolioHistory(DateTime? historyDate);
    }
}