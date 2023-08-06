using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class IrsHeader
    {
        public string RecId { get; set; }
        public string PoolRecId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string FederalTin { get; set; }
        public string StateTin { get; set; }
        public int? TaxYear { get; set; }
        public int? RecType { get; set; }
        public int? DocType { get; set; }
        public bool? CombinedFederalStateFiler { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
