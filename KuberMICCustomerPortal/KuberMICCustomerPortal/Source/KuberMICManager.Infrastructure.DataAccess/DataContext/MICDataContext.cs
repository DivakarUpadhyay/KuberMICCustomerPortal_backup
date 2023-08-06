using KuberMICManager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KuberMICManager.Infrastructure.DataAccess.DataContext
{
    public partial class MICDataContext : DbContext
    {
        public MICDataContext() {}
        public MICDataContext(DbContextOptions<MICDataContext> options) : base(options) {}

        public virtual DbSet<AchLockBox> AchLockBoxes { get; set; }
        public virtual DbSet<AchOption> AchOptions { get; set; }
        public virtual DbSet<AchTransmission> AchTransmissions { get; set; }
        public virtual DbSet<AppAttachment> AppAttachments { get; set; }
        public virtual DbSet<AppAttachmentsTab> AppAttachmentsTabs { get; set; }
        public virtual DbSet<AppCategory> AppCategories { get; set; }
        public virtual DbSet<AppCompany> AppCompanies { get; set; }
        public virtual DbSet<AppContact> AppContacts { get; set; }
        public virtual DbSet<AppConversation> AppConversations { get; set; }
        public virtual DbSet<AppCreditReport> AppCreditReports { get; set; }
        public virtual DbSet<AppJournal> AppJournals { get; set; }
        public virtual DbSet<AppLogin> AppLogins { get; set; }
        public virtual DbSet<AppMailingLabel> AppMailingLabels { get; set; }
        public virtual DbSet<AppNote> AppNotes { get; set; }
        public virtual DbSet<AppNotification> AppNotifications { get; set; }
        public virtual DbSet<AppOption> AppOptions { get; set; }
        public virtual DbSet<AppPickList> AppPickLists { get; set; }
        public virtual DbSet<AppReminder> AppReminders { get; set; }
        public virtual DbSet<AppResource> AppResources { get; set; }
        public virtual DbSet<AppSmartView> AppSmartViews { get; set; }
        public virtual DbSet<AppSystem> AppSystems { get; set; }
        public virtual DbSet<AppTaxPayer> AppTaxPayers { get; set; }
        public virtual DbSet<AppUdl> AppUdls { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AsiTransaction> AsiTransactions { get; set; }
        public virtual DbSet<CcrConsumer> CcrConsumers { get; set; }
        public virtual DbSet<CmoBankAccount> CmoBankAccounts { get; set; }
        public virtual DbSet<CmoDistribution> CmoDistributions { get; set; }
        public virtual DbSet<CmoHolder> CmoHolders { get; set; }
        public virtual DbSet<CmoOption> CmoOptions { get; set; }
        public virtual DbSet<CmoOtherAsset> CmoOtherAssets { get; set; }
        public virtual DbSet<CmoPayable> CmoPayables { get; set; }
        public virtual DbSet<CmoPool> CmoPools { get; set; }
        public virtual DbSet<CmoTransaction> CmoTransactions { get; set; }
        public virtual DbSet<ConBudgetLoan> ConBudgetLoans { get; set; }
        public virtual DbSet<ConBudgetMaster> ConBudgetMasters { get; set; }
        public virtual DbSet<ConCommitment> ConCommitments { get; set; }
        public virtual DbSet<ConInspection> ConInspections { get; set; }
        public virtual DbSet<ConVoucher> ConVouchers { get; set; }
        public virtual DbSet<ConVoucherDetail> ConVoucherDetails { get; set; }
        public virtual DbSet<IrsHeader> IrsHeaders { get; set; }
        public virtual DbSet<IrsOption> IrsOptions { get; set; }
        public virtual DbSet<IrsRecipient> IrsRecipients { get; set; }
        public virtual DbSet<LosAddendum> LosAddendums { get; set; }
        public virtual DbSet<LosBorrower> LosBorrowers { get; set; }
        public virtual DbSet<LosDocument> LosDocuments { get; set; }
        public virtual DbSet<LosEncumbrance> LosEncumbrances { get; set; }
        public virtual DbSet<LosField> LosFields { get; set; }
        public virtual DbSet<LosForm> LosForms { get; set; }
        public virtual DbSet<LosFunding> LosFundings { get; set; }
        public virtual DbSet<LosHmdaLoan> LosHmdaLoans { get; set; }
        public virtual DbSet<LosLender> LosLenders { get; set; }
        public virtual DbSet<LosLoan> LosLoans { get; set; }
        public virtual DbSet<LosMcr> LosMcrs { get; set; }
        public virtual DbSet<LosOption> LosOptions { get; set; }
        public virtual DbSet<LosProduct> LosProducts { get; set; }
        public virtual DbSet<LosProperty> LosProperties { get; set; }
        public virtual DbSet<LosTbill> LosTbills { get; set; }
        public virtual DbSet<LosTracking> LosTrackings { get; set; }
        public virtual DbSet<PssBankAccount> PssBankAccounts { get; set; }
        public virtual DbSet<PssCapital> PssCapitals { get; set; }
        public virtual DbSet<PssCertificate> PssCertificates { get; set; }
        public virtual DbSet<PssDistribution> PssDistributions { get; set; }
        public virtual DbSet<PssMasterCertificate> PssMasterCertificates { get; set; }
        public virtual DbSet<PssOption> PssOptions { get; set; }
        public virtual DbSet<PssOtherAsset> PssOtherAssets { get; set; }
        public virtual DbSet<PssPartner> PssPartners { get; set; }
        public virtual DbSet<PssPool> PssPools { get; set; }
        public virtual DbSet<PssPayable> PssPayables { get; set; }
        public virtual DbSet<PssShareValue> PssShareValues { get; set; }
        public virtual DbSet<PssTransaction> PssTransactions { get; set; }
        public virtual DbSet<PssTrustee> PssTrustees { get; set; }
        public virtual DbSet<RptLetter> RptLetters { get; set; }
        public virtual DbSet<RptReport> RptReports { get; set; }
        public virtual DbSet<SmsMessage> SmsMessages { get; set; }
        public virtual DbSet<TdsArmindex> TdsArmindices { get; set; }
        public virtual DbSet<TdsArmrate> TdsArmrates { get; set; }
        public virtual DbSet<TdsCharge> TdsCharges { get; set; }
        public virtual DbSet<TdsChargesDetail> TdsChargesDetails { get; set; }
        public virtual DbSet<TdsCoBorrower> TdsCoBorrowers { get; set; }
        public virtual DbSet<TdsDraw> TdsDraws { get; set; }
        public virtual DbSet<TdsEscrowProjection> TdsEscrowProjections { get; set; }
        public virtual DbSet<TdsFunding> TdsFundings { get; set; }
        public virtual DbSet<TdsFundingDisb> TdsFundingDisbs { get; set; }
        public virtual DbSet<TdsIdd> TdsIdds { get; set; }
        public virtual DbSet<TdsInsurance> TdsInsurances { get; set; }
        public virtual DbSet<TdsLender> TdsLenders { get; set; }
        public virtual DbSet<TdsLenderHistory> TdsLenderHistories { get; set; }
        public virtual DbSet<TdsLien> TdsLiens { get; set; }
        public virtual DbSet<TdsLoan> TdsLoans { get; set; }
        public virtual DbSet<TdsLoanHistory> TdsLoanHistories { get; set; }
        public virtual DbSet<TdsLocbilling> TdsLocbillings { get; set; }
        public virtual DbSet<TdsModification> TdsModifications { get; set; }
        public virtual DbSet<TdsOption> TdsOptions { get; set; }
        public virtual DbSet<TdsProperty> TdsProperties { get; set; }
        public virtual DbSet<TdsVoucher> TdsVouchers { get; set; }
        public virtual DbSet<TdsWrap> TdsWraps { get; set; }
        public virtual DbSet<TfaAccount> TfaAccounts { get; set; }
        public virtual DbSet<TfaClient> TfaClients { get; set; }
        public virtual DbSet<TfaOption> TfaOptions { get; set; }
        public virtual DbSet<TfaPayee> TfaPayees { get; set; }
        public virtual DbSet<TfaPayer> TfaPayers { get; set; }
        public virtual DbSet<TfaRecon> TfaRecons { get; set; }
        public virtual DbSet<TfaSplit> TfaSplits { get; set; }
        public virtual DbSet<TfaStub> TfaStubs { get; set; }
        public virtual DbSet<TfaTransaction> TfaTransactions { get; set; }
        public virtual DbSet<UdfField> UdfFields { get; set; }
        public virtual DbSet<UdfTab> UdfTabs { get; set; }
        public virtual DbSet<UdfValue> UdfValues { get; set; }
        public virtual DbSet<WpcFaq> WpcFaqs { get; set; }
        public virtual DbSet<WpcLoanApplication> WpcLoanApplications { get; set; }
        public virtual DbSet<WpcLoanApplicationDefaultDocument> WpcLoanApplicationDefaultDocuments { get; set; }
        public virtual DbSet<WpcLoanApplicationDocument> WpcLoanApplicationDocuments { get; set; }
        public virtual DbSet<WpcLoanApplicationWorkflow> WpcLoanApplicationWorkflows { get; set; }
        public virtual DbSet<WpcMessage> WpcMessages { get; set; }
        public virtual DbSet<WpcNewsEvent> WpcNewsEvents { get; set; }
        public virtual DbSet<WpcOffering> WpcOfferings { get; set; }
        public virtual DbSet<WpcOnlinePayment> WpcOnlinePayments { get; set; }
        public virtual DbSet<WpcProduct> WpcProducts { get; set; }
        public virtual DbSet<WpcResource> WpcResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tablel Model Mapping
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AchLockBox>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_ACH_LockBox_RecID");

                entity.ToTable("ACH LockBox");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Crc).HasColumnName("CRC");

                entity.Property(e => e.FileNamePath).HasMaxLength(255);

                entity.Property(e => e.ImportedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AchOption>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_ACH_Options_RecID");

                entity.ToTable("ACH Options");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.CreateBalancedFile).HasDefaultValueSql("((0))");

                entity.Property(e => e.FaxTransmittalPhone).HasMaxLength(20);

                entity.Property(e => e.FileHeaderCr).HasColumnName("FileHeaderCR");

                entity.Property(e => e.FileHeaderDr).HasColumnName("FileHeaderDR");

                entity.Property(e => e.RemoteConnectionId).HasMaxLength(32);

                entity.Property(e => e.UseSchedDateAsTransDate).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AchTransmission>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_ACH_Transmissions_RecID");

                entity.ToTable("ACH Transmissions");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.CreationDateTime).HasColumnType("datetime");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TotalCredits).HasColumnType("money");

                entity.Property(e => e.TotalDebits).HasColumnType("money");

                entity.Property(e => e.TransNumber).HasMaxLength(8);

                entity.Property(e => e.TransmissionDate).HasColumnType("datetime");

                entity.Property(e => e.TrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrustAccountRecID");
            });

            modelBuilder.Entity<AppAttachment>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Attachments_RecID");

                entity.ToTable("APP Attachments");

                entity.HasIndex(e => e.OwnerRecId, "IX_APP_Attachments_OwnerRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.OwnerRecId)
                    .HasMaxLength(32)
                    .HasColumnName("OwnerRecID");

                entity.Property(e => e.Publish).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReadOnly).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TabRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TabRecID");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<AppAttachmentsTab>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Attachments_Tabs_RecID");

                entity.ToTable("APP Attachments Tabs");

                entity.HasIndex(e => new { e.Name, e.OwnerType }, "IX_APP_Attachments_Tabs_Name_OwnerType")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<AppCategory>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Categories_RecID");

                entity.ToTable("APP Categories");

                entity.HasIndex(e => e.Description, "IX_APP_Categories_Description")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Description).HasMaxLength(30);
            });

            modelBuilder.Entity<AppCompany>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Company_RecID");

                entity.ToTable("APP Company");

                entity.HasIndex(e => e.Name, "IX_APP_Company_Name")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AttachmentsPath)
                    .HasMaxLength(255)
                    .HasColumnName("Attachments_Path");

                entity.Property(e => e.BrokerLicense).HasMaxLength(20);

                entity.Property(e => e.BrokerName).HasMaxLength(65);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Dotpath)
                    .HasMaxLength(255)
                    .HasColumnName("DOTPath");

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.EmailAlwaysSendBcc)
                    .HasColumnName("Email_AlwaysSendBcc")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmailBccAddress)
                    .HasMaxLength(255)
                    .HasColumnName("Email_BccAddress");

                entity.Property(e => e.EmailDisplayName)
                    .HasMaxLength(50)
                    .HasColumnName("Email_DisplayName");

                entity.Property(e => e.EmailFromAddress)
                    .HasMaxLength(255)
                    .HasColumnName("Email_FromAddress");

                entity.Property(e => e.EmailPop3HostName)
                    .HasMaxLength(255)
                    .HasColumnName("Email_POP3_HostName");

                entity.Property(e => e.EmailPop3Password)
                    .HasMaxLength(50)
                    .HasColumnName("Email_POP3_Password");

                entity.Property(e => e.EmailPop3PortNumber).HasColumnName("Email_POP3_PortNumber");

                entity.Property(e => e.EmailPop3UserName)
                    .HasMaxLength(50)
                    .HasColumnName("Email_POP3_UserName");

                entity.Property(e => e.EmailReplyAddress)
                    .HasMaxLength(255)
                    .HasColumnName("Email_ReplyAddress");

                entity.Property(e => e.EmailSmtpHostName)
                    .HasMaxLength(255)
                    .HasColumnName("Email_SMTP_HostName");

                entity.Property(e => e.EmailSmtpPassword)
                    .HasMaxLength(50)
                    .HasColumnName("Email_SMTP_Password");

                entity.Property(e => e.EmailSmtpPortNumber).HasColumnName("Email_SMTP_PortNumber");

                entity.Property(e => e.EmailSmtpRequiresAuthentication)
                    .HasColumnName("Email_SMTP_RequiresAuthentication")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmailSmtpSecureProtocol).HasColumnName("Email_SMTP_SecureProtocol");

                entity.Property(e => e.EmailSmtpUserName)
                    .HasMaxLength(50)
                    .HasColumnName("Email_SMTP_UserName");

                entity.Property(e => e.EmailUseSignature)
                    .HasColumnName("Email_UseSignature")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.FederalTin)
                    .HasMaxLength(20)
                    .HasColumnName("FederalTIN");

                entity.Property(e => e.LicenseType).HasMaxLength(1);

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.StateTin)
                    .HasMaxLength(20)
                    .HasColumnName("StateTIN");

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(255)
                    .HasColumnName("WebsiteURL");

                entity.Property(e => e.WpcAboutUs).HasColumnName("WPC_AboutUs");

                entity.Property(e => e.WpcBatchSize).HasColumnName("WPC_BatchSize");

                entity.Property(e => e.WpcBorrowerAnnouncement).HasColumnName("WPC_BorrowerAnnouncement");

                entity.Property(e => e.WpcContactEmail)
                    .HasMaxLength(255)
                    .HasColumnName("WPC_ContactEmail");

                entity.Property(e => e.WpcContactFax)
                    .HasMaxLength(20)
                    .HasColumnName("WPC_ContactFax");

                entity.Property(e => e.WpcContactNameAddress)
                    .HasMaxLength(255)
                    .HasColumnName("WPC_ContactNameAddress");

                entity.Property(e => e.WpcContactPhone)
                    .HasMaxLength(20)
                    .HasColumnName("WPC_ContactPhone");

                entity.Property(e => e.WpcHolderAnnouncement).HasColumnName("WPC_HolderAnnouncement");

                entity.Property(e => e.WpcLastPublished)
                    .HasColumnType("datetime")
                    .HasColumnName("WPC_LastPublished");

                entity.Property(e => e.WpcLenderAnnouncement).HasColumnName("WPC_LenderAnnouncement");

                entity.Property(e => e.WpcPartnerAnnouncement).HasColumnName("WPC_PartnerAnnouncement");

                entity.Property(e => e.WpcPublishId)
                    .HasMaxLength(10)
                    .HasColumnName("WPC_PublishId");

                entity.Property(e => e.WpcPublishLenderTrustFundBalance)
                    .HasColumnName("WPC_PublishLenderTrustFundBalance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WpcPublishLog).HasColumnName("WPC_PublishLog");

                entity.Property(e => e.WpcPublishName)
                    .HasMaxLength(64)
                    .HasColumnName("WPC_PublishName");

                entity.Property(e => e.WpcPublishOutstandingLenderChecks)
                    .HasColumnName("WPC_PublishOutstandingLenderChecks")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WpcRemoteServerUrl)
                    .HasMaxLength(255)
                    .HasColumnName("WPC_RemoteServerURL");

                entity.Property(e => e.WpcTimeOut).HasColumnName("WPC_TimeOut");

                entity.Property(e => e.Xml).HasColumnName("XML");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .HasColumnName("Zip Code");
            });

            modelBuilder.Entity<AppContact>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Contacts_RecID");

                entity.ToTable("APP Contacts");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Category).HasMaxLength(30);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.LicenseNumber).HasMaxLength(30);

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(255)
                    .HasColumnName("WebsiteURL");

                entity.Property(e => e.Xml).HasColumnName("XML");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<AppConversation>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Conversations_RecID");

                entity.ToTable("APP Conversations");

                entity.HasIndex(e => e.CallDate, "IX_APP_Conversations_CallDate");

                entity.HasIndex(e => e.FollowUpDate, "IX_APP_Conversations_FollowUpDate");

                entity.HasIndex(e => e.FollowUpName, "IX_APP_Conversations_FollowUpName");

                entity.HasIndex(e => e.ParentRecId, "IX_APP_Conversations_ParentRecID");

                entity.HasIndex(e => e.ParentType, "IX_APP_Conversations_ParentType");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.CallDate).HasColumnType("datetime");

                entity.Property(e => e.CallPerson).HasMaxLength(50);

                entity.Property(e => e.ChangedLast).HasColumnType("datetime");

                entity.Property(e => e.ChangedName).HasMaxLength(255);

                entity.Property(e => e.Completed).HasDefaultValueSql("((0))");

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.CompletedName).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedName).HasMaxLength(255);

                entity.Property(e => e.FollowUp).HasDefaultValueSql("((0))");

                entity.Property(e => e.FollowUpDate).HasColumnType("datetime");

                entity.Property(e => e.FollowUpName).HasMaxLength(20);

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.Publish).HasDefaultValueSql("((0))");

                entity.Property(e => e.Subject).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppCreditReport>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Credit_Reports_RecID");

                entity.ToTable("APP Credit Reports");

                entity.HasIndex(e => e.OwnerRecId, "IX_APP_Credit_Reports_OwnerRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Applicant).HasMaxLength(255);

                entity.Property(e => e.DateOrdered).HasColumnType("datetime");

                entity.Property(e => e.Equifax).HasMaxLength(32);

                entity.Property(e => e.Experian).HasMaxLength(32);

                entity.Property(e => e.OwnerRecId)
                    .HasMaxLength(32)
                    .HasColumnName("OwnerRecID");

                entity.Property(e => e.ReportId).HasMaxLength(32);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TransUnion).HasMaxLength(32);

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<AppJournal>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Journal_RecID");

                entity.ToTable("APP Journal");

                entity.HasIndex(e => e.AppSource, "IX_APP_Journal_AppSource");

                entity.HasIndex(e => e.EventType, "IX_APP_Journal_EventType");

                entity.HasIndex(e => e.OwnerAcct, "IX_APP_Journal_OwnerAcct");

                entity.HasIndex(e => e.OwnerRecId, "IX_APP_Journal_OwnerRecID");

                entity.HasIndex(e => e.OwnerType, "IX_APP_Journal_OwnerType");

                entity.HasIndex(e => e.Sequence, "IX_APP_Journal_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.ComputerName).HasMaxLength(255);

                entity.Property(e => e.Critical).HasDefaultValueSql("((0))");

                entity.Property(e => e.EventText).HasMaxLength(255);

                entity.Property(e => e.OwnerAcct).HasMaxLength(10);

                entity.Property(e => e.OwnerRecId)
                    .HasMaxLength(32)
                    .HasColumnName("OwnerRecID");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<AppLogin>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Logins_RecID");

                entity.ToTable("APP Logins");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AppserialNumber)
                    .HasMaxLength(15)
                    .HasColumnName("APPSerialNumber");

                entity.Property(e => e.AppversionNumber)
                    .HasMaxLength(15)
                    .HasColumnName("APPVersionNumber");

                entity.Property(e => e.ClientComputerName).HasMaxLength(50);

                entity.Property(e => e.ClientDomainName).HasMaxLength(50);

                entity.Property(e => e.ClientIpaddress)
                    .HasMaxLength(15)
                    .HasColumnName("ClientIPAddress");

                entity.Property(e => e.CpuId).HasMaxLength(50);

                entity.Property(e => e.HostcomputerName)
                    .HasMaxLength(50)
                    .HasColumnName("HOSTComputerName");

                entity.Property(e => e.HostdomainName)
                    .HasMaxLength(50)
                    .HasColumnName("HOSTDomainName");

                entity.Property(e => e.HostphysicalAddress)
                    .HasMaxLength(50)
                    .HasColumnName("HOSTPhysicalAddress");

                entity.Property(e => e.HostprivateIpaddress)
                    .HasMaxLength(15)
                    .HasColumnName("HOSTPrivateIPAddress");

                entity.Property(e => e.HostpublicIpaddress)
                    .HasMaxLength(15)
                    .HasColumnName("HOSTPublicIPAddress");

                entity.Property(e => e.Login).HasColumnType("datetime");

                entity.Property(e => e.Logout).HasColumnType("datetime");

                entity.Property(e => e.OsId).HasMaxLength(50);

                entity.Property(e => e.RemoteSession).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TmologinName)
                    .HasMaxLength(50)
                    .HasColumnName("TMOLoginName");

                entity.Property(e => e.VideoControllerId).HasMaxLength(50);

                entity.Property(e => e.WinloginName)
                    .HasMaxLength(50)
                    .HasColumnName("WINLoginName");

                entity.Property(e => e.WtsloginName)
                    .HasMaxLength(50)
                    .HasColumnName("WTSLoginName");

                entity.Property(e => e.WtssessionName)
                    .HasMaxLength(50)
                    .HasColumnName("WTSSessionName");
            });

            modelBuilder.Entity<AppMailingLabel>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Mailing_Labels_RecID");

                entity.ToTable("APP Mailing Labels");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.FontBold).HasDefaultValueSql("((0))");

                entity.Property(e => e.FontItalic).HasDefaultValueSql("((0))");

                entity.Property(e => e.FontName).HasMaxLength(255);

                entity.Property(e => e.FontSize).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.GapHorizontal).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.GapVertical).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Height).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.LeftMargin).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Name).HasMaxLength(60);

                entity.Property(e => e.RightMargin).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TextLeftMargin).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.TextTopMargin).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.TopMargin).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.UpperCase).HasDefaultValueSql("((0))");

                entity.Property(e => e.Width).HasColumnType("decimal(18, 8)");
            });

            modelBuilder.Entity<AppNote>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Notes_RecID");

                entity.ToTable("APP Notes");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");
            });

            modelBuilder.Entity<AppNotification>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Notifications_RecID");

                entity.ToTable("APP Notifications");

                entity.HasIndex(e => e.UserRecId, "IX_APP_Notifications_UserRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Email).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sms)
                    .HasColumnName("SMS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserRecId)
                    .HasMaxLength(32)
                    .HasColumnName("UserRecID");
            });

            modelBuilder.Entity<AppOption>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Options_RecID");

                entity.ToTable("APP Options");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Asimethod).HasColumnName("ASIMethod");

                entity.Property(e => e.Asiprovider).HasColumnName("ASIProvider");

                entity.Property(e => e.EventsJournalVerbose).HasDefaultValueSql("((0))");

                entity.Property(e => e.GeoMapEnabled)
                    .HasColumnName("GeoMap_Enabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SmsEnabled)
                    .HasColumnName("SMS_Enabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<AppPickList>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_PickList_RecID");

                entity.ToTable("APP PickList");

                entity.HasIndex(e => new { e.TableId, e.Description }, "IX_APP_PickList_TableID_Description")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.System).HasDefaultValueSql("((0))");

                entity.Property(e => e.TableId).HasColumnName("TableID");
            });

            modelBuilder.Entity<AppReminder>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Reminders_RecID");

                entity.ToTable("APP Reminders");

                entity.HasIndex(e => e.Notify, "IX_APP_Reminders_Notify");

                entity.HasIndex(e => e.OwnerType, "IX_APP_Reminders_OwnerType");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Completed).HasDefaultValueSql("((0))");

                entity.Property(e => e.DateDue).HasColumnType("datetime");

                entity.Property(e => e.GroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupRecID");

                entity.Property(e => e.LinkTo).HasMaxLength(10);

                entity.Property(e => e.Notify).HasMaxLength(20);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TimeDue).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppResource>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Resources_RecID");

                entity.ToTable("APP Resources");

                entity.HasIndex(e => e.Resource, "IX_APP_Resources_Resource")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Resource).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            modelBuilder.Entity<AppSmartView>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_SmartViews_RecID");

                entity.ToTable("APP SmartViews");

                entity.HasIndex(e => e.GroupId, "IX_APP_SmartViews_GroupID");

                entity.HasIndex(e => e.Sequence, "IX_APP_SmartViews_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.DisplayName).HasMaxLength(255);

                entity.Property(e => e.GroupId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupID");

                entity.Property(e => e.Sqlqry).HasColumnName("SQLQry");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<AppSystem>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_System_RecID");

                entity.ToTable("APP System");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AchBatchNumber).HasColumnName("ACH_BatchNumber");

                entity.Property(e => e.AchFileIdModifier).HasColumnName("ACH_FileIdModifier");

                entity.Property(e => e.AchTraceNumber).HasColumnName("ACH_TraceNumber");

                entity.Property(e => e.AchTransNumber).HasColumnName("ACH_TransNumber");

                entity.Property(e => e.CmoTransNumber).HasColumnName("CMO_TransNumber");

                entity.Property(e => e.DatabaseCorrupt).HasDefaultValueSql("((0))");

                entity.Property(e => e.DatabaseCreated).HasColumnType("datetime");

                entity.Property(e => e.DatabaseGuid)
                    .HasMaxLength(32)
                    .HasColumnName("DatabaseGUID");

                entity.Property(e => e.DatabaseIdsn)
                    .HasMaxLength(255)
                    .HasColumnName("DatabaseIDSN");

                entity.Property(e => e.DatabaseLocked).HasDefaultValueSql("((0))");

                entity.Property(e => e.DatabaseVersion).HasMaxLength(15);

                entity.Property(e => e.LosLoanNumber).HasColumnName("LOS_LoanNumber");

                entity.Property(e => e.LosPkgbuild)
                    .HasMaxLength(4)
                    .HasColumnName("LOS_PKGBuild");

                entity.Property(e => e.LosPkgversion)
                    .HasMaxLength(4)
                    .HasColumnName("LOS_PKGVersion");

                entity.Property(e => e.PssCertNumber).HasColumnName("PSS_CertNumber");

                entity.Property(e => e.PssJournal).HasColumnName("PSS_Journal");
            });

            modelBuilder.Entity<AppTaxPayer>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_TaxPayer_RecID");

                entity.ToTable("APP TaxPayer");

                entity.HasIndex(e => e.ParentRecId, "IX_APP_TaxPayer_ParentRecID")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tintype).HasColumnName("TINType");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<AppUdl>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_UDL_RecID");

                entity.ToTable("APP UDL");

                entity.HasIndex(e => new { e.Id, e.CompanyRecId }, "IX_APP_UDL_Id_CompanyRecID")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.CompanyRecId)
                    .HasMaxLength(32)
                    .HasColumnName("CompanyRecID");

                entity.Property(e => e.DefaultValue).HasMaxLength(255);

                entity.Property(e => e.Document).HasMaxLength(255);

                entity.Property(e => e.UserValue).HasMaxLength(255);
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_APP_Users_RecID");

                entity.ToTable("APP Users");

                entity.HasIndex(e => e.UserId, "IX_APP_Users_UserId")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.FullName).HasMaxLength(65);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsGroup).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoggedIn).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<AsiTransaction>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_ASI_Transactions_RecID");

                entity.ToTable("ASI Transactions");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Charges).HasColumnType("money");

                entity.Property(e => e.DateDue).HasColumnType("datetime");

                entity.Property(e => e.DateRec).HasColumnType("datetime");

                entity.Property(e => e.ExportDate).HasColumnType("datetime");

                entity.Property(e => e.ExportGrp).HasMaxLength(32);

                entity.Property(e => e.Gst)
                    .HasColumnType("money")
                    .HasColumnName("GST");

                entity.Property(e => e.Impound).HasColumnType("money");

                entity.Property(e => e.Interest).HasColumnType("money");

                entity.Property(e => e.LateCharge).HasColumnType("money");

                entity.Property(e => e.LateChargeAdd).HasColumnType("money");

                entity.Property(e => e.LenderPayable).HasColumnType("money");

                entity.Property(e => e.OrigRecId)
                    .HasMaxLength(32)
                    .HasColumnName("OrigRecID");

                entity.Property(e => e.Other).HasColumnType("money");

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.Prepay).HasColumnType("money");

                entity.Property(e => e.Principal).HasColumnType("money");

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.Reserve).HasColumnType("money");

                entity.Property(e => e.ServFee).HasColumnType("money");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TransDate).HasColumnType("datetime");

                entity.Property(e => e.TransMemo).HasMaxLength(255);

                entity.Property(e => e.UnearnedDisc).HasColumnType("money");

                entity.Property(e => e.UnpaidInt).HasColumnType("money");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<CcrConsumer>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CCR_Consumer_RecID");

                entity.ToTable("CCR Consumer");

                entity.HasIndex(e => e.ParentRecId, "IX_CCR_Consumer_ParentRecID")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountStatus).HasMaxLength(2);

                entity.Property(e => e.AccountType).HasMaxLength(2);

                entity.Property(e => e.Address1).HasMaxLength(32);

                entity.Property(e => e.Address2).HasMaxLength(32);

                entity.Property(e => e.AddressIndicator).HasMaxLength(1);

                entity.Property(e => e.AutoSynch).HasDefaultValueSql("((0))");

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.ComplianceCode).HasMaxLength(2);

                entity.Property(e => e.ConsumerIndicator).HasMaxLength(2);

                entity.Property(e => e.CountryCode).HasMaxLength(2);

                entity.Property(e => e.CycleIdentifier).HasMaxLength(2);

                entity.Property(e => e.DateClose).HasColumnType("datetime");

                entity.Property(e => e.DateFirstDelinquency).HasColumnType("datetime");

                entity.Property(e => e.DateLastReportRun).HasColumnType("datetime");

                entity.Property(e => e.DateLastReported).HasColumnType("datetime");

                entity.Property(e => e.DateOpen).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Ecoa)
                    .HasMaxLength(1)
                    .HasColumnName("ECOA");

                entity.Property(e => e.EmployerAddr1).HasMaxLength(32);

                entity.Property(e => e.EmployerAddr2).HasMaxLength(32);

                entity.Property(e => e.EmployerCity).HasMaxLength(20);

                entity.Property(e => e.EmployerName).HasMaxLength(30);

                entity.Property(e => e.EmployerOccupation).HasMaxLength(18);

                entity.Property(e => e.EmployerState).HasMaxLength(2);

                entity.Property(e => e.EmployerZipCode).HasMaxLength(10);

                entity.Property(e => e.EmploymentReport).HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.GenerationCode).HasMaxLength(1);

                entity.Property(e => e.L1AccountDateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("L1_AccountDateChanged");

                entity.Property(e => e.L1OldAccount)
                    .HasMaxLength(30)
                    .HasColumnName("L1_OldAccount");

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.MiddleName).HasMaxLength(20);

                entity.Property(e => e.OrigCreditor).HasMaxLength(30);

                entity.Property(e => e.OrigCreditorClassification).HasMaxLength(2);

                entity.Property(e => e.OriginalChargeOffAmount).HasColumnType("money");

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.PaymentProfile).HasMaxLength(24);

                entity.Property(e => e.PaymentRating).HasMaxLength(1);

                entity.Property(e => e.Phone).HasMaxLength(14);

                entity.Property(e => e.PortfolioType).HasMaxLength(1);

                entity.Property(e => e.Primary).HasDefaultValueSql("((0))");

                entity.Property(e => e.Report).HasDefaultValueSql("((0))");

                entity.Property(e => e.ResidenceCode).HasMaxLength(1);

                entity.Property(e => e.SpecialComment).HasMaxLength(2);

                entity.Property(e => e.Ssn)
                    .HasMaxLength(20)
                    .HasColumnName("SSN");

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TransactionType).HasMaxLength(1);

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<CmoBankAccount>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CMO_BankAccounts_RecID");

                entity.ToTable("CMO BankAccounts");

                entity.HasIndex(e => e.PoolRecId, "IX_CMO_BankAccounts_PoolRecID");

                entity.HasIndex(e => new { e.PoolRecId, e.TrustAccountRecId }, "IX_CMO_BankAccounts_PoolRecID_TrustAccountRecID")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.IsPrimary).HasDefaultValueSql("((0))");

                entity.Property(e => e.PoolRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PoolRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrustAccountRecID");
            });

            modelBuilder.Entity<CmoDistribution>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CMO_Distributions_RecID");

                entity.ToTable("CMO Distributions");

                entity.HasIndex(e => e.PoolRecId, "IX_CMO_Distributions_PoolRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Interest).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Other).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PayAmount).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Penalty).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PeriodEnd).HasColumnType("datetime");

                entity.Property(e => e.PoolRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PoolRecID");

                entity.Property(e => e.Principal).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Rollover).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrustAccountRecID");
            });

            modelBuilder.Entity<CmoHolder>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CMO_Holders_RecID");

                entity.ToTable("CMO Holders");

                entity.HasIndex(e => e.Account, "IX_CMO_Holders_Account")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.AchAccountNumber)
                    .HasMaxLength(17)
                    .HasColumnName("ACH_AccountNumber");

                entity.Property(e => e.AchAccountType).HasColumnName("ACH_AccountType");

                entity.Property(e => e.AchAddendaRecord)
                    .HasMaxLength(80)
                    .HasColumnName("ACH_AddendaRecord");

                entity.Property(e => e.AchBankAddress)
                    .HasMaxLength(255)
                    .HasColumnName("ACH_BankAddress");

                entity.Property(e => e.AchBankName)
                    .HasMaxLength(50)
                    .HasColumnName("ACH_BankName");

                entity.Property(e => e.AchIndividualId)
                    .HasMaxLength(15)
                    .HasColumnName("ACH_IndividualId");

                entity.Property(e => e.AchIndividualName)
                    .HasMaxLength(22)
                    .HasColumnName("ACH_IndividualName");

                entity.Property(e => e.AchRoutingNumber)
                    .HasMaxLength(9)
                    .HasColumnName("ACH_RoutingNumber");

                entity.Property(e => e.AchSeccode).HasColumnName("ACH_SECCode");

                entity.Property(e => e.AchSendDepositNotificationFlag).HasColumnName("ACH_SendDepositNotificationFlag");

                entity.Property(e => e.AchServiceStatus).HasColumnName("ACH_ServiceStatus");

                entity.Property(e => e.AchUseAddendaRecord)
                    .HasColumnName("ACH_UseAddendaRecord")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.Erisa)
                    .HasColumnName("ERISA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.Payee).HasMaxLength(255);

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(255);

                entity.Property(e => e.Send1099).HasDefaultValueSql("((0))");

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.Tintype).HasColumnName("TINType");

                entity.Property(e => e.UsePayee).HasDefaultValueSql("((0))");

                entity.Property(e => e.WpcPin)
                    .HasMaxLength(10)
                    .HasColumnName("WPC_PIN");

                entity.Property(e => e.WpcPublish)
                    .HasColumnName("WPC_Publish")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<CmoOption>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CMO_Options_RecID");

                entity.ToTable("CMO Options");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountDigits).HasColumnName("Account_Digits");

                entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");

                entity.Property(e => e.AccountNumbering)
                    .HasColumnName("Account_Numbering")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccountPrefix)
                    .HasMaxLength(1)
                    .HasColumnName("Account_Prefix");

                entity.Property(e => e.AccountSuffix)
                    .HasMaxLength(1)
                    .HasColumnName("Account_Suffix");

                entity.Property(e => e.AccountZeroFill)
                    .HasColumnName("Account_ZeroFill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPostLoanServicingTransactions).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintCompanyOnCheck).HasDefaultValueSql("((0))");

                entity.Property(e => e.UseCompanyLogo).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CmoOtherAsset>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CMO_OtherAssets_RecID");

                entity.ToTable("CMO OtherAssets");

                entity.HasIndex(e => e.PoolRecId, "IX_CMO_OtherAssets_PoolRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AppreciationRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.AssetValue).HasColumnType("money");

                entity.Property(e => e.DateLastEvaluated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(64);

                entity.Property(e => e.PoolRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PoolRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<CmoPayable>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CMO_Payables_RecID");

                entity.ToTable("CMO Payables");

                entity.HasIndex(e => e.Account, "IX_CMO_Payables_Account")
                    .IsUnique();

                entity.HasIndex(e => e.PoolRecId, "IX_CMO_Payables_PoolRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(64);

                entity.Property(e => e.IntRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentAmount).HasColumnType("money");

                entity.Property(e => e.PaymentNextDue).HasColumnType("datetime");

                entity.Property(e => e.PoolRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PoolRecID");

                entity.Property(e => e.PrinBalance).HasColumnType("money");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<CmoPool>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CMO_Pools_RecID");

                entity.ToTable("CMO Pools");

                entity.HasIndex(e => e.Account, "IX_CMO_Pools_Account")
                    .IsUnique();

                entity.HasIndex(e => e.LenderRecId, "IX_CMO_Pools_LenderRecID")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.CertDigits).HasColumnName("Cert_Digits");

                entity.Property(e => e.CertNumber).HasColumnName("Cert_Number");

                entity.Property(e => e.CertPrefix)
                    .HasMaxLength(1)
                    .HasColumnName("Cert_Prefix");

                entity.Property(e => e.CertPrepayFee)
                    .HasColumnType("money")
                    .HasColumnName("Cert_PrepayFee");

                entity.Property(e => e.CertPrepayMin)
                    .HasColumnType("money")
                    .HasColumnName("Cert_PrepayMin");

                entity.Property(e => e.CertPrepayMon).HasColumnName("Cert_PrepayMon");

                entity.Property(e => e.CertPrepayPct)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Cert_PrepayPct");

                entity.Property(e => e.CertPrepayUse)
                    .HasColumnName("Cert_PrepayUse")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CertSuffix)
                    .HasMaxLength(1)
                    .HasColumnName("Cert_Suffix");

                entity.Property(e => e.CertTemplate)
                    .HasMaxLength(255)
                    .HasColumnName("Cert_Template");

                entity.Property(e => e.CertZeroFill)
                    .HasColumnName("Cert_ZeroFill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ContributionLimit).HasColumnType("money");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ErisaMaxPct)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("ERISA_MaxPct");

                entity.Property(e => e.InceptionDate).HasColumnType("datetime");

                entity.Property(e => e.LenderRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LenderRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");
            });

            modelBuilder.Entity<CmoTransaction>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CMO_Transactions_RecID");

                entity.ToTable("CMO Transactions");

                entity.HasIndex(e => e.CertificateRecId, "IX_CMO_Transactions_CertificateRecID");

                entity.HasIndex(e => e.HolderRecId, "IX_CMO_Transactions_HolderRecID");

                entity.HasIndex(e => e.PoolRecId, "IX_CMO_Transactions_PoolRecID");

                entity.HasIndex(e => e.Sequence, "IX_CMO_Transactions_Sequence");

                entity.HasIndex(e => e.TransDate, "IX_CMO_Transactions_TransDate");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AchBatchNumber)
                    .HasMaxLength(7)
                    .HasColumnName("ACH_BatchNumber");

                entity.Property(e => e.AchTraceNumber)
                    .HasMaxLength(22)
                    .HasColumnName("ACH_TraceNumber");

                entity.Property(e => e.AchTransNumber)
                    .HasMaxLength(8)
                    .HasColumnName("ACH_TransNumber");

                entity.Property(e => e.AchTransmissionDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACH_Transmission_DateTime");

                entity.Property(e => e.CertificateRecId)
                    .HasMaxLength(32)
                    .HasColumnName("CertificateRecID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DistributionRecId)
                    .HasMaxLength(32)
                    .HasColumnName("DistributionRecID");

                entity.Property(e => e.GroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupRecID");

                entity.Property(e => e.HolderRecId)
                    .HasMaxLength(32)
                    .HasColumnName("HolderRecID");

                entity.Property(e => e.Interest).HasColumnType("money");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OldMaturity)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_Maturity");

                entity.Property(e => e.OldPaidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_PaidTo");

                entity.Property(e => e.OldRolloverRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_RolloverRate");

                entity.Property(e => e.OldRolloverTerm).HasColumnName("Old_RolloverTerm");

                entity.Property(e => e.OldSoldRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_SoldRate");

                entity.Property(e => e.Other).HasColumnType("money");

                entity.Property(e => e.PayAcct).HasMaxLength(10);

                entity.Property(e => e.PayAddress).HasMaxLength(128);

                entity.Property(e => e.PayName).HasMaxLength(64);

                entity.Property(e => e.PayRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PayRecID");

                entity.Property(e => e.Penalty).HasColumnType("money");

                entity.Property(e => e.PoolRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PoolRecID");

                entity.Property(e => e.Principal).HasColumnType("money");

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.ReversalRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ReversalRecID");

                entity.Property(e => e.Rollover).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TransDate).HasColumnType("datetime");

                entity.Property(e => e.TrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrustAccountRecID");
            });

            modelBuilder.Entity<ConBudgetLoan>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CON_Budget_Loans_RecID");

                entity.ToTable("CON Budget Loans");

                entity.HasIndex(e => new { e.AccountRecId, e.LoanRecId }, "IX_CON_Budget_Loans_AccountRecID_LoanRecID")
                    .IsUnique();

                entity.HasIndex(e => e.RecId, "IX_CON_Budget_Loans_RecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("AccountRecID");

                entity.Property(e => e.BudgetAmount).HasColumnType("money");

                entity.Property(e => e.HoldBackAmount).HasColumnType("money");

                entity.Property(e => e.IsHold).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.PctCompleted).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<ConBudgetMaster>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CON_Budget_Master_RecID");

                entity.ToTable("CON Budget Master");

                entity.HasIndex(e => e.Account, "IX_CON_Budget_Master_Account");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.GroupId)
                    .HasMaxLength(3)
                    .HasColumnName("GroupID");

                entity.Property(e => e.IsSoftCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<ConCommitment>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CON_Commitments_RecID");

                entity.ToTable("CON Commitments");

                entity.HasIndex(e => e.LenderRecId, "IX_CON_Commitments_LenderRecID");

                entity.HasIndex(e => e.LoanRecId, "IX_CON_Commitments_LoanRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.DateExpected).HasColumnType("datetime");

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.LenderRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LenderRecID");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<ConInspection>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CON_Inspections_RecID");

                entity.ToTable("CON Inspections");

                entity.HasIndex(e => e.LoanRecId, "IX_CON_Inspections_LoanRecID");

                entity.HasIndex(e => e.VendorRecId, "IX_CON_Inspections_VendorRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.VendorRecId)
                    .HasMaxLength(32)
                    .HasColumnName("VendorRecID");
            });

            modelBuilder.Entity<ConVoucher>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CON_Vouchers_RecID");

                entity.ToTable("CON Vouchers");

                entity.HasIndex(e => e.LoanHistRecId, "IX_CON_Vouchers_LoanHistRecID");

                entity.HasIndex(e => e.LoanRecId, "IX_CON_Vouchers_LoanRecID");

                entity.HasIndex(e => e.VendorHistRecId, "IX_CON_Vouchers_VendorHistRecID");

                entity.HasIndex(e => e.VendorRecId, "IX_CON_Vouchers_VendorRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AchBatchNumber)
                    .HasMaxLength(7)
                    .HasColumnName("ACH_BatchNumber");

                entity.Property(e => e.AchTraceNumber)
                    .HasMaxLength(22)
                    .HasColumnName("ACH_TraceNumber");

                entity.Property(e => e.AchTransNumber)
                    .HasMaxLength(8)
                    .HasColumnName("ACH_TransNumber");

                entity.Property(e => e.AchTransmissionDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACH_Transmission_DateTime");

                entity.Property(e => e.GroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupRecID");

                entity.Property(e => e.IsHold).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsJointCheck).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPaidByOther).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsVoid).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanHistRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanHistRecID");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Memo).HasMaxLength(255);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.PayDate).HasColumnType("datetime");

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.ReversalRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ReversalRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.VendorHistRecId)
                    .HasMaxLength(32)
                    .HasColumnName("VendorHistRecID");

                entity.Property(e => e.VendorRecId)
                    .HasMaxLength(32)
                    .HasColumnName("VendorRecID");
            });

            modelBuilder.Entity<ConVoucherDetail>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_CON_Voucher_Detail_RecID");

                entity.ToTable("CON Voucher Detail");

                entity.HasIndex(e => e.BudgetRecId, "IX_CON_Voucher_Detail_BudgetRecID");

                entity.HasIndex(e => e.VoucherRecId, "IX_CON_Voucher_Detail_VoucherRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.BudgetRecId)
                    .HasMaxLength(32)
                    .HasColumnName("BudgetRecID");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.VoucherRecId)
                    .HasMaxLength(32)
                    .HasColumnName("VoucherRecID");
            });

            modelBuilder.Entity<IrsHeader>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_IRS_Header_RecID");

                entity.ToTable("IRS Header");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.CombinedFederalStateFiler).HasDefaultValueSql("((0))");

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FederalTin)
                    .HasMaxLength(20)
                    .HasColumnName("FederalTIN");

                entity.Property(e => e.FirstName).HasMaxLength(40);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.PoolRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PoolRecID");

                entity.Property(e => e.SecondName).HasMaxLength(40);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.StateTin)
                    .HasMaxLength(20)
                    .HasColumnName("StateTIN");

                entity.Property(e => e.Street).HasMaxLength(40);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Zip).HasMaxLength(10);
            });

            modelBuilder.Entity<IrsOption>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_IRS_Options_RecID");

                entity.ToTable("IRS Options");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.RemoteServerUrl)
                    .HasMaxLength(255)
                    .HasColumnName("RemoteServerURL");
            });

            modelBuilder.Entity<IrsRecipient>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_IRS_Recipients_RecID");

                entity.ToTable("IRS Recipients");

                entity.HasIndex(e => e.DocType, "IX_IRS_Recipients_DocType");

                entity.HasIndex(e => e.ParentRecId, "IX_IRS_Recipients_ParentRecID");

                entity.HasIndex(e => e.RecType, "IX_IRS_Recipients_RecType");

                entity.HasIndex(e => e.TaxYear, "IX_IRS_Recipients_TaxYear");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(255);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.IsFlag).HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.PoolRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PoolRecID");

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.Tintype).HasColumnName("TINType");

                entity.Property(e => e.Xml).HasColumnName("XML");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<LosAddendum>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Addendums_RecID");

                entity.ToTable("LOS Addendums");

                entity.HasIndex(e => e.LoanRecId, "IX_LOS_Addendums_LoanRecID");

                entity.HasIndex(e => e.Sequence, "IX_LOS_Addendums_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Reference).HasMaxLength(20);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<LosBorrower>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Borrowers_RecID");

                entity.ToTable("LOS Borrowers");

                entity.HasIndex(e => e.LoanRecId, "IX_LOS_Borrowers_LoanRecID");

                entity.HasIndex(e => e.Sequence, "IX_LOS_Borrowers_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.SignatureFooter).HasMaxLength(255);

                entity.Property(e => e.SignatureHeader).HasMaxLength(255);

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.Xml).HasColumnName("XML");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<LosDocument>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Documents_RecID");

                entity.ToTable("LOS Documents");

                entity.HasIndex(e => e.DocId, "IX_LOS_Documents_DocID");

                entity.HasIndex(e => e.Sequence, "IX_LOS_Documents_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DocId)
                    .HasMaxLength(32)
                    .HasColumnName("DocID");

                entity.Property(e => e.IsGroup).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.SystemCreated).HasDefaultValueSql("((0))");

                entity.Property(e => e.TemplateName).HasMaxLength(255);

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<LosEncumbrance>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Encumbrances_RecID");

                entity.ToTable("LOS Encumbrances");

                entity.HasIndex(e => e.LoanRecId, "IX_LOS_Encumbrances_LoanRecID");

                entity.HasIndex(e => e.PropRecId, "IX_LOS_Encumbrances_PropRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.BalanceAfter).HasColumnType("money");

                entity.Property(e => e.BalanceNow).HasColumnType("money");

                entity.Property(e => e.BalloonPayment).HasColumnType("money");

                entity.Property(e => e.BeneCity).HasMaxLength(50);

                entity.Property(e => e.BeneName).HasMaxLength(64);

                entity.Property(e => e.BenePhone).HasMaxLength(20);

                entity.Property(e => e.BeneState).HasMaxLength(3);

                entity.Property(e => e.BeneStreet).HasMaxLength(64);

                entity.Property(e => e.BeneZipCode).HasMaxLength(10);

                entity.Property(e => e.InterestRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.LoanNumber).HasMaxLength(20);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.NatureOfLien).HasMaxLength(50);

                entity.Property(e => e.OrigAmount).HasColumnType("money");

                entity.Property(e => e.PropRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PropRecID");

                entity.Property(e => e.RegularPayment).HasColumnType("money");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<LosField>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Fields_RecID");

                entity.ToTable("LOS Fields");

                entity.HasIndex(e => e.Fid, "IX_LOS_Fields_FID")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.DisplayMask).HasMaxLength(50);

                entity.Property(e => e.Fid)
                    .HasMaxLength(10)
                    .HasColumnName("FID");

                entity.Property(e => e.MatchString).HasMaxLength(255);

                entity.Property(e => e.MaxValue).HasMaxLength(50);

                entity.Property(e => e.MinValue).HasMaxLength(50);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<LosForm>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Forms_RecID");

                entity.ToTable("LOS Forms");

                entity.HasIndex(e => e.DocId, "IX_LOS_Forms_DocID");

                entity.HasIndex(e => e.Sequence, "IX_LOS_Forms_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.DocId)
                    .HasMaxLength(32)
                    .HasColumnName("DocID");

                entity.Property(e => e.FormName).HasMaxLength(50);

                entity.Property(e => e.LinkedDocument).HasMaxLength(50);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<LosFunding>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Funding_RecID");

                entity.ToTable("LOS Funding");

                entity.HasIndex(e => e.LoanRecId, "IX_LOS_Funding_LoanRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.AmountFunded).HasColumnType("money");

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateDeposited).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.Institutional).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.LoanTypeAdjustable)
                    .HasColumnName("LoanType_Adjustable")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanTypeFixed)
                    .HasColumnName("LoanType_Fixed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.MultipleSignators).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SuitabilityReviewedBy).HasMaxLength(255);

                entity.Property(e => e.SuitabilityReviewedOn).HasColumnType("datetime");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.Xml).HasColumnName("XML");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<LosHmdaLoan>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_HMDA_Loans_RecID");

                entity.ToTable("LOS HMDA Loans");

                entity.HasIndex(e => e.LoanRecId, "IX_LOS_HMDA_Loans_LoanRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.IncludeInLar)
                    .HasColumnName("IncludeInLAR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<LosLender>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Lenders_RecID");

                entity.ToTable("LOS Lenders");

                entity.HasIndex(e => e.Account, "IX_LOS_Lenders_Account")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.Institutional).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvestorSuitabilityApprovedBy).HasMaxLength(255);

                entity.Property(e => e.InvestorSuitabilityApprovedOn).HasColumnType("datetime");

                entity.Property(e => e.InvestorSuitabilityRecId).HasMaxLength(32);

                entity.Property(e => e.InvestorSuitabilityReceived).HasColumnType("datetime");

                entity.Property(e => e.InvestorSuitabilitySent).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.LoanTypeAdjustable)
                    .HasColumnName("LoanType_Adjustable")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanTypeFixed)
                    .HasColumnName("LoanType_Fixed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.MultipleSignators).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<LosLoan>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Loans_RecID");

                entity.ToTable("LOS Loans");

                entity.HasIndex(e => e.DocId, "IX_LOS_Loans_DocID");

                entity.HasIndex(e => e.LoanNumber, "IX_LOS_Loans_LoanNumber")
                    .IsUnique();

                entity.HasIndex(e => e.UserAccess, "IX_LOS_Loans_UserAccess");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.Property(e => e.BrokerFeeFlat).HasColumnType("money");

                entity.Property(e => e.BrokerFeePct).HasColumnType("money");

                entity.Property(e => e.CalculateFinalPayment).HasDefaultValueSql("((0))");

                entity.Property(e => e.DateLoanClosed).HasColumnType("datetime");

                entity.Property(e => e.DateLoanCreated).HasColumnType("datetime");

                entity.Property(e => e.DocId)
                    .HasMaxLength(32)
                    .HasColumnName("DocID");

                entity.Property(e => e.EscrowNumber).HasMaxLength(15);

                entity.Property(e => e.ExpectedClosingDate).HasColumnType("datetime");

                entity.Property(e => e.FinalActionDate).HasColumnType("datetime");

                entity.Property(e => e.FirstPaymentDate).HasColumnType("datetime");

                entity.Property(e => e.FundingDate).HasColumnType("datetime");

                entity.Property(e => e.IsLocked).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsStepRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsTemplate).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanAmount).HasColumnType("money");

                entity.Property(e => e.LoanNumber).HasMaxLength(10);

                entity.Property(e => e.LoanOfficer).HasMaxLength(50);

                entity.Property(e => e.LoanStatus).HasMaxLength(50);

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.NoteRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Ppy).HasColumnName("PPY");

                entity.Property(e => e.ShortName).HasMaxLength(40);

                entity.Property(e => e.SoldRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserAccess).HasMaxLength(20);

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<LosMcr>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_MCR_RecID");

                entity.ToTable("LOS MCR");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.LastExportDate).HasColumnType("datetime");

                entity.Property(e => e.ReportType).HasMaxLength(255);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<LosOption>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Options_RecID");

                entity.ToTable("LOS Options");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.BrokerFirstName).HasMaxLength(30);

                entity.Property(e => e.BrokerLastName).HasMaxLength(30);

                entity.Property(e => e.BrokerLicense).HasMaxLength(20);

                entity.Property(e => e.BrokerMi)
                    .HasMaxLength(1)
                    .HasColumnName("BrokerMI");

                entity.Property(e => e.CompanyCity).HasMaxLength(50);

                entity.Property(e => e.CompanyEmail).HasMaxLength(255);

                entity.Property(e => e.CompanyFax).HasMaxLength(20);

                entity.Property(e => e.CompanyName).HasMaxLength(64);

                entity.Property(e => e.CompanyPhone).HasMaxLength(20);

                entity.Property(e => e.CompanyState).HasMaxLength(3);

                entity.Property(e => e.CompanyStreet).HasMaxLength(64);

                entity.Property(e => e.CompanyZip).HasMaxLength(10);

                entity.Property(e => e.PrintCompanyOnCheck).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrustAccountRecID");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<LosProduct>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Products_RecID");

                entity.ToTable("LOS Products");

                entity.HasIndex(e => e.Id, "IX_LOS_Products_ID")
                    .IsUnique();

                entity.HasIndex(e => e.Sequence, "IX_LOS_Products_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .HasColumnName("ID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<LosProperty>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Properties_RecID");

                entity.ToTable("LOS Properties");

                entity.HasIndex(e => e.LoanRecId, "IX_LOS_Properties_LoanRecID");

                entity.HasIndex(e => e.Sequence, "IX_LOS_Properties_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.County).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Xml).HasColumnName("XML");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<LosTbill>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_TBills_RecID");

                entity.ToTable("LOS TBills");

                entity.HasIndex(e => e.DatePublished, "IX_LOS_TBills_DatePublished")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.DatePublished).HasColumnType("datetime");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Year1).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Year10).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Year2).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Year20).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Year3).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Year30).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Year5).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Year7).HasColumnType("decimal(18, 8)");
            });

            modelBuilder.Entity<LosTracking>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_LOS_Tracking_RecID");

                entity.ToTable("LOS Tracking");

                entity.HasIndex(e => e.LoanRecId, "IX_LOS_Tracking_LoanRecID");

                entity.HasIndex(e => e.Sequence, "IX_LOS_Tracking_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.DateExpected).HasColumnType("datetime");

                entity.Property(e => e.DateOrdered).HasColumnType("datetime");

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.DocumentName).HasMaxLength(255);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.RequestedFrom).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<PssBankAccount>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_BankAccounts_RecID");

                entity.ToTable("PSS BankAccounts");

                entity.HasIndex(e => e.PartnershipRecId, "IX_PSS_BankAccounts_PartnershipRecID");

                entity.HasIndex(e => new { e.PartnershipRecId, e.TrustAccountRecId }, "IX_PSS_BankAccounts_PartnershipRecID_TrustAccountRecID")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.IsPrimary).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartnershipRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnershipRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrustAccountRecID");
            });

            modelBuilder.Entity<PssCapital>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Capital_RecID");

                entity.ToTable("PSS Capital");

                entity.HasIndex(e => e.PartnerRecId, "IX_PSS_Capital_PartnerRecID");

                entity.HasIndex(e => e.PartnershipRecId, "IX_PSS_Capital_PartnershipRecID");

                entity.HasIndex(e => new { e.PartnershipRecId, e.PartnerRecId, e.TaxYear }, "IX_PSS_Capital_PartnershipRecID_PartnerRecID_TaxYear")
                    .IsUnique();

                entity.HasIndex(e => e.TaxYear, "IX_PSS_Capital_TaxYear");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.BegCapital).HasColumnType("money");

                entity.Property(e => e.PartnerRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnerRecID");

                entity.Property(e => e.PartnershipRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnershipRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<PssCertificate>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Certificates_RecID");

                entity.ToTable("PSS Certificates");

                entity.HasIndex(e => e.PartnerRecId, "IX_PSS_Certificates_PartnerRecID");

                entity.HasIndex(e => e.PartnershipRecId, "IX_PSS_Certificates_PartnershipRecID");

                entity.HasIndex(e => e.Status, "IX_PSS_Certificates_Status");

                entity.HasIndex(e => e.TransferRecId, "IX_PSS_Certificates_TransferRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.DistributionRecId)
                    .HasMaxLength(32)
                    .HasColumnName("DistributionRecID");

                entity.Property(e => e.GrowthPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.IssuedDate).HasColumnType("datetime");

                entity.Property(e => e.MasterCertRecId)
                    .HasMaxLength(32)
                    .HasColumnName("MasterCertRecID");

                entity.Property(e => e.Maturity).HasColumnType("datetime");

                entity.Property(e => e.Number).HasMaxLength(12);

                entity.Property(e => e.PartnerRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnerRecID");

                entity.Property(e => e.PartnershipRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnershipRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TransferRecID");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<PssDistribution>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Distributions_RecID");

                entity.ToTable("PSS Distributions");

                entity.HasIndex(e => e.PartnershipRecId, "IX_PSS_Distributions_PartnershipRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Adjustment).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.AmountPerShare).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.GrossDistribution).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Holdback).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.IsFixedShare).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsProrateDistribution).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsWholeShares).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinReinvestment).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PartnershipRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnershipRecID");

                entity.Property(e => e.PeriodBeg).HasColumnType("datetime");

                entity.Property(e => e.PeriodEnd).HasColumnType("datetime");

                entity.Property(e => e.Reinvested).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.ShareValueBeg).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.ShareValueEnd).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SharesBeg).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SharesEnd).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrustAccountRecID");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<PssMasterCertificate>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Master_Certificates_RecID");

                entity.ToTable("PSS Master Certificates");

                entity.HasIndex(e => e.PartnershipRecId, "IX_PSS_Master_Certificates_PartnershipRecID");

                entity.HasIndex(e => e.TrusteeRecId, "IX_PSS_Master_Certificates_TrusteeRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Dripshares)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("DRIPShares");

                entity.Property(e => e.IssuedDate).HasColumnType("datetime");

                entity.Property(e => e.Number).HasMaxLength(12);

                entity.Property(e => e.OrigShares).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PartnershipRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnershipRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TrusteeRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrusteeRecID");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<PssOption>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Options_RecID");

                entity.ToTable("PSS Options");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountDigits).HasColumnName("Account_Digits");

                entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");

                entity.Property(e => e.AccountNumbering)
                    .HasColumnName("Account_Numbering")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AccountPrefix)
                    .HasMaxLength(1)
                    .HasColumnName("Account_Prefix");

                entity.Property(e => e.AccountSuffix)
                    .HasMaxLength(1)
                    .HasColumnName("Account_Suffix");

                entity.Property(e => e.AccountZeroFill)
                    .HasColumnName("Account_ZeroFill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPostLoanServicingTransactions).HasDefaultValueSql("((0))");

                entity.Property(e => e.CheckStubCaptionsText).HasMaxLength(255);

                entity.Property(e => e.EvalChargesOwedByLender).HasDefaultValueSql("((0))");

                entity.Property(e => e.EvalChargesOwedToLender).HasDefaultValueSql("((0))");

                entity.Property(e => e.EvalLenderTrustBalance).HasDefaultValueSql("((0))");

                entity.Property(e => e.EvalLoanAccruedInterest).HasDefaultValueSql("((0))");

                entity.Property(e => e.EvalLoanAccruedLateCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.EvalLoanPrincipalBalance).HasDefaultValueSql("((0))");

                entity.Property(e => e.EvalLoanUnpaidInterest).HasDefaultValueSql("((0))");

                entity.Property(e => e.EvalLoanUnpaidLateCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExcSharesFromPartnerStmt).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPrintedOnCheckContributions).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPrintedOnCheckDistributions).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPrintedOnCheckPortfolioValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPrintedOnCheckSharesOwned).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPrintedOnCheckSharesPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintCompanyOnCheck).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintIrronPartnerStatements)
                    .HasColumnName("PrintIRRonPartnerStatements")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReplaceDistributionDate).HasDefaultValueSql("((0))");

                entity.Property(e => e.RoundShareValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.TradeConfirmationContributionPath).HasMaxLength(255);

                entity.Property(e => e.TradeConfirmationWithdrawalPath).HasMaxLength(255);

                entity.Property(e => e.UseCompanyLogo).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PssOtherAsset>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_OtherAsset_RecID");

                entity.ToTable("PSS OtherAsset");

                entity.HasIndex(e => e.PartnershipRecId, "IX_PSS_OtherAsset_PartnershipRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AppreciationRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.AssetValue).HasColumnType("money");

                entity.Property(e => e.DateLastEvaluated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(64);

                entity.Property(e => e.PartnershipRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnershipRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<PssPartner>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Partner_RecID");

                entity.ToTable("PSS Partner");

                entity.HasIndex(e => e.Account, "IX_PSS_Partner_Account")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.AchAccountNumber)
                    .HasMaxLength(17)
                    .HasColumnName("ACH_AccountNumber");

                entity.Property(e => e.AchAccountType).HasColumnName("ACH_AccountType");

                entity.Property(e => e.AchAddendaRecord)
                    .HasMaxLength(80)
                    .HasColumnName("ACH_AddendaRecord");

                entity.Property(e => e.AchBankAddress)
                    .HasMaxLength(255)
                    .HasColumnName("ACH_BankAddress");

                entity.Property(e => e.AchBankName)
                    .HasMaxLength(50)
                    .HasColumnName("ACH_BankName");

                entity.Property(e => e.AchIndividualId)
                    .HasMaxLength(15)
                    .HasColumnName("ACH_IndividualId");

                entity.Property(e => e.AchIndividualName)
                    .HasMaxLength(22)
                    .HasColumnName("ACH_IndividualName");

                entity.Property(e => e.AchRoutingNumber)
                    .HasMaxLength(9)
                    .HasColumnName("ACH_RoutingNumber");

                entity.Property(e => e.AchSeccode).HasColumnName("ACH_SECCode");

                entity.Property(e => e.AchSendDepositNotificationFlag).HasColumnName("ACH_SendDepositNotificationFlag");

                entity.Property(e => e.AchServiceStatus).HasColumnName("ACH_ServiceStatus");

                entity.Property(e => e.AchUseAddendaRecord)
                    .HasColumnName("ACH_UseAddendaRecord")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.Erisa)
                    .HasColumnName("ERISA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.GrowthPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.HoldbackPct)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Holdback_Pct");

                entity.Property(e => e.HoldbackRecId)
                    .HasMaxLength(32)
                    .HasColumnName("Holdback_RecID");

                entity.Property(e => e.HoldbackRef)
                    .HasMaxLength(40)
                    .HasColumnName("Holdback_Ref");

                entity.Property(e => e.HoldbackUse)
                    .HasColumnName("Holdback_Use")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HomeAddrEnabled).HasDefaultValueSql("((0))");

                entity.Property(e => e.HomeCity).HasMaxLength(50);

                entity.Property(e => e.HomeState).HasMaxLength(3);

                entity.Property(e => e.HomeStreet).HasMaxLength(64);

                entity.Property(e => e.HomeZipCode).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.NonResident).HasDefaultValueSql("((0))");

                entity.Property(e => e.Payee).HasMaxLength(255);

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.RegisteredShareholderCity).HasMaxLength(50);

                entity.Property(e => e.RegisteredShareholderName).HasMaxLength(255);

                entity.Property(e => e.RegisteredShareholderState).HasMaxLength(3);

                entity.Property(e => e.RegisteredShareholderStreet).HasMaxLength(64);

                entity.Property(e => e.RegisteredShareholderZipCode).HasMaxLength(10);

                entity.Property(e => e.Salutation).HasMaxLength(255);

                entity.Property(e => e.SecurityHeldBy).HasMaxLength(30);

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.Tintype).HasColumnName("TINType");

                entity.Property(e => e.TrusteeAccountRef).HasMaxLength(20);

                entity.Property(e => e.TrusteeAccountType).HasMaxLength(30);

                entity.Property(e => e.TrusteeRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrusteeRecID");

                entity.Property(e => e.UsePayee).HasDefaultValueSql("((0))");

                entity.Property(e => e.WpcPin)
                    .HasMaxLength(10)
                    .HasColumnName("WPC_PIN");

                entity.Property(e => e.WpcPublish)
                    .HasColumnName("WPC_Publish")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<PssPool>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Partnership_RecID");

                entity.ToTable("PSS Partnership");

                entity.HasIndex(e => e.Account, "IX_PSS_Partnership_Account")
                    .IsUnique();

                entity.HasIndex(e => e.LenderRecId, "IX_PSS_Partnership_LenderRecID")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.CertDigits).HasColumnName("Cert_Digits");

                entity.Property(e => e.CertNumber).HasColumnName("Cert_Number");

                entity.Property(e => e.CertPrefix)
                    .HasMaxLength(1)
                    .HasColumnName("Cert_Prefix");

                entity.Property(e => e.CertPrepayFee)
                    .HasColumnType("money")
                    .HasColumnName("Cert_PrepayFee");

                entity.Property(e => e.CertPrepayMin)
                    .HasColumnType("money")
                    .HasColumnName("Cert_PrepayMin");

                entity.Property(e => e.CertPrepayMon).HasColumnName("Cert_PrepayMon");

                entity.Property(e => e.CertPrepayPct)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Cert_PrepayPct");

                entity.Property(e => e.CertPrepayUse)
                    .HasColumnName("Cert_PrepayUse")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CertSuffix)
                    .HasMaxLength(1)
                    .HasColumnName("Cert_Suffix");

                entity.Property(e => e.CertTemplate)
                    .HasMaxLength(255)
                    .HasColumnName("Cert_Template");

                entity.Property(e => e.CertZeroFill)
                    .HasColumnName("Cert_ZeroFill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ContributionLimit).HasColumnType("money");

                entity.Property(e => e.Description).HasMaxLength(64);

                entity.Property(e => e.ErisaMaxPct)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("ERISA_MaxPct");

                entity.Property(e => e.FixedShareValue).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.InceptionDate).HasColumnType("datetime");

                entity.Property(e => e.IsFixedShare).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsProrateDistribution).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsWholeShares).HasDefaultValueSql("((0))");

                entity.Property(e => e.LenderRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LenderRecID");

                entity.Property(e => e.MinReinvestment).HasColumnType("money");

                entity.Property(e => e.MinimumInvestment).HasColumnType("money");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<PssPayable>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Payables_RecID");

                entity.ToTable("PSS Payables");

                entity.HasIndex(e => e.Account, "IX_PSS_Payables_Account")
                    .IsUnique();

                entity.HasIndex(e => e.PartnershipRecId, "IX_PSS_Payables_PartnershipRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(64);

                entity.Property(e => e.IntRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.PartnershipRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnershipRecID");

                entity.Property(e => e.PaymentAmount).HasColumnType("money");

                entity.Property(e => e.PaymentNextDue).HasColumnType("datetime");

                entity.Property(e => e.PrinBalance).HasColumnType("money");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<PssShareValue>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_ShareValues_RecID");

                entity.ToTable("PSS ShareValues");

                entity.HasIndex(e => e.PartnershipRecId, "IX_PSS_ShareValues_PartnershipRecID");

                entity.HasIndex(e => new { e.PartnershipRecId, e.EffectiveDate }, "IX_PSS_ShareValues_PartnershipRecID_EffectiveDate")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.ActualCashOnHand)
                    .HasColumnType("money")
                    .HasColumnName("Actual_CashOnHand");

                entity.Property(e => e.ActualChargesPayable)
                    .HasColumnType("money")
                    .HasColumnName("Actual_ChargesPayable");

                entity.Property(e => e.ActualChargesReceivable)
                    .HasColumnType("money")
                    .HasColumnName("Actual_ChargesReceivable");

                entity.Property(e => e.ActualInterest)
                    .HasColumnType("money")
                    .HasColumnName("Actual_Interest");

                entity.Property(e => e.ActualLateCharges)
                    .HasColumnType("money")
                    .HasColumnName("Actual_LateCharges");

                entity.Property(e => e.ActualOtherAssets)
                    .HasColumnType("money")
                    .HasColumnName("Actual_OtherAssets");

                entity.Property(e => e.ActualOtherLiabilities)
                    .HasColumnType("money")
                    .HasColumnName("Actual_OtherLiabilities");

                entity.Property(e => e.ActualPrincipalBalance)
                    .HasColumnType("money")
                    .HasColumnName("Actual_PrincipalBalance");

                entity.Property(e => e.ActualServicingTrustBalance)
                    .HasColumnType("money")
                    .HasColumnName("Actual_ServicingTrustBalance");

                entity.Property(e => e.AdjustmentCashOnHand)
                    .HasColumnType("money")
                    .HasColumnName("Adjustment_CashOnHand");

                entity.Property(e => e.AdjustmentChargesPayable)
                    .HasColumnType("money")
                    .HasColumnName("Adjustment_ChargesPayable");

                entity.Property(e => e.AdjustmentChargesReceivable)
                    .HasColumnType("money")
                    .HasColumnName("Adjustment_ChargesReceivable");

                entity.Property(e => e.AdjustmentInterest)
                    .HasColumnType("money")
                    .HasColumnName("Adjustment_Interest");

                entity.Property(e => e.AdjustmentLateCharges)
                    .HasColumnType("money")
                    .HasColumnName("Adjustment_LateCharges");

                entity.Property(e => e.AdjustmentOtherAssets)
                    .HasColumnType("money")
                    .HasColumnName("Adjustment_OtherAssets");

                entity.Property(e => e.AdjustmentOtherLiabilities)
                    .HasColumnType("money")
                    .HasColumnName("Adjustment_OtherLiabilities");

                entity.Property(e => e.AdjustmentPrincipalBalance)
                    .HasColumnType("money")
                    .HasColumnName("Adjustment_PrincipalBalance");

                entity.Property(e => e.AdjustmentServicingTrustBalance)
                    .HasColumnType("money")
                    .HasColumnName("Adjustment_ServicingTrustBalance");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.OutstandingShares).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PartnershipRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnershipRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<PssTransaction>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Transaction_RecID");

                entity.ToTable("PSS Transaction");

                entity.HasIndex(e => e.CertificateRecId, "IX_PSS_Transaction_CertificateRecID");

                entity.HasIndex(e => e.Code, "IX_PSS_Transaction_Code");

                entity.HasIndex(e => e.PartnerRecId, "IX_PSS_Transaction_PartnerRecID");

                entity.HasIndex(e => e.PartnershipRecId, "IX_PSS_Transaction_PartnershipRecID");

                entity.HasIndex(e => e.RecDate, "IX_PSS_Transaction_RecDate");

                entity.HasIndex(e => e.Reference, "IX_PSS_Transaction_Reference");

                entity.HasIndex(e => e.Sequence, "IX_PSS_Transaction_Sequence");

                entity.HasIndex(e => e.TdsgroupRecId, "IX_PSS_Transaction_TDSGroupRecID");

                entity.HasIndex(e => e.TrustAccountRecId, "IX_PSS_Transaction_TrustAccountRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AchBatchNumber)
                    .HasMaxLength(7)
                    .HasColumnName("ACH_BatchNumber");

                entity.Property(e => e.AchTraceNumber)
                    .HasMaxLength(22)
                    .HasColumnName("ACH_TraceNumber");

                entity.Property(e => e.AchTransNumber)
                    .HasMaxLength(8)
                    .HasColumnName("ACH_TransNumber");

                entity.Property(e => e.AchTransmissionDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACH_Transmission_DateTime");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CertificateRecId)
                    .HasMaxLength(32)
                    .HasColumnName("CertificateRecID");

                entity.Property(e => e.DepDate).HasColumnType("datetime");

                entity.Property(e => e.DistributionRecId)
                    .HasMaxLength(32)
                    .HasColumnName("DistributionRecID");

                entity.Property(e => e.Drip)
                    .HasColumnName("DRIP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupRecID");

                entity.Property(e => e.Holdback).HasColumnType("money");

                entity.Property(e => e.Memo).HasMaxLength(40);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.PartnerRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnerRecID");

                entity.Property(e => e.PartnershipRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PartnershipRecID");

                entity.Property(e => e.PayAcct).HasMaxLength(10);

                entity.Property(e => e.PayAddress).HasMaxLength(128);

                entity.Property(e => e.PayName).HasMaxLength(64);

                entity.Property(e => e.PayRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PayRecID");

                entity.Property(e => e.Penalty).HasColumnType("money");

                entity.Property(e => e.RecDate).HasColumnType("datetime");

                entity.Property(e => e.RedeemImportRecId)
                    .HasMaxLength(32)
                    .HasColumnName("RedeemImportRecID");

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.ReversalRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ReversalRecID");

                entity.Property(e => e.ShareCost).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SharePrice).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Shares).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TdsgroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TDSGroupRecID");

                entity.Property(e => e.TransferRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TransferRecID");

                entity.Property(e => e.TrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrustAccountRecID");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<PssTrustee>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_PSS_Trustee_RecID");

                entity.ToTable("PSS Trustee");

                entity.HasIndex(e => e.Account, "IX_PSS_Trustee_Account")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.MasterCertTemplate).HasMaxLength(255);

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.Property(e => e.TrusteeName).HasMaxLength(50);

                entity.Property(e => e.UseMasterCert).HasDefaultValueSql("((0))");

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(255)
                    .HasColumnName("WebsiteURL");

                entity.Property(e => e.Xml).HasColumnName("XML");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<RptLetter>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_RPT_Letters_RecID");

                entity.ToTable("RPT Letters");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TemplateName).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(20);
            });

            modelBuilder.Entity<RptReport>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_RPT_Reports_RecID");

                entity.ToTable("RPT Reports");

                entity.HasIndex(e => e.Sequence, "IX_RPT_Reports_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.AutoIncrement).HasDefaultValueSql("((0))");

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(20);

                entity.Property(e => e.Version).HasMaxLength(9);
            });

            modelBuilder.Entity<SmsMessage>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_SMS_Messages_RecID");

                entity.ToTable("SMS Messages");

                entity.HasIndex(e => e.RecipientRecId, "IX_SMS_Messages_RecipientRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateSent).HasColumnType("datetime");

                entity.Property(e => e.ErrorText).HasMaxLength(255);

                entity.Property(e => e.FromNumber).HasMaxLength(20);

                entity.Property(e => e.LastFetch).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.RecipientRecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecipientRecID");

                entity.Property(e => e.Sid)
                    .HasMaxLength(50)
                    .HasColumnName("SID");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.ToNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<TdsArmindex>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_ARMIndex_RecID");

                entity.ToTable("TDS ARMIndex");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.LinkedIndex).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OtherAdjustments).HasMaxLength(255);

                entity.Property(e => e.PublishFrequency).HasMaxLength(50);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.SourceOfInformation).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsArmrate>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_ARMRates_RecID");

                entity.ToTable("TDS ARMRates");

                entity.HasIndex(e => e.ParentRecId, "IX_TDS_ARMRates_ParentRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.EffectiveDateEnd).HasColumnType("datetime");

                entity.Property(e => e.EffectiveDateStart).HasColumnType("datetime");

                entity.Property(e => e.EffectiveRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsCharge>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Charges_RecID");

                entity.ToTable("TDS Charges");

                entity.HasIndex(e => e.ChargeDate, "IX_TDS_Charges_ChargeDate");

                entity.HasIndex(e => e.GroupRecId, "IX_TDS_Charges_GroupRecID");

                entity.HasIndex(e => e.OwedByRecId, "IX_TDS_Charges_OwedByRecID");

                entity.HasIndex(e => e.OwedToRecId, "IX_TDS_Charges_OwedToRecID");

                entity.HasIndex(e => e.ParentRecId, "IX_TDS_Charges_ParentRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AssessFinanceCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChargeDate).HasColumnType("datetime");

                entity.Property(e => e.Deferred).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.GroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupRecID");

                entity.Property(e => e.IntFrom).HasColumnType("datetime");

                entity.Property(e => e.IntRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.OrigAmt).HasColumnType("money");

                entity.Property(e => e.OwedByBal).HasColumnType("money");

                entity.Property(e => e.OwedByRecId)
                    .HasMaxLength(32)
                    .HasColumnName("OwedByRecID");

                entity.Property(e => e.OwedToBal).HasColumnType("money");

                entity.Property(e => e.OwedToRecId)
                    .HasMaxLength(32)
                    .HasColumnName("OwedToRecID");

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsChargesDetail>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Charges_Detail_RecID");

                entity.ToTable("TDS Charges Detail");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_Charges_Detail_LoanRecID");

                entity.HasIndex(e => e.PaidByRecId, "IX_TDS_Charges_Detail_PaidByRecID");

                entity.HasIndex(e => e.ParentRecId, "IX_TDS_Charges_Detail_ParentRecID");

                entity.HasIndex(e => e.PmtGroupRecId, "IX_TDS_Charges_Detail_PmtGroupRecID");

                entity.HasIndex(e => e.TransDate, "IX_TDS_Charges_Detail_TransDate");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.PaidByRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PaidByRecID");

                entity.Property(e => e.PaidOwedByBal).HasColumnType("money");

                entity.Property(e => e.PaidOwedByInt).HasColumnType("money");

                entity.Property(e => e.PaidOwedToBal).HasColumnType("money");

                entity.Property(e => e.PaidOwedToInt).HasColumnType("money");

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.PmtGroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PmtGroupRecID");

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TransDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsCoBorrower>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_CoBorrowers_RecID");

                entity.ToTable("TDS CoBorrowers");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_CoBorrowers_LoanRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.CcrAddressIndicator)
                    .HasMaxLength(1)
                    .HasColumnName("CCR_AddressIndicator");

                entity.Property(e => e.CcrDob)
                    .HasColumnType("datetime")
                    .HasColumnName("CCR_DOB");

                entity.Property(e => e.CcrGenerationCode)
                    .HasMaxLength(1)
                    .HasColumnName("CCR_GenerationCode");

                entity.Property(e => e.CcrReport)
                    .HasColumnName("CCR_Report")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CcrResidenceCode)
                    .HasMaxLength(1)
                    .HasColumnName("CCR_ResidenceCode");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.SendNotices).HasDefaultValueSql("((0))");

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<TdsDraw>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Draws_RecID");

                entity.ToTable("TDS Draws");

                entity.HasIndex(e => e.FundingRecId, "IX_TDS_Draws_FundingRecID");

                entity.HasIndex(e => e.GroupRecId, "IX_TDS_Draws_GroupRecID");

                entity.HasIndex(e => e.LenderRecId, "IX_TDS_Draws_LenderRecID");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_Draws_LoanRecID");

                entity.HasIndex(e => e.TransDate, "IX_TDS_Draws_TransDate");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Fee).HasColumnType("money");

                entity.Property(e => e.FundingRecId)
                    .HasMaxLength(32)
                    .HasColumnName("FundingRecID");

                entity.Property(e => e.GroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupRecID");

                entity.Property(e => e.LenderRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LenderRecID");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TransDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsEscrowProjection>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Escrow_Projections_RecID");

                entity.ToTable("TDS Escrow Projections");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.ComputationPeriodStartingDate).HasColumnType("datetime");

                entity.Property(e => e.Cushion).HasColumnType("money");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<TdsFunding>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Funding_RecID");

                entity.ToTable("TDS Funding");

                entity.HasIndex(e => e.LenderRecId, "IX_TDS_Funding_LenderRecID");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_Funding_LoanRecID");

                entity.HasIndex(e => e.VendorRecId, "IX_TDS_Funding_VendorRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.BrokerFeeFlat).HasColumnType("money");

                entity.Property(e => e.BrokerFeeMin).HasColumnType("money");

                entity.Property(e => e.BrokerFeePct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.DrawControl).HasColumnType("money");

                entity.Property(e => e.EffRateValue).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.FundControl).HasColumnType("money");

                entity.Property(e => e.Gstuse)
                    .HasColumnName("GSTUse")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LenderRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LenderRecID");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.PennyError).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.VendorFeeFlat).HasColumnType("money");

                entity.Property(e => e.VendorFeeMin).HasColumnType("money");

                entity.Property(e => e.VendorFeePct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.VendorRecId)
                    .HasMaxLength(32)
                    .HasColumnName("VendorRecID");
            });

            modelBuilder.Entity<TdsFundingDisb>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_FundingDisb_RecID");

                entity.ToTable("TDS FundingDisb");

                entity.HasIndex(e => e.FundingRecId, "IX_TDS_FundingDisb_FundingRecID");

                entity.HasIndex(e => e.LenderRecId, "IX_TDS_FundingDisb_LenderRecID");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_FundingDisb_LoanRecID");

                entity.HasIndex(e => e.PayeeRecId, "IX_TDS_FundingDisb_PayeeRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.FeeAmt).HasColumnType("money");

                entity.Property(e => e.FeeMin).HasColumnType("money");

                entity.Property(e => e.FeePct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.FundingRecId)
                    .HasMaxLength(32)
                    .HasColumnName("FundingRecID");

                entity.Property(e => e.IsServicingFee).HasDefaultValueSql("((0))");

                entity.Property(e => e.LenderRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LenderRecID");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.PayeeRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PayeeRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsIdd>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_IDD_RecID");

                entity.ToTable("TDS IDD");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_IDD_LoanRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.PctOwn).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.VendorRecId)
                    .HasMaxLength(32)
                    .HasColumnName("VendorRecID");
            });

            modelBuilder.Entity<TdsInsurance>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Insurance_RecID");

                entity.ToTable("TDS Insurance");

                entity.HasIndex(e => e.Active, "IX_TDS_Insurance_Active");

                entity.HasIndex(e => e.PropRecId, "IX_TDS_Insurance_PropRecID");

                entity.HasIndex(e => e.RecId, "IX_TDS_Insurance_RecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.AgentAddress).HasMaxLength(128);

                entity.Property(e => e.AgentEmail).HasMaxLength(255);

                entity.Property(e => e.AgentFax).HasMaxLength(20);

                entity.Property(e => e.AgentName).HasMaxLength(64);

                entity.Property(e => e.AgentPhone).HasMaxLength(20);

                entity.Property(e => e.CompanyName).HasMaxLength(64);

                entity.Property(e => e.Coverage).HasColumnType("money");

                entity.Property(e => e.Description).HasMaxLength(64);

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.InsuredName).HasMaxLength(64);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.PolicyNumber).HasMaxLength(20);

                entity.Property(e => e.PropRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PropRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsLender>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Lenders_RecID");

                entity.ToTable("TDS Lenders");

                entity.HasIndex(e => e.Account, "IX_TDS_Lenders_Account")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.AchAccountNumber)
                    .HasMaxLength(17)
                    .HasColumnName("ACH_AccountNumber");

                entity.Property(e => e.AchAccountType).HasColumnName("ACH_AccountType");

                entity.Property(e => e.AchAddendaRecord)
                    .HasMaxLength(80)
                    .HasColumnName("ACH_AddendaRecord");

                entity.Property(e => e.AchBankAddress)
                    .HasMaxLength(255)
                    .HasColumnName("ACH_BankAddress");

                entity.Property(e => e.AchBankName)
                    .HasMaxLength(50)
                    .HasColumnName("ACH_BankName");

                entity.Property(e => e.AchGroupByLoan)
                    .HasColumnName("ACH_GroupByLoan")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AchIndividualId)
                    .HasMaxLength(15)
                    .HasColumnName("ACH_IndividualId");

                entity.Property(e => e.AchIndividualName)
                    .HasMaxLength(22)
                    .HasColumnName("ACH_IndividualName");

                entity.Property(e => e.AchRoutingNumber)
                    .HasMaxLength(9)
                    .HasColumnName("ACH_RoutingNumber");

                entity.Property(e => e.AchSeccode).HasColumnName("ACH_SECCode");

                entity.Property(e => e.AchServiceStatus).HasColumnName("ACH_ServiceStatus");

                entity.Property(e => e.AchUseAddendaRecord)
                    .HasColumnName("ACH_UseAddendaRecord")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Asiownership).HasColumnName("ASIOwnership");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(15);

                entity.Property(e => e.Counselor).HasMaxLength(64);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.Institutional).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsVendor).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.LoanTypeAdjustable)
                    .HasColumnName("LoanType_Adjustable")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanTypeFixed)
                    .HasColumnName("LoanType_Fixed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.NonemployeeCompensation).HasDefaultValueSql("((0))");

                entity.Property(e => e.Payee).HasMaxLength(192);

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.Send1099).HasDefaultValueSql("((0))");

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.Tintype).HasColumnName("TINType");

                entity.Property(e => e.UsePayee).HasDefaultValueSql("((0))");

                entity.Property(e => e.WpcPin)
                    .HasMaxLength(10)
                    .HasColumnName("WPC_PIN");

                entity.Property(e => e.WpcPublish)
                    .HasColumnName("WPC_Publish")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<TdsLenderHistory>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Lender_History_RecID");

                entity.ToTable("TDS Lender History");

                entity.HasIndex(e => e.CheckDate, "IX_TDS_Lender_History_CheckDate");

                entity.HasIndex(e => e.CheckNo, "IX_TDS_Lender_History_CheckNo");

                entity.HasIndex(e => e.FundingRecId, "IX_TDS_Lender_History_FundingRecID");

                entity.HasIndex(e => e.LenderRecId, "IX_TDS_Lender_History_LenderRecID");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_Lender_History_LoanRecID");

                entity.HasIndex(e => e.PmtDateRec, "IX_TDS_Lender_History_PmtDateRec");

                entity.HasIndex(e => e.PmtGroupRecId, "IX_TDS_Lender_History_PmtGroupRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AchBatchNumber)
                    .HasMaxLength(7)
                    .HasColumnName("ACH_BatchNumber");

                entity.Property(e => e.AchTraceNumber)
                    .HasMaxLength(22)
                    .HasColumnName("ACH_TraceNumber");

                entity.Property(e => e.AchTransNumber)
                    .HasMaxLength(8)
                    .HasColumnName("ACH_TransNumber");

                entity.Property(e => e.AchTransmissionDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACH_Transmission_DateTime");

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CheckMemo).HasMaxLength(255);

                entity.Property(e => e.CheckNo).HasMaxLength(10);

                entity.Property(e => e.ChkGroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ChkGroupRecID");

                entity.Property(e => e.FundingRecId)
                    .HasMaxLength(32)
                    .HasColumnName("FundingRecID");

                entity.Property(e => e.LenderRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LenderRecID");

                entity.Property(e => e.LoanBalance).HasColumnType("money");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.PmtCode).HasMaxLength(6);

                entity.Property(e => e.PmtDateDue).HasColumnType("datetime");

                entity.Property(e => e.PmtDateRec).HasColumnType("datetime");

                entity.Property(e => e.PmtGroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PmtGroupRecID");

                entity.Property(e => e.PrintNote).HasDefaultValueSql("((0))");

                entity.Property(e => e.SourceApp).HasMaxLength(20);

                entity.Property(e => e.SourceTyp).HasMaxLength(6);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.ToChargesInt).HasColumnType("money");

                entity.Property(e => e.ToChargesPrin).HasColumnType("money");

                entity.Property(e => e.ToDefaultInterest).HasColumnType("money");

                entity.Property(e => e.ToGst)
                    .HasColumnType("money")
                    .HasColumnName("ToGST");

                entity.Property(e => e.ToInterest).HasColumnType("money");

                entity.Property(e => e.ToLateCharge).HasColumnType("money");

                entity.Property(e => e.ToOtherPayments).HasColumnType("money");

                entity.Property(e => e.ToOtherTaxFree).HasColumnType("money");

                entity.Property(e => e.ToOtherTaxable).HasColumnType("money");

                entity.Property(e => e.ToPrepay).HasColumnType("money");

                entity.Property(e => e.ToPrincipal).HasColumnType("money");

                entity.Property(e => e.ToServiceFee).HasColumnType("money");

                entity.Property(e => e.ToTrust).HasColumnType("money");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<TdsLien>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Liens_RecID");

                entity.ToTable("TDS Liens");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_Liens_LoanRecID");

                entity.HasIndex(e => e.PropRecId, "IX_TDS_Liens_PropRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountNo).HasMaxLength(20);

                entity.Property(e => e.Contact).HasMaxLength(40);

                entity.Property(e => e.Current).HasColumnType("money");

                entity.Property(e => e.Holder).HasMaxLength(40);

                entity.Property(e => e.LastChecked).HasColumnType("datetime");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Original).HasColumnType("money");

                entity.Property(e => e.Payment).HasColumnType("money");

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PropRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PropRecID");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsLoan>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Loans_RecID");

                entity.ToTable("TDS Loans");

                entity.HasIndex(e => e.Account, "IX_TDS_Loans_Account")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.AchAccountNumber)
                    .HasMaxLength(17)
                    .HasColumnName("ACH_AccountNumber");

                entity.Property(e => e.AchAccountType).HasColumnName("ACH_AccountType");

                entity.Property(e => e.AchAddendaRecord)
                    .HasMaxLength(80)
                    .HasColumnName("ACH_AddendaRecord");

                entity.Property(e => e.AchApplyAs).HasColumnName("ACH_ApplyAs");

                entity.Property(e => e.AchBankAddress)
                    .HasMaxLength(255)
                    .HasColumnName("ACH_BankAddress");

                entity.Property(e => e.AchBankName)
                    .HasMaxLength(50)
                    .HasColumnName("ACH_BankName");

                entity.Property(e => e.AchDebitAmount)
                    .HasColumnType("money")
                    .HasColumnName("ACH_DebitAmount");

                entity.Property(e => e.AchDebitDueDay).HasColumnName("ACH_DebitDueDay");

                entity.Property(e => e.AchFrequency).HasColumnName("ACH_Frequency");

                entity.Property(e => e.AchIndividualId)
                    .HasMaxLength(15)
                    .HasColumnName("ACH_IndividualId");

                entity.Property(e => e.AchIndividualName)
                    .HasMaxLength(22)
                    .HasColumnName("ACH_IndividualName");

                entity.Property(e => e.AchNextDebitDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ACH_NextDebitDate");

                entity.Property(e => e.AchRoutingNumber)
                    .HasMaxLength(9)
                    .HasColumnName("ACH_RoutingNumber");

                entity.Property(e => e.AchSeccode).HasColumnName("ACH_SECCode");

                entity.Property(e => e.AchServiceStatus).HasColumnName("ACH_ServiceStatus");

                entity.Property(e => e.AchStopDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ACH_StopDate");

                entity.Property(e => e.AchUseAddendaRecord)
                    .HasColumnName("ACH_UseAddendaRecord")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AchUseDebitAmount)
                    .HasColumnName("ACH_UseDebitAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArmCarryoverAmount)
                    .HasColumnType("money")
                    .HasColumnName("ARM_CarryoverAmount");

                entity.Property(e => e.ArmCarryoverEnabled)
                    .HasColumnName("ARM_CarryoverEnabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArmCeiling)
                    .HasColumnType("money")
                    .HasColumnName("ARM_Ceiling");

                entity.Property(e => e.ArmFirstNoticeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ARM_FirstNoticeDate");

                entity.Property(e => e.ArmFloor)
                    .HasColumnType("money")
                    .HasColumnName("ARM_Floor");

                entity.Property(e => e.ArmIndexRate)
                    .HasColumnType("money")
                    .HasColumnName("ARM_IndexRate");

                entity.Property(e => e.ArmIndexRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ARM_IndexRecID");

                entity.Property(e => e.ArmIsOptionArm)
                    .HasColumnName("ARM_IsOptionARM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArmLookBackDays).HasColumnName("ARM_LookBackDays");

                entity.Property(e => e.ArmMargin)
                    .HasColumnType("money")
                    .HasColumnName("ARM_Margin");

                entity.Property(e => e.ArmNegAmortCap)
                    .HasColumnType("money")
                    .HasColumnName("ARM_NegAmortCap");

                entity.Property(e => e.ArmNoticeLeadDays).HasColumnName("ARM_NoticeLeadDays");

                entity.Property(e => e.ArmPaymentAdjustment)
                    .HasColumnName("ARM_PaymentAdjustment")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArmPaymentCap)
                    .HasColumnType("money")
                    .HasColumnName("ARM_PaymentCap");

                entity.Property(e => e.ArmPaymentChangeFreq).HasColumnName("ARM_PaymentChangeFreq");

                entity.Property(e => e.ArmPaymentChangeNext)
                    .HasColumnType("datetime")
                    .HasColumnName("ARM_PaymentChangeNext");

                entity.Property(e => e.ArmRateChangeFreq).HasColumnName("ARM_RateChangeFreq");

                entity.Property(e => e.ArmRateChangeNext)
                    .HasColumnType("datetime")
                    .HasColumnName("ARM_RateChangeNext");

                entity.Property(e => e.ArmRateFirstChgActive)
                    .HasColumnName("ARM_RateFirstChgActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArmRateFirstChgMaxCap)
                    .HasColumnType("money")
                    .HasColumnName("ARM_RateFirstChgMaxCap");

                entity.Property(e => e.ArmRateFirstChgMinCap)
                    .HasColumnType("money")
                    .HasColumnName("ARM_RateFirstChgMinCap");

                entity.Property(e => e.ArmRatePeriodicMaxCap)
                    .HasColumnType("money")
                    .HasColumnName("ARM_RatePeriodicMaxCap");

                entity.Property(e => e.ArmRatePeriodicMinCap)
                    .HasColumnType("money")
                    .HasColumnName("ARM_RatePeriodicMinCap");

                entity.Property(e => e.ArmRateRoundFactor)
                    .HasColumnType("money")
                    .HasColumnName("ARM_RateRoundFactor");

                entity.Property(e => e.ArmRateRounding).HasColumnName("ARM_RateRounding");

                entity.Property(e => e.ArmRecastFreq).HasColumnName("ARM_RecastFreq");

                entity.Property(e => e.ArmRecastNextDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ARM_RecastNextDate");

                entity.Property(e => e.ArmRecastPayment)
                    .HasColumnName("ARM_RecastPayment")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArmRecastStopDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ARM_RecastStopDate");

                entity.Property(e => e.ArmRecastToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ARM_RecastToDate");

                entity.Property(e => e.ArmSendRateChangeNotice)
                    .HasColumnName("ARM_SendRateChangeNotice")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArmUseRecastToDate)
                    .HasColumnName("ARM_UseRecastToDate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Article7).HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayFromReserveAmount)
                    .HasColumnType("money")
                    .HasColumnName("AutoPayFromReserve_Amount");

                entity.Property(e => e.AutoPayFromReserveOverdrawnMethod).HasColumnName("AutoPayFromReserve_OverdrawnMethod");

                entity.Property(e => e.AutoPayFromReservePct)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("AutoPayFromReserve_Pct");

                entity.Property(e => e.AutoPayFromReserveUse)
                    .HasColumnName("AutoPayFromReserve_Use")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayUnpaidInterest).HasDefaultValueSql("((0))");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.BorrowerRecId)
                    .HasMaxLength(32)
                    .HasColumnName("BorrowerRecID");

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.CanadianAmortization).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cdfireporting)
                    .HasColumnName("CDFIReporting")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyRecId)
                    .HasMaxLength(32)
                    .HasColumnName("CompanyRecID");

                entity.Property(e => e.ConChargeIntOnAvailFunds)
                    .HasColumnName("CON_ChargeIntOnAvailFunds")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConChargeIntOnAvailFundsMethods).HasColumnName("CON_ChargeIntOnAvailFundsMethods");

                entity.Property(e => e.ConChargeIntOnAvailFundsRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("CON_ChargeIntOnAvailFundsRate");

                entity.Property(e => e.ConCompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CON_CompletionDate");

                entity.Property(e => e.ConConstructionLoan)
                    .HasColumnType("money")
                    .HasColumnName("CON_ConstructionLoan");

                entity.Property(e => e.ConContractorLicNo)
                    .HasMaxLength(20)
                    .HasColumnName("CON_ContractorLicNo");

                entity.Property(e => e.ConContractorRecId)
                    .HasMaxLength(32)
                    .HasColumnName("CON_ContractorRecID");

                entity.Property(e => e.ConJointCheck)
                    .HasColumnName("CON_JointCheck")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConProjectDescription)
                    .HasMaxLength(255)
                    .HasColumnName("CON_ProjectDescription");

                entity.Property(e => e.ConProjectSqft).HasColumnName("CON_ProjectSQFT");

                entity.Property(e => e.ConRevolving)
                    .HasColumnName("CON_Revolving")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultRateLenderPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.DefaultRateUse).HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultRateValue).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.DefaultRateVendorPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Documentation).HasMaxLength(30);

                entity.Property(e => e.DreappraisalFees)
                    .HasColumnType("money")
                    .HasColumnName("DREAppraisalFees");

                entity.Property(e => e.DrebrokerFundedLoanResale)
                    .HasColumnName("DREBrokerFundedLoanResale")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DrecommissionReceived)
                    .HasColumnType("money")
                    .HasColumnName("DRECommissionReceived");

                entity.Property(e => e.DrecostsBorrowerPaid)
                    .HasColumnType("money")
                    .HasColumnName("DRECostsBorrowerPaid");

                entity.Property(e => e.DrecostsBrokerRetained)
                    .HasColumnType("money")
                    .HasColumnName("DRECostsBrokerRetained");

                entity.Property(e => e.DrefundsAdvanced)
                    .HasColumnType("money")
                    .HasColumnName("DREFundsAdvanced");

                entity.Property(e => e.Drelanguage).HasColumnName("DRELanguage");

                entity.Property(e => e.DrenonTraditionalLoan)
                    .HasColumnName("DRENonTraditionalLoan")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DrenoteHolder)
                    .HasMaxLength(255)
                    .HasColumnName("DRENoteHolder");

                entity.Property(e => e.DrenotePurchasePrice)
                    .HasColumnType("money")
                    .HasColumnName("DRENotePurchasePrice");

                entity.Property(e => e.DrenoteSellingPrice)
                    .HasColumnType("money")
                    .HasColumnName("DRENoteSellingPrice");

                entity.Property(e => e.DreoriginationCharges)
                    .HasColumnType("money")
                    .HasColumnName("DREOriginationCharges");

                entity.Property(e => e.DrerefinanceBrokerLoan)
                    .HasColumnName("DRERefinanceBrokerLoan")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DresellingPrice)
                    .HasColumnType("money")
                    .HasColumnName("DRESellingPrice");

                entity.Property(e => e.DretitleFees)
                    .HasColumnType("money")
                    .HasColumnName("DRETitleFees");

                entity.Property(e => e.DretransType).HasColumnName("DRETransType");

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.EscrowStatementNext).HasColumnType("datetime");

                entity.Property(e => e.EscrowStatementSend).HasDefaultValueSql("((0))");

                entity.Property(e => e.Fico).HasColumnName("FICO");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FirstPaymentDate).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.FundControl).HasColumnType("money");

                entity.Property(e => e.IsTemplate).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.LateChgDaily).HasColumnType("money");

                entity.Property(e => e.LateChgLenderPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.LateChgMin).HasColumnType("money");

                entity.Property(e => e.LateChgPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.LateChgVendorPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.LoanCode).HasMaxLength(15);

                entity.Property(e => e.LoanOfficer).HasMaxLength(64);

                entity.Property(e => e.LoanPurpose).HasMaxLength(30);

                entity.Property(e => e.LocBilledToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LOC_BilledToDate");

                entity.Property(e => e.LocBillingFreq).HasColumnName("LOC_BillingFreq");

                entity.Property(e => e.LocBillingStartDay).HasColumnName("LOC_BillingStartDay");

                entity.Property(e => e.LocCalculationMethod).HasColumnName("LOC_CalculationMethod");

                entity.Property(e => e.LocCreditLimit)
                    .HasColumnType("money")
                    .HasColumnName("LOC_CreditLimit");

                entity.Property(e => e.LocDrawFeeMin)
                    .HasColumnType("money")
                    .HasColumnName("LOC_DrawFeeMin");

                entity.Property(e => e.LocDrawFeePct)
                    .HasColumnType("money")
                    .HasColumnName("LOC_DrawFeePct");

                entity.Property(e => e.LocDrawFeePlus)
                    .HasColumnType("money")
                    .HasColumnName("LOC_DrawFeePlus");

                entity.Property(e => e.LocDrawMaximum)
                    .HasColumnType("money")
                    .HasColumnName("LOC_DrawMaximum");

                entity.Property(e => e.LocDrawMinimum)
                    .HasColumnType("money")
                    .HasColumnName("LOC_DrawMinimum");

                entity.Property(e => e.LocDrawPeriod).HasColumnName("LOC_DrawPeriod");

                entity.Property(e => e.LocEarlyClosureAmount)
                    .HasColumnType("money")
                    .HasColumnName("LOC_EarlyClosureAmount");

                entity.Property(e => e.LocEarlyClosureMonths).HasColumnName("LOC_EarlyClosureMonths");

                entity.Property(e => e.LocExcludeFinanceCharges)
                    .HasColumnName("LOC_ExcludeFinanceCharges")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LocExcludeImpoundBalances)
                    .HasColumnName("LOC_ExcludeImpoundBalances")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LocExcludeLateCharges)
                    .HasColumnName("LOC_ExcludeLateCharges")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LocExcludeReserveBalances)
                    .HasColumnName("LOC_ExcludeReserveBalances")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LocMaintenanceFeeAmount)
                    .HasColumnType("money")
                    .HasColumnName("LOC_MaintenanceFeeAmount");

                entity.Property(e => e.LocMaintenanceFeeAssessInt)
                    .HasColumnName("LOC_MaintenanceFeeAssessInt")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LocMaintenanceFeeFreq).HasColumnName("LOC_MaintenanceFeeFreq");

                entity.Property(e => e.LocMaintenanceFeeNextDue)
                    .HasColumnType("datetime")
                    .HasColumnName("LOC_MaintenanceFeeNextDue");

                entity.Property(e => e.LocPayAmountMethod).HasColumnName("LOC_PayAmountMethod");

                entity.Property(e => e.LocPayAmountValue)
                    .HasColumnType("money")
                    .HasColumnName("LOC_PayAmountValue");

                entity.Property(e => e.LocRepaymentPeriod).HasColumnName("LOC_RepaymentPeriod");

                entity.Property(e => e.LocUseDrawFee)
                    .HasColumnName("LOC_UseDrawFee")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LocUseDrawMaximum)
                    .HasColumnName("LOC_UseDrawMaximum")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LocUseMaintenanceFee)
                    .HasColumnName("LOC_UseMaintenanceFee")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.LosloanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LOSLoanRecID");

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.NegAmortToInterest).HasDefaultValueSql("((0))");

                entity.Property(e => e.NextDueDate).HasColumnType("datetime");

                entity.Property(e => e.NextRevision).HasColumnType("datetime");

                entity.Property(e => e.NoteRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.OrigBal).HasColumnType("money");

                entity.Property(e => e.OrigVendorRecId)
                    .HasMaxLength(32)
                    .HasColumnName("OrigVendorRecID");

                entity.Property(e => e.PaidOffDate).HasColumnType("datetime");

                entity.Property(e => e.PaidToDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.PlaceOnHold).HasDefaultValueSql("((0))");

                entity.Property(e => e.PmtFreq).HasMaxLength(15);

                entity.Property(e => e.PmtImpound).HasColumnType("money");

                entity.Property(e => e.PmtPi)
                    .HasColumnType("money")
                    .HasColumnName("PmtPI");

                entity.Property(e => e.PmtReserve).HasColumnType("money");

                entity.Property(e => e.PointsPaid1098).HasColumnType("money");

                entity.Property(e => e.PostMaturity).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrepayExp).HasColumnType("datetime");

                entity.Property(e => e.PrepayLenderPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PrepayOtherRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PrepayOtherRecID");

                entity.Property(e => e.PrepayPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PrepayVendorPct).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PrinBal).HasColumnType("money");

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.Respa)
                    .HasColumnName("RESPA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.Section32).HasDefaultValueSql("((0))");

                entity.Property(e => e.Section4970).HasDefaultValueSql("((0))");

                entity.Property(e => e.Send1098).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendLateNotices).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendPaymentReceipt).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendPaymentStatement).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoldRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.Tintype).HasColumnName("TINType");

                entity.Property(e => e.UnearnedDisc).HasColumnType("money");

                entity.Property(e => e.UnpaidIntRateValue).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.UnpaidInterest).HasColumnType("money");

                entity.Property(e => e.UnpaidLateCharges).HasColumnType("money");

                entity.Property(e => e.Use30DayMonths).HasDefaultValueSql("((0))");

                entity.Property(e => e.Use365DailyRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.UseSoldRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.UseUnpaidInterest).HasDefaultValueSql("((0))");

                entity.Property(e => e.WpcDisableOnlinePmts)
                    .HasColumnName("WPC_DisableOnlinePmts")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WpcPin)
                    .HasMaxLength(10)
                    .HasColumnName("WPC_PIN");

                entity.Property(e => e.WpcPublish)
                    .HasColumnName("WPC_Publish")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Xml).HasColumnName("XML");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<TdsLoanHistory>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Loan_History_RecID");

                entity.ToTable("TDS Loan History");

                entity.HasIndex(e => e.DateDue, "IX_TDS_Loan_History_DateDue");

                entity.HasIndex(e => e.DateRec, "IX_TDS_Loan_History_DateRec");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_Loan_History_LoanRecID");

                entity.HasIndex(e => e.NsfsourceRecId, "IX_TDS_Loan_History_NSFSourceRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AchBatchNumber)
                    .HasMaxLength(7)
                    .HasColumnName("ACH_BatchNumber");

                entity.Property(e => e.AchTraceNumber)
                    .HasMaxLength(22)
                    .HasColumnName("ACH_TraceNumber");

                entity.Property(e => e.AchTransNumber)
                    .HasMaxLength(8)
                    .HasColumnName("ACH_TransNumber");

                entity.Property(e => e.AchTransmissionDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACH_Transmission_DateTime");

                entity.Property(e => e.DateDue).HasColumnType("datetime");

                entity.Property(e => e.DateRec).HasColumnType("datetime");

                entity.Property(e => e.ElectronicPaymentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ElectronicPaymentRecID");

                entity.Property(e => e.GroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupRecID");

                entity.Property(e => e.IsProrate).HasDefaultValueSql("((0))");

                entity.Property(e => e.LateCharge).HasColumnType("money");

                entity.Property(e => e.LoanBalance).HasColumnType("money");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.NsfsourceRecId)
                    .HasMaxLength(32)
                    .HasColumnName("NSFSourceRecID");

                entity.Property(e => e.OldAchNextDebitDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_AchNextDebitDate");

                entity.Property(e => e.OldCcraccountStatus)
                    .HasMaxLength(2)
                    .HasColumnName("Old_CCRAccountStatus");

                entity.Property(e => e.OldCcrdateClose)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_CCRDateClose");

                entity.Property(e => e.OldNextDueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_NextDueDate");

                entity.Property(e => e.OldPaidOffDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_PaidOffDate");

                entity.Property(e => e.OldPaidToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_PaidToDate");

                entity.Property(e => e.PaidTo).HasColumnType("datetime");

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.SourceApp).HasMaxLength(20);

                entity.Property(e => e.SourceTyp).HasMaxLength(6);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.ToBrokerFee).HasColumnType("money");

                entity.Property(e => e.ToChargesInt).HasColumnType("money");

                entity.Property(e => e.ToChargesPrin).HasColumnType("money");

                entity.Property(e => e.ToCurrentBill).HasColumnType("money");

                entity.Property(e => e.ToDefaultInterest).HasColumnType("money");

                entity.Property(e => e.ToImpound).HasColumnType("money");

                entity.Property(e => e.ToInterest).HasColumnType("money");

                entity.Property(e => e.ToLateCharge).HasColumnType("money");

                entity.Property(e => e.ToLenderFee).HasColumnType("money");

                entity.Property(e => e.ToOtherPayments).HasColumnType("money");

                entity.Property(e => e.ToOtherTaxFree).HasColumnType("money");

                entity.Property(e => e.ToOtherTaxable).HasColumnType("money");

                entity.Property(e => e.ToPastDue).HasColumnType("money");

                entity.Property(e => e.ToPrepay).HasColumnType("money");

                entity.Property(e => e.ToPrincipal).HasColumnType("money");

                entity.Property(e => e.ToReserve).HasColumnType("money");

                entity.Property(e => e.ToUnearnedDiscount).HasColumnType("money");

                entity.Property(e => e.ToUnpaidInterest).HasColumnType("money");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<TdsLocbilling>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_LOCBilling_RecID");

                entity.ToTable("TDS LOCBilling");

                entity.HasIndex(e => e.ParentRecId, "IX_TDS_LOCBilling_ParentRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AdditionalDailyAmount).HasColumnType("money");

                entity.Property(e => e.Apr)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("APR");

                entity.Property(e => e.AutoPayFromReserve).HasColumnType("money");

                entity.Property(e => e.AverageDailyBalance).HasColumnType("money");

                entity.Property(e => e.BalanceBeg).HasColumnType("money");

                entity.Property(e => e.BalanceEnd).HasColumnType("money");

                entity.Property(e => e.BillBegDate).HasColumnType("datetime");

                entity.Property(e => e.BillEndDate).HasColumnType("datetime");

                entity.Property(e => e.ChargesGroupRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ChargesGroupRecID");

                entity.Property(e => e.CurrentPayment).HasColumnType("money");

                entity.Property(e => e.DailyRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.DefaultRateUsed).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeferredAmount).HasColumnType("money");

                entity.Property(e => e.FinanceCharge).HasColumnType("money");

                entity.Property(e => e.FinanceChargeRecId)
                    .HasMaxLength(32)
                    .HasColumnName("FinanceChargeRecID");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupID");

                entity.Property(e => e.HighestDailyBalance).HasColumnType("money");

                entity.Property(e => e.ImpoundPayment).HasColumnType("money");

                entity.Property(e => e.LateChargeAmount).HasColumnType("money");

                entity.Property(e => e.LateChargeRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LateChargeRecID");

                entity.Property(e => e.LowestDailyBalance).HasColumnType("money");

                entity.Property(e => e.MaintenanceFeeAmount).HasColumnType("money");

                entity.Property(e => e.NextBillDefaultInterestAdj).HasColumnType("money");

                entity.Property(e => e.OldAchDebitAmount)
                    .HasColumnType("money")
                    .HasColumnName("Old_ACH_DebitAmount");

                entity.Property(e => e.OldLocbilledToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_LOCBilledToDate");

                entity.Property(e => e.OldLocmaintenanceFeeNextDue)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_LOCMaintenanceFeeNextDue");

                entity.Property(e => e.OldNextDueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_NextDueDate");

                entity.Property(e => e.OldPaidToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_PaidToDate");

                entity.Property(e => e.OldPmtPi)
                    .HasColumnType("money")
                    .HasColumnName("Old_PmtPI");

                entity.Property(e => e.OtherPayment).HasColumnType("money");

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.PastDuePayment).HasColumnType("money");

                entity.Property(e => e.PaymentDueDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentPi)
                    .HasColumnType("money")
                    .HasColumnName("PaymentPI");

                entity.Property(e => e.ReservePayment).HasColumnType("money");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.ThisBillDefaultInterestAdj).HasColumnType("money");

                entity.Property(e => e.ThisBillDefaultInterestAdjRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ThisBillDefaultInterestAdjRecID");

                entity.Property(e => e.TotalCharges).HasColumnType("money");

                entity.Property(e => e.TotalCredits).HasColumnType("money");
            });

            modelBuilder.Entity<TdsModification>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Modifications_RecID");

                entity.ToTable("TDS Modifications");

                entity.HasIndex(e => e.AdjustmentDate, "IX_TDS_Modifications_AdjustmentDate");

                entity.HasIndex(e => e.ParentRecId, "IX_TDS_Modifications_ParentRecID");

                entity.HasIndex(e => e.Sequence, "IX_TDS_Modifications_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AdjustmentDate).HasColumnType("datetime");

                entity.Property(e => e.AppliedDate).HasColumnType("datetime");

                entity.Property(e => e.DefaultRateStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.FullyAmortizedPi)
                    .HasColumnType("money")
                    .HasColumnName("FullyAmortizedPI");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(32)
                    .HasColumnName("GroupID");

                entity.Property(e => e.IndexRecId)
                    .HasMaxLength(32)
                    .HasColumnName("IndexRecID");

                entity.Property(e => e.InterestOnlyPi)
                    .HasColumnType("money")
                    .HasColumnName("InterestOnlyPI");

                entity.Property(e => e.IsInterestOnly).HasDefaultValueSql("((0))");

                entity.Property(e => e.LetterSentDate).HasColumnType("datetime");

                entity.Property(e => e.NewCarryover)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("New_Carryover");

                entity.Property(e => e.NewIndexRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("New_IndexRate");

                entity.Property(e => e.NewNextPaymentAdj)
                    .HasColumnType("datetime")
                    .HasColumnName("New_NextPaymentAdj");

                entity.Property(e => e.NewNextRateChange)
                    .HasColumnType("datetime")
                    .HasColumnName("New_NextRateChange");

                entity.Property(e => e.NewNextRecastDate)
                    .HasColumnType("datetime")
                    .HasColumnName("New_NextRecastDate");

                entity.Property(e => e.NewNoteRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("New_NoteRate");

                entity.Property(e => e.NewPaymentAmount)
                    .HasColumnType("money")
                    .HasColumnName("New_PaymentAmount");

                entity.Property(e => e.NewPaymentImpound)
                    .HasColumnType("money")
                    .HasColumnName("New_PaymentImpound");

                entity.Property(e => e.NewPaymentPi)
                    .HasColumnType("money")
                    .HasColumnName("New_PaymentPI");

                entity.Property(e => e.NewPaymentReserve)
                    .HasColumnType("money")
                    .HasColumnName("New_PaymentReserve");

                entity.Property(e => e.NewSoldRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("New_SoldRate");

                entity.Property(e => e.NotifyBorrower).HasDefaultValueSql("((0))");

                entity.Property(e => e.OldAmortType).HasColumnName("Old_AmortType");

                entity.Property(e => e.OldCarryoverAmount)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_CarryoverAmount");

                entity.Property(e => e.OldCarryoverEnabled)
                    .HasColumnName("Old_CarryoverEnabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OldCeiling)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_Ceiling");

                entity.Property(e => e.OldFloor)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_Floor");

                entity.Property(e => e.OldIndexRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_IndexRate");

                entity.Property(e => e.OldLookBackDays).HasColumnName("Old_LookBackDays");

                entity.Property(e => e.OldMargin)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_Margin");

                entity.Property(e => e.OldMaturityDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_MaturityDate");

                entity.Property(e => e.OldNegAmortCap)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_NegAmortCap");

                entity.Property(e => e.OldNoteRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_NoteRate");

                entity.Property(e => e.OldNoticeLeadDays).HasColumnName("Old_NoticeLeadDays");

                entity.Property(e => e.OldOriginalBalance)
                    .HasColumnType("money")
                    .HasColumnName("Old_OriginalBalance");

                entity.Property(e => e.OldPaymentAdjustment)
                    .HasColumnName("Old_PaymentAdjustment")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OldPaymentAmount)
                    .HasColumnType("money")
                    .HasColumnName("Old_PaymentAmount");

                entity.Property(e => e.OldPaymentCap)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_PaymentCap");

                entity.Property(e => e.OldPaymentChangeFreq).HasColumnName("Old_PaymentChangeFreq");

                entity.Property(e => e.OldPaymentChangeNext)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_PaymentChangeNext");

                entity.Property(e => e.OldPaymentImpound)
                    .HasColumnType("money")
                    .HasColumnName("Old_PaymentImpound");

                entity.Property(e => e.OldPaymentPi)
                    .HasColumnType("money")
                    .HasColumnName("Old_PaymentPI");

                entity.Property(e => e.OldPaymentReserve)
                    .HasColumnType("money")
                    .HasColumnName("Old_PaymentReserve");

                entity.Property(e => e.OldPrincipalBalance)
                    .HasColumnType("money")
                    .HasColumnName("Old_PrincipalBalance");

                entity.Property(e => e.OldRateChangeFreq).HasColumnName("Old_RateChangeFreq");

                entity.Property(e => e.OldRateChangeNext)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_RateChangeNext");

                entity.Property(e => e.OldRateFirstChgActive)
                    .HasColumnName("Old_RateFirstChgActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OldRateMaxCap)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_RateMaxCap");

                entity.Property(e => e.OldRateMinCap)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_RateMinCap");

                entity.Property(e => e.OldRateRoundFactor)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_RateRoundFactor");

                entity.Property(e => e.OldRateRounding).HasColumnName("Old_RateRounding");

                entity.Property(e => e.OldRecastFreq).HasColumnName("Old_RecastFreq");

                entity.Property(e => e.OldRecastNextDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_RecastNextDate");

                entity.Property(e => e.OldRecastPayment)
                    .HasColumnName("Old_RecastPayment")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OldRecastStopDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_RecastStopDate");

                entity.Property(e => e.OldRecastToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Old_RecastToDate");

                entity.Property(e => e.OldSendRateChangeNotice)
                    .HasColumnName("Old_SendRateChangeNotice")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OldSoldRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("Old_SoldRate");

                entity.Property(e => e.OldUseSoldRate)
                    .HasColumnName("Old_UseSoldRate")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.PaymentAdjDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentWasRecasted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProjectedBalance).HasColumnType("money");

                entity.Property(e => e.RateChangeDate).HasColumnType("datetime");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsOption>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Options_RecID");

                entity.ToTable("TDS Options");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccrueInterestOnChargesThroughToday).HasDefaultValueSql("((0))");

                entity.Property(e => e.AccrueInterestOnPayoffDate).HasDefaultValueSql("((0))");

                entity.Property(e => e.ArmnoticeName)
                    .HasMaxLength(255)
                    .HasColumnName("ARMNoticeName");

                entity.Property(e => e.Armrespa1noticeName)
                    .HasMaxLength(255)
                    .HasColumnName("ARMRESPA1NoticeName");

                entity.Property(e => e.Armrespa2noticeName)
                    .HasMaxLength(255)
                    .HasColumnName("ARMRESPA2NoticeName");

                entity.Property(e => e.AutoPayCharges)
                    .HasColumnName("AutoPay_Charges")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayChargesAllOrNone)
                    .HasColumnName("AutoPay_ChargesAllOrNone")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayChargesCompanyFirst)
                    .HasColumnName("AutoPay_ChargesCompanyFirst")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayExcessToPrincipal)
                    .HasColumnName("AutoPay_ExcessToPrincipal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayGroupPayments)
                    .HasColumnName("AutoPay_GroupPayments")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayLateCharges)
                    .HasColumnName("AutoPay_LateCharges")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayNegPrinBalToBorrower)
                    .HasColumnName("AutoPay_NegPrinBal_ToBorrower")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayNegPrinBalToPrincipal)
                    .HasColumnName("AutoPay_NegPrinBal_ToPrincipal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayNegPrinBalToReserve)
                    .HasColumnName("AutoPay_NegPrinBal_ToReserve")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayShortPayment)
                    .HasColumnName("AutoPay_ShortPayment")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayShortPaymentAccruedLateCharge)
                    .HasColumnName("AutoPay_ShortPayment_AccruedLateCharge")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayShortPaymentImpound)
                    .HasColumnName("AutoPay_ShortPayment_Impound")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayShortPaymentOtherPayments)
                    .HasColumnName("AutoPay_ShortPayment_OtherPayments")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayShortPaymentPi)
                    .HasColumnName("AutoPay_ShortPayment_PI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayShortPaymentReserve)
                    .HasColumnName("AutoPay_ShortPayment_Reserve")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayShortPaymentUnpaidCharges)
                    .HasColumnName("AutoPay_ShortPayment_UnpaidCharges")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayShortPaymentUnpaidInterest)
                    .HasColumnName("AutoPay_ShortPayment_UnpaidInterest")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoPayShortPaymentUnpaidLateCharges)
                    .HasColumnName("AutoPay_ShortPayment_UnpaidLateCharges")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BalloonNoticeName).HasMaxLength(255);

                entity.Property(e => e.BeneStatementName).HasMaxLength(255);

                entity.Property(e => e.BorrAccountDigits).HasColumnName("Borr_Account_Digits");

                entity.Property(e => e.BorrAccountNumber).HasColumnName("Borr_Account_Number");

                entity.Property(e => e.BorrAccountNumbering)
                    .HasColumnName("Borr_Account_Numbering")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BorrAccountPrefix)
                    .HasMaxLength(1)
                    .HasColumnName("Borr_Account_Prefix");

                entity.Property(e => e.BorrAccountSuffix)
                    .HasMaxLength(1)
                    .HasColumnName("Borr_Account_Suffix");

                entity.Property(e => e.BorrAccountZeroFill)
                    .HasColumnName("Borr_Account_ZeroFill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompanyRecId)
                    .HasMaxLength(32)
                    .HasColumnName("CompanyRecID");

                entity.Property(e => e.ConprintCompanyOnCheck)
                    .HasColumnName("CONPrintCompanyOnCheck")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ContrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("CONTrustAccountRecID");

                entity.Property(e => e.EscrowAnalysisDeficiencyLessThanOnePaymentDoNothing)
                    .HasColumnName("EscrowAnalysis_Deficiency_LessThanOnePayment_DoNothing")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisDeficiencyLessThanOnePaymentNumberOfMonths).HasColumnName("EscrowAnalysis_Deficiency_LessThanOnePayment_NumberOfMonths");

                entity.Property(e => e.EscrowAnalysisDeficiencyLessThanOnePaymentRepayInMonths)
                    .HasColumnName("EscrowAnalysis_Deficiency_LessThanOnePayment_RepayInMonths")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisDeficiencyLessThanOnePaymentRepayInThirtyDays)
                    .HasColumnName("EscrowAnalysis_Deficiency_LessThanOnePayment_RepayInThirtyDays")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisDeficiencyMoreThanOnePaymentDoNothing)
                    .HasColumnName("EscrowAnalysis_Deficiency_MoreThanOnePayment_DoNothing")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisDeficiencyMoreThanOnePaymentNumberOfMonths).HasColumnName("EscrowAnalysis_Deficiency_MoreThanOnePayment_NumberOfMonths");

                entity.Property(e => e.EscrowAnalysisDeficiencyMoreThanOnePaymentRepayInMonths)
                    .HasColumnName("EscrowAnalysis_Deficiency_MoreThanOnePayment_RepayInMonths")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisExcludeBorrowersInForeclosure)
                    .HasColumnName("EscrowAnalysis_ExcludeBorrowersInForeclosure")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisExcludeBorrowersOnHold)
                    .HasColumnName("EscrowAnalysis_ExcludeBorrowersOnHold")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisExcludeLateBorrowers)
                    .HasColumnName("EscrowAnalysis_ExcludeLateBorrowers")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisNumberOfPaymentsAsCushion).HasColumnName("EscrowAnalysis_NumberOfPaymentsAsCushion");

                entity.Property(e => e.EscrowAnalysisShortageLessThanOnePaymentDoNothing)
                    .HasColumnName("EscrowAnalysis_Shortage_LessThanOnePayment_DoNothing")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisShortageLessThanOnePaymentRepayInAyear)
                    .HasColumnName("EscrowAnalysis_Shortage_LessThanOnePayment_RepayInAYear")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisShortageLessThanOnePaymentRepayInThirtyDays)
                    .HasColumnName("EscrowAnalysis_Shortage_LessThanOnePayment_RepayInThirtyDays")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisShortageMoreThanOnePaymentDoNothing)
                    .HasColumnName("EscrowAnalysis_Shortage_MoreThanOnePayment_DoNothing")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisShortageMoreThanOnePaymentRepay)
                    .HasColumnName("EscrowAnalysis_Shortage_MoreThanOnePayment_Repay")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EscrowAnalysisSurplusRefundToBorrower)
                    .HasColumnName("EscrowAnalysis_Surplus_RefundToBorrower")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Gstrate)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("GSTRate");

                entity.Property(e => e.Gstuse)
                    .HasColumnName("GSTUse")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GstvendorRecId)
                    .HasMaxLength(32)
                    .HasColumnName("GSTVendorRecID");

                entity.Property(e => e.GtmnoticeName)
                    .HasMaxLength(255)
                    .HasColumnName("GTMNoticeName");

                entity.Property(e => e.HoldAchdays).HasColumnName("HoldACHDays");

                entity.Property(e => e.HudnoticeDays).HasColumnName("HUDNoticeDays");

                entity.Property(e => e.HudnoticeName)
                    .HasMaxLength(255)
                    .HasColumnName("HUDNoticeName");

                entity.Property(e => e.InsExpNoticeName).HasMaxLength(255);

                entity.Property(e => e.LateNoticeName).HasMaxLength(255);

                entity.Property(e => e.LenderFilterIsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.LndrAccountDigits).HasColumnName("Lndr_Account_Digits");

                entity.Property(e => e.LndrAccountNumber).HasColumnName("Lndr_Account_Number");

                entity.Property(e => e.LndrAccountNumbering)
                    .HasColumnName("Lndr_Account_Numbering")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LndrAccountPrefix)
                    .HasMaxLength(1)
                    .HasColumnName("Lndr_Account_Prefix");

                entity.Property(e => e.LndrAccountSuffix)
                    .HasMaxLength(1)
                    .HasColumnName("Lndr_Account_Suffix");

                entity.Property(e => e.LndrAccountZeroFill)
                    .HasColumnName("Lndr_Account_ZeroFill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanFilterIsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nsfcharge)
                    .HasColumnType("money")
                    .HasColumnName("NSFCharge");

                entity.Property(e => e.NsfdeleteChecks)
                    .HasColumnName("NSFDeleteChecks")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NsfnoticeName)
                    .HasMaxLength(255)
                    .HasColumnName("NSFNoticeName");

                entity.Property(e => e.PayoffNoticeFeeAmt1).HasColumnType("money");

                entity.Property(e => e.PayoffNoticeFeeAmt2).HasColumnType("money");

                entity.Property(e => e.PayoffNoticeFeeAmt3).HasColumnType("money");

                entity.Property(e => e.PayoffNoticeFeeAmt4).HasColumnType("money");

                entity.Property(e => e.PayoffNoticeFeeAmt5).HasColumnType("money");

                entity.Property(e => e.PayoffNoticeFeeDesc1).HasMaxLength(40);

                entity.Property(e => e.PayoffNoticeFeeDesc2).HasMaxLength(40);

                entity.Property(e => e.PayoffNoticeFeeDesc3).HasMaxLength(40);

                entity.Property(e => e.PayoffNoticeFeeDesc4).HasMaxLength(40);

                entity.Property(e => e.PayoffNoticeFeeDesc5).HasMaxLength(40);

                entity.Property(e => e.PayoffNoticeName).HasMaxLength(255);

                entity.Property(e => e.PrintChargeDescOnChecks).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintChargeNotesOnChecks).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintDetailOnBrokerCheck).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintLenderChecks).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintPortfolioYieldOnChecks).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintYtdInterestOnChecks).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReinstmtNoticeName).HasMaxLength(255);

                entity.Property(e => e.ReportInterestLessFees).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReportNetRatePayment).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendInsExpNotice1).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendInsExpNotice2).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendInsExpNotice3).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendLateNotice1).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendLateNotice2).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendLateNotice3).HasDefaultValueSql("((0))");

                entity.Property(e => e.SendLateNotice4).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrustAccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TrustAccountRecID");

                entity.Property(e => e.UseCompanyLogo).HasDefaultValueSql("((0))");

                entity.Property(e => e.VndrAccountDigits).HasColumnName("Vndr_Account_Digits");

                entity.Property(e => e.VndrAccountNumber).HasColumnName("Vndr_Account_Number");

                entity.Property(e => e.VndrAccountNumbering)
                    .HasColumnName("Vndr_Account_Numbering")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VndrAccountPrefix)
                    .HasMaxLength(1)
                    .HasColumnName("Vndr_Account_Prefix");

                entity.Property(e => e.VndrAccountSuffix)
                    .HasMaxLength(1)
                    .HasColumnName("Vndr_Account_Suffix");

                entity.Property(e => e.VndrAccountZeroFill)
                    .HasColumnName("Vndr_Account_ZeroFill")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TdsProperty>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Properties_RecID");

                entity.ToTable("TDS Properties");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_Properties_LoanRecID");

                entity.HasIndex(e => e.Primary, "IX_TDS_Properties_Primary");

                entity.HasIndex(e => e.PropertyType, "IX_TDS_Properties_PropertyType");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Apn)
                    .HasMaxLength(30)
                    .HasColumnName("APN");

                entity.Property(e => e.AppraisalDate).HasColumnType("datetime");

                entity.Property(e => e.AppraiserFmv)
                    .HasColumnType("money")
                    .HasColumnName("AppraiserFMV");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.County).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(64);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.Ltv)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("LTV");

                entity.Property(e => e.Occupancy).HasMaxLength(30);

                entity.Property(e => e.PledgedEquity).HasColumnType("money");

                entity.Property(e => e.Primary).HasDefaultValueSql("((0))");

                entity.Property(e => e.PropertyType).HasMaxLength(30);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.ThomasMap).HasMaxLength(15);

                entity.Property(e => e.ZipCode).HasMaxLength(10);

                entity.Property(e => e.Zoning).HasMaxLength(15);
            });

            modelBuilder.Entity<TdsVoucher>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Vouchers_RecID");

                entity.ToTable("TDS Vouchers");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_Vouchers_LoanRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.IsDiscretionary).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsHold).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPaid).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.PayDate).HasColumnType("datetime");

                entity.Property(e => e.PayeeRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PayeeRecID");

                entity.Property(e => e.Reference).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TdsWrap>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TDS_Wraps_RecID");

                entity.ToTable("TDS Wraps");

                entity.HasIndex(e => e.Active, "IX_TDS_Wraps_Active");

                entity.HasIndex(e => e.LoanRecId, "IX_TDS_Wraps_LoanRecID");

                entity.HasIndex(e => e.PaidByLender, "IX_TDS_Wraps_PaidByLender");

                entity.HasIndex(e => e.VendorRecId, "IX_TDS_Wraps_VendorRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.LoanRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanRecID");

                entity.Property(e => e.PaidByLender).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayAmount).HasColumnType("money");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.VendorRecId)
                    .HasMaxLength(32)
                    .HasColumnName("VendorRecID");
            });

            modelBuilder.Entity<TfaAccount>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TFA_Accounts_RecID");

                entity.ToTable("TFA Accounts");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountName).HasMaxLength(64);

                entity.Property(e => e.AchUse)
                    .HasColumnName("ACH_Use")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.BankAccount).HasMaxLength(17);

                entity.Property(e => e.BankAddress).HasMaxLength(255);

                entity.Property(e => e.BankName).HasMaxLength(64);

                entity.Property(e => e.BankRoutingNumber).HasMaxLength(9);

                entity.Property(e => e.CurrencyCode).HasMaxLength(3);

                entity.Property(e => e.IsInterest).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayIntRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.ReconClosingBalance).HasColumnType("money");

                entity.Property(e => e.ReconClosingDate).HasColumnType("datetime");

                entity.Property(e => e.ReconDate).HasColumnType("datetime");

                entity.Property(e => e.ReconOpeningBalance).HasColumnType("money");

                entity.Property(e => e.ReconOpeningDate).HasColumnType("datetime");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<TfaClient>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TFA_Clients_RecID");

                entity.ToTable("TFA Clients");

                entity.HasIndex(e => new { e.Account, e.OwnerType }, "IX_TFA_Clients_Account_OwnerType")
                    .IsUnique();

                entity.HasIndex(e => e.OwnerRecId, "IX_TFA_Clients_OwnerRecID");

                entity.HasIndex(e => e.OwnerType, "IX_TFA_Clients_OwnerType");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.OwnerRecId)
                    .HasMaxLength(32)
                    .HasColumnName("OwnerRecID");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.PropertyCity).HasMaxLength(50);

                entity.Property(e => e.PropertyCounty).HasMaxLength(50);

                entity.Property(e => e.PropertyDescription).HasMaxLength(64);

                entity.Property(e => e.PropertyState).HasMaxLength(2);

                entity.Property(e => e.PropertyStreet).HasMaxLength(64);

                entity.Property(e => e.PropertyZipCode).HasMaxLength(10);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<TfaOption>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TFA_Options_RecID");

                entity.ToTable("TFA Options");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.PrintCompanyOnCheck).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TfaPayee>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TFA_Payees_RecID");

                entity.ToTable("TFA Payees");

                entity.HasIndex(e => e.Account, "IX_TFA_Payees_Account")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<TfaPayer>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TFA_Payers_RecID");

                entity.ToTable("TFA Payers");

                entity.HasIndex(e => e.Account, "IX_TFA_Payers_Account")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.ByLastName).HasMaxLength(64);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .HasColumnName("MI");

                entity.Property(e => e.PhoneCell).HasMaxLength(20);

                entity.Property(e => e.PhoneFax).HasMaxLength(20);

                entity.Property(e => e.PhoneHome).HasMaxLength(20);

                entity.Property(e => e.PhoneWork).HasMaxLength(20);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.SortName).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Tin)
                    .HasMaxLength(20)
                    .HasColumnName("TIN");

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<TfaRecon>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TFA_Recons_RecID");

                entity.ToTable("TFA Recons");

                entity.HasIndex(e => new { e.AccountRecId, e.ReconDate }, "IX_TFA_Recons_AccountRecID_ReconDate")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountBalance).HasColumnType("money");

                entity.Property(e => e.AccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("AccountRecID");

                entity.Property(e => e.BankClosingBalance).HasColumnType("money");

                entity.Property(e => e.BankClosingDate).HasColumnType("datetime");

                entity.Property(e => e.BankOpeningBalance).HasColumnType("money");

                entity.Property(e => e.BankOpeningDate).HasColumnType("datetime");

                entity.Property(e => e.OutstandingChecks).HasColumnType("money");

                entity.Property(e => e.OutstandingDeposits).HasColumnType("money");

                entity.Property(e => e.ReconDate).HasColumnType("datetime");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TfaSplit>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TFA_Splits_RecID");

                entity.ToTable("TFA Splits");

                entity.HasIndex(e => e.AccountRecId, "IX_TFA_Splits_AccountRecID");

                entity.HasIndex(e => e.Category, "IX_TFA_Splits_Category");

                entity.HasIndex(e => e.ClientRecId, "IX_TFA_Splits_ClientRecID");

                entity.HasIndex(e => e.TransRecId, "IX_TFA_Splits_TransRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("AccountRecID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.ClientRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ClientRecID");

                entity.Property(e => e.Memo).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TransRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TransRecID");
            });

            modelBuilder.Entity<TfaStub>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TFA_Stubs_RecID");

                entity.ToTable("TFA Stubs");

                entity.HasIndex(e => e.TransRecId, "IX_TFA_Stubs_TransRecID");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("AccountRecID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Text).HasMaxLength(255);

                entity.Property(e => e.TransRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TransRecID");
            });

            modelBuilder.Entity<TfaTransaction>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_TFA_Transactions_RecID");

                entity.ToTable("TFA Transactions");

                entity.HasIndex(e => e.AccountRecId, "IX_TFA_Transactions_AccountRecID");

                entity.HasIndex(e => e.DateDeposited, "IX_TFA_Transactions_DateDeposited");

                entity.HasIndex(e => e.DepositGrp, "IX_TFA_Transactions_DepositGrp");

                entity.HasIndex(e => e.SortField, "IX_TFA_Transactions_SortField");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AccountRecId)
                    .HasMaxLength(32)
                    .HasColumnName("AccountRecID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.ClearStatus).HasMaxLength(1);

                entity.Property(e => e.DateDeposited).HasColumnType("datetime");

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.DepositGrp).HasMaxLength(32);

                entity.Property(e => e.IsAch)
                    .HasColumnName("IsACH")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LinkedRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LinkedRecID");

                entity.Property(e => e.Memo).HasMaxLength(255);

                entity.Property(e => e.PayAccount).HasMaxLength(10);

                entity.Property(e => e.PayAddress).HasMaxLength(255);

                entity.Property(e => e.PayName).HasMaxLength(64);

                entity.Property(e => e.PayRecId)
                    .HasMaxLength(32)
                    .HasColumnName("PayRecID");

                entity.Property(e => e.PayeeBox).HasMaxLength(255);

                entity.Property(e => e.ReconRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ReconRecID");

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.SortField).HasMaxLength(66);

                entity.Property(e => e.SourceGrp).HasMaxLength(32);

                entity.Property(e => e.SourceRef).HasMaxLength(10);

                entity.Property(e => e.StubMemo).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<UdfField>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_UDF_Fields_RecID");

                entity.ToTable("UDF Fields");

                entity.HasIndex(e => new { e.Name, e.OwnerType }, "IX_UDF_Fields_Name_OwnerType")
                    .IsUnique();

                entity.HasIndex(e => e.Sequence, "IX_UDF_Fields_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Format).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TabRecId)
                    .HasMaxLength(32)
                    .HasColumnName("TabRecID");
            });

            modelBuilder.Entity<UdfTab>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_UDF_Tabs_RecID");

                entity.ToTable("UDF Tabs");

                entity.HasIndex(e => new { e.Name, e.OwnerType }, "IX_UDF_Tabs_Name_OwnerType")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<UdfValue>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_UDF_Values_RecID");

                entity.ToTable("UDF Values");

                entity.HasIndex(e => e.OwnerRecId, "IX_UDF_Values_OwnerRecID");

                entity.HasIndex(e => e.ParentRecId, "IX_UDF_Values_ParentRecID");

                entity.HasIndex(e => new { e.ParentRecId, e.OwnerRecId }, "IX_UDF_Values_ParentRecID_OwnerRecID")
                    .IsUnique();

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.OwnerRecId)
                    .HasMaxLength(32)
                    .HasColumnName("OwnerRecID");

                entity.Property(e => e.ParentRecId)
                    .HasMaxLength(32)
                    .HasColumnName("ParentRecID");

                entity.Property(e => e.Value).HasMaxLength(255);
            });

            modelBuilder.Entity<WpcFaq>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_FAQ_RecID");

                entity.ToTable("WPC FAQ");

                entity.HasIndex(e => e.Sequence, "IX_WPC_FAQ_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Question).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<WpcLoanApplication>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_Loan_Applications_RecID");

                entity.ToTable("WPC Loan Applications");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.DateApplied).HasColumnType("datetime");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastMessageCheckDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OnlineStatus).HasMaxLength(255);

                entity.Property(e => e.StatusDate).HasColumnType("datetime");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Xml).HasColumnName("XML");
            });

            modelBuilder.Entity<WpcLoanApplicationDefaultDocument>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_Loan_Application_Default_Documents_RecID");

                entity.ToTable("WPC Loan Application Default Documents");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<WpcLoanApplicationDocument>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_Loan_Application_Documents_RecID");

                entity.ToTable("WPC Loan Application Documents");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FileName).HasMaxLength(50);

                entity.Property(e => e.LoanApplicationRecId)
                    .HasMaxLength(32)
                    .HasColumnName("LoanApplicationRecID");

                entity.Property(e => e.Reason).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<WpcLoanApplicationWorkflow>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_Loan_Application_Workflows_RecID");

                entity.ToTable("WPC Loan Application Workflows");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<WpcMessage>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_Messages_RecID");

                entity.ToTable("WPC Messages");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.OriginatorName).HasMaxLength(255);

                entity.Property(e => e.ReadDateTime).HasColumnType("datetime");

                entity.Property(e => e.ReceivedDateTime).HasColumnType("datetime");

                entity.Property(e => e.RecipientName).HasMaxLength(255);

                entity.Property(e => e.RepliedBy).HasMaxLength(255);

                entity.Property(e => e.RepliedDateTime).HasColumnType("datetime");

                entity.Property(e => e.SentDateTime).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(255);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<WpcNewsEvent>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_NewsEvents_RecID");

                entity.ToTable("WPC NewsEvents");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.DatePublished).HasColumnType("datetime");

                entity.Property(e => e.Heading).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<WpcOffering>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_Offerings_RecID");

                entity.ToTable("WPC Offerings");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.AppraisalDate).HasColumnType("datetime");

                entity.Property(e => e.BalloonPayment).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.DateFirstPublished).HasColumnType("datetime");

                entity.Property(e => e.DateLastPublished).HasColumnType("datetime");

                entity.Property(e => e.FairMarketValue).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.GrossAnnualIncome).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.HeadLine).HasMaxLength(255);

                entity.Property(e => e.IsIncomeProperty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsOwnerOccupied).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPaymentsCurrent).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPrepaymentPenalty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPrivate).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPublish).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanAmount).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.LoanToValue).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.NetAnnualIncome).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.NoteRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PropertyAnnualTaxes).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PropertyCity).HasMaxLength(50);

                entity.Property(e => e.PropertyState).HasMaxLength(2);

                entity.Property(e => e.PropertyStreet).HasMaxLength(64);

                entity.Property(e => e.PropertyUnpaidTaxes).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PropertyZipCode).HasMaxLength(10);

                entity.Property(e => e.Reference).HasMaxLength(10);

                entity.Property(e => e.RegularPayment).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SalesPersonEmail).HasMaxLength(255);

                entity.Property(e => e.SalesPersonFax).HasMaxLength(20);

                entity.Property(e => e.SalesPersonName).HasMaxLength(65);

                entity.Property(e => e.SalesPersonPhone).HasMaxLength(20);

                entity.Property(e => e.SeniorLiens).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SoldRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<WpcOnlinePayment>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_Online_Payments_RecID");

                entity.ToTable("WPC Online Payments");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Account).HasMaxLength(10);

                entity.Property(e => e.AccountNumber).HasMaxLength(4);

                entity.Property(e => e.CcCvv)
                    .HasMaxLength(7)
                    .HasColumnName("CC_CVV");

                entity.Property(e => e.CcMonth)
                    .HasMaxLength(2)
                    .HasColumnName("CC_Month");

                entity.Property(e => e.CcYear)
                    .HasMaxLength(4)
                    .HasColumnName("CC_Year");

                entity.Property(e => e.ConfirmationNumber).HasMaxLength(30);

                entity.Property(e => e.ConvenienceFee).HasColumnType("money");

                entity.Property(e => e.CreditCard).HasMaxLength(4);

                entity.Property(e => e.CustomerFee).HasColumnType("money");

                entity.Property(e => e.DateApplied).HasColumnType("datetime");

                entity.Property(e => e.DateDownloaded).HasColumnType("datetime");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentAmount).HasColumnType("money");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PayorCity).HasMaxLength(50);

                entity.Property(e => e.PayorFirstName).HasMaxLength(50);

                entity.Property(e => e.PayorLastName).HasMaxLength(50);

                entity.Property(e => e.PayorState).HasMaxLength(3);

                entity.Property(e => e.PayorStreet).HasMaxLength(50);

                entity.Property(e => e.PayorZipCode).HasMaxLength(20);

                entity.Property(e => e.RoutingNumber).HasMaxLength(4);

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<WpcProduct>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_Products_RecID");

                entity.ToTable("WPC Products");

                entity.HasIndex(e => e.Sequence, "IX_WPC_Products_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Heading).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<WpcResource>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PK_WPC_Resources_RecID");

                entity.ToTable("WPC Resources");

                entity.HasIndex(e => e.Sequence, "IX_WPC_Resources_Sequence");

                entity.Property(e => e.RecId)
                    .HasMaxLength(32)
                    .HasColumnName("RecID");

                entity.Property(e => e.Heading).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.SysCreatedBy).HasMaxLength(255);

                entity.Property(e => e.SysCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SysTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("URL");
            });
            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}