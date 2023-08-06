using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;
using KuberMICManager.Infrastructure.DataAccess.Framework;

namespace KuberMICManager.Infrastructure.DataAccess
{
    /// <summary>
    /// MIC Manager Entity Framework Repository
    /// </summary>
    public class RenewalRepository : ReadWriteEFRespository<int, TdsLoanRenewal>, IRenewalRepository
    {
        public RenewalRepository(ApplicationDbContext context) : base(context) { }
    }
}
