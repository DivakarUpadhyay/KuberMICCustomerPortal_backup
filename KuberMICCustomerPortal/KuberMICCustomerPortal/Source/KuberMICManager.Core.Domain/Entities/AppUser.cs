using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class AppUser
    {
        public string RecId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public bool? LoggedIn { get; set; }
        public bool? IsGroup { get; set; }
        public bool? IsActive { get; set; }
        public string Xml { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
