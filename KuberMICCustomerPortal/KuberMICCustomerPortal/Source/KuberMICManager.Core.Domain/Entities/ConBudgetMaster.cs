﻿using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class ConBudgetMaster
    {
        public string RecId { get; set; }
        public string GroupId { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
        public bool? IsSoftCost { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
