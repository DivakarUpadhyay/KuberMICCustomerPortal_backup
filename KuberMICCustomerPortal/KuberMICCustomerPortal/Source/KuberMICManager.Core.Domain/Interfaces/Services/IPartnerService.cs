using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure;
using KuberMICManager.Core.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.Interfaces.Services
{
    public interface IPartnerService
    {
        Task<IEnumerable<PssPartner>> GetAllPartners();
        IEnumerable<PartnerIndexModel> GetPartnersWithValidationErrors(IEnumerable<PartnerIndexModel> partners, IEnumerable<UdfValue> udfValueList);
        Task<IEnumerable<ValidationModel>> GetPartnersWithValidationErrors();
        Task<PartnerViewModel> GetPartnerDetailsByIdAsync(string RecId);
        Task<IEnumerable<PartnerTransactionDetails>> GetPartnerTransactionDetailsAsync(DateTime? startDate = null, DateTime? endDate = null);
        IEnumerable<UniqueInvestorIndexModel> GetUniqueActiveInvestorList(IEnumerable<PartnerIndexModel> partnerList, IEnumerable<UdfValue> udfValueList);
        int GetNumberOfUniqueActiveInvestors(IEnumerable<PartnerIndexModel> partnerList, IEnumerable<UdfValue> udfValueList);
        Task<IEnumerable<PartnerIndexModel>> GetFilteredPartners(PartnerFilterType? FilterType);
        Task<IEnumerable<UdfValue>> GetUserDefinedFieldsByParentID(string parentID = null);
        IEnumerable<PartnerIndexModel> PartnerFilter(IEnumerable<PartnerIndexModel> PartnerDataList, PartnerFilterType? FilterType);
    }
}