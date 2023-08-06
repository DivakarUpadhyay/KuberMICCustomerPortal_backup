using System;
using System.ComponentModel.DataAnnotations;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.Entities.Application
{
    public partial class MICPortfolioHistory
    {
        [Key]
        public int RecId { get; set; }
        [MaxLength(256)]
        public string Key { get; set; }
        public decimal? Value { get; set; }
        public MICPortfolioHistoryCategory Category { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
