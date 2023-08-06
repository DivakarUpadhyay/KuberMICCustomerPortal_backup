using System;
using System.Collections.Generic;

#nullable disable

namespace KuberMICManager.Core.Domain.Entities
{
    public partial class PssOption
    {
        public string RecId { get; set; }
        public bool? PrintIrronPartnerStatements { get; set; }
        public bool? PrintCompanyOnCheck { get; set; }
        public bool? ExcSharesFromPartnerStmt { get; set; }
        public bool? AutoPostLoanServicingTransactions { get; set; }
        public bool? RoundShareValue { get; set; }
        public int? RoundShareValueDecimals { get; set; }
        public int? CheckStyle { get; set; }
        public bool? IsPrintedOnCheckSharesOwned { get; set; }
        public bool? IsPrintedOnCheckSharesPrice { get; set; }
        public bool? IsPrintedOnCheckPortfolioValue { get; set; }
        public bool? IsPrintedOnCheckDistributions { get; set; }
        public bool? IsPrintedOnCheckContributions { get; set; }
        public string CheckStubCaptionsText { get; set; }
        public bool? EvalLoanPrincipalBalance { get; set; }
        public bool? EvalLoanUnpaidInterest { get; set; }
        public bool? EvalLoanAccruedInterest { get; set; }
        public bool? EvalLoanUnpaidLateCharges { get; set; }
        public bool? EvalLoanAccruedLateCharges { get; set; }
        public bool? EvalLenderTrustBalance { get; set; }
        public bool? EvalChargesOwedToLender { get; set; }
        public bool? EvalChargesOwedByLender { get; set; }
        public byte[] CompanyLogo { get; set; }
        public bool? UseCompanyLogo { get; set; }
        public bool? ReplaceDistributionDate { get; set; }
        public bool? AccountNumbering { get; set; }
        public string AccountPrefix { get; set; }
        public int? AccountNumber { get; set; }
        public string AccountSuffix { get; set; }
        public int? AccountDigits { get; set; }
        public bool? AccountZeroFill { get; set; }
        public string TradeConfirmationContributionPath { get; set; }
        public string TradeConfirmationWithdrawalPath { get; set; }
    }
}
