using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppOption
    {
        public string RecId { get; set; }
        public bool? EventsJournalVerbose { get; set; }
        public int? Asiprovider { get; set; }
        public int? Asimethod { get; set; }
        public bool? SmsEnabled { get; set; }
        public bool? GeoMapEnabled { get; set; }
        public string Xml { get; set; }
    }
}
