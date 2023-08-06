using KuberMICManager.Core.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    public partial class DetailsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DetailsModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public DetailUserModel DetailsUser { get; set; }

        public class DetailUserModel
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
            DetailsUser = new DetailUserModel
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
            DetailsUser.ClaimList = new List<UserClaimModel>();
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(appUser);

            foreach (UserClaimType claim in Enum.GetValues(typeof(UserClaimType)))
            {
                if (userClaims.Any(c => c.Type == claim.ToString() && c.Value == "true"))
                {
                    DetailsUser.ClaimList.Add(new UserClaimModel
                    {
                        isSelected = false,
                        claimName = claim
                    });
                }
            }

            return Page();
        }
    }
}
