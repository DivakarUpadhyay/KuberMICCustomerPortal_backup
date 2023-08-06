using KuberMICManager.Core.Domain.Interfaces.Framework;
using System;

namespace KuberMICManager.Core.Domain.Interfaces
{
    public interface ILoanUnitOfWork : IUnitOfWork, IDisposable
    {
        ILoanRepository LoanRepository { get; }
        ILoanHistoryRepository LoanHistoryRepository { get; }
        ILienRepository LienRepository { get; }
        IChargeRepository ChargeRepository { get; }
        IChargesDetailRepository ChargesDetailRepository { get; }
        ICoBorrowerRepository CoBorrowerRepository { get; }
        IFundingRepository FundingRepository { get; }
        ILenderRepository LenderRepository { get; }
        IInsuranceRepository InsuranceRepository { get; }
        IPropertyRepository PropertyRepository { get; }
    }
}