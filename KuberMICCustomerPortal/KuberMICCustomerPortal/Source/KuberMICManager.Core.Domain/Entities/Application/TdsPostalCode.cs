using System;
using System.ComponentModel.DataAnnotations;

namespace KuberMICManager.Core.Domain.Entities.Application
{
    public class TdsPostalCode
    {
        [Key]
        public int PostalCodeID { get; set; }

        [MaxLength(10)]
        [Required]
        public string PostalCode { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [MaxLength(100)]
        public string County { get; set; }

        [MaxLength(100)]
        public string MortgageRegion { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
