using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;
using KuberMICManager.Infrastructure.DataAccess.Framework;

namespace KuberMICManager.Infrastructure.DataAccess
{
    /// <summary>
    /// Site Settings Entity Framework Repository
    /// </summary>
    public class SiteSettingRepository : ReadWriteEFRespository<int, SiteSetting>, ISiteSettingRepository
    {
        public SiteSettingRepository(ApplicationDbContext context) : base(context) { }
    }
}
