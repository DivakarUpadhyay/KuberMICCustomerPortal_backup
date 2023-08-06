using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsEscrowProjection
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public DateTime? ComputationPeriodStartingDate { get; set; }
        public decimal? Cushion { get; set; }
        public string Xml { get; set; }
    }
}
