using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TdsProperty
    {
        public string RecId { get; set; }
        public string LoanRecId { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public string PropertyType { get; set; }
        public string Occupancy { get; set; }
        public decimal? Ltv { get; set; }
        public decimal? AppraiserFmv { get; set; }
        public DateTime? AppraisalDate { get; set; }
        public string ThomasMap { get; set; }
        public string Apn { get; set; }
        public string Zoning { get; set; }
        public bool? Primary { get; set; }
        public string LegalDescription { get; set; }
        public decimal? PledgedEquity { get; set; }
        public int? Priority { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
