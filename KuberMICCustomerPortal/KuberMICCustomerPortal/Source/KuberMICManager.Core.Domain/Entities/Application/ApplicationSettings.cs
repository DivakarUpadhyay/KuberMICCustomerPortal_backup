using System.IO;

namespace KuberMICManager.Core.Domain.Entities.Application
{
    public class AppSettings
    {
        public string LogPath { get; set; }
        public int PageSize { get; set; }
        public string BasePath { get; set; }
        public string DocumentTemplatePath { get; set; }
        public string DownloadPath { get; set; }

        // Path of template doc in local directory
        public string GetTemplateDocPath(string templateDocName)
        {
            var templateFolderPath = Path.Combine(BasePath, DocumentTemplatePath);
            return Path.Combine(templateFolderPath, templateDocName);
        }

        //Path of download doc in local directory
        public string GetDownloadDocPath(string destDocName)
        {
            var destFolderPath = Path.Combine(BasePath, DownloadPath);
            return Path.Combine(destFolderPath, destDocName);
        }
    }

    public class AppIdentitySettings
    {
        public UserSettings User { get; set; }
        public PasswordSettings Password { get; set; }
        public LockoutSettings Lockout { get; set; }
    }

    public class UserSettings
    {
        public bool RequireUniqueEmail { get; set; }
    }

    public class PasswordSettings
    {
        public int RequiredLength { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireDigit { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
    }

    public class LockoutSettings
    {
        public bool AllowedForNewUsers { get; set; }
        public int DefaultLockoutTimeSpanInMins { get; set; }
        public int MaxFailedAccessAttempts { get; set; }
    }

    public class EmailSettings
    {
        public string EmailHost { get; set; }
        public int EmailPort { get; set; }
        public string FromEmail { get; set; }
        public string FromPassword { get; set; }
        public string ToEmail { get; set; }
        public string CcEmail { get; set; }
        public string BccEmail { get; set; }
    }
}
