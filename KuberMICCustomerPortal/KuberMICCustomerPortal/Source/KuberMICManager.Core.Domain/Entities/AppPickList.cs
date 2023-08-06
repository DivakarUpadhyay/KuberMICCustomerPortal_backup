using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppPickList
    {
        public string RecId { get; set; }
        public int? TableId { get; set; }
        public string Description { get; set; }
        public int? Sequence { get; set; }
        public bool? System { get; set; }
    }
}
