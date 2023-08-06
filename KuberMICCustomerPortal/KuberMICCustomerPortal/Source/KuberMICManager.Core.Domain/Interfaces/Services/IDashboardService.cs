using KuberMICManager.Core.Domain.ViewModels;
using System;
using System.Threading.Tasks;

namespace KuberMICManager.Core.Domain.Interfaces.Services
{
    public interface IDashboardService
    {
        Task<DashboardLoanViewModel> GetLoanSummaryForDashboard(DateTime? endDate);
        Task<DashboardPartnerViewModel> GetPartnerSummaryForDashboard(DateTime? endDate);
    }
}