using System;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class ValidationModel
    {
        public string RecId { get; set; }
        public string Account { get; set; }
        public string FullName { get; set; }
        public string PoolAccount { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? MaturityDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public ValidationAccountType Type { get; set; }

        public string MissingInfoList { get; set; }
    }
}