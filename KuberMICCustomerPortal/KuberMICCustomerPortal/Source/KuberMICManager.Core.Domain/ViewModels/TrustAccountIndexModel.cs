using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Framework;
using System.Collections.Generic;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class TrustAccountIndexModel
    {
        public IEnumerable<TfaAccount> TrustAccounts { get; set; }
        public PaginatedList<TfaTransaction> TrustAccountTransactions { get; set; }
    }
}