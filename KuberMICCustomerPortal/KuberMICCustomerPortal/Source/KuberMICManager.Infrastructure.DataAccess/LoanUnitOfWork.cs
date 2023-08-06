using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;

namespace KuberMICManager.Infrastructure.DataAccess
{
    public class LoanUnitOfWork : SharedUnitOfWork, ILoanUnitOfWork
    {
        public ILoanRepository LoanRepository { get; }
        public ILoanHistoryRepository LoanHistoryRepository { get; }
        public ILienRepository LienRepository { get; }
        public IChargeRepository ChargeRepository { get; }
        public IChargesDetailRepository ChargesDetailRepository { get; }
        public ICoBorrowerRepository CoBorrowerRepository { get; }
        public IFundingRepository FundingRepository { get; }
        public ILenderRepository LenderRepository { get; }
        public IInsuranceRepository InsuranceRepository { get; }
        public IPropertyRepository PropertyRepository { get; }

        public LoanUnitOfWork(MICDataContext context) : base(context)
        {
            LoanRepository = new TdsLoanRepository(_context);
            LoanHistoryRepository = new TdsLoanHistoryRepository(_context);
            LienRepository = new TdsLienRepository(_context);
            ChargeRepository = new TdsChargeRepository(_context);
            ChargesDetailRepository = new TdsChargesDetailRepository(_context);
            CoBorrowerRepository = new TdsCoBorrowerRepository(_context);
            FundingRepository = new TdsFundingRepository(_context);
            LenderRepository = new TdsLenderRepository(_context);
            InsuranceRepository = new TdsInsuranceRepository(_context);
            PropertyRepository = new TdsPropertyRepository(_context);       
        }
    }
}