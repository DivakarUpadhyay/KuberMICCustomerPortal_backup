using KuberMICManager.Core.Domain.Interfaces.Framework;
using System;

namespace KuberMICManager.Core.Domain.Interfaces
{
    public interface ITrustAccountUnitOfWork : IUnitOfWork, IDisposable
    {
        ITAccountRepository TAccountRepository { get; }
        ITATransactionRepository TATransactionRepository { get; }
    }
}