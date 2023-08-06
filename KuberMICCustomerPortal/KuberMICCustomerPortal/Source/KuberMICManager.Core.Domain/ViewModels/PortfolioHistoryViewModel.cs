using KuberMICManager.Core.Domain.ReportModels;
using System;
using System.Collections.Generic;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class PortfolioHistoryViewModel
    {
        public BBCReportModel ReportsViewModel { get; set; }
        public DashboardLoanViewModel DashboardViewModel { get; set; }
        public StressTestReportModel StressTestReportViewModel { get; set; }
        public IEnumerable<DateTime> DateList { get; set; }
    }
}