using KuberMICManager.Core.Application.HelperSerivces;
using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure;
using KuberMICManager.Core.Domain.HelperDataModels;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ReportModels;
using KuberMICManager.Core.Domain.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Application
{
    public class LoanService : ILoanService
    {
        // inject the dependencies
        private readonly ILogger<LoanService> _logger;
        private readonly ILoanUnitOfWork _loanUnitOfWork;
        private readonly ISPRepository _SPRepository;
        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly IRenewalRepository _renewalRepository;
        private readonly ISPRepository _certificateDetailsRepository;
        private readonly IMemoryCache _cache;

        public LoanService(ILogger<LoanService> logger,
                           ILoanUnitOfWork loanUnitOfWork,
                           ISPRepository SPRepository,
                           IPostalCodeRepository postalCodeRepository,
                           IRenewalRepository renewalRepository,
                           ISPRepository certificateDetailsRepository,
                           IMemoryCache cache)
        {
            _logger = logger;
            _loanUnitOfWork = loanUnitOfWork;
            _SPRepository = SPRepository;
            _postalCodeRepository = postalCodeRepository;
            _renewalRepository = renewalRepository;
            _certificateDetailsRepository = certificateDetailsRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<TdsLoan>> GetAllLoans(DateTime? endDate = null)
        {
            return await _loanUnitOfWork.LoanRepository.FindAsync(l => !endDate.HasValue || l.ClosingDate.Value.Date <= endDate.Value.Date);
        }

        public async Task<IEnumerable<TdsLoan>> GetNONMaturedActiveLoans(DateTime endDate)
        {
            return await _loanUnitOfWork.LoanRepository.FindAsync(l => l.PrinBal > 0 &&
                                                                       l.MaturityDate.Value.Date > endDate.Date &&
                                                                       l.ClosingDate.Value.Date <= endDate.Date);
        }

        public async Task<IEnumerable<TdsLoan>> GetActiveLoans(DateTime? endDate = null)
        {
            return await _loanUnitOfWork.LoanRepository.FindAsync(l => l.PrinBal > 0 &&
                                                                       (!endDate.HasValue || l.ClosingDate.Value.Date <= endDate.Value.Date), l => l.Account, OrderDirection.Descending);
        }

        public async Task<decimal> GetTotalLoanFundedToDate(DateTime? fundingDateAsOf = null)
        {
            if (fundingDateAsOf == null)
                fundingDateAsOf = DateTime.MaxValue;

            return await _certificateDetailsRepository.GetTotalLoanFundedToDate(fundingDateAsOf);
        }

        public IEnumerable<TdsLoan> GetLoansWithValidationErrors(IEnumerable<TdsLoan> loans,
                                                                 IEnumerable<TdsProperty> propertyList,
                                                                 IEnumerable<TdsPostalCode> postalCodeList,
                                                                 IEnumerable<UdfValue> userDefinedFieldList,
                                                                 IEnumerable<TdsLoanRenewal> renewalForApproval)
        {
            _logger.LogInformation($"Calling: LoanService.GetLoansWithValidationErrors()\n");

            IEnumerable<TdsLoan> qualifiedLoans = LoanFilterService.FilterLoansByFilterType(loans, LoanFilterType.Qualified, DateTime.Today); // Qualfied Loan Validtion as of today
            IEnumerable<TdsLoan> ineligibleLoans = LoanFilterService.FilterLoansByFilterType(loans, LoanFilterType.Ineligible);

            IEnumerable<TdsLoan> incompleteLoans = null;
            IEnumerable<TdsLoan> incompleteLoanProperties = null;
            IEnumerable<TdsLoan> incompleteLoanCustomFileds = null;
            IEnumerable<TdsLoan> incompleteLoanPostalCodeList = null;
            IEnumerable<TdsLoan> incompleteLoanRenewal = null;

            IEnumerable<TdsLoan> BBCViolationLessorAppraisedValueorPurchasePriceGreaterThanAppraisalValue = null; // Qualified Original Commitment Terms
            IEnumerable<TdsLoan> BBCViolationLessorAppraisedValueorPurchaseNotEqualAppraisalValue = null; // Qualified Non Original Commitment Terms
            IEnumerable<TdsLoan> IneligibleLoanViolationNonEmptyLessorAppraisedValueorPurchase = null; // Ineligible
            IEnumerable<TdsLoan> LoanViolationAppraisalDateGreaterThanMaturityDate = null;

            Parallel.Invoke(
                                // Find missing critical information in loans
                                () => incompleteLoans = loans.Where(l => String.IsNullOrEmpty(l.EmailAddress) ||
                                                                         String.IsNullOrEmpty(l.Tin) ||
                                                                         (String.IsNullOrEmpty(l.PhoneCell) &&
                                                                          String.IsNullOrEmpty(l.PhoneHome) &&
                                                                          String.IsNullOrEmpty(l.PhoneWork))),

                                // Find missing critical information in properties
                                () => incompleteLoanProperties = from loan in loans
                                                                 from property in propertyList.Where(p => p.LoanRecId == loan.RecId)
                                                                 where String.IsNullOrEmpty(property.County) || String.IsNullOrEmpty(property.ZipCode)
                                                                 select loan,

                                // Find missing critical information in custom fields
                                () => incompleteLoanCustomFileds = from loan in loans
                                                                   where String.IsNullOrEmpty(userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == QualifiedAmountParentRecId)?.Value) && // Qualified Amount is empty - not in user defined list
                                                                         String.IsNullOrEmpty(userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == IneligibleReasonParentRecId)?.Value) // Ineligible Reason is empty - not in user defined list
                                                                   select loan,

                                // Find missing county entries in postal code list
                                () => incompleteLoanPostalCodeList = from loan in loans
                                                                     from property in propertyList.Where(p => p.LoanRecId == loan.RecId)
                                                                     where !postalCodeList.Any(p => p.County.Trim().ToLower() == property.County.Trim().ToLower()) // Property county not in postal code list
                                                                     select loan,
                                // Find Qualified Loans with Lessor Appraised Value or Purchase Price > appraisal value where Loan Terms Custom Fields is "Original Commitment Terms"
                                () => BBCViolationLessorAppraisedValueorPurchasePriceGreaterThanAppraisalValue = from loan in qualifiedLoans
                                                                                                     from property in propertyList.Where(p => p.LoanRecId == loan.RecId && (bool)p.Primary)
                                                                                                     where userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LoanTermsParentRecId)?.Value == "Original Commitment Terms" && // Loan Term Custom Fields is "Original Commitment Terms"
                                                                                                           userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LessorAppraisedValueorPurchasePriceParentRecId)?.Value.ToDecimal() > property.AppraiserFmv // Lessor Appraised Value or Purchase Price > appraisal value
                                                                                                     select loan,
                                // Find Qualified Loans with Lessor Appraised Value or Purchase Price != appraisal value where Loan Terms Custom Fields is NOT "Original Commitment Terms"
                                () => BBCViolationLessorAppraisedValueorPurchaseNotEqualAppraisalValue = from loan in qualifiedLoans
                                                                                             from property in propertyList.Where(p => p.LoanRecId == loan.RecId && (bool)p.Primary)
                                                                                             where userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LoanTermsParentRecId)?.Value != "Original Commitment Terms" && // Loan Term Custom Fields is NOT "Original Commitment Terms"
                                                                                                   userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LessorAppraisedValueorPurchasePriceParentRecId)?.Value.ToDecimal() != property.AppraiserFmv // Lessor Appraised Value or Purchase Price != appraisal value
                                                                                             select loan,

                                // Find Ineligible Loans with non-empty Lessor Appraised Value or Purchase Price
                                () => IneligibleLoanViolationNonEmptyLessorAppraisedValueorPurchase = from loan in ineligibleLoans
                                                                               where !String.IsNullOrEmpty(userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LessorAppraisedValueorPurchasePriceParentRecId)?.Value) // Lessor Appraised Value or Purchase Price - Not empty
                                                                               select loan,

                                // Find loans with appraisal date greater then maturity date
                                () => LoanViolationAppraisalDateGreaterThanMaturityDate = from loan in loans
                                                                             from property in propertyList.Where(p => p.LoanRecId == loan.RecId)
                                                                             where property.AppraisalDate != null && property.AppraisalDate.Value.Date > loan.MaturityDate.Value.Date // Appraisal Date > Maturity Date
                                                                             select loan,

                                // Incomplete loan renewals
                                () => incompleteLoanRenewal = from loan in loans
                                                              where renewalForApproval.Any(r => r.LoanRecId == loan.RecId)
                                                              select loan
                            );

            return incompleteLoans.Union(incompleteLoanProperties)
                                  .Union(incompleteLoanCustomFileds)
                                  .Union(incompleteLoanPostalCodeList)
                                  .Union(BBCViolationLessorAppraisedValueorPurchasePriceGreaterThanAppraisalValue)
                                  .Union(BBCViolationLessorAppraisedValueorPurchaseNotEqualAppraisalValue)
                                  .Union(IneligibleLoanViolationNonEmptyLessorAppraisedValueorPurchase)
                                  .Union(LoanViolationAppraisalDateGreaterThanMaturityDate)
                                  .Union(incompleteLoanRenewal);

        }

        public async Task<IEnumerable<ValidationModel>> GetLoansWithValidationErrors()
        {
            _logger.LogInformation($"Calling: LoanService.GetMissingCriticalInformationList()\n");

            IEnumerable<TdsLoan> loans = await GetActiveLoans();
            IEnumerable<TdsProperty> propertyList = await GetProperties();
            IEnumerable<TdsPostalCode> postalCodeList = await _postalCodeRepository.FindAllAsync();
            IEnumerable<UdfValue> userDefinedFieldList = await GetUserDefinedFieldsByParentID(null);
            IEnumerable<TdsLoanRenewal> incompleteLoanRenewalList = await _renewalRepository.FindAsync(r => r.RenewalStatus == MortgageRenewalStatus.Completed && !r.ApprovedDate.HasValue);

            IEnumerable<TdsLoan> loanList = GetLoansWithValidationErrors(loans, propertyList, postalCodeList, userDefinedFieldList, incompleteLoanRenewalList);

            IEnumerable<ValidationModel> loanValidationList = from loan in loanList
                                                              from property in propertyList.Where(p => p.LoanRecId == loan.RecId && (bool)p.Primary)
                                                              select new ValidationModel()
                                                              {
                                                                  RecId = loan.RecId,
                                                                  Account = loan.Account,
                                                                  FullName = loan.FullName,
                                                                  Balance = loan.PrinBal,
                                                                  MaturityDate = incompleteLoanRenewalList.FirstOrDefault(r => r.LoanRecId == loan.RecId)?.MaturityDate,
                                                                  Street = property.Street,
                                                                  City = property.City,
                                                                  State = property.State,
                                                                  ZipCode = property.ZipCode,
                                                                  Type = ValidationAccountType.Loan,

                                                                  MissingInfoList = GetMissingInfoList(loan, propertyList, postalCodeList, userDefinedFieldList, incompleteLoanRenewalList)
                                                              };
            return loanValidationList;
        }

        private string GetMissingInfoList(TdsLoan loan, IEnumerable<TdsProperty> propertyList, IEnumerable<TdsPostalCode> postalCodeList, IEnumerable<UdfValue> userDefinedFieldList, IEnumerable<TdsLoanRenewal> incompleteLoanRenewalList)
        {
            // Validating: SIN, EmailAddress, PhoneHome, PhoneWork, PhoneCell and QualifiedAmount

            IList<string> strings = new List<string> { };

            // Loans
            if (String.IsNullOrEmpty(loan.Tin))
                strings.Add("SIN");
            if (String.IsNullOrEmpty(loan.EmailAddress))
                strings.Add("Email");
            if (String.IsNullOrEmpty(loan.PhoneCell) &&
                String.IsNullOrEmpty(loan.PhoneHome) &&
                 String.IsNullOrEmpty(loan.PhoneWork))
                strings.Add("Phone Number");

            // Properties
            if (propertyList.Any(p => p.LoanRecId == loan.RecId && String.IsNullOrEmpty(p.ZipCode)))
                strings.Add("Property Postal Code");
            if (propertyList.Any(p => p.LoanRecId == loan.RecId && String.IsNullOrEmpty(p.County)))
                strings.Add("Property County");

            // Qualified Amount
            if (String.IsNullOrEmpty(userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == QualifiedAmountParentRecId)?.Value) &&
                String.IsNullOrEmpty(userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == IneligibleReasonParentRecId)?.Value))
                strings.Add("Both Qualified Amount and Ineligible Reason are empty");

            // Postal Code County
            // based on: var subset = new[] { 2, 4, 6, 8 }; var superset = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; bool contained = !subset.Except(superset).Any();
            if (propertyList.Where(p => p.LoanRecId == loan.RecId && !String.IsNullOrEmpty(p.County)).Select(p => p.County.Trim().ToLower()).Except(postalCodeList.Select(p => p.County.Trim().ToLower())).Any())
                strings.Add("Property County not in Postal Code List");

            // Qualified Loans - Lessor Appraised Value or Purchase Price > appraisal value where Loan Terms Custom Fields is "Original Commitment Terms"
            if (IsQualifiedLoan(loan.Documentation) && 
                userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LoanTermsParentRecId)?.Value == "Original Commitment Terms" &&
                userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LessorAppraisedValueorPurchasePriceParentRecId)?.Value.ToDecimal() > propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId && (bool)p.Primary).AppraiserFmv)
                strings.Add("Qualified (Original Commitment Terms): Lessor Appraised Value or Purchase Price must be <= Appraisal Value");

            // Qualified Loans - Lessor Appraised Value or Purchase Price != appraisal value where Loan Terms Custom Fields is NOT "Original Commitment Terms"
            if (IsQualifiedLoan(loan.Documentation) && 
                userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LoanTermsParentRecId)?.Value != "Original Commitment Terms" &&
                userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LessorAppraisedValueorPurchasePriceParentRecId)?.Value.ToDecimal() != propertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId && (bool)p.Primary).AppraiserFmv)
                strings.Add("Qualified (Non Original Commitment Terms): Lessor Appraised Value or Purchase Price must = Appraisal Value");

            // Ineligible Loans - non-empty Lessor Appraised Value or Purchase Price
            if (IsIneligibleLoan(loan.Documentation) && !String.IsNullOrEmpty(userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == loan.RecId && f.ParentRecId == LessorAppraisedValueorPurchasePriceParentRecId)?.Value))
                strings.Add("Ineligible: Lessor Appraised Value or Purchase Price must be Empty");

            // Appraisal Date
            if (propertyList.Where(p => p.LoanRecId == loan.RecId).Any(p => p.AppraisalDate != null && p.AppraisalDate.Value.Date > loan.MaturityDate.Value.Date))
                strings.Add("Appraisal Date must be <= Maturity Date");

            // Incomplete loan renewals
            if (incompleteLoanRenewalList.Any(r => r.LoanRecId == loan.RecId))
                strings.Add("Renewal Approval Pending");

            return String.Join(", ", strings);
        }

        public async Task<IEnumerable<TdsCoBorrower>> GetCoBorrowers()
        {
            return await _loanUnitOfWork.CoBorrowerRepository.FindAllAsync();
        }

        public async Task<IEnumerable<TdsProperty>> GetProperties()
        {
            return await _loanUnitOfWork.PropertyRepository.FindAllAsync();
        }

        public async Task<IEnumerable<ModifiedProperty>> GetModifiedPropertyDetailsAsync(DateTime? asOfDate = null)
        {
            _logger.LogInformation($"Calling: LoanService.GetModifiedPropertyDetailsAsync()");

            IEnumerable<ModifiedProperty> modifiedPropertyList = (await _SPRepository.GetModifiedPropertyDetails(asOfDate));

            return modifiedPropertyList;
        }

        public async Task<IEnumerable<TdsLien>> GetLiens()
        {
            return await _loanUnitOfWork.LienRepository.FindAllAsync();
        }

        public async Task<IEnumerable<LienIndexModel>> GetLiens(LienFilterType? FilterType)
        {
            IEnumerable<TdsLoan> loanList = null;
            if (FilterType == LienFilterType.PrincipalBalanceGreaterThanZero) {
                loanList = await GetActiveLoans(DateTime.Today); // Get only closed active loans
            }
            else
            {
                loanList = await GetAllLoans(DateTime.Today); // Get only closed loans
            }
            IEnumerable<TdsProperty> propertyList = await GetProperties();
            IEnumerable<TdsLien> lienList = await _loanUnitOfWork.LienRepository.FindAllAsync();

            IEnumerable<LienIndexModel> LienIndexData = from lien in lienList.OrderBy(l => l.Holder) // Ascending order by holder
                                                        from property in propertyList.Where(p => p.RecId == lien.PropRecId)
                                                        from loan in loanList.Where(l => l.RecId == lien.LoanRecId)
                                                        select new LienIndexModel()
                                                        {
                                                            RecId = lien.RecId,
                                                            LoanRecId = lien.LoanRecId,
                                                            PropRecId = lien.PropRecId,
                                                            Priority = lien.Priority,
                                                            Holder = lien.Holder,
                                                            AccountNo = lien.AccountNo,
                                                            Contact = lien.Contact,
                                                            Phone = lien.Phone,
                                                            Original = lien.Original,
                                                            Current = lien.Current,
                                                            Payment = lien.Payment,
                                                            LastChecked = lien.LastChecked,
                                                            SysTimeStamp = lien.SysTimeStamp,
                                                            SysRecStatus = lien.SysRecStatus,
                                                            SysCreatedDate = lien.SysCreatedDate,
                                                            LoanAccount = loan.Account,
                                                            PrinBal = loan.PrinBal,
                                                            PropertyAddress = property.Street + ", " + property.City + " " + property.State + " " + property.ZipCode
                                                        };
            return LienIndexData;
        }

        public async Task<IEnumerable<UdfValue>> GetUserDefinedFieldsByParentID(string parentID = null)
        {
            return await ((ISharedUnitOfWork)_loanUnitOfWork).UserDefinedValueRepository.FindAsync(v => string.IsNullOrEmpty(parentID) || v.ParentRecId == parentID);
        }

        public async Task<IEnumerable<AppNote>> GetNotes()
        {
            return await ((ISharedUnitOfWork)_loanUnitOfWork).NoteRepository.FindAllAsync();
        }

        public async Task<LoanViewModel> GetLoanDetailsByIdAsync(string RecId)
        {
            _logger.LogInformation("Calling: LoanService.GetLoanDetailsByIdAsync()");

            LoanViewModel loanViewModel = new LoanViewModel();

            loanViewModel.Loan = await _loanUnitOfWork.LoanRepository.FindAsync(RecId);
            loanViewModel.CoBorrowers = await _loanUnitOfWork.CoBorrowerRepository.FindAsync(p => p.LoanRecId == RecId);
            loanViewModel.Fundings = await _loanUnitOfWork.FundingRepository.FindAsync(p => p.LoanRecId == RecId);
            loanViewModel.lenders = (from l in (await _loanUnitOfWork.LenderRepository.FindAllAsync())
                                     join f in loanViewModel.Fundings on l.RecId equals f.LenderRecId
                                     select l).ToList();
            loanViewModel.LoanHistories = await _loanUnitOfWork.LoanHistoryRepository.FindAsync(p => p.LoanRecId == RecId);
            loanViewModel.Charges = await _loanUnitOfWork.ChargeRepository.FindAsync(p => p.ParentRecId == RecId);
            //loanViewModel.ChargesDetails = await _loanUnitOfWork.ChargesDetailRepository.FindAsync(p => p.LoanRecId == RecId);
            loanViewModel.Properties = await _loanUnitOfWork.PropertyRepository.FindAsync(p => p.LoanRecId == RecId);
            loanViewModel.Liens = await _loanUnitOfWork.LienRepository.FindAsync(p => p.LoanRecId == RecId);
            loanViewModel.Insurances = await _loanUnitOfWork.InsuranceRepository.FindAsync(p => p.LoanRecId == RecId);

            // Shared
            //loanViewModel.MICCompany = (await ((ISharedUnitOfWork)_loanUnitOfWork).CompanyRepository.FindAllAsync()).FirstOrDefault();
            loanViewModel.Attachments = await ((ISharedUnitOfWork)_loanUnitOfWork).AttachmentRepository.FindAsync(p => p.OwnerRecId == RecId);
            loanViewModel.Notes = (await ((ISharedUnitOfWork)_loanUnitOfWork).NoteRepository.FindAsync(p => p.RecId == RecId)).FirstOrDefault();
            loanViewModel.UDFFields = await ((ISharedUnitOfWork)_loanUnitOfWork).UserDefinedFieldRepository.FindAsync(p => (UDFFieldOwnerType)p.OwnerType == UDFFieldOwnerType.Loan);
            loanViewModel.UDFValues = await ((ISharedUnitOfWork)_loanUnitOfWork).UserDefinedValueRepository.FindAsync(p => p.OwnerRecId == RecId);
            loanViewModel.UDFTabs = await ((ISharedUnitOfWork)_loanUnitOfWork).UserDefinedTabRepository.FindAllAsync();

            return loanViewModel;
        }

        public BBCCategory GetBBCCategory(TdsLoan loan)
        {
            BBCCategory result = BBCCategory.Undefined;

            if (loan.Documentation == LoanTypeList.SFRCMAOwner.ToDescription() &&
                loan.Priority == (int)LoanPriority.First)
            {
                result = BBCCategory.OwnerOccupied1stMortgages;
            }
            else if ((loan.Documentation == LoanTypeList.SFRCMAOwner.ToDescription() && loan.Priority == (int)LoanPriority.Second) ||
                     (loan.Documentation == LoanTypeList.SFRCMANonOwner.ToDescription() && loan.Priority == (int)LoanPriority.Second))
            {
                result = BBCCategory.OwnerOccupied2ndMortgages;
            }
            else if (loan.Documentation == LoanTypeList.SFRCMANonOwner.ToDescription() &&
                     loan.Priority == (int)LoanPriority.First)
            {
                result = BBCCategory.NonOwner1stMortgages;
            }
            else if (loan.Documentation == LoanTypeList.CMACommercial.ToDescription() &&
                     loan.Priority == (int)LoanPriority.First)
            {
                result = BBCCategory.Commercial1stMortgages;
            }

            return result;
        }

        public async Task<IEnumerable<LoanIndexModel>> GetFilteredLoans(string SearchFor, LoanFilterType? FilterType, List<LoanSearchEnumModel> checkBoxLoanSearchGroup, DateTime? EndDate = null, List<string> releatedLoanList = null)
        {
            _logger.LogInformation($"Calling: LoanService.GetFilteredLoans(): SearchFor, {SearchFor}, LoanFilterType: {FilterType.ToDescription}");

            IEnumerable<TdsProperty> propertyList = await GetProperties();

            // Filtered Loans list is used to pick loans from on each search step
            IEnumerable<TdsLoan> FilteredLoans = await GetFilteredLoansList(FilterType, EndDate, propertyList, releatedLoanList);
            // Loans contains the result
            IEnumerable<TdsLoan> Loans = Enumerable.Empty<TdsLoan>();
            if (checkBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.Loan).IsSelected)
                Loans = FilteredLoans;

            // Get all active loans to calculate qualified amount
            IEnumerable<TdsLoan> AllActiveLoanList = await GetActiveLoans();

            IEnumerable<TdsLien> lienList = await GetLiens();
            IEnumerable<UdfValue> UdfValues = await GetUserDefinedFieldsByParentID();
            IEnumerable<TdsCoBorrower> coborrowers = await GetCoBorrowers();
            IEnumerable<AppNote> notesList = await GetNotes();

            if (!string.IsNullOrEmpty(SearchFor)) {
                if (checkBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.Loan).IsSelected)
                    Loans = LoanFilterService.FilterLoansByLoanContent(SearchFor, Loans);
                // If properties not selected, filter by mailing address
                if (!checkBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.Properties).IsSelected)
                    Loans = Loans.Concat(LoanFilterService.FilterLoansByMailingAddress(SearchFor, Loans, FilteredLoans));

                // Concat all loans which have matching search query in properties, liens, custom fileds and coborrowers
                if (checkBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.Properties).IsSelected)
                    Loans = Loans.Concat(LoanFilterService.FilterLoansByProperties(SearchFor, propertyList, Loans, FilteredLoans));
                if (checkBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.Liens).IsSelected)
                    Loans = Loans.Concat(LoanFilterService.FilterLoansByLiens(SearchFor, lienList, Loans, FilteredLoans));
                if (checkBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.CustomFields).IsSelected)
                    Loans = Loans.Concat(LoanFilterService.FilterLoansByUDFValues(SearchFor, UdfValues, Loans, FilteredLoans));
                if (checkBoxLoanSearchGroup.FirstOrDefault(e => e.LoanSearchGroup == LoanSearchGroup.CoBorrowers).IsSelected)
                    Loans = Loans.Concat(LoanFilterService.FilterLoansByCoBorrowers(SearchFor, coborrowers, Loans, FilteredLoans));
            }

            if (Loans == null || !Loans.Any())
                return Enumerable.Empty<LoanIndexModel>();

            IEnumerable<LoanIndexModel> loanIndexModelList =
            from loan in Loans
            from property in propertyList where property.LoanRecId == loan.RecId && (bool)property.Primary
            select new LoanIndexModel()
            {
                RecId = loan.RecId,
                PlaceOnHold = loan.PlaceOnHold,
                AchServiceStatus = loan.AchServiceStatus,
                Account = loan.Account,
                FirstName = loan.FirstName,
                LastName = loan.LastName,
                PrinBal = loan.PrinBal,
                Priority = loan.Priority,
                ClosingDate = loan.ClosingDate,
                PaidToDate = loan.PaidToDate,
                NextDueDate = loan.NextDueDate,
                MaturityDate = loan.MaturityDate,
                PmtFreq = loan.PmtFreq,
                PmtPi = loan.PmtPi,
                NoteRate = loan.NoteRate,
                SoldRate = loan.SoldRate,
                LoanProperties = propertyList.Where(p => p.LoanRecId == loan.RecId),
                StoredLTV = property.Ltv == null ? 0 : (decimal)property.Ltv,
                ReleatedLoanList = null,
                Notes= notesList.FirstOrDefault(n => n.RecId == loan.RecId),
                QualifiedAmount = (from udfValue in UdfValues
                                   where udfValue.OwnerRecId == loan.RecId && udfValue.ParentRecId == QualifiedAmountParentRecId
                                   select udfValue).FirstOrDefault()?.Value,
                TitleInsuranceAmount = (from udfValue in UdfValues
                                        where udfValue.OwnerRecId == loan.RecId && udfValue.ParentRecId == TitleInsuranceAmountParentRecId
                                        select udfValue).FirstOrDefault()?.Value,
                FireInsuranceAmount = (from udfValue in UdfValues
                                       where udfValue.OwnerRecId == loan.RecId && udfValue.ParentRecId == FireInsuranceAmountParentRecId
                                       select udfValue).FirstOrDefault()?.Value,
                CalculatedQualifiedAmount = GetCalculatedQualifiedAmount(loan,
                            GetCustomValue(UdfValues, loan, LessorAppraisedValueorPurchasePriceParentRecId),
                            propertyList.Where(p => p.LoanRecId == loan.RecId && (bool)p.Primary).FirstOrDefault(),
                            lienList.Where(l => l.LoanRecId == loan.RecId && l.PropRecId == property.RecId).FirstOrDefault(),
                            GetTotalQualifiedOfPreviousLoansForSameSIN(loan, AllActiveLoanList, UdfValues.Where(v => v.ParentRecId == QualifiedAmountParentRecId), coborrowers)),
                CalculatedLTV = LoanFilterService.GetCalculatedLTV(loan, propertyList.Where(p => p.LoanRecId == loan.RecId), lienList.Where(l => l.LoanRecId == loan.RecId)),
                TermsLeft = LoanFilterService.GetTermsLeft(loan)
            };

            return loanIndexModelList;
        }

        public decimal GetCalculatedQualifiedAmount(TdsLoan loan, string UdfValue, TdsProperty primaryPropery, TdsLien primaryFirstLien, decimal totoalQualifiedAmountOfOtherLoansForSameSIN)
        {
            decimal calculatedQualifiedAmount = 0;
            decimal LessorAppraisedValueorPurchasePrice = UdfValue.ToDecimal();

            if (loan.Priority == (int)LoanPriority.Second)
                calculatedQualifiedAmount = Math.Min((decimal)loan.PrinBal, GetSiteSetting(_cache, SiteSettingKey.BMOQUALIFIEDAMOUNTLTVLIMITINPERCENT.ToString()) / 100 * (primaryPropery == null ? 0 : (decimal)primaryPropery.AppraiserFmv) - (primaryFirstLien == null ? 0 : (decimal)primaryFirstLien.Current));
            else
                calculatedQualifiedAmount = Math.Min((decimal)loan.PrinBal, GetSiteSetting(_cache, SiteSettingKey.BMOQUALIFIEDAMOUNTLTVLIMITINPERCENT.ToString()) / 100 * LessorAppraisedValueorPurchasePrice);

            if (GetBBCCategory(loan) == BBCCategory.Commercial1stMortgages)
                calculatedQualifiedAmount = Math.Min(calculatedQualifiedAmount, GetSiteSetting(_cache, SiteSettingKey.BMOCOMMERCIALMAXLIMITPERLOAN.ToString()));
            else
                calculatedQualifiedAmount = Math.Min(calculatedQualifiedAmount, GetSiteSetting(_cache, SiteSettingKey.BMORESIDENTIALMAXLIMITPERLOAN.ToString()));

            // Total qualified amount for all related loans must be less then the Max Limit. Show the difference only for the latest loan.
            if (totoalQualifiedAmountOfOtherLoansForSameSIN > 0 && (totoalQualifiedAmountOfOtherLoansForSameSIN + calculatedQualifiedAmount) > GetSiteSetting(_cache, SiteSettingKey.BMOAGGRAGATEMAXLIMITPERSIN.ToString()))
                calculatedQualifiedAmount = GetSiteSetting(_cache, SiteSettingKey.BMOAGGRAGATEMAXLIMITPERSIN.ToString()) - totoalQualifiedAmountOfOtherLoansForSameSIN;

            return calculatedQualifiedAmount;
        }

        public IEnumerable<TdsProperty> GetActiveProperties(IEnumerable<TdsProperty> propertyList, TdsLoan loan)
        {
            return propertyList.Where(p => p.LoanRecId == loan.RecId && p.AppraiserFmv > 0);
        }

        public string GetCustomValue(IEnumerable<UdfValue> customFieldsValueList, TdsLoan loan, string parentRecID)
        {
            return customFieldsValueList.Where(v => v.OwnerRecId == loan.RecId && v.ParentRecId == parentRecID).FirstOrDefault()?.Value;
        }

        public decimal GetTotalQualifiedOfPreviousLoansForSameSIN(TdsLoan loan, IEnumerable<TdsLoan> loanList, IEnumerable<UdfValue> qualifiedAmountList, IEnumerable<TdsCoBorrower> coborrowersList)
        {
            // Get all loans with same SIN and loans with same SIN in co-borrower list
            IEnumerable<TdsLoan> relatedLoanList = GetRelatedLoanList(loan, loanList, coborrowersList);

            // If not the latest loan, then qualified amount must be calculated. Don't check max limit. Max limit only checked for latest loan.
            // 0 will force to show calculated qualified amount instead of the difference.
            if (IsNotLatestLoan(loan, relatedLoanList))
            {
                return 0;
            }
            // Get the qualified amount of all other loans
            IEnumerable<UdfValue> qualifiedAmountListforSIN = from l in relatedLoanList
                                                              from qualifiedAmount in qualifiedAmountList.Where(v => v.OwnerRecId == l.RecId)
                                                              select qualifiedAmount;

            if (qualifiedAmountListforSIN.Any())
                return qualifiedAmountListforSIN.Sum(v => v.Value.ToDecimal());
            else
                return 0;
        }

        private bool IsNotLatestLoan(TdsLoan loan, IEnumerable<TdsLoan> relatedLoanList)
        {
            int loanNumber = int.Parse(loan.Account.Trim().Replace("L", string.Empty));

            return relatedLoanList.Where(l => int.Parse(l.Account.Trim().Replace("L", string.Empty)) > loanNumber).Any();
        }
        private IEnumerable<TdsLoan> GetRelatedLoanList(TdsLoan loan, IEnumerable<TdsLoan> loanList, IEnumerable<TdsCoBorrower> coborrowersList)
        {
            string SIN = loan.Tin.Trim().Replace("-", string.Empty).Replace(" ", string.Empty);

            // Get all loans with same SIN and loans with same SIN in co-borrower list: principal balance > 0
            IEnumerable<TdsCoBorrower> sameSINCoborrowers = coborrowersList.Where(c => !string.IsNullOrEmpty(SIN) && c.Tin.Trim().Replace("-", string.Empty).Replace(" ", string.Empty) == SIN);
            IEnumerable<TdsLoan> relatedLoanList = from l in loanList
                                                   where (!string.IsNullOrEmpty(SIN) && l.Tin.Trim().Replace("-", string.Empty).Replace(" ", string.Empty) == SIN && l.RecId != loan.RecId && l.PrinBal > 0) // primary borrowers
                                                   select l;

            return relatedLoanList;
        }

        private async Task<IEnumerable<TdsLoan>> GetFilteredLoansList(LoanFilterType? FilterType, DateTime? EndDate, IEnumerable<TdsProperty> propertyList = null, List<string> releatedLoanList = null)
        {
            if (FilterType == LoanFilterType.All)
            {
                return await _loanUnitOfWork.LoanRepository.FindAllAsync(l => l.Account, OrderDirection.Descending);
            }
            else if (FilterType == LoanFilterType.ACHActive)
            {
                return await _loanUnitOfWork.LoanRepository.FindAsync(loan => loan.AchServiceStatus == (int)AchServiceStatus.Active, l => l.Account, OrderDirection.Descending);
            }

            IEnumerable<TdsLoan> loans = await GetActiveLoans(EndDate);

            IEnumerable<TdsPostalCode> PostalCodes = null;
            if (FilterType == LoanFilterType.GTAMortgages ||
                FilterType == LoanFilterType.OttawaMortgages ||
                FilterType == LoanFilterType.GoldenHorseshoeMortgages ||
                FilterType == LoanFilterType.OtherMajorUrbanAreasMortgages)
            {
                PostalCodes = await _postalCodeRepository.FindAllAsync();
            }

            IEnumerable<UdfValue> customFieldsValueList = null;
            IEnumerable<string> outsideGTAPostCodes = null;
            IEnumerable<TdsLien> lienList = null;
            if (FilterType == LoanFilterType.L10To80Mortgages ||
                FilterType == LoanFilterType.L180To90Mortgages ||
                FilterType == LoanFilterType.L190To95Mortgages ||
                FilterType == LoanFilterType.L195To100Mortgages ||
                FilterType == LoanFilterType.L1Above100Mortgages ||
                FilterType == LoanFilterType.L1OverThresholdLTVBelowThreshodBeaconScoreMortgages ||
                FilterType == LoanFilterType.L1OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages ||

                FilterType == LoanFilterType.L20To80Mortgages ||
                FilterType == LoanFilterType.L280To90Mortgages ||
                FilterType == LoanFilterType.L290To95Mortgages ||
                FilterType == LoanFilterType.L295To100Mortgages ||
                FilterType == LoanFilterType.L2Above100Mortgages ||
                FilterType == LoanFilterType.L2OverThresholdLTVBelowThreshodBeaconScoreMortgages ||
                FilterType == LoanFilterType.L2OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages ||

                FilterType == LoanFilterType.L30To80Mortgages ||
                FilterType == LoanFilterType.L380To90Mortgages ||
                FilterType == LoanFilterType.L390To95Mortgages ||
                FilterType == LoanFilterType.L395To100Mortgages ||
                FilterType == LoanFilterType.L3Above100Mortgages ||
                FilterType == LoanFilterType.L3OverThresholdLTVBelowThreshodBeaconScoreMortgages ||
                FilterType == LoanFilterType.L3OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages ||

                FilterType == LoanFilterType.L4OverThresholdLTVBelowThreshodBeaconScoreMortgages ||
                FilterType == LoanFilterType.L4OverThresholdLTVBelowThreshodBeaconScoreOutsideGTAMortgages)
            {
                customFieldsValueList = await GetUserDefinedFieldsByParentID();
                outsideGTAPostCodes = (await _postalCodeRepository.FindAllAsync()).Where(p => p.MortgageRegion != MortgageRegion.GTA.ToDescription()).Select(p => p.County.Trim().ToLower());
                lienList = await GetLiens();

                StressTestReportModel stressTestReportData = new StressTestReportModel()
                {
                    Level1MarketDeclineLimit = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTLEVELONEMARKETDECLINELIMIT.ToString()),
                    Level2MarketDeclineLimit = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTLEVELTWOMARKETDECLINELIMIT.ToString()),
                    Level3MarketDeclineLimit = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTLEVELTHREEMARKETDECLINELIMIT.ToString()),
                    AtRiskBeaconScoreThreshold = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTATRISKBEACONSCORETHRESHOLD.ToString()),
                    AtRiskLTVThreshold = (int)GetSiteSetting(_cache, SiteSettingKey.STRESSTESTATRISKLTVTHRESHOLD.ToString())
                };

                return LoanFilterService.StressTestLoanFilter(loans, FilterType, stressTestReportData, propertyList, customFieldsValueList, outsideGTAPostCodes, lienList, GetSiteSettingDateTime(_cache, SiteSettingKey.STRESSTESTLEVEL4APPRAISALDATEUPPERLIMIT.ToString()));
            }

            if (FilterType == LoanFilterType.PortfolioByLTVMoreThan80 ||
                FilterType == LoanFilterType.PortfolioByLTV75To80 ||
                FilterType == LoanFilterType.PortfolioByLTV65To75 ||
                FilterType == LoanFilterType.PortfolioByLTVLessEqual65)
            {
                lienList = await GetLiens();
            }

            if (FilterType == LoanFilterType.OwnerOccupied1stMortgagesLTVLessThan50GTA ||
                FilterType == LoanFilterType.OwnerOccupied1stMortgagesOther)
            {
                customFieldsValueList = await GetUserDefinedFieldsByParentID(LessorAppraisedValueorPurchasePriceParentRecId);
                PostalCodes = await _postalCodeRepository.FindAsync(p => p.MortgageRegion == MortgageRegion.GTA.ToDescription());
                lienList = await GetLiens();
            }

            return LoanFilterService.FilterLoansByFilterType(loans, FilterType, EndDate, releatedLoanList, PostalCodes, propertyList, lienList, customFieldsValueList);
        }

        public async Task UpdateRenewal(LoanRenewalModel loanRenewalModel)
        {
            TdsLoan loan = await _loanUnitOfWork.LoanRepository.FindAsync(loanRenewalModel.RecId);

            TdsLoanRenewal loanRenewalData = (await _renewalRepository.FindAsync(r => r.LoanRecId == loanRenewalModel.RecId && r.MaturityDate == loanRenewalModel.MaturityDate)).FirstOrDefault();

            if (loanRenewalData == null)
            {
                loanRenewalData = new TdsLoanRenewal()
                {
                    CreatedDate = DateTime.Now,
                    CreatedBy = loanRenewalModel.ModifiedBy,
                    RenewalStatus = MortgageRenewalStatus.None // Need this to trigger a full update in the next if statement
                };
            }

            // For completed and paid off status, only update the status. Users have to change to status before editing the content.
            if (loanRenewalModel.RenewalIsActive(loanRenewalData.RenewalStatus))
            {
                loanRenewalData.LoanRecId = loan.RecId;
                loanRenewalData.Account = loan.Account;
                loanRenewalData.Notes = String.IsNullOrEmpty(loanRenewalModel.Notes) ? "<p></p>" : loanRenewalModel.Notes;
                loanRenewalData.MaturityDate = loanRenewalModel.MaturityDate;
                loanRenewalData.ModifiedDate = DateTime.Now;
                loanRenewalData.ModifiedBy = loanRenewalModel.ModifiedBy;
                
                loanRenewalData.PrinBal = loanRenewalModel.PrinBal ?? loan.PrinBal;
                loanRenewalData.PrinPaydown = loanRenewalModel.PrinPaydown ?? 0;
                loanRenewalData.NewPrinBal = loanRenewalModel.NewPrinBal ?? loan.PrinBal;
                loanRenewalData.RenewalTerms = loanRenewalModel.RenewalTerms;
                loanRenewalData.MortgageType = loanRenewalModel.MortgageType;
                loanRenewalData.PrimeInterestRate = loanRenewalModel.RenewalIRIsVariable == true ? loanRenewalModel.PrimeInterestRate : null;
                loanRenewalData.RenewalIR = loanRenewalModel.RenewalIR;
                loanRenewalData.RenewalIRIsVariable = loanRenewalModel.RenewalIRIsVariable;
                loanRenewalData.RenewalFee = loanRenewalModel.RenewalFee;
                loanRenewalData.RenewalFeeIsDollar = loanRenewalModel.RenewalFeeIsDollar;
                loanRenewalData.AddRenewalFeeToPrinBal = loanRenewalModel.AddRenewalFeeToPrinBal;
                loanRenewalData.LenderFee = loanRenewalModel.LenderFee;
                loanRenewalData.LenderFeeIsDollar = loanRenewalModel.LenderFeeIsDollar;
                loanRenewalData.AddLenderFeeToPrinBal = loanRenewalModel.AddLenderFeeToPrinBal;
                loanRenewalData.BrokerFee = loanRenewalModel.BrokerFee;
                loanRenewalData.BrokerFeeIsDollar = loanRenewalModel.BrokerFeeIsDollar;
                loanRenewalData.AddBrokerFeeToPrinBal = loanRenewalModel.AddBrokerFeeToPrinBal;
                loanRenewalData.AdminFee = loanRenewalModel.AdminFee;
                loanRenewalData.AddAdminFeeToPrinBal = loanRenewalModel.AddAdminFeeToPrinBal;
                loanRenewalData.AppraisalFee = loanRenewalModel.AppraisalFee;
                loanRenewalData.AddAppraisalFeeToPrinBal = loanRenewalModel.AddAppraisalFeeToPrinBal;
                loanRenewalData.OtherFees = loanRenewalModel.OtherFees;

                loanRenewalData.IDExpired = loanRenewalModel.IDExpired;
                loanRenewalData.FireInsuranceExpired = loanRenewalModel.FireInsuranceExpired;
            }

            loanRenewalData.ApprovedDate = loanRenewalModel.ApprovedDate;
            loanRenewalData.ApprovedBy = loanRenewalModel.ApprovedBy;
            loanRenewalData.RenewalStatus = loanRenewalModel.RenewalStatus;

            await _renewalRepository.UpdateAsync(loanRenewalData);
        }

        public async Task<LoanRenewalModel> GetRenewalByIdAndMaturityDate(string loanRecId, DateTime maturityDate)
        {
            TdsLoan loan = await _loanUnitOfWork.LoanRepository.FindAsync(loanRecId);
            IEnumerable<TdsProperty> propertyList = (await _loanUnitOfWork.PropertyRepository.FindAsync(p => p.LoanRecId == loan.RecId));
            UdfValue consentingSpouseUDFValue = (await ((ISharedUnitOfWork)_loanUnitOfWork).UserDefinedValueRepository.FindAsync(v => v.OwnerRecId == loan.RecId &&
                                                                                                                                      v.ParentRecId == ConsentingSpouseParentRecId)).FirstOrDefault();
            IEnumerable<TdsCoBorrower> coBorrowersList = await _loanUnitOfWork.CoBorrowerRepository.FindAsync(c => c.LoanRecId == loan.RecId);
            TdsLoanRenewal loanRenewalData = (await _renewalRepository.FindAsync(r => r.LoanRecId == loanRecId && r.MaturityDate == maturityDate)).FirstOrDefault();

            LoanRenewalModel renewalList = new LoanRenewalModel()
            {
                RecId = loan.RecId,
                Account = loan.Account,
                FullName = loan.FullName,
                PrimaryFirstLastName = $"{loan.FirstName} {loan.Mi} {loan.LastName}",
                CoBorrowersList = coBorrowersList.Count() > 0 ? string.Join(',', coBorrowersList.Select(c => c.FullName)) : "",
                DirectorsList = GetDirectors(),
                ConscentingSpouse = consentingSpouseUDFValue?.Value,
                PmtPi = loan.PmtPi,
                Priority = (LoanPriority)loan.Priority,
                NoteRate = loan.NoteRate,
                SoldRate = loan.SoldRate,
                PaidToDate = loan.PaidToDate,
                PropertyAddresses = GetPropertyAddresses(propertyList),
                MaturityDate = loanRenewalData?.MaturityDate ?? loan.MaturityDate,
                Notes = String.IsNullOrEmpty(loanRenewalData?.Notes) ? "<p></p>" : loanRenewalData.Notes,

                PrinBal = loanRenewalData?.PrinBal ?? loan.PrinBal,
                PrinPaydown = loanRenewalData?.PrinPaydown ?? 0,
                NewPrinBal = loanRenewalData?.NewPrinBal ?? loan.PrinBal,
                RenewalStatus = loanRenewalData?.RenewalStatus ?? MortgageRenewalStatus.None,
                RenewalTerms = loanRenewalData?.RenewalTerms ?? MortgageRenewalTerms.TwelveMonths,
                MortgageType = loanRenewalData?.MortgageType ?? MortgageType.Closed,
                PrimeInterestRate = loanRenewalData?.PrimeInterestRate ?? GetSiteSetting(_cache, SiteSettingKey.BMOPRIMEINTERESTRATE.ToString()), // New - use current prime
                RenewalIR = Math.Round(loanRenewalData?.RenewalIR ?? 0, 2),
                RenewalIRIsVariable = loanRenewalData?.RenewalIRIsVariable ?? true,
                RenewalFee = Math.Round(loanRenewalData?.RenewalFee ?? 0),
                RenewalFeeIsDollar = loanRenewalData?.RenewalFeeIsDollar ?? true,
                AddRenewalFeeToPrinBal = loanRenewalData?.AddRenewalFeeToPrinBal ?? false,
                LenderFee = Math.Round(loanRenewalData?.LenderFee ?? 0),
                LenderFeeIsDollar = loanRenewalData?.LenderFeeIsDollar ?? true,
                AddLenderFeeToPrinBal = loanRenewalData?.AddLenderFeeToPrinBal ?? false,
                BrokerFee = Math.Round(loanRenewalData?.BrokerFee ?? 0),
                BrokerFeeIsDollar = loanRenewalData?.BrokerFeeIsDollar ?? true,
                AddBrokerFeeToPrinBal = loanRenewalData?.AddBrokerFeeToPrinBal ?? false,
                AdminFee = Math.Round(loanRenewalData?.AdminFee ?? 750),
                AddAdminFeeToPrinBal = loanRenewalData?.AddAdminFeeToPrinBal ?? false,
                AppraisalFee = Math.Round(loanRenewalData?.AppraisalFee ?? 0),
                AddAppraisalFeeToPrinBal = loanRenewalData?.AddAppraisalFeeToPrinBal ?? false,
                OtherFees = loanRenewalData?.OtherFees ?? "[{\"Name\":\"Other Fee\",\"Value\":\"0\",\"AddToPrincipal\":true}]",

                IDExpired = loanRenewalData?.IDExpired ?? false,
                FireInsuranceExpired = loanRenewalData?.FireInsuranceExpired ?? false,

                ApprovedDate = loanRenewalData?.ApprovedDate,
                ApprovedBy = loanRenewalData?.ApprovedBy,

                // Dynamic
                DaysLeft = (int)(loan.MaturityDate.Value.Date - DateTime.Today.Date).TotalDays
            };

            return renewalList;

            string GetDirectors()
            {
                string directors = "";

                // Primary Borrower as Director
                if (loan.FullName.Contains("INC", StringComparison.OrdinalIgnoreCase) ||
                    loan.FullName.Contains("LTD", StringComparison.OrdinalIgnoreCase) ||
                    loan.FullName.Contains("incorporated", StringComparison.OrdinalIgnoreCase) ||
                    loan.FullName.Contains("limited", StringComparison.OrdinalIgnoreCase)) 
                {
                    directors += $"{loan.FirstName} {loan.Mi} {loan.LastName}";
                }

                // CoBorrowers as Directors
                var directorCoborrowerList = coBorrowersList.Where(c => c.RecType == (int)CoBorrowerType.Other);
                if (directorCoborrowerList != null && directorCoborrowerList.Count() > 0)
                {
                    if (!String.IsNullOrEmpty(directors))
                        directors += ",";
                    directors += String.Join(',', directorCoborrowerList.Select(c => c.FullName));
                }

                // Consenting Spouse as Director
                if (!String.IsNullOrEmpty(directors) && !string.IsNullOrEmpty(consentingSpouseUDFValue?.Value))
                {
                    directors += $",{consentingSpouseUDFValue?.Value}";
                }
                return directors;
            }
        }

        public IEnumerable<TdsLoan> GetRenewalLoans(IEnumerable<TdsLoan> Loans)
        {
            return LoanFilterService.RenewalLoanFilter(Loans, (double)GetSiteSetting(_cache, SiteSettingKey.NOOFDAYSLOANSUPFORRENEWAL.ToString()));
        }

        public async Task<IEnumerable<LoanRenewalModel>> GetRenewals(string searchFor = null)
        {
            IEnumerable<TdsLoan> allLoanList = await GetAllLoans();
            IEnumerable<TdsLoan> renewalLoanList = GetRenewalLoans(allLoanList);  
            IEnumerable<TdsProperty> propertyList = await _loanUnitOfWork.PropertyRepository.FindAllAsync();

            IEnumerable<TdsLoanRenewal> loanRenewalDataList = await _renewalRepository.FindAllAsync();

            // First get all records in the TdsLoanRenewal. This contains inprogress and past records.
            IEnumerable<LoanRenewalModel> loanRenewalList = from renewal in loanRenewalDataList
                                                            join loan in allLoanList on renewal.LoanRecId equals loan.RecId
                                                            select new LoanRenewalModel()
                                                            {
                                                                RecId = loan.RecId,
                                                                Account = loan.Account,
                                                                FullName = loan.FullName,
                                                                PrinBal = loan.PrinBal,
                                                                PmtPi = loan.PmtPi,
                                                                PaidToDate = loan.PaidToDate,
                                                                PropertyAddresses = GetPropertyAddresses(propertyList.Where(p => p.LoanRecId == loan.RecId)),
                                                                MaturityDate = renewal.MaturityDate,
                                                                Notes = String.IsNullOrEmpty(renewal.Notes) ? "<p></p>" : renewal.Notes,

                                                                PrinPaydown = renewal.PrinPaydown,
                                                                NewPrinBal = renewal.NewPrinBal,
                                                                RenewalStatus = renewal.RenewalStatus,
                                                                RenewalTerms = renewal.RenewalTerms,
                                                                MortgageType = renewal.MortgageType,
                                                                PrimeInterestRate = renewal.PrimeInterestRate, // New - list does not need a prime - set to 0
                                                                RenewalIR = renewal.RenewalIR,
                                                                RenewalIRIsVariable = renewal.RenewalIRIsVariable,
                                                                RenewalFee = renewal.RenewalFee,
                                                                RenewalFeeIsDollar = renewal.RenewalFeeIsDollar,
                                                                LenderFee = renewal.LenderFee,
                                                                LenderFeeIsDollar = renewal.LenderFeeIsDollar,
                                                                BrokerFee = renewal.BrokerFee,
                                                                BrokerFeeIsDollar = renewal.BrokerFeeIsDollar,
                                                                AdminFee = renewal.AdminFee,
                                                                AppraisalFee = renewal.AppraisalFee,
                                                                OtherFees = renewal.OtherFees,
                                                            
                                                                IDExpired = renewal.IDExpired,
                                                                FireInsuranceExpired = renewal.FireInsuranceExpired,

                                                                ApprovedBy = renewal.ApprovedBy,
                                                                ApprovedDate = renewal.ApprovedDate,

                                                                // Dynamic
                                                                DaysLeft = (int)(loan.MaturityDate.Value.Date - DateTime.Today.Date).TotalDays,
                                                                PastRenewalCount = loanRenewalDataList.Where(r => r.LoanRecId == loan.RecId && r.MaturityDate < renewal.MaturityDate && r.RenewalStatus == MortgageRenewalStatus.Completed).Count()
                                                            };

            // Then, get all the fresh renewals which do not have records in the TdsLoanRenewal table.
            IEnumerable<LoanRenewalModel> newRenewalList = from loan in renewalLoanList.Where(r => !loanRenewalList.Any(l => l.RecId == r.RecId && l.MaturityDate == r.MaturityDate))
                                                           select new LoanRenewalModel()
                                                           {
                                                               RecId = loan.RecId,
                                                               Account = loan.Account,
                                                               FullName = loan.FullName,
                                                               PrinBal = loan.PrinBal,
                                                               PrinPaydown = 0,
                                                               NewPrinBal = loan.PrinBal,
                                                               PmtPi = loan.PmtPi,
                                                               PaidToDate = loan.PaidToDate,
                                                               PropertyAddresses = GetPropertyAddresses(propertyList.Where(p => p.LoanRecId == loan.RecId)),
                                                               MaturityDate = loan.MaturityDate,
                                                               Notes = "<p></p>",

                                                               // New record - default values
                                                               RenewalStatus = MortgageRenewalStatus.None,
                                                               RenewalTerms = MortgageRenewalTerms.TwelveMonths,
                                                               MortgageType = MortgageType.Closed,
                                                               PrimeInterestRate = 0,
                                                               RenewalIR = 0,
                                                               RenewalIRIsVariable = true,
                                                               RenewalFee = 0,
                                                               RenewalFeeIsDollar = true,
                                                               LenderFee = 0,
                                                               LenderFeeIsDollar = true,
                                                               BrokerFee = 0,
                                                               BrokerFeeIsDollar = true,
                                                               AdminFee = 0,
                                                               AppraisalFee = 0,
                                                               OtherFees = "[{\"Name\":\"Other Fee\",\"Value\":\"0\",\"AddToPrincipal\":true}]",
                                                           
                                                               IDExpired = false,
                                                               FireInsuranceExpired = false,
                                                           
                                                               // Dynamic
                                                               DaysLeft = (int)(loan.MaturityDate.Value.Date - DateTime.Today.Date).TotalDays,
                                                               PastRenewalCount = loanRenewalDataList.Where(r => r.LoanRecId == loan.RecId && r.MaturityDate < loan.MaturityDate && r.RenewalStatus == MortgageRenewalStatus.Completed).Count()
                                                           };
            
            // Merge two and return
            return newRenewalList.Concat(loanRenewalList);
        }

        public IEnumerable<LoanAvgAppraisalDataModel> GetAverageAppraisalDateDataForLoans(IEnumerable<TdsLoan> loanList, IEnumerable<TdsProperty> propertyList)
        {
            IEnumerable<TdsProperty> filteredPropertyList = propertyList.Where(p => loanList.Any(l => l.RecId == p.LoanRecId) &&
                                                                                                p.AppraiserFmv != null && p.AppraiserFmv > 0 && p.AppraisalDate != null);

            return from property in filteredPropertyList
                   group property by property.LoanRecId into propertyGroup
                   select new LoanAvgAppraisalDataModel()
                   {
                       LoanRecID = propertyGroup.Key,
                       Account = loanList.FirstOrDefault(l => l.RecId == propertyGroup.Key).Account,
                       AverageAppraisalDaysToDate = (decimal)(propertyGroup?.Average(p => (DateTime.Now - p.AppraisalDate).Value.TotalDays) ?? 0) // Average Appraisal Days Since Last Appraisal
                   };
        }

        private string GetPropertyAddresses(IEnumerable<TdsProperty> propertyList)
        {
            TdsProperty primparyProperty = propertyList.FirstOrDefault(p => (bool)p.Primary);
            string propertyAddressList = $"{primparyProperty.Street}, {primparyProperty.City} {primparyProperty.State} {primparyProperty.ZipCode}";

            IEnumerable<TdsProperty> blanketPropertyList = propertyList.Where(p => !(bool)p.Primary);

            foreach (TdsProperty property in blanketPropertyList ?? Enumerable.Empty<TdsProperty>())
            {
                propertyAddressList += $" &amp; {property.Street}, {property.City} {property.State} {property.ZipCode}";
            }

            return propertyAddressList;
        }

    }
}