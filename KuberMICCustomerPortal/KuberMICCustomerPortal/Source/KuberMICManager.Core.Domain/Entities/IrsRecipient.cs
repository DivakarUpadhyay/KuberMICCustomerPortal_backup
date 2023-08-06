using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class IrsRecipient
    {
        public string RecId { get; set; }
        public string ParentRecId { get; set; }
        public string PoolRecId { get; set; }
        public int? RecType { get; set; }
        public int? DocType { get; set; }
        public int? TaxYear { get; set; }
        public bool? IsFlag { get; set; }
        public string Account { get; set; }
        public string FullName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Tin { get; set; }
        public int? Tintype { get; set; }
        public decimal? Amount { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
