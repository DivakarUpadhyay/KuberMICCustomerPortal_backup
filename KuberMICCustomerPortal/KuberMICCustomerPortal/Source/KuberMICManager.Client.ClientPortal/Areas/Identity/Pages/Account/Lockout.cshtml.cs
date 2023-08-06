using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LockoutModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;
        private IUserLogRepository _userLogRepository;
        private ILogger<LoginModel> _logger;

        public LockoutModel(
            SignInManager<ApplicationUser> signInManager,
            IUserLogRepository userLogRepository,
            ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userLogRepository = userLogRepository;
            _logger = logger;
        }
        public async Task OnGetAsync()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);

            _logger.LogInformation("User " + user.UserName + " lock-out.");
            await _userLogRepository.LogEvent(
                        AreaType.SiteAccess,
                        EventType.Lockout,
                        user.UserName
                    );
        }
    }
}
