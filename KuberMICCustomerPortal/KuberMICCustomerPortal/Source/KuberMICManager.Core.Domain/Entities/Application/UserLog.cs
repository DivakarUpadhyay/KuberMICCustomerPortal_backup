using System;
using System.ComponentModel.DataAnnotations;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.Entities.Application
{
    public class UserLog
    {
        public int UserLogId     { get; set; }

        [MaxLength(32)]
        public AreaType Area { get; set; }  // Area by function - admintrative, mainfunctions

        [MaxLength(32)]
        public EventType Event { get; set; }  // Group for reporting purpose

        [MaxLength(128)]
        public string UserName { get; set; }  // Who logged in

        [MaxLength(128)]
        public string Email { get; set; }  // Email address of the agency sent via post reqeust

        public DateTimeOffset Timestamp { get; set; }  // When it was generated

        [MaxLength] // max size allowed by the sql-server - nvarchar(max)
        public string Description { get; set; }

        [MaxLength(32)]
        public ResultType? Result { get; set; }  // Where applicable

        /// <summary>
        /// Convert the Timestamp to the default local time zone: Eastern Standard Time 
        /// </summary>
        /// <returns></returns>
        public DateTimeOffset TimestampToLocalTime()
        {
            return TimestampToLocalTime(Common.DefaultReportingTimeZone);
        }

        /// <summary>
        /// Convert the Timestamp to a specified time zone
        /// </summary>
        /// <returns></returns>
        public DateTimeOffset TimestampToLocalTime(TimeZoneInfo timeZoneInfo)
        {
            return TimeZoneInfo.ConvertTime(Timestamp, timeZoneInfo);
        }
    }
}
