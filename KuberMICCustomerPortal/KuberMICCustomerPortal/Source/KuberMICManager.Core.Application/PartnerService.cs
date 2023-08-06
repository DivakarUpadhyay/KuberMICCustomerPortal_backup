using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Application
{
    public class PartnerService : IPartnerService
    {
        // inject the dependencies
        private readonly ILogger<LoanService> _logger;
        private readonly IPartnerUnitOfWork _partnerUnitOfWork;
        private readonly ISPRepository _certificateDetailsRepository;

        public PartnerService(ILogger<LoanService> logger,
                              IPartnerUnitOfWork partnerUnitOfWork,
                              ISPRepository certificateDetailsRepository)
        {
            _logger = logger;
            _partnerUnitOfWork = partnerUnitOfWork;
            _certificateDetailsRepository = certificateDetailsRepository;
        }

        public async Task<IEnumerable<PssPartner>> GetAllPartners()
        {
            return await _partnerUnitOfWork.PartnerRepository.FindAllAsync(p => p.Account, OrderDirection.Descending);
        }

        private async Task<IEnumerable<PssCertificate>> GetAllCertificates()
        {
            return await _partnerUnitOfWork.CertificateRepository.FindAllAsync();
        }

        public IEnumerable<PartnerIndexModel> GetPartnersWithValidationErrors(IEnumerable<PartnerIndexModel> partnerList, IEnumerable<UdfValue> userDefinedFieldList)
        {
            _logger.LogInformation($"Calling: PartnerService.GetPartnersWithValidationErrors()\n");

            IEnumerable<PartnerIndexModel> incompletePartners = null;
            IEnumerable<PartnerIndexModel> incompleteCompanyPartners = null;
            IEnumerable<PartnerIndexModel> incompleteJTWROSPartners = null;

            Parallel.Invoke(
                // Find missing critical information in Partners
                () => incompletePartners = partnerList.Where(p => String.IsNullOrEmpty(p.Partner.EmailAddress) ||
                                                        String.IsNullOrEmpty(p.Partner.Tin) ||
                                                        (String.IsNullOrEmpty(p.Partner.PhoneCell) &&
                                                            String.IsNullOrEmpty(p.Partner.PhoneHome) &&
                                                            String.IsNullOrEmpty(p.Partner.PhoneWork)) ||
                                                        p.TotalShares * p.SharePrice != p.TotalInvestmentAmount ||
                                                        p.RedeemedCertificateShareTotal != 0),

                // Find missing critical information in company partner custom fields
                () => incompleteCompanyPartners = from p in PartnerFilter(partnerList, PartnerFilterType.NonRegisteredCompany)
                                                  where String.IsNullOrEmpty(userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == p.Partner.RecId && f.ParentRecId == BusinessNumberParentRecId)?.Value) // Business Number is empty - not in user defined list
                                                  select p,

                // Find missing critical information in JTWROS partner custom fields
                () => incompleteJTWROSPartners = from p in PartnerFilter(partnerList, PartnerFilterType.NonRegisteredJTWROS)
                                                  where String.IsNullOrEmpty(userDefinedFieldList.FirstOrDefault(f => f.OwnerRecId == p.Partner.RecId && f.ParentRecId == JointPartnerNamesParentRecId)?.Value) // Joint Partner Names is empty - not in user defined list
                                                  select p
            );

            return incompletePartners.Union(incompleteCompanyPartners).Union(incompleteJTWROSPartners);
        }

        public async Task<IEnumerable<ValidationModel>> GetPartnersWithValidationErrors()
        {
            _logger.LogInformation($"Calling: PartnerService.GetPartnersWithValidationErrors()\n");

            IEnumerable<PartnerIndexModel> Partners = await GetFilteredPartners(PartnerFilterType.ShareBalanceGreaterThanZero);
            IEnumerable<UdfValue> udfValueList = await GetUserDefinedFieldsByParentID(null);

            IEnumerable<PartnerIndexModel> partnersWithErrors = GetPartnersWithValidationErrors(Partners, udfValueList);

            IEnumerable<ValidationModel> partnerValidationList = from partnerData in partnersWithErrors
                                                                 select new ValidationModel()
                                                                 {
                                                                     RecId = partnerData.Partner.RecId,
                                                                     Account = partnerData.Partner.Account,
                                                                     FullName = partnerData.Partner.FullName,
                                                                     PoolAccount = partnerData.PoolAccount,
                                                                     Balance = partnerData.TotalInvestmentAmount,
                                                                     Street = partnerData.Partner.Street,
                                                                     City = partnerData.Partner.City,
                                                                     State = partnerData.Partner.State,
                                                                     ZipCode = partnerData.Partner.ZipCode,
                                                                     Type = ValidationAccountType.Partner,

                                                                     MissingInfoList = GetMissingInfoList(partnerData, udfValueList)
                                                                 };
            return partnerValidationList;
        }

        private string GetMissingInfoList(PartnerIndexModel partnerData, IEnumerable<UdfValue> udfValueList)
        {
            // Validating: SIN, EmailAddress, PhoneHome, PhoneWork and PhoneCell
            IList<string> strings = new List<string> { };

            // Loans
            if (String.IsNullOrEmpty(partnerData.Partner.Tin))
                strings.Add("SIN");
            if (String.IsNullOrEmpty(partnerData.Partner.EmailAddress))
                strings.Add("Email");
            if (String.IsNullOrEmpty(partnerData.Partner.PhoneCell) &&
                String.IsNullOrEmpty(partnerData.Partner.PhoneHome) &&
                 String.IsNullOrEmpty(partnerData.Partner.PhoneWork))
                strings.Add("Phone Number");

            // Compare Total Shares and Total Investment Amount
            if (partnerData.SharePrice * partnerData.TotalShares != partnerData.TotalInvestmentAmount)
                strings.Add("Mismatched Total Share and Investment Amount");

            // Orphaned shares
            if (partnerData.RedeemedCertificateShareTotal > 0)
                strings.Add("Orphaned shares in redeemed certificate");

            // Missing company partner custom fields
            if (partnerData.Partner.TrusteeAccountType == "Non-Registered - Company" && String.IsNullOrEmpty(udfValueList.FirstOrDefault(f => f.OwnerRecId == partnerData.Partner.RecId && f.ParentRecId == BusinessNumberParentRecId)?.Value))
                strings.Add("Missing Bussiness Number");

            // Missing Joint JTWROS partner names custom fields
            if (partnerData.Partner.TrusteeAccountType == "Non-Registered - JTWROS" && String.IsNullOrEmpty(udfValueList.FirstOrDefault(f => f.OwnerRecId == partnerData.Partner.RecId && f.ParentRecId == JointPartnerNamesParentRecId)?.Value))
                strings.Add("Missing Joint JTWROS Partner Names");

            return String.Join(", ", strings);
        }

        public async Task<PartnerViewModel> GetPartnerDetailsByIdAsync(string RecId)
        {
            _logger.LogInformation($"Calling: PartnerService.GetPartnerDetailsByIdAsync(): RecId: {RecId}");

            PartnerViewModel partnerViewModel = new PartnerViewModel();

            partnerViewModel.Partner = await _partnerUnitOfWork.PartnerRepository.FindAsync(RecId);
            partnerViewModel.Trustee = (await _partnerUnitOfWork.TrusteeRepository.FindAsync(t => t.RecId == partnerViewModel.Partner.TrusteeRecId)).FirstOrDefault();
            partnerViewModel.Certificates = await _partnerUnitOfWork.CertificateRepository.FindAsync(p => p.PartnerRecId == RecId);
            if (partnerViewModel.Certificates.Any())
                partnerViewModel.Pool = (await _partnerUnitOfWork.PoolRepository.FindAsync(p => p.RecId == partnerViewModel.Certificates.FirstOrDefault().PartnershipRecId)).FirstOrDefault();
            partnerViewModel.Transactions = await _partnerUnitOfWork.TransactionRepository.FindAsync(p => p.PartnerRecId == RecId);
            
            // Shared
            partnerViewModel.Attachments = await ((ISharedUnitOfWork)_partnerUnitOfWork).AttachmentRepository.FindAsync(p => p.OwnerRecId == RecId);
            partnerViewModel.Notes = (await ((ISharedUnitOfWork)_partnerUnitOfWork).NoteRepository.FindAsync(p => p.RecId == RecId)).FirstOrDefault();
            partnerViewModel.UDFFields = await ((ISharedUnitOfWork)_partnerUnitOfWork).UserDefinedFieldRepository.FindAsync(p => (UDFFieldOwnerType)p.OwnerType == UDFFieldOwnerType.Partner);
            partnerViewModel.UDFValues = await ((ISharedUnitOfWork)_partnerUnitOfWork).UserDefinedValueRepository.FindAsync(p => p.OwnerRecId == RecId);
            partnerViewModel.UDFTabs = await ((ISharedUnitOfWork)_partnerUnitOfWork).UserDefinedTabRepository.FindAllAsync();

            return partnerViewModel;
        }

        public async Task<IEnumerable<PartnerTransactionDetails>> GetPartnerTransactionDetailsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            _logger.LogInformation($"Calling: PartnerService.GetPartnerTransactionDetailsAsync()");

            IEnumerable<PartnerTransactionDetails> partnerTransactionList = (await _certificateDetailsRepository.GetTransactionDetails(startDate, endDate));

            return partnerTransactionList;
        }

        public IEnumerable<UniqueInvestorIndexModel> GetUniqueActiveInvestorList(IEnumerable<PartnerIndexModel> partnerList, IEnumerable<UdfValue> udfValueList)
        {
            // Company Partners
            var nonRegisteredCompanyPartnerList = from partnerData in PartnerFilter(partnerList, PartnerFilterType.NonRegisteredCompany).Where(p => p.TotalShares > 0)
                                                  select new UniqueInvestorIndexModel
                                                  {
                                                      FirstName = udfValueList.FirstOrDefault(v => v.OwnerRecId == partnerData.Partner.RecId && v.ParentRecId == BusinessNumberParentRecId)?.Value.Trim().Replace(" ", "") ?? "Missing Business Number",
                                                      LastName = "",
                                                      Accounts = partnerData.Partner.Account,
                                                      AccountTypes = partnerData.Partner.TrusteeAccountType
                                                  };

            var nonRegisteredUniqueCompanyPartnerList = (from p in nonRegisteredCompanyPartnerList
                                                         group p by p.FirstName?.ToLower() into g
                                                         select new UniqueInvestorIndexModel { FirstName = g.Key, LastName = "", Accounts = string.Join(", ", g.Select(v => v.Accounts)), AccountTypes = string.Join(", ", g.Select(v => v.AccountTypes)) }).ToList();

            // Individual partners
            IEnumerable<PartnerIndexModel> registeredPartnerList = PartnerFilter(partnerList, PartnerFilterType.Registered).Where(p => p.TotalShares > 0);
            IEnumerable<PartnerIndexModel> nonRegisteredIndividualPartnerList = PartnerFilter(partnerList, PartnerFilterType.NonRegisteredIndividual).Where(p => p.TotalShares > 0);

            var registeredAndNonRegisteredIndividualList = registeredPartnerList.Concat(nonRegisteredIndividualPartnerList)
                                                                .Select(p => new UniqueInvestorIndexModel
                                                                {
                                                                    FirstName = p.Partner.FirstName.Trim(),
                                                                    LastName = p.Partner.LastName.Trim(),
                                                                    Accounts = p.Partner.Account,
                                                                    AccountTypes = p.Partner.TrusteeAccountType
                                                                })
                                                                .ToList();

            // JTWROS partners - get a list of Name, Account and Account Type
            var nonRegisteredJTWROSJointPartnerList = from p in PartnerFilter(partnerList, PartnerFilterType.NonRegisteredJTWROS).Where(p => p.TotalShares > 0)
                                                      join nameData in udfValueList.Where(v => v.ParentRecId == JointPartnerNamesParentRecId)
                                                          on p.Partner.RecId equals nameData.OwnerRecId
                                                      select new
                                                      {
                                                          Names = nameData.Value.Trim(),
                                                          Accounts = p.Partner.Account,
                                                          AccountTypes = p.Partner.TrusteeAccountType
                                                      };

            var nonRegisteredJTWROSPartnerList = nonRegisteredJTWROSJointPartnerList
                                                 .SelectMany(p => p.Names.Split('&')
                                                 .Select(n => new UniqueInvestorIndexModel
                                                 {
                                                     FirstName = n.Trim().Split(' ').First().Trim().ToLower(),
                                                     LastName = n.Trim().Split(' ').Last().Trim().ToLower(),
                                                     Accounts = p.Accounts,
                                                     AccountTypes = p.AccountTypes
                                                 }));

            var uniqueIndividuals = registeredAndNonRegisteredIndividualList.Concat(nonRegisteredJTWROSPartnerList)
                                    .GroupBy(p => new { FirstName = p.FirstName.Trim().ToLower(), LastName = p.LastName.Trim().ToLower() })
                                    .Select(g => new UniqueInvestorIndexModel { FirstName = g.FirstOrDefault().FirstName, LastName = g.FirstOrDefault().LastName, Accounts = string.Join(", ", g.Select(v => v.Accounts)), AccountTypes = string.Join(", ", g.Select(v => v.AccountTypes)) })
                                    .ToList();

            return uniqueIndividuals.Concat(nonRegisteredUniqueCompanyPartnerList);
        }

        public int GetNumberOfUniqueActiveInvestors(IEnumerable<PartnerIndexModel> partnerList, IEnumerable<UdfValue> udfValueList)
        {
            return GetUniqueActiveInvestorList(partnerList, udfValueList).Count();
        }

        public async Task<IEnumerable<PartnerIndexModel>> GetFilteredPartners(PartnerFilterType? FilterType)
        {
            _logger.LogInformation($"Calling: PartnerService.GetFilteredPartners(): PartnerFilterType: {FilterType.ToDescription}");

            IEnumerable<PssPartner> Partners = await GetAllPartners();
            IEnumerable<PartnerCertificateDetails> certificateList = await _certificateDetailsRepository.GetCertificatesWithShareDetails();
            IEnumerable<PssPool> poolList = await _partnerUnitOfWork.PoolRepository.FindAllAsync();

            IEnumerable<PartnerIndexModel> partnerList = Partners
                                                         .Select(p => new { partner = p, certificates = certificateList.Where(c => c.PartnerRecId == p.RecId)})
                                                         .Select(data => new PartnerIndexModel()
                                                              {
                                                                  Partner = data.partner,
                                                                  PoolAccount = poolList.FirstOrDefault(p => p.RecId == data.certificates.FirstOrDefault()?.PartnershipRecId)?.Account ?? "",
                                                                  SharePrice = data.certificates.Max(c => c.SharePrice) ?? 0,
                                                                  TotalShares = data.certificates.Sum(c => c.TotalShares ?? 0),
                                                                  TotalInvestmentAmount = data.certificates.Sum(c => c.TotalInvestmentAmount ?? 0),
                                                                  RedeemedCertificateShareTotal = data.certificates.Sum(c => c.RedeemedCertificateShareTotal ?? 0),
                                                                  SearchString = string.Join(",", data.certificates.Select(x => x.Number)) + ',' +
                                                                                  data.partner.Tin.Trim() + ',' +
                                                                                  data.partner.Tin.Trim().Replace(" ", "") + ',' +
                                                                                  data.partner.PhoneCell.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "") + ',' +
                                                                                  data.partner.PhoneHome.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "") + ',' +
                                                                                  data.partner.PhoneWork.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "") + ',' +
                                                                                  data.partner.PhoneFax.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "") + ',' +
                                                                                  data.partner.PhoneCell.Trim() + ',' + data.partner.PhoneCell.Trim().Replace(" ", "") + ',' + data.partner.PhoneCell.Trim().Replace(" ", "").Replace("(", "").Replace(")", "") + ',' +
                                                                                  data.partner.PhoneHome.Trim() + ',' + data.partner.PhoneHome.Trim().Replace(" ", "") + ',' + data.partner.PhoneHome.Trim().Replace(" ", "").Replace("(", "").Replace(")", "") + ',' +
                                                                                  data.partner.PhoneWork.Trim() + ',' + data.partner.PhoneWork.Trim().Replace(" ", "") + ',' + data.partner.PhoneWork.Trim().Replace(" ", "").Replace("(", "").Replace(")", "") + ',' +
                                                                                  data.partner.PhoneFax.Trim() + ',' + data.partner.PhoneFax.Trim().Replace(" ", "") + ',' + data.partner.PhoneFax.Trim().Replace(" ", "").Replace("(", "").Replace(")", "") + ',' +
                                                                                  data.partner.EmailAddress.Trim() + ',' + data.partner.EmailAddress.Trim().ToLower() + ','
                                                              }).ToList();

            IEnumerable<PartnerIndexModel> FilteredPartnerList = PartnerFilter(partnerList, FilterType);

            // All filters other then All should be on active (TotalShares > 0) partners
            if (FilterType != PartnerFilterType.All)
            {
                return FilteredPartnerList.Where(p => /*p.TotalInvestmentAmount > 0 ||*/ p.TotalShares > 0);
            }

            return FilteredPartnerList;
        }

        public async Task<IEnumerable<UdfValue>> GetUserDefinedFieldsByParentID(string parentID = null)
        {
            return await ((ISharedUnitOfWork)_partnerUnitOfWork).UserDefinedValueRepository.FindAsync(v => string.IsNullOrEmpty(parentID) || v.ParentRecId == parentID);
        }

        public  IEnumerable<PartnerIndexModel> PartnerFilter(IEnumerable<PartnerIndexModel> PartnerDataList, PartnerFilterType? FilterType)
        {
            IEnumerable<PartnerIndexModel> filteredPartnerDataList = null;
            switch (FilterType)
            {
                case PartnerFilterType.Active:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.Categories.Contains("Active"));
                        break;
                    }

                case PartnerFilterType.ACHActive:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.AchServiceStatus == (int)AchServiceStatus.Active);
                        break;
                    }

                case PartnerFilterType.Growth:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.AccountType == (int)PartnerAccountType.Growth);
                        break;
                    }

                case PartnerFilterType.Income:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.AccountType == (int)PartnerAccountType.Income);
                        break;
                    }

                case PartnerFilterType.DateCore:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.Categories.Contains("Datacore"));
                        break;
                    }

                case PartnerFilterType.Management:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.Categories.Contains("Management"));
                        break;
                    }

                case PartnerFilterType.NonRegisteredIndividual:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "Non-Registered - Individual");
                        break;
                    }

                case PartnerFilterType.NonRegisteredCompany:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "Non-Registered - Company");
                        break;
                    }

                case PartnerFilterType.NonRegisteredJTWROS:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "Non-Registered - JTWROS");
                        break;
                    }

                case PartnerFilterType.TFSA:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "TFSA");
                        break;
                    }

                case PartnerFilterType.RRSP:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "RRSP");
                        break;
                    }

                case PartnerFilterType.RRSPSpousal:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "RRSP SPOUSAL");
                        break;
                    }

                case PartnerFilterType.LIRA:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "LIRA");
                        break;
                    }

                case PartnerFilterType.LRSP:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "LRSP");
                        break;
                    }

                case PartnerFilterType.RESPFamily:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "RESP Family");
                        break;
                    }

                case PartnerFilterType.RLSP:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "RLSP");
                        break;
                    }

                case PartnerFilterType.LIF:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "LIF");
                        break;
                    }

                case PartnerFilterType.NewLIF:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "New LIF");
                        break;
                    }

                case PartnerFilterType.RLIF:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "RLIF");
                        break;
                    }

                case PartnerFilterType.RRIF:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "RRIF");
                        break;
                    }

                case PartnerFilterType.RRIFSpousal:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType == "RRIF Spousal");
                        break;
                    }
                case PartnerFilterType.Registered:
                    {
                        filteredPartnerDataList = PartnerDataList.Where(p => p.Partner.TrusteeAccountType != "Non-Registered - Individual" && p.Partner.TrusteeAccountType != "Non-Registered - Company" && p.Partner.TrusteeAccountType != "Non-Registered - JTWROS");
                        break;
                    }

                default:
                    {
                        filteredPartnerDataList = PartnerDataList;
                        break;
                    }
            }

            return filteredPartnerDataList.ToList(); // Use ToList() to force to compiler to reify the results right away
        }
    }
}