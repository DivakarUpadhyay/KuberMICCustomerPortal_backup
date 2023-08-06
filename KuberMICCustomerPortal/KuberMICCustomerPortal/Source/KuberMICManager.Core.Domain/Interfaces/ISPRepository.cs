using KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KuberMICManager.Core.Domain.Interfaces
{
    public interface ISPRepository
    {
        // Loan
        Task<decimal> GetTotalLoanFundedToDate(DateTime? AsOfDate);
        Task<List<ModifiedProperty>> GetModifiedPropertyDetails(DateTime? asOfDate = null);

        // Partner
        Task<List<PartnerCertificateDetails>> GetCertificatesWithShareDetails();
        Task<List<PartnerTransactionDetails>> GetTransactionDetails(DateTime? startDate = null, DateTime? endDate = null);

        Task<List<GetUserData>> GetUserData();

    }
}
