using KuberMICManager.Core.Domain.Interfaces.Framework;
using System;

namespace KuberMICManager.Core.Domain.Interfaces
{
    public interface IPartnerUnitOfWork : IUnitOfWork, IDisposable
    {
        IPartnerRepository PartnerRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        ICertificateRepository CertificateRepository { get; }
        IDistributionRepository DistributionRepository { get; }
        IPoolRepository PoolRepository { get; }
        ITrusteeRepository TrusteeRepository { get; }
    }
}