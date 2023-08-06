using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppJournal
    {
        public string RecId { get; set; }
        public int? Sequence { get; set; }
        public int? EventType { get; set; }
        public string EventText { get; set; }
        public string OwnerRecId { get; set; }
        public string OwnerAcct { get; set; }
        public int? OwnerType { get; set; }
        public string UserId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int? AppSource { get; set; }
        public bool? Critical { get; set; }
        public string ComputerName { get; set; }
    }
}
