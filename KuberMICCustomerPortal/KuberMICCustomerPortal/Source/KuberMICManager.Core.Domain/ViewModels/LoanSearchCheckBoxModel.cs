using System.Collections.Generic;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class LoanSearchEnumModel
    {
        public LoanSearchGroup LoanSearchGroup { get; set; }
        public bool IsSelected { get; set; }
    }
}
