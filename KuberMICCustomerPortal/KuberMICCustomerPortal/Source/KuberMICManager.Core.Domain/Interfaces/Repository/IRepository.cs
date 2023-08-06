using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Interfaces.Framework;

namespace KuberMICManager.Core.Domain.Interfaces
{
    // Investments
    public interface IPartnerRepository : IReadWriteRepository<string, PssPartner> {}
    public interface ITransactionRepository : IReadWriteRepository<string, PssTransaction> {}
    public interface ICertificateRepository : IReadWriteRepository<string, PssCertificate> {}
    public interface IDistributionRepository : IReadWriteRepository<string, PssDistribution> { }
    public interface IPoolRepository : IReadWriteRepository<string, PssPool> { }
    public interface ITrusteeRepository : IReadWriteRepository<string, PssTrustee> { }

    // Loans
    public interface ILoanRepository : IReadWriteRepository<string, TdsLoan> { }
    public interface ILoanHistoryRepository : IReadWriteRepository<string, TdsLoanHistory> { }
    public interface ILienRepository : IReadWriteRepository<string, TdsLien> { }
    public interface IChargeRepository : IReadWriteRepository<string, TdsCharge> { }
    public interface IChargesDetailRepository : IReadWriteRepository<string, TdsChargesDetail> { }
    public interface ICoBorrowerRepository : IReadWriteRepository<string, TdsCoBorrower> { }
    public interface IFundingRepository : IReadWriteRepository<string, TdsFunding> { }
    public interface ILenderRepository : IReadWriteRepository<string, TdsLender> { }
    public interface IInsuranceRepository : IReadWriteRepository<string, TdsInsurance> { }
    public interface IPropertyRepository : IReadWriteRepository<string, TdsProperty> { }

    // Shared
    public interface ICompanyRepository : IReadWriteRepository<string, AppCompany> { }
    public interface IAttachmentRepository : IReadWriteRepository<string, AppAttachment> { }
    public interface INoteRepository : IReadWriteRepository<string, AppNote> { }
    public interface IUserDefinedFieldRepository : IReadWriteRepository<string, UdfField> { }
    public interface IUserDefinedTabRepository : IReadWriteRepository<string, UdfTab> { }
    public interface IUserDefinedValueRepository : IReadWriteRepository<string, UdfValue> { }

    // Trust Accounts
    public interface ITAccountRepository : IReadWriteRepository<string, TfaAccount> { }
    public interface ITATransactionRepository : IReadWriteRepository<string, TfaTransaction> { }
}