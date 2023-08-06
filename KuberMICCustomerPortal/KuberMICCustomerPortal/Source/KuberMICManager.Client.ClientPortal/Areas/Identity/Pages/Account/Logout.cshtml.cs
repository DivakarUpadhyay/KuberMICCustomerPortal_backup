using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IUserLogRepository _userLogRepository;
        private readonly IHttpContextAccessor _HttpContextAccessor;

        public LogoutModel(
            SignInManager<ApplicationUser> signInManager, 
            ILogger<LogoutModel> logger, 
            IUserLogRepository userLogRepository,
            IHttpContextAccessor HttpContextAccessor)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userLogRepository = userLogRepository;
            _HttpContextAccessor = HttpContextAccessor;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await LogoutUser(string.Empty);
            return Redirect(_HttpContextAccessor.HttpContext.Request.PathBase + "/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            return await LogoutUser(returnUrl);
        }

        private async Task<IActionResult> LogoutUser(string returnUrl)
        {
            try
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);

                await _userLogRepository.LogEvent(
                            AreaType.SiteAccess,
                            EventType.Logout,
                            user.UserName,
                            $"[Exit: Logout] " + string.Join(" ", HttpContext.Request.Headers),
                            ResultType.Success
                        );

                await _signInManager.SignOutAsync();
                _logger.LogInformation("User " + user.UserName + " logged out.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Logout error: " + ex.Message);
                return LocalRedirect("/account/login");
            }

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return LocalRedirect("~/");
            }

            return Page();
        }
    }
}