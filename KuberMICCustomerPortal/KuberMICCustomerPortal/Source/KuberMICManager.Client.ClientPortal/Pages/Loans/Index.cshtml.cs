using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Entities.Identity;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SautinSoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Client.WebUI.Pages.Loans
{
    [Authorize(Policy = "CanViewLoans")]
    public class IndexModel : PageModel
    {
        private readonly ILoanService _loanService;
        private readonly ILoanUnitOfWork _loanUnitOfWork;
        private readonly IUserLogRepository _userLogRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public IEnumerable<LoanIndexModel> Loans { get; set; }

        public List<LoanSearchEnumModel> CheckBoxLoanSearchGroup { get; set; }
        public string SearchFor { get; set; }
        public LoanFilterType? FilterType { get; set; }
        public DateTime? EndDate { get; set; }
        public string AtRiskBeaconScoreThreshold { get; set; }
        public string AtRiskLTVThreshold { get; set; }

        public IndexModel(ILoanService loanService,
                          ILoanUnitOfWork loanUnitOfWork,
                          IUserLogRepository userLogRepository,
                          UserManager<ApplicationUser> userManager,
                          IMemoryCache cache)
        {
            _loanService = loanService;
            _loanUnitOfWork = loanUnitOfWork;
            _userLogRepository = userLogRepository;
            _userManager = userManager;
            FilterType = LoanFilterType.PrincipalBalanceGreaterThanZero;

            CheckBoxLoanSearchGroup = new List<LoanSearchEnumModel>();
            foreach (LoanSearchGroup loanSearchGroup in Enum.GetValues(typeof(LoanSearchGroup)))
            {
                CheckBoxLoanSearchGroup.Add(new LoanSearchEnumModel() { LoanSearchGroup = loanSearchGroup, IsSelected = false });
            }
            CheckBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.Loan).IsSelected = true;
            CheckBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.Properties).IsSelected = true;

            AtRiskBeaconScoreThreshold = GetSiteSetting(cache, SiteSettingKey.STRESSTESTATRISKBEACONSCORETHRESHOLD.ToString()).ToString();
            AtRiskLTVThreshold = GetSiteSetting(cache, SiteSettingKey.STRESSTESTATRISKLTVTHRESHOLD.ToString()).ToString();
        }

        public async Task OnGetAsync(string searchFor, LoanFilterType? filterType, DateTime? endDate, List<string> releatedLoanList, List<LoanSearchEnumModel> checkBoxLoanSearchGroup)
        {
            SearchFor = searchFor?.Trim();

            if (filterType != null)
                FilterType = filterType;

            if (filterType == LoanFilterType.Arrears1stMortgages || filterType == LoanFilterType.Arrears2ndMortgages || filterType == LoanFilterType.DelinquentMortgages)
            {
                endDate = DateTime.Today.Date;
            }

            if (endDate != null)
                EndDate = endDate;

            if (checkBoxLoanSearchGroup.Any())
                CheckBoxLoanSearchGroup = checkBoxLoanSearchGroup;
            // If non selected, make loan as default
            if (CheckBoxLoanSearchGroup.All(e => e.IsSelected == false))
            {
                ModelState.Remove("checkBoxLoanSearchGroup[0].IsSelected");
                CheckBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.Loan).IsSelected = true;
            }

            Loans = await _loanService.GetFilteredLoans(SearchFor, FilterType, CheckBoxLoanSearchGroup, EndDate);

            var currentUser = await _userManager.GetUserAsync(User);
            await _userLogRepository.LogEvent(
                        AreaType.LoanManagement,
                        EventType.GetLoans,
                        currentUser.UserName,
                        $"[Get] Loans: Filter - {FilterType}, Search - {SearchFor}",
                        ResultType.Success
                    );
        }

        public async Task<ActionResult> OnPostSaveNotesAsync(string recID, string loanNotes)
        {
            string message;

            if (!ModelState.IsValid)
            {
                return new JsonResult(new { Result = ResultType.Failure.ToDescription(), Message = "Invalid model state" });
            }

            try
            {
                AppNote originalLoanNote = await ((ISharedUnitOfWork)_loanUnitOfWork).NoteRepository.FindAsync(recID);

                string originalLoanNoteHtml = RtfPipe.Rtf.ToHtml(originalLoanNote.Notes);
                if (!originalLoanNoteHtml.Contains(loanNotes))
                {

                    if (originalLoanNote == null)
                    {
                        originalLoanNote = new AppNote()
                        {
                            RecId = recID,
                        };
                    }

                    HtmlToRtf h = new HtmlToRtf();
                    if (h.OpenHtml(loanNotes))
                    {
                        originalLoanNote.Notes = h.ToRtf();
                    }

                    await ((ISharedUnitOfWork)_loanUnitOfWork).NoteRepository.UpdateAsync(originalLoanNote);

                    var user = await _userManager.GetUserAsync(User);
                    if (user == null)
                    {
                        return new JsonResult(new { Result = ResultType.Failure.ToDescription(), Message = $"Unable to load user with ID '{_userManager.GetUserId(User)}'." });
                    }

                    message = "Changes have been updated!";

                    await _userLogRepository.LogEvent(
                                AreaType.LoanManagement,
                                EventType.UpdateNotes,
                                user.UserName,
                                $"[Post] Loan Notes Update - {JsonConvert.SerializeObject(originalLoanNote)}",
                                ResultType.Success
                            );
                }
                else
                {
                    message = "No Changes Detected.";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return new JsonResult(new { Result = ResultType.Success.ToDescription(), Message = message });
        }

        public bool IsCorrectQualifiedAmount(string stored, decimal calculated)
        {
            string stroedStringVal = String.IsNullOrEmpty(stored) ? "0" : stored;
            return IsCorrectLTV(stroedStringVal.ToDecimal(), calculated);
        }

        public bool IsCorrectLTV(decimal stored, decimal calculated)
        {
            double diff = (double)Math.Abs((Decimal.Round(stored, 2) - Decimal.Round(calculated, 2)));
            return diff < 0.05;
        }
    }
}