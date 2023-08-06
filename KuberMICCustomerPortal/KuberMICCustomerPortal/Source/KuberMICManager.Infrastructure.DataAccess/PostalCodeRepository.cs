using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;
using KuberMICManager.Infrastructure.DataAccess.Framework;

namespace KuberMICManager.Infrastructure.DataAccess
{
    /// <summary>
    /// Postal Code Entity Framework Repository
    /// </summary>
    public class PostalCodeRepository : ReadWriteEFRespository<int, TdsPostalCode>, IPostalCodeRepository
    {
        public PostalCodeRepository(ApplicationDbContext context) : base(context) { }
    }
}
