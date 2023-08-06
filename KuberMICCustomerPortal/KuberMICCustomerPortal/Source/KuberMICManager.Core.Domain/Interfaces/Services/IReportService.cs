using KuberMICManager.Core.Domain.ReportModels;
using System;
using System.Threading.Tasks;

namespace KuberMICManager.Core.Domain.Interfaces.Services
{
    public interface IReportService
    {
        Task<StressTestReportModel> GetStressTestReportData(DateTime? endDate);
        Task<BBCReportModel> GetLoanDetailsForBBCSummary(DateTime? endDate);
        Task<BBCReportModel> GetLoanDataForBBCExcelReport(DateTime? endDate);
    }
}