using Microsoft.AspNetCore.Identity;

namespace KuberMICManager.Core.Domain.Entities.Identity
{
    /// <summary>
    /// User in the Kuber MIC Manager
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}