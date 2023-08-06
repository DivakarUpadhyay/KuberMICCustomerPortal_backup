using KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KuberMICManager.Infrastructure.DataAccess
{
    /// <summary>
    /// Repository to get portfolio detail via Stored Procedure
    /// </summary>
    public class SPRepository : ISPRepository
    {
        private readonly ApplicationDbContext _context;

        public SPRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /******* Loan Stored Procedure *******/
        /// <summary>
        /// Get total funding as of date given
        /// </summary>
        /// <param name="asOfDate"></param>
        /// <returns></returns>
        public async Task<decimal> GetTotalLoanFundedToDate(DateTime? asOfDate)
        {
            return await _context.SPGetTotalLoanFundedToDate(asOfDate);
        }

        /// <summary>
        /// Get modified property list as of target date with appraisal date prior to target date
        /// </summary>
        /// <param name="asOfDate">Date properies modified as of</param>
        /// <returns>List of modified property details</returns>
        public async Task<List<ModifiedProperty>> GetModifiedPropertyDetails(DateTime? asOfDate = null)
        {
            return await _context.SPGetModifiedProperties(asOfDate);
        }

        /******* Partner Stored Procedure *******/
        /// <summary>
        /// Get certificate details along with share summary.
        /// </summary>
        /// <returns></returns>
        public async Task<List<PartnerCertificateDetails>> GetCertificatesWithShareDetails()
        {
            return await _context.SPGetPartnerCertificates();
        }

        /// <summary>
        /// Get Partner transaction details.
        /// </summary>
        /// <returns></returns>
        public async Task<List<PartnerTransactionDetails>> GetTransactionDetails(DateTime? startDate = null, DateTime? endDate = null)
        {
            return await _context.SPGetPartnerTransactions(startDate, endDate);
        }
        public async Task<List<GetUserData>> GetUserData()
        {
            return await _context.SPGetUserData();
        }
    }
}
