using KuberMICManager.Core.Application.HelperSerivces;
using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure;
using KuberMICManager.Core.Domain.HelperDataModels;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
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
    public class DashboardService : IDashboardService
    {
        // inject the dependencies
        private readonly ILogger<DashboardService> _logger;
        private readonly ILoanService _loanService;
        private readonly IRenewalRepository _renewalRepository;
        private readonly IPartnerService _partnerService;
        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly IMemoryCache _cache;
        private readonly ISPRepository _getUserData;
        public DashboardService(ILogger<DashboardService> logger,
                           ILoanService loanService,
                           IRenewalRepository renewalRepository,
                           IPartnerService partnerService,
                           IPostalCodeRepository postalCodeRepository,
                           IMemoryCache cache,
                           ISPRepository getUserData
                           )
        {
            _logger = logger;
            _loanService = loanService;
            _renewalRepository = renewalRepository;
            _partnerService = partnerService;
            _postalCodeRepository = postalCodeRepository;
            _cache = cache;
            _getUserData = getUserData; 
        }

        public async Task<DashboardLoanViewModel> GetLoanSummaryForDashboard(DateTime? endDate)
        {
            _logger.LogInformation($"Calling: DashboardService.GetLoanSummaryForDashboard(): End Date, {endDate}\n");

            IEnumerable<TdsLoan> Loans = await _loanService.GetActiveLoans(endDate);
            IEnumerable<UdfValue> udfValueList = await _loanService.GetUserDefinedFieldsByParentID(null);
            IEnumerable<UdfValue> AverageCreditScoreUDFValues = udfValueList.Where(u => u.ParentRecId == AverageCreditScoreParentRecId);
            IEnumerable<UdfValue> SubjectPropertySquareFootageUDFValues = udfValueList.Where(u => u.ParentRecId == SubjectPropertySquareFootageParentRecId);
            IEnumerable<TdsProperty> propertyList = await _loanService.GetProperties();
            IEnumerable<TdsProperty> primaryPropertyList = propertyList.Where(p => (bool)p.Primary);
            IEnumerable<TdsLien> lienList = await _loanService.GetLiens();
            IEnumerable<TdsPostalCode> postalCodeList = await _postalCodeRepository.FindAllAsync();
            IEnumerable<TdsLoanRenewal> incompleteLoanRenewalList = await _renewalRepository.FindAsync(r => r.RenewalStatus == MortgageRenewalStatus.Completed && !r.ApprovedDate.HasValue);
            IEnumerable<GetUserData> userdata = await _getUserData.GetUserData();

            IEnumerable<TdsLoan> LoansFirst = null;
            IEnumerable<TdsLoan> LoansSecond = null;
            IEnumerable<TdsLoan> LoansThird = null;

            IEnumerable<TdsLoan> LoansResidential = null;
            IEnumerable<TdsLoan> LoansCommercial = null;
            IEnumerable<TdsLoan> LoansLand = null;
            IEnumerable<TdsLoan> LoansConstruction = null;
            IEnumerable<TdsLoan> LoansUncategorized = null;

            IEnumerable<TdsLoan> Loans0To30DaysLate = null;
            IEnumerable<TdsLoan> Loans31To90DaysLate = null;
            IEnumerable<TdsLoan> Loans91To270DaysLate = null;
            IEnumerable<TdsLoan> LoansGtrThan270DaysLate = null;

            IEnumerable<TdsLoan> LoansGTA = null;
            IEnumerable<TdsLoan> LoansOttawa = null;
            IEnumerable<TdsLoan> LoansGoldenHorseshoe = null;
            IEnumerable<TdsLoan> LoansOtherMajorUrbanAreas = null;

            IEnumerable<TdsLoan> LoansRemainingTermtoMaturityLessEqual6 = null;
            IEnumerable<TdsLoan> LoansRemainingTermtoMaturity6To9 = null;
            IEnumerable<TdsLoan> LoansRemainingTermtoMaturity9To12 = null;
            IEnumerable<TdsLoan> LoansRemainingTermtoMaturityMoreThan12 = null;

            IEnumerable<TdsLoan> LoansByLTVMoreThan80 = null;
            IEnumerable<TdsLoan> LoansByLTV75To80 = null;
            IEnumerable<TdsLoan> LoansByLTV65To75 = null;
            IEnumerable<TdsLoan> LoansByLTVLessEqual65 = null;

            Parallel.Invoke(() => LoansFirst = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.FirstMortgage),
                            () => LoansSecond = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.SecondMortgage),
                            () => LoansThird = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.ThirdMortgage),

                            () => LoansResidential = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.Residential),
                            () => LoansCommercial = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.Commercial),
                            () => LoansLand = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.Land),
                            () => LoansConstruction = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.Construction),
                            () => LoansUncategorized = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.Uncategorized),

                            () => Loans0To30DaysLate = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.DaysLate0To30),
                            () => Loans31To90DaysLate = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.DaysLate31To90),
                            () => Loans91To270DaysLate = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.DaysLate91To270),
                            () => LoansGtrThan270DaysLate = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.DaysLateGtrThan270),

                            () => LoansGTA = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.GTAMortgages, endDate, null, postalCodeList, propertyList),
                            () => LoansOttawa = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.OttawaMortgages, endDate, null, postalCodeList, propertyList),
                            () => LoansGoldenHorseshoe = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.GoldenHorseshoeMortgages, endDate, null, postalCodeList, propertyList),
                            () => LoansOtherMajorUrbanAreas = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.OtherMajorUrbanAreasMortgages, endDate, null, postalCodeList, propertyList),

                            () => LoansRemainingTermtoMaturityLessEqual6 = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.RemainingTermToMaturityLessEqual6, endDate, null, postalCodeList, propertyList, lienList),
                            () => LoansRemainingTermtoMaturity6To9 = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.RemainingTermToMaturity6To9, endDate, null, postalCodeList, propertyList, lienList),
                            () => LoansRemainingTermtoMaturity9To12 = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.RemainingTermToMaturity9To12, endDate, null, postalCodeList, propertyList, lienList),
                            () => LoansRemainingTermtoMaturityMoreThan12 = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.RemainingTermToMaturityMoreThan12, endDate, null, postalCodeList, propertyList, lienList),

                            () => LoansByLTVMoreThan80 = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.PortfolioByLTVMoreThan80, endDate, null, postalCodeList, propertyList, lienList),
                            () => LoansByLTV75To80 = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.PortfolioByLTV75To80, endDate, null, postalCodeList, propertyList, lienList),
                            () => LoansByLTV65To75 = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.PortfolioByLTV65To75, endDate, null, postalCodeList, propertyList, lienList),
                            () => LoansByLTVLessEqual65 = LoanFilterService.FilterLoansByFilterType(Loans, LoanFilterType.PortfolioByLTVLessEqual65, endDate, null, postalCodeList, propertyList, lienList));

            IEnumerable<TdsLoan> PricePerSFLoansDetachedInGTA = null;
            IEnumerable<TdsLoan> PricePerSFLoansSemiDetachedInGTA = null;
            IEnumerable<TdsLoan> PricePerSFLoansRowHousingInGTA = null;
            IEnumerable<TdsLoan> PricePerSFLoansCondoInGTA = null;
            IEnumerable<TdsLoan> PricePerSFLoansGTA = null;

            IEnumerable<TdsLoan> PricePerSFLoansDetachedInOttawa = null;
            IEnumerable<TdsLoan> PricePerSFLoansSemiDetachedInOttawa = null;
            IEnumerable<TdsLoan> PricePerSFLoansRowHousingInOttawa = null;
            IEnumerable<TdsLoan> PricePerSFLoansCondoInOttawa = null;
            IEnumerable<TdsLoan> PricePerSFLoansOttawa = null;

            IEnumerable<TdsLoan> PricePerSFLoansDetachedInGoldenHorseshoe = null;
            IEnumerable<TdsLoan> PricePerSFLoansSemiDetachedInGoldenHorseshoe = null;
            IEnumerable<TdsLoan> PricePerSFLoansRowHousingInGoldenHorseshoe = null;
            IEnumerable<TdsLoan> PricePerSFLoansCondoInGoldenHorseshoe = null;
            IEnumerable<TdsLoan> PricePerSFLoansGoldenHorseshoe = null;

            IEnumerable<TdsLoan> PricePerSFLoansDetachedInOtherMajorUrbanAreas = null;
            IEnumerable<TdsLoan> PricePerSFLoansSemiDetachedInOtherMajorUrbanAreas = null;
            IEnumerable<TdsLoan> PricePerSFLoansRowHousingInOtherMajorUrbanAreas = null;
            IEnumerable<TdsLoan> PricePerSFLoansCondoPriceInOtherMajorUrbanAreas = null;
            IEnumerable<TdsLoan> PricePerSFLoansOtherMajorUrbanAreas = null;

            IEnumerable<TdsLoan> PricePerSFLoansDetached = null;
            IEnumerable<TdsLoan> PricePerSFLoansSemiDetached = null;
            IEnumerable<TdsLoan> PricePerSFLoansRowHousing = null;
            IEnumerable<TdsLoan> PricePerSFLoansCondo = null;
            IEnumerable<TdsLoan> PricePerSFLoans = null;

            Parallel.Invoke(() => PricePerSFLoansDetachedInGTA = LoanFilterService.FilterLoansByPropertyType(LoansGTA, LoanFilterType.Detached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansSemiDetachedInGTA = LoanFilterService.FilterLoansByPropertyType(LoansGTA, LoanFilterType.SemiDetached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansRowHousingInGTA = LoanFilterService.FilterLoansByPropertyType(LoansGTA, LoanFilterType.RowHousing, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansCondoInGTA = LoanFilterService.FilterLoansByPropertyType(LoansGTA, LoanFilterType.Condo, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansGTA = LoanFilterService.FilterLoansByPropertyType(LoansGTA, LoanFilterType.All, primaryPropertyList, SubjectPropertySquareFootageUDFValues),

                            () => PricePerSFLoansDetachedInOttawa = LoanFilterService.FilterLoansByPropertyType(LoansOttawa, LoanFilterType.Detached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansSemiDetachedInOttawa = LoanFilterService.FilterLoansByPropertyType(LoansOttawa, LoanFilterType.SemiDetached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansRowHousingInOttawa = LoanFilterService.FilterLoansByPropertyType(LoansOttawa, LoanFilterType.RowHousing, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansCondoInOttawa = LoanFilterService.FilterLoansByPropertyType(LoansOttawa, LoanFilterType.Condo, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansOttawa = LoanFilterService.FilterLoansByPropertyType(LoansOttawa, LoanFilterType.All, primaryPropertyList, SubjectPropertySquareFootageUDFValues),

                            () => PricePerSFLoansDetachedInGoldenHorseshoe = LoanFilterService.FilterLoansByPropertyType(LoansGoldenHorseshoe, LoanFilterType.Detached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansSemiDetachedInGoldenHorseshoe = LoanFilterService.FilterLoansByPropertyType(LoansGoldenHorseshoe, LoanFilterType.SemiDetached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansRowHousingInGoldenHorseshoe = LoanFilterService.FilterLoansByPropertyType(LoansGoldenHorseshoe, LoanFilterType.RowHousing, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansCondoInGoldenHorseshoe = LoanFilterService.FilterLoansByPropertyType(LoansGoldenHorseshoe, LoanFilterType.Condo, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansGoldenHorseshoe = LoanFilterService.FilterLoansByPropertyType(LoansGoldenHorseshoe, LoanFilterType.All, primaryPropertyList, SubjectPropertySquareFootageUDFValues),

                            () => PricePerSFLoansDetachedInOtherMajorUrbanAreas = LoanFilterService.FilterLoansByPropertyType(LoansOtherMajorUrbanAreas, LoanFilterType.Detached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansSemiDetachedInOtherMajorUrbanAreas = LoanFilterService.FilterLoansByPropertyType(LoansOtherMajorUrbanAreas, LoanFilterType.SemiDetached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansRowHousingInOtherMajorUrbanAreas = LoanFilterService.FilterLoansByPropertyType(LoansOtherMajorUrbanAreas, LoanFilterType.RowHousing, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansCondoPriceInOtherMajorUrbanAreas = LoanFilterService.FilterLoansByPropertyType(LoansOtherMajorUrbanAreas, LoanFilterType.Condo, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansOtherMajorUrbanAreas = LoanFilterService.FilterLoansByPropertyType(LoansOtherMajorUrbanAreas, LoanFilterType.All, primaryPropertyList, SubjectPropertySquareFootageUDFValues),

                            () => PricePerSFLoansDetached = LoanFilterService.FilterLoansByPropertyType(Loans, LoanFilterType.Detached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansSemiDetached = LoanFilterService.FilterLoansByPropertyType(Loans, LoanFilterType.SemiDetached, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansRowHousing = LoanFilterService.FilterLoansByPropertyType(Loans, LoanFilterType.RowHousing, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoansCondo = LoanFilterService.FilterLoansByPropertyType(Loans, LoanFilterType.Condo, primaryPropertyList, SubjectPropertySquareFootageUDFValues),
                            () => PricePerSFLoans = LoanFilterService.FilterLoansByPropertyType(Loans, LoanFilterType.All, primaryPropertyList, SubjectPropertySquareFootageUDFValues));

            decimal TotalPrincipalBalance = 0;
            decimal TotalPrincipalBalanceForFirst = 0;
            decimal TotalPrincipalBalanceForSecond = 0;
            decimal TotalPrincipalBalanceForThird = 0;

            decimal TotalPrincipalBalanceForResidential = 0;
            decimal TotalPrincipalBalanceForCommercial = 0;
            decimal TotalPrincipalBalanceForLand = 0;
            decimal TotalPrincipalBalanceForConstruction = 0;
            decimal TotalPrincipalBalanceForUncategorized = 0;

            decimal PrincipalBalance0To30DaysLate = 0;
            decimal PrincipalBalance31To90DaysLate = 0;
            decimal PrincipalBalance91To270DaysLate = 0;
            decimal PrincipalBalanceMoreThan270DaysLate = 0;

            decimal PrincipalBalanceForGTA = 0;
            decimal PrincipalBalanceForOttawa = 0;
            decimal PrincipalBalanceForGoldenHorseshoe = 0;
            decimal PrincipalBalanceForOtherMajorUrbanAreas = 0;

            decimal TotalPrincipalBalanceRemainingTermtoMaturityLessEqual6 = 0;
            decimal TotalPrincipalBalanceRemainingTermtoMaturity6To9 = 0;
            decimal TotalPrincipalBalanceRemainingTermtoMaturity9To12 = 0;
            decimal TotalPrincipalBalanceRemainingTermtoMaturityMoreThan12 = 0;

            decimal TotalPrincipalBalancePortfolioByLTVMoreThan80 = 0;
            decimal TotalPrincipalBalancePortfolioByLTV75To80 = 0;
            decimal TotalPrincipalBalancePortfolioByLTV65To75 = 0;
            decimal TotalPrincipalBalancePortfolioByLTVLessEqual65 = 0;

            // Mortgage by Priority
            int NoOfLoansFirst = 0;
            int NoOfLoansSecond = 0;
            int NoOfLoansThird = 0;

            // Loan Summary by Loan Type
            int NoOfLoansResidential = 0;
            int NoOfLoansCommercial = 0;
            int NoOfLoansLand = 0;
            int NoOfLoansConstruction = 0;
            int NoOfLoansUncategorized = 0;

            // Late Payment
            int TotoalNoOfLoans0To30DaysLate = 0;
            int TotoalNoOfLoans31To90DaysLate = 0;
            int TotoalNoOfLoans91To270DaysLate = 0;
            int TotoalNoOfLoansMoreThan270DaysLate = 0;

            // Postal Code Summary
            int NoOfLoansByPostalCodeInGTA = 0;
            int NoOfLoansByPostalCodeInOttawa = 0;
            int NoOfLoansByPostalCodeInGoldenHorseshoe = 0;
            int NoOfLoansByPostalCodeInOtherMajorUrbanAreas = 0;

            // Price per SF
            int NoOfLoansPricePerSFDetachedInGTA = 0;
            int NoOfLoansPricePerSFSemiDetachedInGTA = 0;
            int NoOfLoansPricePerSFRowHousingInGTA = 0;
            int NoOfLoansPricePerSFCondoInGTA = 0;
            int NoOfLoansPricePerSFGTA = 0;

            int NoOfLoansPricePerSFDetachedInOttawa = 0;
            int NoOfLoansPricePerSFSemiDetachedInOttawa = 0;
            int NoOfLoansPricePerSFRowHousingInOttawa = 0;
            int NoOfLoansPricePerSFCondoInOttawa = 0;
            int NoOfLoansPricePerSFOttawa = 0;

            int NoOfLoansPricePerSFDetachedInGoldenHorseshoe = 0;
            int NoOfLoansPricePerSFSemiDetachedInGoldenHorseshoe = 0;
            int NoOfLoansPricePerSFRowHousingInGoldenHorseshoe = 0;
            int NoOfLoansPricePerSFCondoInGoldenHorseshoe = 0;
            int NoOfLoansPricePerSFGoldenHorseshoe = 0;

            int NoOfLoansPricePerSFDetachedInOtherMajorUrbanAreas = 0;
            int NoOfLoansPricePerSFSemiDetachedInOtherMajorUrbanAreas = 0;
            int NoOfLoansPricePerSFRowHousingInOtherMajorUrbanAreas = 0;
            int NoOfLoansPricePerSFCondoPriceInOtherMajorUrbanAreas = 0;
            int NoOfLoansPricePerSFOtherMajorUrbanAreas = 0;

            int NoOfLoansPricePerSFDetached = 0;
            int NoOfLoansPricePerSFSemiDetached = 0;
            int NoOfLoansPricePerSFRowHousing = 0;
            int NoOfLoansPricePerSFCondo = 0;
            int NoOfLoansPricePerSF = 0;

            // Remaining Term to Maturity
            int NoOfLoansRemainingTermtoMaturityLessEqual6 = 0;
            int NoOfLoansRemainingTermtoMaturity6To9 = 0;
            int NoOfLoansRemainingTermtoMaturity9To12 = 0;
            int NoOfLoansRemainingTermtoMaturityMoreThan12 = 0;

            // Portfolio Summary by LTV
            int NoOfLoansPortfolioByLTVMoreThan80 = 0;
            int NoOfLoansPortfolioByLTV75To80 = 0;
            int NoOfLoansPortfolioByLTV65To75 = 0;
            int NoOfLoansPortfolioByLTVLessEqual65 = 0;

            Parallel.Invoke(() => TotalPrincipalBalance = (decimal)Loans.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceForFirst = (decimal)LoansFirst.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceForSecond = (decimal)LoansSecond.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceForThird = (decimal)LoansThird.Sum(l => l.PrinBal),

                            () => TotalPrincipalBalanceForResidential = (decimal)LoansResidential.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceForCommercial = (decimal)LoansCommercial.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceForLand = (decimal)LoansLand.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceForConstruction = (decimal)LoansConstruction.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceForUncategorized = (decimal)LoansUncategorized.Sum(l => l.PrinBal),

                            () => PrincipalBalance0To30DaysLate = (decimal)Loans0To30DaysLate.Sum(l => l.PrinBal),
                            () => PrincipalBalance31To90DaysLate = (decimal)Loans31To90DaysLate.Sum(l => l.PrinBal),
                            () => PrincipalBalance91To270DaysLate = (decimal)Loans91To270DaysLate.Sum(l => l.PrinBal),
                            () => PrincipalBalanceMoreThan270DaysLate = (decimal)LoansGtrThan270DaysLate.Sum(l => l.PrinBal),

                            () => PrincipalBalanceForGTA = (decimal)LoansGTA.Sum(l => l.PrinBal),
                            () => PrincipalBalanceForOttawa = (decimal)LoansOttawa.Sum(l => l.PrinBal),
                            () => PrincipalBalanceForGoldenHorseshoe = (decimal)LoansGoldenHorseshoe.Sum(l => l.PrinBal),
                            () => PrincipalBalanceForOtherMajorUrbanAreas = (decimal)LoansOtherMajorUrbanAreas.Sum(l => l.PrinBal),

                            () => TotalPrincipalBalanceRemainingTermtoMaturityLessEqual6 = (decimal)LoansRemainingTermtoMaturityLessEqual6.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceRemainingTermtoMaturity6To9 = (decimal)LoansRemainingTermtoMaturity6To9.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceRemainingTermtoMaturity9To12 = (decimal)LoansRemainingTermtoMaturity9To12.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalanceRemainingTermtoMaturityMoreThan12 = (decimal)LoansRemainingTermtoMaturityMoreThan12.Sum(l => l.PrinBal),

                            () => TotalPrincipalBalancePortfolioByLTVMoreThan80 = (decimal)LoansByLTVMoreThan80.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalancePortfolioByLTV75To80 = (decimal)LoansByLTV75To80.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalancePortfolioByLTV65To75 = (decimal)LoansByLTV65To75.Sum(l => l.PrinBal),
                            () => TotalPrincipalBalancePortfolioByLTVLessEqual65 = (decimal)LoansByLTVLessEqual65.Sum(l => l.PrinBal),

                            // Mortgage by Priority
                            () => NoOfLoansFirst = LoansFirst.Count(),
                            () => NoOfLoansSecond = LoansSecond.Count(),
                            () => NoOfLoansThird = LoansThird.Count(),

                            // Loan Summary by Loan Type
                            () => NoOfLoansResidential = LoansResidential.Count(),
                            () => NoOfLoansCommercial = LoansCommercial.Count(),
                            () => NoOfLoansLand = LoansLand.Count(),
                            () => NoOfLoansConstruction = LoansConstruction.Count(),
                            () => NoOfLoansUncategorized = LoansUncategorized.Count(),

                            // Late Payment
                            () => TotoalNoOfLoans0To30DaysLate = Loans0To30DaysLate.Count(),
                            () => TotoalNoOfLoans31To90DaysLate = Loans31To90DaysLate.Count(),
                            () => TotoalNoOfLoans91To270DaysLate = Loans91To270DaysLate.Count(),
                            () => TotoalNoOfLoansMoreThan270DaysLate = LoansGtrThan270DaysLate.Count(),

                            // Postal Code Summary
                            () => NoOfLoansByPostalCodeInGTA = LoansGTA.Count(),
                            () => NoOfLoansByPostalCodeInOttawa = LoansOttawa.Count(),
                            () => NoOfLoansByPostalCodeInGoldenHorseshoe = LoansGoldenHorseshoe.Count(),
                            () => NoOfLoansByPostalCodeInOtherMajorUrbanAreas = LoansOtherMajorUrbanAreas.Count(),

                            // Price per SF
                            () => NoOfLoansPricePerSFDetachedInGTA = PricePerSFLoansDetachedInGTA.Count(),
                            () => NoOfLoansPricePerSFSemiDetachedInGTA = PricePerSFLoansSemiDetachedInGTA.Count(),
                            () => NoOfLoansPricePerSFRowHousingInGTA = PricePerSFLoansRowHousingInGTA.Count(),
                            () => NoOfLoansPricePerSFCondoInGTA = PricePerSFLoansCondoInGTA.Count(),
                            () => NoOfLoansPricePerSFGTA = PricePerSFLoansGTA.Count(),

                            () => NoOfLoansPricePerSFDetachedInOttawa = PricePerSFLoansDetachedInOttawa.Count(),
                            () => NoOfLoansPricePerSFSemiDetachedInOttawa = PricePerSFLoansSemiDetachedInOttawa.Count(),
                            () => NoOfLoansPricePerSFRowHousingInOttawa = PricePerSFLoansRowHousingInOttawa.Count(),
                            () => NoOfLoansPricePerSFCondoInOttawa = PricePerSFLoansCondoInOttawa.Count(),
                            () => NoOfLoansPricePerSFOttawa = PricePerSFLoansOttawa.Count(),

                            () => NoOfLoansPricePerSFDetachedInGoldenHorseshoe = PricePerSFLoansDetachedInGoldenHorseshoe.Count(),
                            () => NoOfLoansPricePerSFSemiDetachedInGoldenHorseshoe = PricePerSFLoansSemiDetachedInGoldenHorseshoe.Count(),
                            () => NoOfLoansPricePerSFRowHousingInGoldenHorseshoe = PricePerSFLoansRowHousingInGoldenHorseshoe.Count(),
                            () => NoOfLoansPricePerSFCondoInGoldenHorseshoe = PricePerSFLoansCondoInGoldenHorseshoe.Count(),
                            () => NoOfLoansPricePerSFGoldenHorseshoe = PricePerSFLoansGoldenHorseshoe.Count(),

                            () => NoOfLoansPricePerSFDetachedInOtherMajorUrbanAreas = PricePerSFLoansDetachedInOtherMajorUrbanAreas.Count(),
                            () => NoOfLoansPricePerSFSemiDetachedInOtherMajorUrbanAreas = PricePerSFLoansSemiDetachedInOtherMajorUrbanAreas.Count(),
                            () => NoOfLoansPricePerSFRowHousingInOtherMajorUrbanAreas = PricePerSFLoansRowHousingInOtherMajorUrbanAreas.Count(),
                            () => NoOfLoansPricePerSFCondoPriceInOtherMajorUrbanAreas = PricePerSFLoansCondoPriceInOtherMajorUrbanAreas.Count(),
                            () => NoOfLoansPricePerSFOtherMajorUrbanAreas = PricePerSFLoansOtherMajorUrbanAreas.Count(),

                            () => NoOfLoansPricePerSFDetached = PricePerSFLoansDetached.Count(),
                            () => NoOfLoansPricePerSFSemiDetached = PricePerSFLoansSemiDetached.Count(),
                            () => NoOfLoansPricePerSFRowHousing = PricePerSFLoansRowHousing.Count(),
                            () => NoOfLoansPricePerSFCondo = PricePerSFLoansCondo.Count(),
                            () => NoOfLoansPricePerSF = PricePerSFLoans.Count(),

                            // Remaining Term to Maturity
                            () => NoOfLoansRemainingTermtoMaturityLessEqual6 = LoansRemainingTermtoMaturityLessEqual6.Count(),
                            () => NoOfLoansRemainingTermtoMaturity6To9 = LoansRemainingTermtoMaturity6To9.Count(),
                            () => NoOfLoansRemainingTermtoMaturity9To12 = LoansRemainingTermtoMaturity9To12.Count(),
                            () => NoOfLoansRemainingTermtoMaturityMoreThan12 = LoansRemainingTermtoMaturityMoreThan12.Count(),

                            // Portfolio Summary by LTV
                            () => NoOfLoansPortfolioByLTVMoreThan80 = LoansByLTVMoreThan80.Count(),
                            () => NoOfLoansPortfolioByLTV75To80 = LoansByLTV75To80.Count(),
                            () => NoOfLoansPortfolioByLTV65To75 = LoansByLTV65To75.Count(),
                            () => NoOfLoansPortfolioByLTVLessEqual65 = LoansByLTVLessEqual65.Count());

            int noOfLoansWithValidationErrors = 0;
            int noOfLoansUpForRenewal = 0;
            decimal totalLoanFundedToDate = 0;
            int averageDaysSinceLastAppraisalForResidentialLoans = 0;

            decimal AverageAppraisalFirst = 0;
            decimal AverageAppraisalSecond = 0;
            decimal AverageAppraisalThird = 0;
            decimal AverageAppraisalTotal = 0;

            decimal TotalWeightedLTV = 0;
            decimal FirstWeightedLTV = 0;
            decimal SecondlWeightedLTV = 0;

            decimal TotalWeightedBeaconScore = 0;
            decimal FirstWeightedBeaconScore = 0;
            decimal SecondlWeightedBeaconScore = 0;

            decimal TotalWeightedMaturityDateInMonths = 0;
            decimal FirstWeightedMaturityDateInMonths = 0;
            decimal SecondlWeightedMaturityDateInMonths = 0;

            decimal TotalWeightedInterestRate = 0;
            decimal FirstWeightedInterestRate = 0;
            decimal SecondlWeightedInterestRate = 0;

            decimal WeightedLTVByPostalCodeInGTA = 0;
            decimal WeightedBeaconScoreByPostalCodeInGTA = 0;

            decimal WeightedLTVByPostalCodeInOttawa = 0;
            decimal WeightedBeaconScoreByPostalCodeInOttawa = 0;

            decimal WeightedLTVByPostalCodeInGoldenHorseshoe = 0;
            decimal WeightedBeaconScoreByPostalCodeInGoldenHorseshoe = 0;

            decimal WeightedLTVByPostalCodeInOtherMajorUrbanAreas = 0;
            decimal WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas = 0;

            // Mortgage by Priority
            decimal PctOfAUMFirst = 0;
            decimal PctOfAUMSecond = 0;
            decimal PctOfAUMThird = 0;

            // Loan Summary by Loan Type
            decimal PctOfAUMResidential = 0;
            decimal PctOfAUMCommercial = 0;
            decimal PctOfAUMLand = 0;
            decimal PctOfAUMConstruction = 0;
            decimal PctOfAUMUncategorized = 0;

            // Late Payment
            decimal TotalPctOfAUM0To30DaysLate = 0;
            decimal TotalPctOfAUM31To90DaysLate = 0;
            decimal TotalPctOfAUM91To270DaysLate = 0;
            decimal TotalPctOfAUMMoreThan270DaysLate = 0;

            // Postal Code Summary
            decimal PctOfAUMByPostalCodeInGTA = 0;
            decimal PctOfAUMByPostalCodeInOttawa = 0;
            decimal PctOfAUMByPostalCodeInGoldenHorseshoe = 0;
            decimal PctOfAUMByPostalCodeInOtherMajorUrbanAreas = 0;

            // Price per SF
            decimal DetachedPricePerSquareFootInGTA = 0;
            decimal SemiDetachedPricePerSquareFootInGTA = 0;
            decimal RowHousingPricePerSquareFootInGTA = 0;
            decimal CondoPricePerSquareFootInGTA = 0;
            decimal TotalPricePerSquareFootInGTA = 0;

            decimal DetachedPricePerSquareFootInOttawa = 0;
            decimal SemiDetachedPricePerSquareFootInOttawa = 0;
            decimal RowHousingPricePerSquareFootInOttawa = 0;
            decimal CondoPricePerSquareFootInOttawa = 0;
            decimal TotalPricePerSquareFootInOttawa = 0;

            decimal DetachedPricePerSquareFootInGoldenHorseshoe = 0;
            decimal SemiDetachedPricePerSquareFootInGoldenHorseshoe = 0;
            decimal RowHousingPricePerSquareFootInGoldenHorseshoe = 0;
            decimal CondoPricePerSquareFootInGoldenHorseshoe = 0;
            decimal TotalPricePerSquareFootInGoldenHorseshoe = 0;

            decimal DetachedPricePerSquareFootInOtherMajorUrbanAreas = 0;
            decimal SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas = 0;
            decimal RowHousingPricePerSquareFootInOtherMajorUrbanAreas = 0;
            decimal CondoPricePerSquareFootInOtherMajorUrbanAreas = 0;
            decimal TotalPricePerSquareFootInOtherMajorUrbanAreas = 0;

            decimal DetachedPricePerSquareFootForAllRegions = 0;
            decimal SemiDetachedPricePerSquareFootForAllRegions = 0;
            decimal RowHousingPricePerSquareFootForAllRegions = 0;
            decimal CondoPricePerSquareFootForAllRegions = 0;
            decimal TotalPricePerSquareFootForAllRegions = 0;

            // Remaining Term to Maturity Summary
            decimal PctOfAUMRemainingTermtoMaturityLessEqual6 = 0;
            decimal PctOfAUMRemainingTermtoMaturity6To9 = 0;
            decimal PctOfAUMRemainingTermtoMaturity9To12 = 0;
            decimal PctOfAUMRemainingTermtoMaturityMoreThan12 = 0;

            // Portfolio Summary by LTV
            decimal PctOfAUMPortfolioByLTVMoreThan80 = 0;
            decimal PctOfAUMPortfolioByLTV75To80 = 0;
            decimal PctOfAUMPortfolioByLTV65To75 = 0;
            decimal PctOfAUMPortfolioByLTVLessEqual65 = 0;

            Parallel.Invoke(() => noOfLoansWithValidationErrors = _loanService.GetLoansWithValidationErrors(Loans, propertyList, postalCodeList, udfValueList, incompleteLoanRenewalList).Count(),
                            () => noOfLoansUpForRenewal = _loanService.GetRenewalLoans(Loans).Count(),
                            async () => totalLoanFundedToDate = await _loanService.GetTotalLoanFundedToDate(endDate),
                            () => averageDaysSinceLastAppraisalForResidentialLoans = GetAverageDaysSinceLastAppraisalForResidential(LoansResidential, propertyList),

                            () => AverageAppraisalFirst = GetTotalAverageApprasial(LoansFirst, propertyList),
                            () => AverageAppraisalSecond = GetTotalAverageApprasial(LoansSecond, propertyList),
                            () => AverageAppraisalThird = GetTotalAverageApprasial(LoansThird, propertyList),
                            () => AverageAppraisalTotal = GetTotalAverageApprasial(Loans, propertyList),

                            () => TotalWeightedLTV = (decimal)Loans.Sum(l => LoanFilterService.GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) * l.PrinBal) / TotalPrincipalBalance,
                            () => FirstWeightedLTV = (decimal)LoansFirst.Sum(l => LoanFilterService.GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) * l.PrinBal) / TotalPrincipalBalanceForFirst,
                            () => SecondlWeightedLTV = (decimal)LoansSecond.Sum(l => LoanFilterService.GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) * l.PrinBal) / TotalPrincipalBalanceForSecond,

                            () => TotalWeightedBeaconScore = (decimal)Loans.Sum(l => GetAverageCreditScroe(l, AverageCreditScoreUDFValues) * l.PrinBal) / TotalPrincipalBalance,
                            () => FirstWeightedBeaconScore = (decimal)LoansFirst.Sum(l => GetAverageCreditScroe(l, AverageCreditScoreUDFValues) * l.PrinBal) / TotalPrincipalBalanceForFirst,
                            () => SecondlWeightedBeaconScore = (decimal)LoansSecond.Sum(l => GetAverageCreditScroe(l, AverageCreditScoreUDFValues) * l.PrinBal) / TotalPrincipalBalanceForSecond,

                            () => TotalWeightedMaturityDateInMonths = (decimal)Loans.Sum(l => LoanFilterService.GetTermsLeft(l) * l.PrinBal) / TotalPrincipalBalance,
                            () => FirstWeightedMaturityDateInMonths = (decimal)LoansFirst.Sum(l => LoanFilterService.GetTermsLeft(l) * l.PrinBal) / TotalPrincipalBalanceForFirst,
                            () => SecondlWeightedMaturityDateInMonths = (decimal)LoansSecond.Sum(l => LoanFilterService.GetTermsLeft(l) * l.PrinBal) / TotalPrincipalBalanceForSecond,

                            () => TotalWeightedInterestRate = (decimal)Loans.Sum(l => l.NoteRate * l.PrinBal) / TotalPrincipalBalance,
                            () => FirstWeightedInterestRate = (decimal)LoansFirst.Sum(l => l.NoteRate * l.PrinBal) / TotalPrincipalBalanceForFirst,
                            () => SecondlWeightedInterestRate = (decimal)LoansSecond.Sum(l => l.NoteRate * l.PrinBal) / TotalPrincipalBalanceForSecond,

                            () => WeightedLTVByPostalCodeInGTA = (decimal)LoansGTA.Sum(l => LoanFilterService.GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) * l.PrinBal) / PrincipalBalanceForGTA,
                            () => WeightedBeaconScoreByPostalCodeInGTA = (decimal)LoansGTA.Sum(l => GetAverageCreditScroe(l, AverageCreditScoreUDFValues) * l.PrinBal) / PrincipalBalanceForGTA,

                            () => WeightedLTVByPostalCodeInOttawa = (decimal)LoansOttawa.Sum(l => LoanFilterService.GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) * l.PrinBal) / PrincipalBalanceForOttawa,
                            () => WeightedBeaconScoreByPostalCodeInOttawa = (decimal)LoansOttawa.Sum(l => GetAverageCreditScroe(l, AverageCreditScoreUDFValues) * l.PrinBal) / PrincipalBalanceForOttawa,

                            () => WeightedLTVByPostalCodeInGoldenHorseshoe = (decimal)LoansGoldenHorseshoe.Sum(l => LoanFilterService.GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) * l.PrinBal) / PrincipalBalanceForGoldenHorseshoe,
                            () => WeightedBeaconScoreByPostalCodeInGoldenHorseshoe = (decimal)LoansGoldenHorseshoe.Sum(l => GetAverageCreditScroe(l, AverageCreditScoreUDFValues) * l.PrinBal) / PrincipalBalanceForGoldenHorseshoe,

                            () => WeightedLTVByPostalCodeInOtherMajorUrbanAreas = (decimal)LoansOtherMajorUrbanAreas.Sum(l => LoanFilterService.GetCalculatedLTV(l, propertyList.Where(p => p.LoanRecId == l.RecId), lienList.Where(p => p.LoanRecId == l.RecId)) * l.PrinBal) / PrincipalBalanceForOtherMajorUrbanAreas,
                            () => WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas = (decimal)LoansOtherMajorUrbanAreas.Sum(l => GetAverageCreditScroe(l, AverageCreditScoreUDFValues) * l.PrinBal) / PrincipalBalanceForOtherMajorUrbanAreas,

                            // Mortgage by Priority
                            () => PctOfAUMFirst = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceForFirst),
                            () => PctOfAUMSecond = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceForSecond),
                            () => PctOfAUMThird = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceForThird),

                            // Loan Summary by Loan Type
                            () => PctOfAUMResidential = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceForResidential),
                            () => PctOfAUMCommercial = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceForCommercial),
                            () => PctOfAUMLand = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceForLand),
                            () => PctOfAUMConstruction = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceForConstruction),
                            () => PctOfAUMUncategorized = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceForUncategorized),

                            // Late Payment
                            () => TotalPctOfAUM0To30DaysLate = GetPct(TotalPrincipalBalance, PrincipalBalance0To30DaysLate),
                            () => TotalPctOfAUM31To90DaysLate = GetPct(TotalPrincipalBalance, PrincipalBalance31To90DaysLate),
                            () => TotalPctOfAUM91To270DaysLate = GetPct(TotalPrincipalBalance, PrincipalBalance91To270DaysLate),
                            () => TotalPctOfAUMMoreThan270DaysLate = GetPct(TotalPrincipalBalance, PrincipalBalanceMoreThan270DaysLate),

                            // Postal Code Summary
                            () => PctOfAUMByPostalCodeInGTA = GetPct(TotalPrincipalBalance, PrincipalBalanceForGTA),
                            () => PctOfAUMByPostalCodeInOttawa = GetPct(TotalPrincipalBalance, PrincipalBalanceForOttawa),
                            () => PctOfAUMByPostalCodeInGoldenHorseshoe = GetPct(TotalPrincipalBalance, PrincipalBalanceForGoldenHorseshoe),
                            () => PctOfAUMByPostalCodeInOtherMajorUrbanAreas = GetPct(TotalPrincipalBalance, PrincipalBalanceForOtherMajorUrbanAreas),

                            // Price per Square Foot - GTA
                            () => DetachedPricePerSquareFootInGTA = NoOfLoansPricePerSFDetachedInGTA > 0 ? (decimal)PricePerSFLoansDetachedInGTA.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFDetachedInGTA : 0,
                            () => SemiDetachedPricePerSquareFootInGTA = NoOfLoansPricePerSFSemiDetachedInGTA > 0 ? (decimal)PricePerSFLoansSemiDetachedInGTA.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFSemiDetachedInGTA : 0,
                            () => RowHousingPricePerSquareFootInGTA = NoOfLoansPricePerSFRowHousingInGTA > 0 ? (decimal)PricePerSFLoansRowHousingInGTA.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFRowHousingInGTA : 0,
                            () => CondoPricePerSquareFootInGTA = NoOfLoansPricePerSFCondoInGTA > 0 ? (decimal)PricePerSFLoansCondoInGTA.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFCondoInGTA : 0,
                            () => TotalPricePerSquareFootInGTA = NoOfLoansPricePerSFGTA > 0 ? (decimal)PricePerSFLoansGTA.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFGTA : 0,

                            // Price per Square Foot - Ottawa
                            () => DetachedPricePerSquareFootInOttawa = NoOfLoansPricePerSFDetachedInOttawa > 0 ? (decimal)PricePerSFLoansDetachedInOttawa.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFDetachedInOttawa : 0,
                            () => SemiDetachedPricePerSquareFootInOttawa = NoOfLoansPricePerSFSemiDetachedInOttawa > 0 ? (decimal)PricePerSFLoansSemiDetachedInOttawa.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFSemiDetachedInOttawa : 0,
                            () => RowHousingPricePerSquareFootInOttawa = NoOfLoansPricePerSFRowHousingInOttawa > 0 ? (decimal)PricePerSFLoansRowHousingInOttawa.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFRowHousingInOttawa : 0,
                            () => CondoPricePerSquareFootInOttawa = NoOfLoansPricePerSFCondoInOttawa > 0 ? (decimal)PricePerSFLoansCondoInOttawa.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFCondoInOttawa : 0,
                            () => TotalPricePerSquareFootInOttawa = NoOfLoansPricePerSFOttawa > 0 ? (decimal)PricePerSFLoansOttawa.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFOttawa : 0,

                            // Price per Square Foot - GoldenHorseshoe
                            () => DetachedPricePerSquareFootInGoldenHorseshoe = NoOfLoansPricePerSFDetachedInGoldenHorseshoe > 0 ? (decimal)PricePerSFLoansDetachedInGoldenHorseshoe.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFDetachedInGoldenHorseshoe : 0,
                            () => SemiDetachedPricePerSquareFootInGoldenHorseshoe = NoOfLoansPricePerSFSemiDetachedInGoldenHorseshoe > 0 ? (decimal)PricePerSFLoansSemiDetachedInGoldenHorseshoe.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFSemiDetachedInGoldenHorseshoe : 0,
                            () => RowHousingPricePerSquareFootInGoldenHorseshoe = NoOfLoansPricePerSFRowHousingInGoldenHorseshoe > 0 ? (decimal)PricePerSFLoansRowHousingInGoldenHorseshoe.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFRowHousingInGoldenHorseshoe : 0,
                            () => CondoPricePerSquareFootInGoldenHorseshoe = NoOfLoansPricePerSFCondoInGoldenHorseshoe > 0 ? (decimal)PricePerSFLoansCondoInGoldenHorseshoe.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFCondoInGoldenHorseshoe : 0,
                            () => TotalPricePerSquareFootInGoldenHorseshoe = NoOfLoansPricePerSFGoldenHorseshoe > 0 ? (decimal)PricePerSFLoansGoldenHorseshoe.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFGoldenHorseshoe : 0,

                            // Price per Square Foot - OtherMajorUrbanAreas
                            () => DetachedPricePerSquareFootInOtherMajorUrbanAreas = NoOfLoansPricePerSFDetachedInOtherMajorUrbanAreas > 0 ? (decimal)PricePerSFLoansDetachedInOtherMajorUrbanAreas.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFDetachedInOtherMajorUrbanAreas : 0,
                            () => SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas = NoOfLoansPricePerSFSemiDetachedInOtherMajorUrbanAreas > 0 ? (decimal)PricePerSFLoansSemiDetachedInOtherMajorUrbanAreas.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFSemiDetachedInOtherMajorUrbanAreas : 0,
                            () => RowHousingPricePerSquareFootInOtherMajorUrbanAreas = NoOfLoansPricePerSFRowHousingInOtherMajorUrbanAreas > 0 ? (decimal)PricePerSFLoansRowHousingInOtherMajorUrbanAreas.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFRowHousingInOtherMajorUrbanAreas : 0,
                            () => CondoPricePerSquareFootInOtherMajorUrbanAreas = NoOfLoansPricePerSFCondoPriceInOtherMajorUrbanAreas > 0 ? (decimal)PricePerSFLoansCondoPriceInOtherMajorUrbanAreas.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFCondoPriceInOtherMajorUrbanAreas : 0,
                            () => TotalPricePerSquareFootInOtherMajorUrbanAreas = NoOfLoansPricePerSFOtherMajorUrbanAreas > 0 ? (decimal)PricePerSFLoansOtherMajorUrbanAreas.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFOtherMajorUrbanAreas : 0,

                            // Price per Square Foot - AllRegions
                            () => DetachedPricePerSquareFootForAllRegions = NoOfLoansPricePerSFDetached > 0 ? (decimal)PricePerSFLoansDetached.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFDetached : 0,
                            () => SemiDetachedPricePerSquareFootForAllRegions = NoOfLoansPricePerSFSemiDetached > 0 ? (decimal)PricePerSFLoansSemiDetached.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFSemiDetached : 0,
                            () => RowHousingPricePerSquareFootForAllRegions = NoOfLoansPricePerSFRowHousing > 0 ? (decimal)PricePerSFLoansRowHousing.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFRowHousing : 0,
                            () => CondoPricePerSquareFootForAllRegions = NoOfLoansPricePerSFCondo > 0 ? (decimal)PricePerSFLoansCondo.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSFCondo : 0,
                            () => TotalPricePerSquareFootForAllRegions = NoOfLoansPricePerSF > 0 ? (decimal)PricePerSFLoans.Sum(l => GetPricePerSquareFoot(l, SubjectPropertySquareFootageUDFValues, primaryPropertyList)) / NoOfLoansPricePerSF : 0,

                            // Remaining Term to Maturity Summary
                            () => PctOfAUMRemainingTermtoMaturityLessEqual6 = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceRemainingTermtoMaturityLessEqual6),
                            () => PctOfAUMRemainingTermtoMaturity6To9 = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceRemainingTermtoMaturity6To9),
                            () => PctOfAUMRemainingTermtoMaturity9To12 = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceRemainingTermtoMaturity9To12),
                            () => PctOfAUMRemainingTermtoMaturityMoreThan12 = GetPct(TotalPrincipalBalance, TotalPrincipalBalanceRemainingTermtoMaturityMoreThan12),

                            // Portfolio Summary by LTV
                            () => PctOfAUMPortfolioByLTVMoreThan80 = GetPct(TotalPrincipalBalance, TotalPrincipalBalancePortfolioByLTVMoreThan80),
                            () => PctOfAUMPortfolioByLTV75To80 = GetPct(TotalPrincipalBalance, TotalPrincipalBalancePortfolioByLTV75To80),
                            () => PctOfAUMPortfolioByLTV65To75 = GetPct(TotalPrincipalBalance, TotalPrincipalBalancePortfolioByLTV65To75),
                            () => PctOfAUMPortfolioByLTVLessEqual65 = GetPct(TotalPrincipalBalance, TotalPrincipalBalancePortfolioByLTVLessEqual65));
            
            List<UserData> ud = new List<UserData>();
            foreach(var usrdt in userdata)
            {
                UserData usdt = new UserData();
                usdt.Type = usrdt.Type;
                usdt.Account = usrdt.Account;
                usdt.LoanAccount = usrdt.LoanAccount;
                usdt.PartnerAccount = usrdt.PartnerAccount;
                usdt.EmailAddress = usrdt.EmailAddress;
                usdt.Status = usrdt.Status;
                usdt.Password = usrdt.Password;
                usdt.FirstName = usrdt.FirstName;
                usdt.LastName = usrdt.LastName;
                usdt.PhoneCell = usrdt.PhoneCell;
                usdt.IsBothTypeOfUser = usrdt.IsBothTypeOfUser;
                ud.Add(usdt);
            }

            return new DashboardLoanViewModel()
            {
                //-------Active Loans-------
                // Stats
                NoOfLoansWithValidationErrors = noOfLoansWithValidationErrors,
                NoOfLoansUpForRenewal = noOfLoansUpForRenewal,
                TotalLoanFundedToDate = totalLoanFundedToDate,
                AverageDaysSinceLastAppraisalForResidentialLoans = averageDaysSinceLastAppraisalForResidentialLoans,

                // First
                NoOfLoansFirst = NoOfLoansFirst,
                AverageAppraisalFirst = AverageAppraisalFirst,

                PrincipalBalanceFirst = TotalPrincipalBalanceForFirst,
                PctOfAUMFirst = PctOfAUMFirst,
                // Second
                NoOfLoansSecond = NoOfLoansSecond,
                AverageAppraisalSecond = AverageAppraisalSecond,

                PrincipalBalanceSecond = TotalPrincipalBalanceForSecond,
                PctOfAUMSecond = PctOfAUMSecond,
                // Third
                NoOfLoansThird = NoOfLoansThird,
                AverageAppraisalThird = AverageAppraisalThird,

                PrincipalBalanceThird = TotalPrincipalBalanceForThird,
                PctOfAUMThird = PctOfAUMThird,
                //Total
                AverageAppraisalTotal = AverageAppraisalTotal,

                // ***Weighted Average***
                // Calculated Weighted LTV
                TotalWeightedLTV = TotalWeightedLTV,
                FirstWeightedLTV = FirstWeightedLTV,
                SecondlWeightedLTV = SecondlWeightedLTV,

                // Weighted Beacon Score                
                TotalWeightedBeaconScore = TotalWeightedBeaconScore,
                FirstWeightedBeaconScore = FirstWeightedBeaconScore,
                SecondlWeightedBeaconScore = SecondlWeightedBeaconScore,

                // Weighted Beacon Score (in months)                
                TotalWeightedMaturityDateInMonths = TotalWeightedMaturityDateInMonths,
                FirstWeightedMaturityDateInMonths = FirstWeightedMaturityDateInMonths,
                SecondlWeightedMaturityDateInMonths = SecondlWeightedMaturityDateInMonths,

                // Weighted Interest
                TotalWeightedInterestRate = TotalWeightedInterestRate,
                FirstWeightedInterestRate = FirstWeightedInterestRate,
                SecondlWeightedInterestRate = SecondlWeightedInterestRate,

                // ***Loan Summary by Loan Type***
                // Residential
                NoOfLoansResidential = NoOfLoansResidential,
                PrincipalBalanceResidential = TotalPrincipalBalanceForResidential,
                PctOfAUMResidential = PctOfAUMResidential,

                // Commercial
                NoOfLoansCommercial = NoOfLoansCommercial,
                PrincipalBalanceCommercial = TotalPrincipalBalanceForCommercial,
                PctOfAUMCommercial = PctOfAUMCommercial,

                // Land
                NoOfLoansLand = NoOfLoansLand,
                PrincipalBalanceLand = TotalPrincipalBalanceForLand,
                PctOfAUMLand = PctOfAUMLand,

                // Construction
                NoOfLoansConstruction = NoOfLoansConstruction,
                PrincipalBalanceConstruction = TotalPrincipalBalanceForConstruction,
                PctOfAUMConstruction = PctOfAUMConstruction,

                // Uncategorized
                NoOfLoansUncategorized = NoOfLoansUncategorized,
                PrincipalBalanceUncategorized = TotalPrincipalBalanceForUncategorized,
                PctOfAUMUncategorized = PctOfAUMUncategorized,

                // *** Late Payment Summary ***
                // > 0 days late
                TotoalNoOfLoans0To30DaysLate = TotoalNoOfLoans0To30DaysLate,
                TotalPrincipalBalance0To30DaysLate = PrincipalBalance0To30DaysLate,
                TotalPctOfAUM0To30DaysLate = TotalPctOfAUM0To30DaysLate,
                // > 30 days late
                TotoalNoOfLoans31To90DaysLate = TotoalNoOfLoans31To90DaysLate,
                TotalPrincipalBalance31To90DaysLate = PrincipalBalance31To90DaysLate,
                TotalPctOfAUM31To90DaysLate = TotalPctOfAUM31To90DaysLate,
                // > 90 days late
                TotoalNoOfLoans91To270DaysLate = TotoalNoOfLoans91To270DaysLate,
                TotalPrincipalBalance91To270DaysLate = PrincipalBalance91To270DaysLate,
                TotalPctOfAUM91To270DaysLate = TotalPctOfAUM91To270DaysLate,
                // > 270 days late
                TotoalNoOfLoansMoreThan270DaysLate = TotoalNoOfLoansMoreThan270DaysLate,
                TotalPrincipalBalanceMoreThan270DaysLate = PrincipalBalanceMoreThan270DaysLate,
                TotalPctOfAUMMoreThan270DaysLate = TotalPctOfAUMMoreThan270DaysLate,

                // *** Postal Code Summary ***
                // GTA
                NoOfLoansByPostalCodeInGTA = NoOfLoansByPostalCodeInGTA,
                WeightedLTVByPostalCodeInGTA = WeightedLTVByPostalCodeInGTA,
                WeightedBeaconScoreByPostalCodeInGTA = WeightedBeaconScoreByPostalCodeInGTA,
                PrincipalBalanceByPostalCodeInGTA = PrincipalBalanceForGTA,
                PctOfAUMByPostalCodeInGTA = PctOfAUMByPostalCodeInGTA,
                // Ottawa
                NoOfLoansByPostalCodeInOttawa = NoOfLoansByPostalCodeInOttawa,
                WeightedLTVByPostalCodeInOttawa = WeightedLTVByPostalCodeInOttawa,
                WeightedBeaconScoreByPostalCodeInOttawa = WeightedBeaconScoreByPostalCodeInOttawa,
                PrincipalBalanceByPostalCodeInOttawa = PrincipalBalanceForOttawa,
                PctOfAUMByPostalCodeInOttawa = PctOfAUMByPostalCodeInOttawa,
                // Golden Horseshoe
                NoOfLoansByPostalCodeInGoldenHorseshoe = NoOfLoansByPostalCodeInGoldenHorseshoe,
                WeightedLTVByPostalCodeInGoldenHorseshoe = WeightedLTVByPostalCodeInGoldenHorseshoe,
                WeightedBeaconScoreByPostalCodeInGoldenHorseshoe = WeightedBeaconScoreByPostalCodeInGoldenHorseshoe,
                PrincipalBalanceByPostalCodeInGoldenHorseshoe = PrincipalBalanceForGoldenHorseshoe,
                PctOfAUMByPostalCodeInGoldenHorseshoe = PctOfAUMByPostalCodeInGoldenHorseshoe,
                // Other Major Urban Areas
                NoOfLoansByPostalCodeInOtherMajorUrbanAreas = NoOfLoansByPostalCodeInOtherMajorUrbanAreas,
                WeightedLTVByPostalCodeInOtherMajorUrbanAreas = WeightedLTVByPostalCodeInOtherMajorUrbanAreas,
                WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas = WeightedBeaconScoreByPostalCodeInOtherMajorUrbanAreas,
                PrincipalBalanceByPostalCodeInOtherMajorUrbanAreas = PrincipalBalanceForOtherMajorUrbanAreas,
                PctOfAUMByPostalCodeInOtherMajorUrbanAreas = PctOfAUMByPostalCodeInOtherMajorUrbanAreas,

                // *** Price per Square Foot Summary ***
                // GTA
                DetachedPricePerSquareFootInGTA = DetachedPricePerSquareFootInGTA,
                SemiDetachedPricePerSquareFootInGTA = SemiDetachedPricePerSquareFootInGTA,
                RowHousingPricePerSquareFootInGTA = RowHousingPricePerSquareFootInGTA,
                CondoPricePerSquareFootInGTA = CondoPricePerSquareFootInGTA,
                TotalPricePerSquareFootInGTA = TotalPricePerSquareFootInGTA,

                NoOfLoansDetachedInGTA = NoOfLoansPricePerSFDetachedInGTA,
                NoOfLoansSemiDetachedInGTA = NoOfLoansPricePerSFSemiDetachedInGTA,
                NoOfLoansRowHousingInGTA = NoOfLoansPricePerSFRowHousingInGTA,
                NoOfLoansCondoInGTA = NoOfLoansPricePerSFCondoInGTA,

                // Ottawa
                DetachedPricePerSquareFootInOttawa = DetachedPricePerSquareFootInOttawa,
                SemiDetachedPricePerSquareFootInOttawa = SemiDetachedPricePerSquareFootInOttawa,
                RowHousingPricePerSquareFootInOttawa = RowHousingPricePerSquareFootInOttawa,
                CondoPricePerSquareFootInOttawa = CondoPricePerSquareFootInOttawa,
                TotalPricePerSquareFootInOttawa = TotalPricePerSquareFootInOttawa,

                NoOfLoansDetachedInOttawa = NoOfLoansPricePerSFDetachedInOttawa,
                NoOfLoansSemiDetachedInOttawa = NoOfLoansPricePerSFSemiDetachedInOttawa,
                NoOfLoansRowHousingInOttawa = NoOfLoansPricePerSFRowHousingInOttawa,
                NoOfLoansCondoInOttawa = NoOfLoansPricePerSFCondoInOttawa,

                // Golden Horseshoe
                DetachedPricePerSquareFootInGoldenHorseshoe = DetachedPricePerSquareFootInGoldenHorseshoe,
                SemiDetachedPricePerSquareFootInGoldenHorseshoe = SemiDetachedPricePerSquareFootInGoldenHorseshoe,
                RowHousingPricePerSquareFootInGoldenHorseshoe = RowHousingPricePerSquareFootInGoldenHorseshoe,
                CondoPricePerSquareFootInGoldenHorseshoe = CondoPricePerSquareFootInGoldenHorseshoe,
                TotalPricePerSquareFootInGoldenHorseshoe = TotalPricePerSquareFootInGoldenHorseshoe,

                NoOfLoansDetachedInGoldenHorseshoe = NoOfLoansPricePerSFDetachedInGoldenHorseshoe,
                NoOfLoansSemiDetachedInGoldenHorseshoe = NoOfLoansPricePerSFSemiDetachedInGoldenHorseshoe,
                NoOfLoansRowHousingInGoldenHorseshoe = NoOfLoansPricePerSFRowHousingInGoldenHorseshoe,
                NoOfLoansCondoInGoldenHorseshoe = NoOfLoansPricePerSFCondoInGoldenHorseshoe,

                // Other Major Urban Areas
                DetachedPricePerSquareFootInOtherMajorUrbanAreas = DetachedPricePerSquareFootInOtherMajorUrbanAreas,
                SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas = SemiDetachedPricePerSquareFootInOtherMajorUrbanAreas,
                RowHousingPricePerSquareFootInOtherMajorUrbanAreas = RowHousingPricePerSquareFootInOtherMajorUrbanAreas,
                CondoPricePerSquareFootInOtherMajorUrbanAreas = CondoPricePerSquareFootInOtherMajorUrbanAreas,
                TotalPricePerSquareFootInOtherMajorUrbanAreas = TotalPricePerSquareFootInOtherMajorUrbanAreas,

                NoOfLoansDetachedInOtherMajorUrbanAreas = NoOfLoansPricePerSFDetachedInOtherMajorUrbanAreas,
                NoOfLoansSemiDetachedInOtherMajorUrbanAreas = NoOfLoansPricePerSFSemiDetachedInOtherMajorUrbanAreas,
                NoOfLoansRowHousingInOtherMajorUrbanAreas = NoOfLoansPricePerSFRowHousingInOtherMajorUrbanAreas,
                NoOfLoansCondoInOtherMajorUrbanAreas = NoOfLoansPricePerSFCondoPriceInOtherMajorUrbanAreas,

                // Total
                DetachedPricePerSquareFootForAllRegions = DetachedPricePerSquareFootForAllRegions,
                SemiDetachedPricePerSquareFootForAllRegions = SemiDetachedPricePerSquareFootForAllRegions,
                RowHousingPricePerSquareFootForAllRegions = RowHousingPricePerSquareFootForAllRegions,
                CondoPricePerSquareFootForAllRegions = CondoPricePerSquareFootForAllRegions,
                TotalPricePerSquareFootForAllRegions = TotalPricePerSquareFootForAllRegions,

                NoOfLoansDetachedInAllRegions = NoOfLoansPricePerSFDetached,
                NoOfLoansSemiDetachedInAllRegions = NoOfLoansPricePerSFSemiDetached,
                NoOfLoansRowHousingInAllRegions = NoOfLoansPricePerSFRowHousing,
                NoOfLoansCondoInAllRegions = NoOfLoansPricePerSFCondo,

                // *** Remaining Term to Maturity Summary ***
                // <= 6
                NoOfLoansRemainingTermtoMaturityLessEqual6 = NoOfLoansRemainingTermtoMaturityLessEqual6,
                PrincipalBalanceRemainingTermtoMaturityLessEqual6 = TotalPrincipalBalanceRemainingTermtoMaturityLessEqual6,
                PctOfAUMRemainingTermtoMaturityLessEqual6 = PctOfAUMRemainingTermtoMaturityLessEqual6,
                // > 6 - 9
                NoOfLoansRemainingTermtoMaturity6To9 = NoOfLoansRemainingTermtoMaturity6To9,
                PrincipalBalanceRemainingTermtoMaturity6To9 = TotalPrincipalBalanceRemainingTermtoMaturity6To9,
                PctOfAUMRemainingTermtoMaturity6To9 = PctOfAUMRemainingTermtoMaturity6To9,
                // > 9 - 12
                NoOfLoansRemainingTermtoMaturity9To12 = NoOfLoansRemainingTermtoMaturity9To12,
                PrincipalBalanceRemainingTermtoMaturity9To12 = TotalPrincipalBalanceRemainingTermtoMaturity9To12,
                PctOfAUMRemainingTermtoMaturity9To12 = PctOfAUMRemainingTermtoMaturity9To12,
                // > 12
                NoOfLoansRemainingTermtoMaturityMoreThan12 = NoOfLoansRemainingTermtoMaturityMoreThan12,
                PrincipalBalanceRemainingTermtoMaturityMoreThan12 = TotalPrincipalBalanceRemainingTermtoMaturityMoreThan12,
                PctOfAUMRemainingTermtoMaturityMoreThan12 = PctOfAUMRemainingTermtoMaturityMoreThan12,

                // *** Portfolio Summary by LTV ***
                // > 80%
                NoOfLoansPortfolioByLTVMoreThan80 = NoOfLoansPortfolioByLTVMoreThan80,
                PrincipalBalancePortfolioByLTVMoreThan80 = TotalPrincipalBalancePortfolioByLTVMoreThan80,
                PctOfAUMPortfolioByLTVMoreThan80 = PctOfAUMPortfolioByLTVMoreThan80,
                // > 75% - 80%
                NoOfLoansPortfolioByLTV75To80 = NoOfLoansPortfolioByLTV75To80,
                PrincipalBalancePortfolioByLTV75To80 = TotalPrincipalBalancePortfolioByLTV75To80,
                PctOfAUMPortfolioByLTV75To80 = PctOfAUMPortfolioByLTV75To80,
                // > 65% - 75%
                NoOfLoansPortfolioByLTV65To75 = NoOfLoansPortfolioByLTV65To75,
                PrincipalBalancePortfolioByLTV65To75 = TotalPrincipalBalancePortfolioByLTV65To75,
                PctOfAUMPortfolioByLTV65To75 = PctOfAUMPortfolioByLTV65To75,
                // ≤ 65%
                NoOfLoansPortfolioByLTVLessEqual65 = NoOfLoansPortfolioByLTVLessEqual65,
                PrincipalBalancePortfolioByLTVLessEqual65 = TotalPrincipalBalancePortfolioByLTVLessEqual65,
                PctOfAUMPortfolioByLTVLessEqual65 = PctOfAUMPortfolioByLTVLessEqual65,              
                userDatas = ud,
            };
        }

        public async Task<DashboardPartnerViewModel> GetPartnerSummaryForDashboard(DateTime? endDate)
        {
            _logger.LogInformation($"Calling: DashboardService.GetPartnerSummaryForDashboard(): End Date, {endDate}\n");

            IEnumerable<PartnerIndexModel> Partners = await _partnerService.GetFilteredPartners(PartnerFilterType.ShareBalanceGreaterThanZero);
            IEnumerable<UdfValue> udfValueList = await _partnerService.GetUserDefinedFieldsByParentID(null);

            IEnumerable<PartnerIndexModel> PartnersGrowth = null;
            IEnumerable<PartnerIndexModel> PartnersIncome = null;

            IEnumerable<PartnerIndexModel> PartnersNonRegisteredIndividual = null;
            IEnumerable<PartnerIndexModel> PartnersNonRegisteredCompany = null;
            IEnumerable<PartnerIndexModel> PartnersNonRegisteredJTWROS = null;
            IEnumerable<PartnerIndexModel> PartnersTFSA = null;
            IEnumerable<PartnerIndexModel> PartnersRRSP = null;
            IEnumerable<PartnerIndexModel> PartnersRRSPSpousal = null;
            IEnumerable<PartnerIndexModel> PartnersLIRA = null;
            IEnumerable<PartnerIndexModel> PartnersLRSP = null;
            IEnumerable<PartnerIndexModel> PartnersRESPFamily = null;
            IEnumerable<PartnerIndexModel> PartnersRLSP = null;
            IEnumerable<PartnerIndexModel> PartnersLIF = null;
            IEnumerable<PartnerIndexModel> PartnersNewLIF = null;
            IEnumerable<PartnerIndexModel> PartnersRLIF = null;
            IEnumerable<PartnerIndexModel> PartnersRRIF = null;
            IEnumerable<PartnerIndexModel> PartnersRRIFSpousal = null;

            Parallel.Invoke(() => PartnersGrowth = _partnerService.PartnerFilter(Partners, PartnerFilterType.Growth),
                            () => PartnersIncome = _partnerService.PartnerFilter(Partners, PartnerFilterType.Income),

                            () => PartnersTFSA = _partnerService.PartnerFilter(Partners, PartnerFilterType.TFSA),
                            () => PartnersRRSP = _partnerService.PartnerFilter(Partners, PartnerFilterType.RRSP),
                            () => PartnersRRSPSpousal = _partnerService.PartnerFilter(Partners, PartnerFilterType.RRSPSpousal),
                            () => PartnersLIRA = _partnerService.PartnerFilter(Partners, PartnerFilterType.LIRA),
                            () => PartnersLRSP = _partnerService.PartnerFilter(Partners, PartnerFilterType.LRSP),
                            () => PartnersRESPFamily = _partnerService.PartnerFilter(Partners, PartnerFilterType.RESPFamily),
                            () => PartnersRLSP = _partnerService.PartnerFilter(Partners, PartnerFilterType.RLSP),
                            () => PartnersLIF = _partnerService.PartnerFilter(Partners, PartnerFilterType.LIF),
                            () => PartnersNewLIF = _partnerService.PartnerFilter(Partners, PartnerFilterType.NewLIF),
                            () => PartnersRLIF = _partnerService.PartnerFilter(Partners, PartnerFilterType.RLIF),
                            () => PartnersRRIF = _partnerService.PartnerFilter(Partners, PartnerFilterType.RRIF),
                            () => PartnersRRIFSpousal = _partnerService.PartnerFilter(Partners, PartnerFilterType.RRIFSpousal),
                            () => PartnersNonRegisteredIndividual = _partnerService.PartnerFilter(Partners, PartnerFilterType.NonRegisteredIndividual),
                            () => PartnersNonRegisteredCompany = _partnerService.PartnerFilter(Partners, PartnerFilterType.NonRegisteredCompany),
                            () => PartnersNonRegisteredJTWROS = _partnerService.PartnerFilter(Partners, PartnerFilterType.NonRegisteredJTWROS));

            decimal totalInvestmentAmount = 0;

            // Account Type
            decimal investmentAmountGrowth = 0;
            decimal investmentAmountIncome = 0;

            // Investment Type
            decimal investmentAmountTFSA = 0;
            decimal investmentAmountRRSP = 0;
            decimal investmentAmountRRSPSpousal = 0;
            decimal investmentAmountLIRA = 0;
            decimal investmentAmountLRSP = 0;
            decimal investmentAmountRESPFamily = 0;
            decimal investmentAmountRLSP = 0;
            decimal investmentAmountLIF = 0;
            decimal investmentAmountNewLIF = 0;
            decimal investmentAmountRLIF = 0;
            decimal investmentAmountRRIF = 0;
            decimal investmentAmountRRIFSpousal = 0;
            decimal investmentAmountNonRegisteredIndividual = 0;
            decimal investmentAmountNonRegisteredCompany = 0;
            decimal investmentAmountNonRegisteredJTWROS = 0;

            Parallel.Invoke(() => totalInvestmentAmount = Partners.Sum(p => p.TotalInvestmentAmount),

                            // Account Type
                            () => investmentAmountGrowth = PartnersGrowth?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountIncome = PartnersIncome?.Sum(p => p.TotalInvestmentAmount) ?? 0,

                            // Investment Type
                            () => investmentAmountTFSA = PartnersTFSA?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountRRSP = PartnersRRSP?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountRRSPSpousal = PartnersRRSPSpousal?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountLIRA = PartnersLIRA?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountLRSP = PartnersLRSP?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountRESPFamily = PartnersRESPFamily?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountRLSP = PartnersRLSP?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountLIF = PartnersLIF?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountNewLIF = PartnersNewLIF?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountRLIF = PartnersRLIF?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountRRIF = PartnersRRIF?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountRRIFSpousal = PartnersRRIFSpousal?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountNonRegisteredIndividual = PartnersNonRegisteredIndividual?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountNonRegisteredCompany = PartnersNonRegisteredCompany?.Sum(p => p.TotalInvestmentAmount) ?? 0,
                            () => investmentAmountNonRegisteredJTWROS = PartnersNonRegisteredJTWROS?.Sum(p => p.TotalInvestmentAmount) ?? 0);

            int noOfPartnersWithValidationErrors = 0;
            int noOfUniqueActiveInvestors = 0;

            // Account Type
            int noOfPartnersGrowth = 0;
            decimal noOfSharesGrowth = 0;
            decimal pctGrowth = 0;

            int noOfPartnersIncome = 0;
            decimal noOfSharesIncome = 0;
            decimal pctIncome = 0;

            // Investment Type
            int noOfPartnersTFSA = 0;
            decimal noOfSharesTFSA = 0;
            decimal pctTFSA = 0;

            int noOfPartnersRRSP = 0;
            decimal noOfSharesRRSP = 0;
            decimal pctRRSP = 0;

            int noOfPartnersRRSPSpousal = 0;
            decimal noOfSharesRRSPSpousal = 0;
            decimal pctRRSPSpousal = 0;

            int noOfPartnersLIRA = 0;
            decimal noOfSharesLIRA = 0;
            decimal pctLIRA = 0;

            int noOfPartnersLRSP = 0;
            decimal noOfSharesLRSP = 0;
            decimal pctLRSP = 0;

            int noOfPartnersRESPFamily = 0;
            decimal noOfSharesRESPFamily = 0;
            decimal pctRESPFamily = 0;

            int noOfPartnersRLSP = 0;
            decimal noOfSharesRLSP = 0;
            decimal pctRLSP = 0;

            int noOfPartnersLIF = 0;
            decimal noOfSharesLIF = 0;
            decimal pctLIF = 0;

            int noOfPartnersNewLIF = 0;
            decimal noOfSharesNewLIF = 0;
            decimal pctNewLIF = 0;

            int noOfPartnersRLIF = 0;
            decimal noOfSharesRLIF = 0;
            decimal pctRLIF = 0;

            int noOfPartnersRRIF = 0;
            decimal noOfSharesRRIF = 0;
            decimal pctRRIF = 0;

            int noOfPartnersRRIFSpousal = 0;
            decimal noOfSharesRRIFSpousal = 0;
            decimal pctRRIFSpousal = 0;

            int noOfPartnersNonRegisteredIndividual = 0;
            decimal noOfSharesNonRegisteredIndividual = 0;
            decimal pctNonRegisteredIndividual = 0;

            int noOfPartnersNonRegisteredCompany = 0;
            decimal noOfSharesNonRegisteredCompany = 0;
            decimal pctNonRegisteredCompany = 0;

            int noOfPartnersNonRegisteredJTWROS = 0;
            decimal noOfSharesNonRegisteredJTWROS = 0;
            decimal pctNonRegisteredJTWROS = 0;

            Parallel.Invoke(() => noOfPartnersWithValidationErrors = _partnerService.GetPartnersWithValidationErrors(Partners, udfValueList).Count(),
                            () => noOfUniqueActiveInvestors = _partnerService.GetNumberOfUniqueActiveInvestors(Partners, udfValueList),

                            // Account Type
                            () => noOfPartnersGrowth = PartnersGrowth.Count(),
                            () => noOfSharesGrowth = PartnersGrowth?.Sum(p => p.TotalShares) ?? 0,
                            () => pctGrowth = GetPct(totalInvestmentAmount, investmentAmountGrowth),

                            () => noOfPartnersIncome = PartnersIncome.Count(),
                            () => noOfSharesIncome = PartnersIncome?.Sum(p => p.TotalShares) ?? 0,
                            () => pctIncome = GetPct(totalInvestmentAmount, investmentAmountIncome),

                            // Investment Type
                            () => noOfPartnersTFSA = PartnersTFSA.Count(),
                            () => noOfSharesTFSA = PartnersTFSA?.Sum(p => p.TotalShares) ?? 0,
                            () => pctTFSA = GetPct(totalInvestmentAmount, investmentAmountTFSA),

                            () => noOfPartnersRRSP = PartnersRRSP.Count(),
                            () => noOfSharesRRSP = PartnersRRSP?.Sum(p => p.TotalShares) ?? 0,
                            () => pctRRSP = GetPct(totalInvestmentAmount, investmentAmountRRSP),

                            () => noOfPartnersRRSPSpousal = PartnersRRSPSpousal.Count(),
                            () => noOfSharesRRSPSpousal = PartnersRRSPSpousal?.Sum(p => p.TotalShares) ?? 0,
                            () => pctRRSPSpousal = GetPct(totalInvestmentAmount, investmentAmountRRSPSpousal),

                            () => noOfPartnersLIRA = PartnersLIRA.Count(),
                            () => noOfSharesLIRA = PartnersLIRA?.Sum(p => p.TotalShares) ?? 0,
                            () => pctLIRA = GetPct(totalInvestmentAmount, investmentAmountLIRA),

                            () => noOfPartnersLRSP = PartnersLRSP.Count(),
                            () => noOfSharesLRSP = PartnersLRSP?.Sum(p => p.TotalShares) ?? 0,
                            () => pctLRSP = GetPct(totalInvestmentAmount, investmentAmountLRSP),

                            () => noOfPartnersRESPFamily = PartnersRESPFamily.Count(),
                            () => noOfSharesRESPFamily = PartnersRESPFamily?.Sum(p => p.TotalShares) ?? 0,
                            () => pctRESPFamily = GetPct(totalInvestmentAmount, investmentAmountRESPFamily),

                            () => noOfPartnersRLSP = PartnersRLSP.Count(),
                            () => noOfSharesRLSP = PartnersRLSP?.Sum(p => p.TotalShares) ?? 0,
                            () => pctRLSP = GetPct(totalInvestmentAmount, investmentAmountRLSP),

                            () => noOfPartnersLIF = PartnersLIF.Count(),
                            () => noOfSharesLIF = PartnersLIF?.Sum(p => p.TotalShares) ?? 0,
                            () => pctLIF = GetPct(totalInvestmentAmount, investmentAmountLIF),

                            () => noOfPartnersNewLIF = PartnersNewLIF.Count(),
                            () => noOfSharesNewLIF = PartnersNewLIF?.Sum(p => p.TotalShares) ?? 0,
                            () => pctNewLIF = GetPct(totalInvestmentAmount, investmentAmountNewLIF),

                            () => noOfPartnersRLIF = PartnersRLIF.Count(),
                            () => noOfSharesRLIF = PartnersRLIF?.Sum(p => p.TotalShares) ?? 0,
                            () => pctRLIF = GetPct(totalInvestmentAmount, investmentAmountRLIF),

                            () => noOfPartnersRRIF = PartnersRRIF.Count(),
                            () => noOfSharesRRIF = PartnersRRIF?.Sum(p => p.TotalShares) ?? 0,
                            () => pctRRIF = GetPct(totalInvestmentAmount, investmentAmountRRIF),

                            () => noOfPartnersRRIFSpousal = PartnersRRIFSpousal.Count(),
                            () => noOfSharesRRIFSpousal = PartnersRRIFSpousal?.Sum(p => p.TotalShares) ?? 0,
                            () => pctRRIFSpousal = GetPct(totalInvestmentAmount, investmentAmountRRIFSpousal),

                            () => noOfPartnersNonRegisteredIndividual = PartnersNonRegisteredIndividual.Count(),
                            () => noOfSharesNonRegisteredIndividual = PartnersNonRegisteredIndividual?.Sum(p => p.TotalShares) ?? 0,
                            () => pctNonRegisteredIndividual = GetPct(totalInvestmentAmount, investmentAmountNonRegisteredIndividual),

                            () => noOfPartnersNonRegisteredCompany = PartnersNonRegisteredCompany.Count(),
                            () => noOfSharesNonRegisteredCompany = PartnersNonRegisteredCompany?.Sum(p => p.TotalShares) ?? 0,
                            () => pctNonRegisteredCompany = GetPct(totalInvestmentAmount, investmentAmountNonRegisteredCompany),

                            () => noOfPartnersNonRegisteredJTWROS = PartnersNonRegisteredJTWROS.Count(),
                            () => noOfSharesNonRegisteredJTWROS = PartnersNonRegisteredJTWROS?.Sum(p => p.TotalShares) ?? 0,
                            () => pctNonRegisteredJTWROS = GetPct(totalInvestmentAmount, investmentAmountNonRegisteredJTWROS));

            return new DashboardPartnerViewModel()
            {
                NoOfPartnersWithValidationErrors = noOfPartnersWithValidationErrors,
                NoOfUniqueActiveInvestors = noOfUniqueActiveInvestors,

                // Account Type
                NoOfPartnersGrowth = noOfPartnersGrowth,
                NoOfSharesGrowth = noOfSharesGrowth,
                InvestmentAmountGrowth = investmentAmountGrowth,
                PctGrowth = pctGrowth,

                NoOfPartnersIncome = noOfPartnersIncome,
                NoOfSharesIncome = noOfSharesIncome,
                InvestmentAmountIncome = investmentAmountIncome,
                PctIncome = pctIncome,

                // Investment Type
                NoOfPartnersTFSA = noOfPartnersTFSA,
                NoOfSharesTFSA = noOfSharesTFSA,
                InvestmentAmountTFSA = investmentAmountTFSA,
                PctTFSA = pctTFSA,

                NoOfPartnersRRSP = noOfPartnersRRSP,
                NoOfSharesRRSP = noOfSharesRRSP,
                InvestmentAmountRRSP = investmentAmountRRSP,
                PctRRSP = pctRRSP,

                NoOfPartnersRRSPSpousal = noOfPartnersRRSPSpousal,
                NoOfSharesRRSPSpousal = noOfSharesRRSPSpousal,
                InvestmentAmountRRSPSpousal = investmentAmountRRSPSpousal,
                PctRRSPSpousal = pctRRSPSpousal,

                NoOfPartnersLIRA = noOfPartnersLIRA,
                NoOfSharesLIRA = noOfSharesLIRA,
                InvestmentAmountLIRA = investmentAmountLIRA,
                PctLIRA = pctLIRA,

                NoOfPartnersLRSP = noOfPartnersLRSP,
                NoOfSharesLRSP = noOfSharesLRSP,
                InvestmentAmountLRSP = investmentAmountLRSP,
                PctLRSP = pctLRSP,

                NoOfPartnersRESPFamily = noOfPartnersRESPFamily,
                NoOfSharesRESPFamily = noOfSharesRESPFamily,
                InvestmentAmountRESPFamily = investmentAmountRESPFamily,
                PctRESPFamily = pctRESPFamily,

                NoOfPartnersRLSP = noOfPartnersRLSP,
                NoOfSharesRLSP = noOfSharesRLSP,
                InvestmentAmountRLSP = investmentAmountRLSP,
                PctRLSP = pctRLSP,

                NoOfPartnersLIF = noOfPartnersLIF,
                NoOfSharesLIF = noOfSharesLIF,
                InvestmentAmountLIF = investmentAmountLIF,
                PctLIF = pctLIF,

                NoOfPartnersNewLIF = noOfPartnersNewLIF,
                NoOfSharesNewLIF = noOfSharesNewLIF,
                InvestmentAmountNewLIF = investmentAmountNewLIF,
                PctNewLIF = pctNewLIF,

                NoOfPartnersRLIF = noOfPartnersRLIF,
                NoOfSharesRLIF = noOfSharesRLIF,
                InvestmentAmountRLIF = investmentAmountRLIF,
                PctRLIF = pctRLIF,

                NoOfPartnersRRIF = noOfPartnersRRIF,
                NoOfSharesRRIF = noOfSharesRRIF,
                InvestmentAmountRRIF = investmentAmountRRIF,
                PctRRIF = pctRRIF,

                NoOfPartnersRRIFSpousal = noOfPartnersRRIFSpousal,
                NoOfSharesRRIFSpousal = noOfSharesRRIFSpousal,
                InvestmentAmountRRIFSpousal = investmentAmountRRIFSpousal,
                PctRRIFSpousal = pctRRIFSpousal,

                NoOfPartnersNonRegisteredIndividual = noOfPartnersNonRegisteredIndividual,
                NoOfSharesNonRegisteredIndividual = noOfSharesNonRegisteredIndividual,
                InvestmentAmountNonRegisteredIndividual = investmentAmountNonRegisteredIndividual,
                PctNonRegisteredIndividual = pctNonRegisteredIndividual,

                NoOfPartnersNonRegisteredCompany = noOfPartnersNonRegisteredCompany,
                NoOfSharesNonRegisteredCompany = noOfSharesNonRegisteredCompany,
                InvestmentAmountNonRegisteredCompany = investmentAmountNonRegisteredCompany,
                PctNonRegisteredCompany = pctNonRegisteredCompany,

                NoOfPartnersNonRegisteredJTWROS = noOfPartnersNonRegisteredJTWROS,
                NoOfSharesNonRegisteredJTWROS = noOfSharesNonRegisteredJTWROS,
                InvestmentAmountNonRegisteredJTWROS = investmentAmountNonRegisteredJTWROS,
                PctNonRegisteredJTWROS = pctNonRegisteredJTWROS
            };
        }

        private int GetAverageDaysSinceLastAppraisalForResidential(IEnumerable<TdsLoan> residentialLoanList, IEnumerable<TdsProperty> propertyList)
        {
            IEnumerable<LoanAvgAppraisalDataModel> loanDataListWithAvgDaysSinceAppraisal = _loanService.GetAverageAppraisalDateDataForLoans(residentialLoanList, propertyList);

            return (int)loanDataListWithAvgDaysSinceAppraisal.Average(a => a.AverageAppraisalDaysToDate);
        }

        private decimal GetTotalAverageApprasial(IEnumerable<TdsLoan> loanList, IEnumerable<TdsProperty> propertyList)
        {
            IEnumerable<TdsProperty> filteredPropertyList = propertyList.Where(p => loanList.Any(l => l.RecId == p.LoanRecId) && 
                                                                                    p.AppraiserFmv != null && p.AppraiserFmv > 0 && // Appraisal > 0
                                                                                    (bool)p.Primary); // Only primary property
            var loanListWithAverageAppraisal = from property in filteredPropertyList
                                               group property by property.LoanRecId into propertyGroup
                                               select new
                                               {
                                                   LoanRecID = propertyGroup.Key,
                                                   Account = loanList.FirstOrDefault(l => l.RecId == propertyGroup.Key).Account,
                                                   AverageAppraiserFmv = propertyGroup.Average(p => p.AppraiserFmv)
                                               };

            return (decimal)loanListWithAverageAppraisal.Average(a => a.AverageAppraiserFmv);
        }

        private decimal? GetAverageCreditScroe(TdsLoan loan, IEnumerable<UdfValue> AverageCreditScoreUDFValues)
        {
            string AverageCreditScore = AverageCreditScoreUDFValues.Where(v => v.OwnerRecId == loan.RecId).FirstOrDefault()?.Value;
            decimal AverageCreditScoreInt = String.IsNullOrEmpty(AverageCreditScore) ?
                                            GetSiteSetting(_cache, SiteSettingKey.DEFAULTAVERAGECREDITSCORE.ToString()) : decimal.Parse(AverageCreditScore);
            return AverageCreditScoreInt;
        }

        private decimal? GetPricePerSquareFoot(TdsLoan loan, IEnumerable<UdfValue> SubjectPropertySquareFootageUDFValues, IEnumerable<TdsProperty> primaryPropertyList)
        {
            string SubjectPropertySquareFootage = SubjectPropertySquareFootageUDFValues.FirstOrDefault(v => v.OwnerRecId == loan.RecId)?.Value;
            decimal PricePerSquareFoot = (decimal)primaryPropertyList.FirstOrDefault(p => p.LoanRecId == loan.RecId)?.AppraiserFmv / SubjectPropertySquareFootage.ToDecimal();
            return PricePerSquareFoot;
        }
    
    
    
    }
}