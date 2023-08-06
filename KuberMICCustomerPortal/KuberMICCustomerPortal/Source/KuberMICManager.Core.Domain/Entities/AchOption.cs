using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AchOption
    {
        public string RecId { get; set; }
        public bool? CreateBalancedFile { get; set; }
        public bool? UseSchedDateAsTransDate { get; set; }
        public string FileHeaderCr { get; set; }
        public string FileHeaderDr { get; set; }
        public string RemoteConnectionId { get; set; }
        public string FaxTransmittalPhone { get; set; }
    }
}
