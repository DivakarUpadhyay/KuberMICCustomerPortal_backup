using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.WebUI.Areas.Identity.Pages.Users.Manage
{
    [Authorize(Policy = "ManageUsers")]
    public partial class EditModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IUserLogRepository _userLogRepository;
        private readonly ILogger<EditModel> _logger;

        public EditModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            IUserLogRepository userLogRepository,
            ILogger<EditModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _userLogRepository = userLogRepository;
            _logger = logger;
        }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public EditUserModel InputEditUser { get; set; }

        public class EditUserModel
        {
            public string UserId { get; set; }

            [Required]
            [Display(Name = "User name")]
            public string Username { get; set; }

            [Required]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Display(Name = "Company name")]
            public string CompanyName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "User Access Rights")]
            public List<UserClaimModel> ClaimList { get; set; }
        }

        public class UserClaimModel
        {
            public int id { get; set; }
            public UserClaimType claimName { get; set; }
            public bool isSelected { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            // For displaying it
            InputEditUser = new EditUserModel
            {
                UserId = appUser.Id,
                Username = appUser.UserName,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                CompanyName = appUser.CompanyName,
                Email = appUser.Email,
                PhoneNumber = appUser.PhoneNumber
            };

            // Populate the claim list and pick the added claims
            InputEditUser.ClaimList = new List<UserClaimModel>();
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(appUser);

            foreach (UserClaimType claim in Enum.GetValues(typeof(UserClaimType)))
            {
                var tempInputClaim = new UserClaimModel
                {
                    isSelected = false
                };
                tempInputClaim.claimName = claim;
                if (userClaims.Any(c => c.Type == claim.ToString() && c.Value == "true"))
                {
                    tempInputClaim.isSelected = true;
                }
                InputEditUser.ClaimList.Add(tempInputClaim);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = await _userManager.FindByNameAsync(InputEditUser.Username);
                if (user == null)
                {
                    return NotFound($"Unable to load user with UserName '{InputEditUser.Username}'.");
                }

                user.FirstName = InputEditUser.FirstName;
                user.LastName = InputEditUser.LastName;
                user.CompanyName = InputEditUser.CompanyName;
                user.Email = InputEditUser.Email;
                user.PhoneNumber = InputEditUser.PhoneNumber;

                var userSetResult = await _userManager.UpdateAsync(user);
                if (!userSetResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred updating user with ID '{userId}'.");
                }

                _logger.LogInformation($"User profile for {InputEditUser.Username} has been updated.");
                StatusMessage = $"User profile for '{InputEditUser.Username}' has been updated";
                var currentUser = await _userManager.GetUserAsync(User);

                string updatedValue = $"UserName: {InputEditUser.Username}&FirstName: {InputEditUser.FirstName}&LastName: {InputEditUser.LastName}&" +
                    $"CompanyName: {InputEditUser.CompanyName}&Email: {InputEditUser.Email}&PhoneNumber: {InputEditUser.PhoneNumber}";

                // Go through the claim list and add/remove if it's selected/unselected
                IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
                foreach (UserClaimModel claim in InputEditUser.ClaimList)
                {
                    // Selected and not in the added claims -> add it
                    if (claim.isSelected && !userClaims.Any(c => c.Type == claim.claimName.ToString() && c.Value == "true"))
                    {
                        await _userManager.AddClaimAsync(user, new Claim(claim.claimName.ToString(), "true"));
                        updatedValue += $"&ClaimsAdded: {claim.claimName.ToString()}";
                    }
                    // Not selected but in the added claims -> remove it
                    else if (!claim.isSelected && userClaims.Any(c => c.Type == claim.claimName.ToString() && c.Value == "true"))
                    {
                        var claimToRemove = (from c in userClaims
                                     where (c.Type == claim.claimName.ToString() && c.Value == "true")
                                     select c).Single();
                        await _userManager.RemoveClaimAsync(user, claimToRemove);
                        updatedValue += $"&ClaimsRemoved: {claimToRemove.ToString()}";
                    }
                }

                await _userLogRepository.LogEvent(
                            AreaType.UserManagement,
                            EventType.UpdateUserInfo,
                            currentUser.UserName,
                            updatedValue,
                            ResultType.Success
                        );
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(InputEditUser.Username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return await OnGetAsync(InputEditUser.UserId);
        }

        private bool UserExists(string userName)
        {
            return _userManager.FindByNameAsync(userName) != null ? true : false;
        }
    }
}
