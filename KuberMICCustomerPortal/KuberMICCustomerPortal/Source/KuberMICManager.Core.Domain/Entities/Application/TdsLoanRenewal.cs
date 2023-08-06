using System;
using System.ComponentModel.DataAnnotations;
using static KuberMICManager.Core.Domain.Entities.Application.Common;

namespace KuberMICManager.Core.Domain.Entities.Application
{
    public partial class TdsLoanRenewal
    {
        [Key]
        public int RecId { get; set; }

        [MaxLength(32)]
        public string LoanRecId { get; set; }
        [MaxLength(1024)]
        public string Notes { get; set; }
        [MaxLength(10)]
        public string Account { get; set; }
        public DateTime? MaturityDate { get; set; }

        public MortgageRenewalStatus RenewalStatus { get; set; }
        public MortgageRenewalTerms RenewalTerms { get; set; }
        public MortgageType MortgageType { get; set; }

        public decimal? PrinBal { get; set; }
        public decimal? PrinPaydown { get; set; }
        public decimal? NewPrinBal { get; set; }

        public decimal? PrimeInterestRate { get; set; }

        public decimal? RenewalIR { get; set; }
        public bool? RenewalIRIsVariable { get; set; }

        public decimal? RenewalFee { get; set; }
        public bool? RenewalFeeIsDollar { get; set; }
        public bool AddRenewalFeeToPrinBal { get; set; }

        public decimal? LenderFee { get; set; }
        public bool? LenderFeeIsDollar { get; set; }
        public bool AddLenderFeeToPrinBal { get; set; }

        public decimal? BrokerFee { get; set; }
        public bool? BrokerFeeIsDollar { get; set; }
        public bool AddBrokerFeeToPrinBal { get; set; }

        public decimal? AdminFee { get; set; }
        public bool AddAdminFeeToPrinBal { get; set; }

        public decimal? AppraisalFee { get; set; }
        public bool AddAppraisalFeeToPrinBal { get; set; }

        [MaxLength(1024)]
        public string OtherFees { get; set; }

        public bool IDExpired { get; set; }
        public bool FireInsuranceExpired { get; set; }

        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
