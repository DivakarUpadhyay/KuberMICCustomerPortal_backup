using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;

namespace KuberMICManager.Infrastructure.DataAccess
{
    public class PartnerUnitOfWork : SharedUnitOfWork, IPartnerUnitOfWork
    {
        public IPartnerRepository PartnerRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public ICertificateRepository  CertificateRepository { get; }
        public IDistributionRepository DistributionRepository { get; }
        public IPoolRepository  PoolRepository { get; }
        public ITrusteeRepository TrusteeRepository { get; }

        public PartnerUnitOfWork(MICDataContext context) : base(context)
        {
            PartnerRepository = new PssPartnerRepository(_context);
            TransactionRepository = new PssTransactionRepository(_context);
            CertificateRepository = new PssCertificateRepository(_context);
            DistributionRepository = new PssDistributionRepository(_context);
            PoolRepository = new PssPartnershipRepository(_context);
            TrusteeRepository = new PssTrusteeRepository(_context);
        }
    }
}