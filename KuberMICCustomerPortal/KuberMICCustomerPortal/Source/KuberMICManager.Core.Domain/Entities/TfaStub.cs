using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class TfaStub
    {
        public string RecId { get; set; }
        public string AccountRecId { get; set; }
        public string TransRecId { get; set; }
        public int? LineNo { get; set; }
        public string Text { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? SysTimeStamp { get; set; }
        public int? SysRecStatus { get; set; }
        public string SysCreatedBy { get; set; }
        public DateTime? SysCreatedDate { get; set; }
    }
}
