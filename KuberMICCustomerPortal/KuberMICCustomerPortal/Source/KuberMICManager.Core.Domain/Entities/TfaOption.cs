using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TfaOption
    {
        public string RecId { get; set; }
        public bool? PrintCompanyOnCheck { get; set; }
    }
}
