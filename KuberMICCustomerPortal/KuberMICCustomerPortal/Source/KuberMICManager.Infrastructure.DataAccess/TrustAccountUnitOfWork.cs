using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;

namespace KuberMICManager.Infrastructure.DataAccess
{
    public class TrustAccountUnitOfWork : SharedUnitOfWork, ITrustAccountUnitOfWork
    {
        public ITAccountRepository TAccountRepository { get; }
        public ITATransactionRepository TATransactionRepository { get; }

        public TrustAccountUnitOfWork(MICDataContext context) : base(context)
        {
            TAccountRepository = new TfaAccountRepository(_context);
            TATransactionRepository = new TfaTransactionRepository(_context);
        }
    }
}