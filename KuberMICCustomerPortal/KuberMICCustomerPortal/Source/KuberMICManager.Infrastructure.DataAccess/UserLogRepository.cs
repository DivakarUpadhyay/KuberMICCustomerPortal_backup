using KuberMICManager.Core.Domain.Entities.Application;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;
using KuberMICManager.Infrastructure.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Infrastructure.DataAccess
{
    /// <summary>
    /// UserLog Entity Framework Repository
    /// </summary>
    public class UserLogRepository : ReadWriteEFRespository<int, UserLog>, IUserLogRepository
    {
        public UserLogRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<UserLog>> GetLogs(string queryString, AreaType? areaType, EventType? eventType)
        {
            IEnumerable<UserLog> logs = null;
            try
            {
                logs =  await FindAsync(l => l.Area == areaType ||
                                             l.Event == eventType ||
                                             l.Description.Contains(queryString) ||
                                             l.Email.Contains(queryString) ||
                                             l.UserName.Contains(queryString));
            }
            catch (Exception ex)
            {
                // if logging fails don't break what the user was doing
                System.Diagnostics.Debug.WriteLine("Error Getting User Event Logs: " + ex.Message);
            }

            return logs;
        }

        /// <summary>
        /// Log Event that occurs within an instructure component
        /// </summary>
        /// <param name="areaType"></param>
        /// <param name="eventType"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task LogEvent(AreaType areaType, EventType eventType, string description)
        {
            try
            {
                await LogEvent(areaType, eventType, "", description, null);
            }
            catch (Exception ex)
            {
                // if logging fails don't break what the user was doing
                System.Diagnostics.Debug.WriteLine("Error Logging: " + ex.Message);
            }
        }

        /// <summary>
        /// Log event into db for generating report
        /// </summary>
        /// <param name="areaType"></param>
        /// <param name="eventType"></param>
        /// <param name="userName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task LogEvent(AreaType areaType, EventType eventType, string userName, string description)
        {
            try
            {
                await AddAsync(new UserLog()
                {
                    Area = areaType,
                    Event = eventType,
                    UserName = userName,
                    Timestamp = DateTimeOffset.Now,
                    Description = description
                });
            }
            catch (Exception ex)
            {
                // if logging fails don't break what the user was doing
                System.Diagnostics.Debug.WriteLine("Error Logging: " + ex.Message);
            }
        }

        /// <summary>
        /// Log event into db for generating report
        /// </summary>
        /// <param name="areaType"></param>
        /// <param name="eventType"></param>
        /// <param name="userName"></param>
        /// <param name="description"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public async Task LogEvent(AreaType areaType, EventType eventType, string userName, string description, ResultType? result)
        {
            try
            {
                await AddAsync(new UserLog()
                {
                    Area = areaType,
                    Event = eventType,
                    UserName = userName,
                    Timestamp = DateTimeOffset.Now,
                    Description = description,
                    Result = result
                });
            }
            catch (Exception ex)
            {
                // if logging fails don't break what the user was doing
                System.Diagnostics.Debug.WriteLine("Error Logging: " + ex.Message);
            }
        }
    }
}
