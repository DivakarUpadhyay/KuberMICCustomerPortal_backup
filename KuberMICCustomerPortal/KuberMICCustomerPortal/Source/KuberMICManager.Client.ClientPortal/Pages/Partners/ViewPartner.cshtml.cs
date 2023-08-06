using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Client.WebUI.Pages.Partners
{
    [Authorize(Policy = "CanViewInvestments")]
    public class ViewPartnerModel : PageModel
    {
        private readonly IUserLogRepository _userLogRepository;
        private readonly IPartnerService _partnerService;
        private readonly IGoogleAPISerivce _googleAPIService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ViewPartnerModel(IUserLogRepository userLogRepository, 
                                IPartnerService partnerService,
                                IGoogleAPISerivce googleAPIService,
                                UserManager<ApplicationUser> userManager)
        {
            _userLogRepository = userLogRepository;
            _partnerService = partnerService;
            _googleAPIService = googleAPIService;
            _userManager = userManager;
    }

        [BindProperty]
        public PartnerViewModel PartnerViewModel { get; set; }
        public ReturnToPage ReturnToPage { get; set; }

        public async Task<IActionResult> OnGetAsync(string id, ReturnToPage returnToPage = ReturnToPage.PartnerList)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReturnToPage = returnToPage;

            PartnerViewModel = await _partnerService.GetPartnerDetailsByIdAsync(id);

            var currentUser = await _userManager.GetUserAsync(User);
            if (PartnerViewModel == null)
            {
                await _userLogRepository.LogEvent(
                        AreaType.PartnerManagement,
                        EventType.GetPartners,
                        currentUser.UserName,
                        $"View Partner - Partner ID: {id}",
                        ResultType.NotFound);

                return NotFound();
            }

            await _userLogRepository.LogEvent(
                        AreaType.PartnerManagement,
                        EventType.GetPartners,
                        currentUser.UserName,
                        $"View Partner - Partner ID: {id}, Parner Account: {PartnerViewModel.Partner.Account}",
                        ResultType.Success);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDownloadAsync(string fileName, string fileDescription)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            MemoryStream outputStream = new System.IO.MemoryStream();
            await _googleAPIService.GetGDriveFileByName(fileName, outputStream);

            var currentUser = await _userManager.GetUserAsync(User);
            await _userLogRepository.LogEvent(
                        AreaType.PartnerManagement,
                        EventType.GetPartnerAttachment,
                        currentUser.UserName,
                        $"View Partner - Attachment Download - File Name: {fileName}, Description: {fileDescription}",
                        outputStream.Length > 0 ? ResultType.Success : ResultType.Failure);

            return File(outputStream.ToArray(), "application/force-download", fileDescription + "." + fileInfo.Extension);
        }
    }
}