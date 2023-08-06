using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Infrastructure.DataAccess.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KuberMICManager.WebUI.Areas.Identity.Pages.Users
{
    [Authorize(Policy = "ManageUsers")]
    public partial class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(
            ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public string acPostReqUserName { get; set; }
        public string acPostReqTestUserName { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public List<ApplicationUser> applicationUsers { get; set; }

        public async Task OnGetAsync()
        {
            using (var context = _applicationDbContext)
            {
                applicationUsers = await _userManager.Users.ToListAsync();
            }
        }
    }
}