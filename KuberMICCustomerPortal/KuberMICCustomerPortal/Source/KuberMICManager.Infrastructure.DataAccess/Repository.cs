using KuberMICManager.Core.Domain.Entities;
using KuberMICManager.Core.Domain.Interfaces;
using KuberMICManager.Infrastructure.DataAccess.DataContext;
using KuberMICManager.Infrastructure.DataAccess.Framework;
using Microsoft.EntityFrameworkCore;

namespace KuberMICManager.Infrastructure.DataAccess
{
    // Investments
    public class PssPartnerRepository : ReadWriteEFRespository<string, PssPartner>, IPartnerRepository
    {
        public PssPartnerRepository(DbContext context) : base(context) {}
    }

    public class PssTransactionRepository : ReadWriteEFRespository<string, PssTransaction>, ITransactionRepository
    {
        public PssTransactionRepository(DbContext context) : base(context) {}
    }

    public class PssCertificateRepository : ReadWriteEFRespository<string, PssCertificate>, ICertificateRepository
    {
        public PssCertificateRepository(MICDataContext context) : base(context) {}
    }

    public class PssDistributionRepository : ReadWriteEFRespository<string, PssDistribution>, IDistributionRepository
    {
        public PssDistributionRepository(DbContext context) : base(context) {}
    }

    public class PssPartnershipRepository : ReadWriteEFRespository<string, PssPool>, IPoolRepository
    {
        public PssPartnershipRepository(DbContext context) : base(context) {}
    }
    public class PssTrusteeRepository : ReadWriteEFRespository<string, PssTrustee>, ITrusteeRepository
    {
        public PssTrusteeRepository(DbContext context) : base(context) {}
    }

    // Loans
    public class TdsLoanRepository : ReadWriteEFRespository<string, TdsLoan>, ILoanRepository
    {
        public TdsLoanRepository(DbContext context) : base(context) {}
    }
    public class TdsLoanHistoryRepository : ReadWriteEFRespository<string, TdsLoanHistory>, ILoanHistoryRepository
    {
        public TdsLoanHistoryRepository(DbContext context) : base(context) {}
    }
    public class TdsLienRepository : ReadWriteEFRespository<string, TdsLien>, ILienRepository
    {
        public TdsLienRepository(DbContext context) : base(context) {}
    }
    public class TdsChargeRepository : ReadWriteEFRespository<string, TdsCharge>, IChargeRepository
    {
        public TdsChargeRepository(DbContext context) : base(context) {}
    }
    public class TdsChargesDetailRepository : ReadWriteEFRespository<string, TdsChargesDetail>, IChargesDetailRepository
    {
        public TdsChargesDetailRepository(DbContext context) : base(context) {}
    }
    public class TdsCoBorrowerRepository : ReadWriteEFRespository<string, TdsCoBorrower>, ICoBorrowerRepository
    {
        public TdsCoBorrowerRepository(DbContext context) : base(context) {}
    }
    public class TdsFundingRepository : ReadWriteEFRespository<string, TdsFunding>, IFundingRepository
    {
        public TdsFundingRepository(DbContext context) : base(context) {}
    }
    public class TdsLenderRepository : ReadWriteEFRespository<string, TdsLender>, ILenderRepository
    {
        public TdsLenderRepository(DbContext context) : base(context) {}
    }
    public class TdsInsuranceRepository : ReadWriteEFRespository<string, TdsInsurance>, IInsuranceRepository
    {
        public TdsInsuranceRepository(DbContext context) : base(context) {}
    }
    public class TdsPropertyRepository : ReadWriteEFRespository<string, TdsProperty>, IPropertyRepository
    {
        public TdsPropertyRepository(DbContext context) : base(context) {}
    }

    // Shared
    public class AppCompanyRepository : ReadWriteEFRespository<string, AppCompany>, ICompanyRepository
    {
        public AppCompanyRepository(DbContext context) : base(context) {}
    }
    public class AppAttachmentRepository : ReadWriteEFRespository<string, AppAttachment>, IAttachmentRepository
    {
        public AppAttachmentRepository(DbContext context) : base(context) {}
    }
    public class AppNoteRepository : ReadWriteEFRespository<string, AppNote>, INoteRepository
    {
        public AppNoteRepository(DbContext context) : base(context) {}
    }
    public class UdfFieldRepository : ReadWriteEFRespository<string, UdfField>, IUserDefinedFieldRepository
    {
        public UdfFieldRepository(DbContext context) : base(context) {}
    }
    public class UdfTabRepository : ReadWriteEFRespository<string, UdfTab>, IUserDefinedTabRepository
    {
        public UdfTabRepository(DbContext context) : base(context) {}
    }
    public class UdfValueRepository : ReadWriteEFRespository<string, UdfValue>, IUserDefinedValueRepository
    {
        public UdfValueRepository(DbContext context) : base(context) {}
    }

    // Trust Accounts
    public class TfaAccountRepository : ReadWriteEFRespository<string, TfaAccount>, ITAccountRepository
    {
        public TfaAccountRepository(DbContext context) : base(context) {}
    }

    public class TfaTransactionRepository : ReadWriteEFRespository<string, TfaTransaction>, ITATransactionRepository
    {
        public TfaTransactionRepository(DbContext context) : base(context) {}
    }
}