using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppSystem
    {
        public string RecId { get; set; }
        public string DatabaseGuid { get; set; }
        public string DatabaseIdsn { get; set; }
        public string DatabaseVersion { get; set; }
        public string DatabaseBlockId { get; set; }
        public DateTime? DatabaseCreated { get; set; }
        public bool? DatabaseCorrupt { get; set; }
        public bool? DatabaseLocked { get; set; }
        public string LosPkgbuild { get; set; }
        public string LosPkgversion { get; set; }
        public int? AchTraceNumber { get; set; }
        public int? AchTransNumber { get; set; }
        public int? AchFileIdModifier { get; set; }
        public int? AchBatchNumber { get; set; }
        public int? CmoTransNumber { get; set; }
        public int? LosLoanNumber { get; set; }
        public int? PssJournal { get; set; }
        public int? PssCertNumber { get; set; }
        public int? PaymentReceipt { get; set; }
    }
}
