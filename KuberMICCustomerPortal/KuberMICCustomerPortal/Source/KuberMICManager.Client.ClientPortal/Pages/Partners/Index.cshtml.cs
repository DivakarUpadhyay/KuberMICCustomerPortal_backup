using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Client.WebUI.Pages.Partners
{
    [Authorize(Policy = "CanViewInvestments")]
    public class IndexModel : PageModel
    {
        private readonly IPartnerService _partnerService;
        private readonly IUserLogRepository _userLogRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public IEnumerable<PartnerIndexModel> Partners { get; set; }

        public PartnerFilterType? FilterType { get; set; }

        public IndexModel(IPartnerService partnerService,
                          IUserLogRepository userLogRepository,
                          UserManager<ApplicationUser> userManager)
        {
            _partnerService = partnerService;
            _userLogRepository = userLogRepository;
            _userManager = userManager;
            FilterType = PartnerFilterType.ShareBalanceGreaterThanZero;
        }

        public async Task OnGetAsync(PartnerFilterType? filterType)
        {
            if (filterType != null)
            {
                FilterType = (PartnerFilterType)filterType;
            }

            Partners = await _partnerService.GetFilteredPartners(FilterType);

            var currentUser = await _userManager.GetUserAsync(User);
            await _userLogRepository.LogEvent(
                        AreaType.PartnerManagement,
                        EventType.GetPartners,
                        currentUser.UserName,
                        $"Partners: Filter - {FilterType}",
                        ResultType.Success
                    );
        }
    }
}