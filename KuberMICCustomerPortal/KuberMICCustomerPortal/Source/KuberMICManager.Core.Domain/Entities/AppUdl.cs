using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppUdl
    {
        public string RecId { get; set; }
        public int? Id { get; set; }
        public int? Module { get; set; }
        public string Document { get; set; }
        public string DefaultValue { get; set; }
        public string UserValue { get; set; }
        public string CompanyRecId { get; set; }
    }
}
