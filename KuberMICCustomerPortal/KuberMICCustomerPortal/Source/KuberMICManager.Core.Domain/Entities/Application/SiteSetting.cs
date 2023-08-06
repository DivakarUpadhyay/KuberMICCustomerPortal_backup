using System.ComponentModel.DataAnnotations;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.Entities.Application
{
    /// <summary>
    /// Site Settings Variables
    /// </summary>
    public class SiteSetting
    {
        [Key]
        public int SiteSettingID { get; set; }

        /// <summary>
        /// Access the localized text
        /// </summary>
        [MaxLength(256)]
        public string Key { get; set; }

        /// <summary>
        /// For display purpose
        /// </summary>
        public SettingsCategory Category { get; set; }

        /// <summary>
        /// Short description of the text
        /// </summary>
        [MaxLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Values to be used
        /// </summary>
        [MaxLength(1024)]
        public string SettingValue { get; set; }
    }
}
