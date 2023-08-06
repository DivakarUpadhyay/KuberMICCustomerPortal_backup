using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppAttachmentsTab
    {
        public string RecId { get; set; }
        public int? OwnerType { get; set; }
        public string Name { get; set; }
        public int? Sequence { get; set; }
    }
}
