using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.WebUI.Areas.Identity.Pages.Users
{
    [Authorize(Policy = "ManageUsers")]
    public class NewUserModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<NewUserModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IUserLogRepository _userLogRepository;

        public NewUserModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<NewUserModel> logger,
            IEmailSender emailSender,
            IUserLogRepository userLogRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _userLogRepository = userLogRepository;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel InputCreateUser { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Display(Name = "Company name")]
            public string CompanyName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "User Access Rights")]
            public List<UserClaimModel> ClaimList { get; set; }
        }

        public class UserClaimModel
        {
            public int id { get; set; }
            public UserClaimType claimName { get; set; }
            public bool isSelected { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            InputCreateUser = new InputModel
            {
                ClaimList = new List<UserClaimModel>()
            };

            // Populate the list of claims available
            foreach (UserClaimType claim in Enum.GetValues(typeof(UserClaimType)))
            {
                var tempInputClaim = new UserClaimModel();
                tempInputClaim.claimName = claim;
                tempInputClaim.isSelected = false;
                InputCreateUser.ClaimList.Add(tempInputClaim);
            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/identity/Account/Manage");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = InputCreateUser.UserName,
                    FirstName = InputCreateUser.FirstName,
                    LastName = InputCreateUser.LastName,
                    CompanyName = InputCreateUser.CompanyName,
                    Email = InputCreateUser.Email,
                    PhoneNumber = InputCreateUser.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, InputCreateUser.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation($"User profile for {InputCreateUser.UserName} has been Created.");
                    StatusMessage = $"User profile for {InputCreateUser.UserName} has been Created.";

                    var currentUser = await _userManager.GetUserAsync(User);

                    string updatedValue = $"UserName: {InputCreateUser.UserName}&FirstName: {InputCreateUser.FirstName}&LastName: {InputCreateUser.LastName}&" +
                        $"CompanyName: {InputCreateUser.CompanyName}&Email: {InputCreateUser.Email}&PhoneNumber: {InputCreateUser.PhoneNumber}";

                    // Go through the claim list and add if it's selected
                    foreach (UserClaimModel claim in InputCreateUser.ClaimList)
                    {
                        if (claim.isSelected)
                        {
                            await _userManager.AddClaimAsync(user, new Claim(claim.claimName.ToString(), "true"));
                            updatedValue += $"&ClaimsAdded: {claim.claimName.ToString()}";
                        }
                    }

                    await _userLogRepository.LogEvent(
                        AreaType.UserManagement,
                        EventType.NewUser,
                        currentUser.UserName,
                        updatedValue,
                        ResultType.Success
                    );

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(InputCreateUser.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
  
                    return RedirectToPage("./index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
