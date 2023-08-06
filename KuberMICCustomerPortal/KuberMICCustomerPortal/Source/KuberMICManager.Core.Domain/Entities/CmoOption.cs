using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class CmoOption
    {
        public string RecId { get; set; }
        public bool? AutoPostLoanServicingTransactions { get; set; }
        public bool? PrintCompanyOnCheck { get; set; }
        public int? CheckStyle { get; set; }
        public byte[] CompanyLogo { get; set; }
        public bool? UseCompanyLogo { get; set; }
        public bool? AccountNumbering { get; set; }
        public string AccountPrefix { get; set; }
        public int? AccountNumber { get; set; }
        public string AccountSuffix { get; set; }
        public int? AccountDigits { get; set; }
        public bool? AccountZeroFill { get; set; }
    }
}
