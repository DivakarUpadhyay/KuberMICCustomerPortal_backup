using KuberMICManager.Core.Domain.Entities;
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

namespace KuberMICManager.Client.WebUI.Pages.Loans
{
    [Authorize(Policy = "CanViewLoans")]
    public class ViewLoanModel : PageModel
    {
        private readonly IUserLogRepository _userLogRepository;
        private readonly ILoanService _loanService;
        private readonly IGoogleAPISerivce _googleAPIService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ViewLoanModel(IUserLogRepository userLogRepository, 
                             ILoanService loanService,
                             IGoogleAPISerivce googleAPIService,
                             UserManager<ApplicationUser> userManager)
        {
            _userLogRepository = userLogRepository;
            _loanService = loanService;
            _googleAPIService = googleAPIService;
            _userManager = userManager;
        }

        [BindProperty]
        public LoanViewModel LoanViewModel { get; set; }
        public ReturnToPage ReturnToPage { get; set; }

        public async Task<IActionResult> OnGetAsync(string id, ReturnToPage returnToPage = ReturnToPage.LoanList)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReturnToPage = returnToPage;

            LoanViewModel = await _loanService.GetLoanDetailsByIdAsync(id);

            var currentUser = await _userManager.GetUserAsync(User);
            if (LoanViewModel == null)
            {
                await _userLogRepository.LogEvent(
                        AreaType.LoanManagement,
                        EventType.GetLoans,
                        currentUser.UserName,
                        $"View Loan - Loan ID {id}",
                        ResultType.NotFound);

                return NotFound();
            }

            await _userLogRepository.LogEvent(
                        AreaType.LoanManagement,
                        EventType.GetPartners,
                        currentUser.UserName,
                        $"View Loan - Loan ID: {id}, Loan Account: {LoanViewModel.Loan.Account}",
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
                        AreaType.LoanManagement,
                        EventType.GetLoanAttachment,
                        currentUser.UserName,
                        $"View Loan - Attachment Download - File Name: {fileName}, Description: {fileDescription}",
                        outputStream.Length > 0 ? ResultType.Success : ResultType.Failure);

            return File(outputStream.ToArray(), "application/force-download", fileDescription + "." + fileInfo.Extension);
        }

        public decimal? GetTotalAmountReceived(TdsLoanHistory loanHistory)
        {
            return ((loanHistory.ToInterest > 0) ? loanHistory.ToInterest : 0) +
                   ((loanHistory.ToPrincipal > 0) ? loanHistory.ToPrincipal : 0) +
                   ((loanHistory.ToChargesPrin > 0) ? loanHistory.ToChargesPrin : 0);
        }
    }
}