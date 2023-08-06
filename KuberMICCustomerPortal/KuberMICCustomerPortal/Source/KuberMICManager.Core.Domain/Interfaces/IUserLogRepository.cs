using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.Interfaces
{
    public interface IUserLogRepository : IReadWriteRepository<int, UserLog>
    {
        Task<IEnumerable<UserLog>> GetLogs(string queryString, AreaType? areaType, EventType? eventType);
        Task LogEvent(AreaType areaType, EventType eventType, string description);
        Task LogEvent(AreaType areaType, EventType eventType, string userName, string description);
        Task LogEvent(AreaType areaType, EventType eventType, string userName, string description, ResultType? result);
    }
}
