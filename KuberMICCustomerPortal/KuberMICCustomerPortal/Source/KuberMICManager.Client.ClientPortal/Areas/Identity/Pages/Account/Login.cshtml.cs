using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IUserLogRepository _userLogRepository;
        private readonly IWebHostEnvironment _env;

        public string ServerID { get; set; }
        public string Version { get; set; }

        public LoginModel(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            ILogger<LoginModel> logger,
            IUserLogRepository userLogRepository,
            IWebHostEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _userLogRepository = userLogRepository;
            _env = env;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
                                                                                                    
        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            // Set default culture variable in cookie 
            Response.Cookies.Append(
               CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en")),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            ServerID = Environment.GetEnvironmentVariable("KMIC_SRVR");
            Version = System.IO.File.ReadAllLines(System.IO.Path.Combine(_env.WebRootPath, "VERSION")).First();
        }

        public async Task<IActionResult> OnPostAsync(string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var userName = Input.Email;
                if(userName.IndexOf('@') > -1)
                {
                    var user = await _userManager.FindByEmailAsync(Input.Email);
                    if(user == null)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                    else
                    {
                        userName = user.UserName;
                    }
                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(userName, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User " + Input.Email + " logged in.");

                    await _userLogRepository.LogEvent(
                        AreaType.SiteAccess,
                        EventType.Login,
                        userName,
                        $"[Entry: Login Page] " + string.Join(" ", HttpContext.Request.Headers),
                        ResultType.Success
                    );

                    if (!String.IsNullOrEmpty(ReturnUrl))
                        return LocalRedirect(ReturnUrl);
                    return LocalRedirect("~/dashboard");
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = "~/", RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User " + Input.Email + " account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
