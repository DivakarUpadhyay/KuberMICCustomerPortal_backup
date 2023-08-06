using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces.Framework;

namespace KuberMICManager.Core.Domain.Interfaces
{
    public interface IRenewalRepository : IReadWriteRepository<int, TdsLoanRenewal> {}
}
