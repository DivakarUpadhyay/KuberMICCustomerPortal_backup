using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AchLockBox
    {
        public string RecId { get; set; }
        public int? Crc { get; set; }
        public string FileNamePath { get; set; }
        public DateTime? ImportedDate { get; set; }
        public int? ImportedPmts { get; set; }
        public int? ExcludedPmts { get; set; }
    }
}
