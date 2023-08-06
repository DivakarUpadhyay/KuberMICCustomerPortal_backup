using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppResource
    {
        public string RecId { get; set; }
        public string Resource { get; set; }
        public string UserName { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
