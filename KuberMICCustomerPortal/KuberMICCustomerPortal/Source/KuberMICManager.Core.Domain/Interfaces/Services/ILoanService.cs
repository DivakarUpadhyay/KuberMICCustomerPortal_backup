using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure;
using KuberMICManager.Core.Domain.HelperDataModels;
using KuberMICManager.Core.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.Interfaces.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<TdsLoan>> GetAllLoans(DateTime? endDate = null);
        Task<IEnumerable<TdsLoan>> GetNONMaturedActiveLoans(DateTime endDate);
        Task<IEnumerable<TdsLoan>> GetActiveLoans(DateTime? endDate = null);
        Task<decimal> GetTotalLoanFundedToDate(DateTime? fundingDateAsOf);
        IEnumerable<TdsLoan> GetLoansWithValidationErrors(IEnumerable<TdsLoan> loans, IEnumerable<TdsProperty> properyList, IEnumerable<TdsPostalCode> postalCodeList, IEnumerable<UdfValue> userDefinedFieldList, IEnumerable<TdsLoanRenewal> renewalForApproval);
        Task<IEnumerable<ValidationModel>> GetLoansWithValidationErrors();
        Task<IEnumerable<TdsCoBorrower>> GetCoBorrowers();
        Task<IEnumerable<TdsProperty>> GetProperties();
        Task<IEnumerable<ModifiedProperty>> GetModifiedPropertyDetailsAsync(DateTime? asOfDate = null);
        Task<IEnumerable<TdsLien>> GetLiens();
        Task<IEnumerable<LienIndexModel>> GetLiens(LienFilterType? FilterType);
        Task<IEnumerable<UdfValue>> GetUserDefinedFieldsByParentID(string parentID = null);
        Task<IEnumerable<AppNote>> GetNotes();
        Task<LoanViewModel> GetLoanDetailsByIdAsync(string RecId);
        BBCCategory GetBBCCategory(TdsLoan loan);
        Task<IEnumerable<LoanIndexModel>> GetFilteredLoans(string SearchFor, LoanFilterType? FilterType, List<LoanSearchEnumModel> checkBoxLoanSearchGroup, DateTime? EndDate = null, List<string> releatedLoanList = null);
        decimal GetCalculatedQualifiedAmount(TdsLoan loan, string UdfValue, TdsProperty primaryPropery, TdsLien primaryFirstLien, decimal totoalQualifiedAmountOfOtherLoansForSameSIN);
        IEnumerable<TdsProperty> GetActiveProperties(IEnumerable<TdsProperty> propertyList, TdsLoan loan);
        string GetCustomValue(IEnumerable<UdfValue> customFieldsValueList, TdsLoan loan, string parentRecID);
        decimal GetTotalQualifiedOfPreviousLoansForSameSIN(TdsLoan loan, IEnumerable<TdsLoan> loanList, IEnumerable<UdfValue> qualifiedAmountList, IEnumerable<TdsCoBorrower> coborrowersList);

        Task UpdateRenewal(LoanRenewalModel loanRenewalModel);
        Task<LoanRenewalModel> GetRenewalByIdAndMaturityDate(string recId, DateTime maturityDate);
        IEnumerable<TdsLoan> GetRenewalLoans(IEnumerable<TdsLoan> Loans);
        Task<IEnumerable<LoanRenewalModel>> GetRenewals(string searchFor = null);
        IEnumerable<LoanAvgAppraisalDataModel> GetAverageAppraisalDateDataForLoans(IEnumerable<TdsLoan> loanList, IEnumerable<TdsProperty> propertyList);
    }
}