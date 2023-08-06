using KuberMICManager.Client.WebUI.Utility;
using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Client.WebUI.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
        private readonly IDashboardService _dashboardService;
        private readonly IExportService _exportService;
        private readonly IUserLogRepository _userLogRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public readonly IMemoryCache _cache;
        private readonly ISPRepository _getUserData;
        [BindProperty]
        public bool asOfToday { get; set; }

        public DashboardLoanViewModel DashboardLoanViewData { get; set; }
        public DashboardPartnerViewModel DashboardPartnerViewData { get; set; }


        public DashboardModel(IDashboardService dashboardService,
                              IExportService exportService,
                              IUserLogRepository userLogRepository,
                              UserManager<ApplicationUser> userManager,
                              IMemoryCache cache,
                              ISPRepository getUserData)
        {
            _dashboardService = dashboardService;
            _exportService = exportService;
            _userLogRepository = userLogRepository;
            _userManager = userManager;
            _cache = cache;
            _getUserData = getUserData;
        }

        public async Task OnGetAsync()
        {
            await GetDashboardData();
        }

        public async Task OnPostAsync() // Used when checkbox is toggled in dashboard
        {
            await GetDashboardData();
        }

        private async Task GetDashboardData()
        {
            DateTime? EndDate = null;

            if (asOfToday)
            {
                EndDate = DateTime.Today.Date; // Only get the closed loans
            }

            DashboardLoanViewData = await _dashboardService.GetLoanSummaryForDashboard(EndDate);
            DashboardPartnerViewData = await _dashboardService.GetPartnerSummaryForDashboard(EndDate);
           
        }

        public async Task<IActionResult> OnPostExportAsync() // for export to pdf button
        {
            await GetDashboardData();

            string contentString = TemplateGenerator.GetDashboardHTMLString(DashboardLoanViewData);
            string docTitle = $"Kuber MIC Manager Dashboard - {DateTime.Now}";

            var pdfContent = await _exportService.ExportToPDF(contentString);

            var currentUser = await _userManager.GetUserAsync(User);
            await _userLogRepository.LogEvent(
                        AreaType.Reports,
                        EventType.DownloanDashboardPortfolioSummary,
                        currentUser.UserName,
                        $"Download Dashboard Portfolio Summary - {docTitle}",
                        ResultType.Success
                    );

            return File(pdfContent, "application/pdf", docTitle + ".pdf");
        }
    }
}