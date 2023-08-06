using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class UdfValue
    {
        public string RecId { get; set; }
        public string ParentRecId { get; set; }
        public string OwnerRecId { get; set; }
        public string Value { get; set; }
    }
}
