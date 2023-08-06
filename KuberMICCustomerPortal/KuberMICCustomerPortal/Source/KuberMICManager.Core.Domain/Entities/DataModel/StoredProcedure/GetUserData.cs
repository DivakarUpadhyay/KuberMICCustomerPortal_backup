using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace KuberMICManager.Core.Domain.Entities.DataModel.StoredProcedure
{
    [Keyless]
    public class GetUserData
    {
        public string Type { get; set; }
        public string Account { get; set; }
        public string LoanAccount { get; set; }
        public string PartnerAccount { get; set; }
        public string EmailAddress { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneCell { get; set; }
        public string IsBothTypeOfUser { get; set; }
    }
}
