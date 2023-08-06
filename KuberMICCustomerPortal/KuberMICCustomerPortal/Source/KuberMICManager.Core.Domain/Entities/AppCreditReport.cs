using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppCreditReport
    {
        public string RecId { get; set; }
        public string OwnerRecId { get; set; }
        public int? OwnerType { get; set; }
        public DateTime? DateOrdered { get; set; }
        public string ReportId { get; set; }
        public string Applicant { get; set; }
        public string TransUnion { get; set; }
        public string Experian { get; set; }
        public string Equifax { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
