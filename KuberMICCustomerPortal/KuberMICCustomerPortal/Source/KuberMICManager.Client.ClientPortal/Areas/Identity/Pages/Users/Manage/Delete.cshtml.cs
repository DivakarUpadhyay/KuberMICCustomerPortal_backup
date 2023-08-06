using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class DeleteModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserLogRepository _userLogRepository;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserLogRepository userLogRepository,
            ILogger<DeleteModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userLogRepository = userLogRepository;
            _logger = logger;
        }

        public string acPostReqUserName { get; set; }
        public string acPostReqTestUserName { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public DeleteUserModel DeleteUser { get; set; }

        public class DeleteUserModel
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
            DeleteUser = new DeleteUserModel
            {
                UserId = appUser.Id,
                Username = appUser.UserName,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                CompanyName = appUser.CompanyName,
                Email = appUser.Email,
                PhoneNumber = appUser.PhoneNumber
            };

            // pick the added claims
            DeleteUser.ClaimList = new List<UserClaimModel>();
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(appUser);

            foreach (UserClaimType claim in Enum.GetValues(typeof(UserClaimType)))
            {
                if (userClaims.Any(c => c.Type == claim.ToString() && c.Value == "true"))
                {
                    DeleteUser.ClaimList.Add(new UserClaimModel {
                        isSelected = false,
                        claimName = claim
                    });
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound($"Unable to load user with UserName '{userId}'.");
                }

                // Make sure a user cannot delete himself, vzadmin, web user or test web users
                if (user.UserName == _userManager.GetUserName(User) || 
                    user.UserName == "vzadmin" || 
                    user.UserName == acPostReqUserName || 
                    user.UserName == acPostReqTestUserName)
                {
                    return NotFound($"Not allowed to delete user '{userId}'.");
                }

                string updatedValue = $"UserName: {DeleteUser.Username}&FirstName: {DeleteUser.FirstName}&LastName: {DeleteUser.LastName}&" +
                   $"CompanyName: {DeleteUser.CompanyName}&Email: {DeleteUser.Email}&PhoneNumber: {DeleteUser.PhoneNumber}";

                // Go through the claim list and remove them
                IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
                foreach (Claim claimToRemove in userClaims)
                {
                    await _userManager.RemoveClaimAsync(user, claimToRemove);
                    updatedValue += $"&ClaimsRemoved: {claimToRemove.ToString()}";
                }

                var userSetResult = await _userManager.DeleteAsync(user);
                if (!userSetResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error occurred updating user with ID '{userId}'.");
                }

                _logger.LogInformation($"User profile for {DeleteUser.Username} has been Deleted.");
                StatusMessage = $"User profile for '{DeleteUser.Username}' has been Deleted";
                var currentUser = await _userManager.GetUserAsync(User);

                await _userLogRepository.LogEvent(
                            AreaType.UserManagement,
                            EventType.DeleteUser,
                            currentUser.UserName,
                            updatedValue,
                            ResultType.Success
                        );
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(DeleteUser.Username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return RedirectToPage("../index");
        }

        private bool UserExists(string userName)
        {
            return _userManager.FindByNameAsync(userName) != null ? true : false;
        }
    }
}