namespace SrimsOUC.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SrimsContext : DbContext
    {
        public SrimsContext()
            : base("name=SrimsContext")
        {
        }

        public virtual DbSet<AccountBookNumberCount> AccountBookNumberCount { get; set; }
        public virtual DbSet<AllocationT> AllocationT { get; set; }
        public virtual DbSet<Announcement> Announcement { get; set; }
        public virtual DbSet<Award> Award { get; set; }
        public virtual DbSet<AwardDocument> AwardDocument { get; set; }
        public virtual DbSet<AwardWinner> AwardWinner { get; set; }
        public virtual DbSet<Base> Base { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Count> Count { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentModel> DocumentModel { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Expert> Expert { get; set; }
        public virtual DbSet<ExpertAchieveStatistic> ExpertAchieveStatistic { get; set; }
        public virtual DbSet<ExpertInfoHistory> ExpertInfoHistory { get; set; }
        public virtual DbSet<Finance> Finance { get; set; }
        public virtual DbSet<FinanceBak> FinanceBak { get; set; }
        public virtual DbSet<FinanceFundDescend> FinanceFundDescend { get; set; }
        public virtual DbSet<FundAllocation> FundAllocation { get; set; }
        public virtual DbSet<FundAllocationStateHistory> FundAllocationStateHistory { get; set; }
        public virtual DbSet<FundDescend> FundDescend { get; set; }
        public virtual DbSet<FundDescendStateHistory> FundDescendStateHistory { get; set; }
        public virtual DbSet<FundMember> FundMember { get; set; }
        public virtual DbSet<LiberalArtsPaper> LiberalArtsPaper { get; set; }
        public virtual DbSet<LiberalArtsPaperAuthor> LiberalArtsPaperAuthor { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Magazine> Magazine { get; set; }
        public virtual DbSet<MagazineInformation> MagazineInformation { get; set; }
        public virtual DbSet<MagazineOccupation> MagazineOccupation { get; set; }
        public virtual DbSet<MagazineSubjectClass> MagazineSubjectClass { get; set; }
        public virtual DbSet<ManagementFees> ManagementFees { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<NoticeText> NoticeText { get; set; }
        public virtual DbSet<Outsourcing> Outsourcing { get; set; }
        public virtual DbSet<Paper> Paper { get; set; }
        public virtual DbSet<PaperAuthor> PaperAuthor { get; set; }
        public virtual DbSet<PaperIndexed> PaperIndexed { get; set; }
        public virtual DbSet<Patent> Patent { get; set; }
        public virtual DbSet<PatentAgency> PatentAgency { get; set; }
        public virtual DbSet<PatentInventer> PatentInventer { get; set; }
        public virtual DbSet<PayPlanItem> PayPlanItem { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<PerformanceAllocation> PerformanceAllocation { get; set; }
        public virtual DbSet<PerformanceAllocationStateHistory> PerformanceAllocationStateHistory { get; set; }
        public virtual DbSet<PerformanceVoucher> PerformanceVoucher { get; set; }
        public virtual DbSet<PerformanceVoucherStateHistory> PerformanceVoucherStateHistory { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectInfo_Fund> ProjectInfo_Fund { get; set; }
        public virtual DbSet<ProjectInfo_Type> ProjectInfo_Type { get; set; }
        public virtual DbSet<ProjectMember> ProjectMember { get; set; }
        public virtual DbSet<ProjectOut> ProjectOut { get; set; }
        public virtual DbSet<ProjectOutsourcingBudget> ProjectOutsourcingBudget { get; set; }
        public virtual DbSet<ProjectQualityPrincipal> ProjectQualityPrincipal { get; set; }
        public virtual DbSet<ProjectRank> ProjectRank { get; set; }
        public virtual DbSet<ProjectStateHistory> ProjectStateHistory { get; set; }
        public virtual DbSet<ProjectSupportCategory> ProjectSupportCategory { get; set; }
        public virtual DbSet<ProjectSupportField> ProjectSupportField { get; set; }
        public virtual DbSet<ProjectSupportSubField> ProjectSupportSubField { get; set; }
        public virtual DbSet<ProjectType> ProjectType { get; set; }
        public virtual DbSet<Recovery> Recovery { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<Stamp> Stamp { get; set; }
        public virtual DbSet<StampApplication> StampApplication { get; set; }
        public virtual DbSet<StampApplicationFirstAdmin> StampApplicationFirstAdmin { get; set; }
        public virtual DbSet<StampApplicationSecondAdmin> StampApplicationSecondAdmin { get; set; }
        public virtual DbSet<StampApplicationType> StampApplicationType { get; set; }
        public virtual DbSet<StampApplicationTypeGroup> StampApplicationTypeGroup { get; set; }
        public virtual DbSet<StampStateHistory> StampStateHistory { get; set; }
        public virtual DbSet<Stuff> Stuff { get; set; }
        public virtual DbSet<StuffStamp> StuffStamp { get; set; }
        public virtual DbSet<SubjectClassChineseEnglish> SubjectClassChineseEnglish { get; set; }
        public virtual DbSet<SubjectFirstLevel> SubjectFirstLevel { get; set; }
        public virtual DbSet<SubjectSecondLevel> SubjectSecondLevel { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SystemSetting> SystemSetting { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserLockLog> UserLockLog { get; set; }
        public virtual DbSet<UserLoginLog> UserLoginLog { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserRolePermission> UserRolePermission { get; set; }
        public virtual DbSet<View> View { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }
        public virtual DbSet<VoucherOut> VoucherOut { get; set; }
        public virtual DbSet<VoucherStateHistory> VoucherStateHistory { get; set; }
        public virtual DbSet<VoucherT> VoucherT { get; set; }
        public virtual DbSet<ExpertAchieveStatisticIDArray> ExpertAchieveStatisticIDArray { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountBookNumberCount>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<AllocationT>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Announcement>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Award>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Award>()
                .HasMany(e => e.AwardDocument)
                .WithRequired(e => e.Award)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Award>()
                .HasMany(e => e.AwardWinner1)
                .WithRequired(e => e.Award1)
                .HasForeignKey(e => e.AwardID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AwardDocument>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<AwardWinner>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<AwardWinner>()
                .HasMany(e => e.Award)
                .WithOptional(e => e.AwardWinner)
                .HasForeignKey(e => e.FirstWinnerID);

            modelBuilder.Entity<Base>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Contract>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Count>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Award)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.CollegeID);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Expert)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.CollegeID);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Expert1)
                .WithOptional(e => e.Department1)
                .HasForeignKey(e => e.College2ID);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Expert2)
                .WithOptional(e => e.Department2)
                .HasForeignKey(e => e.DepartmentID);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.LiberalArtsPaper)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.CollegeID);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Paper)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.CollegeID);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Patent)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.CollegeID);

            modelBuilder.Entity<Document>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<DocumentModel>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Event>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Expert>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.Base)
                .WithOptional(e => e.Expert)
                .HasForeignKey(e => e.AcademyDirectorID);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.Base1)
                .WithOptional(e => e.Expert1)
                .HasForeignKey(e => e.DirectorID);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.ExpertAchieveStatistic)
                .WithRequired(e => e.Expert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.ExpertInfoHistory)
                .WithRequired(e => e.Expert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.MagazineOccupation)
                .WithRequired(e => e.Expert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.Outsourcing)
                .WithOptional(e => e.Expert)
                .HasForeignKey(e => e.AdderID);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.Project)
                .WithRequired(e => e.Expert)
                .HasForeignKey(e => e.PrincipalID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.Project1)
                .WithOptional(e => e.Expert1)
                .HasForeignKey(e => e.PrincipalDelegateID);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.Project2)
                .WithOptional(e => e.Expert2)
                .HasForeignKey(e => e.PrincipalQualityID);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.ProjectMember)
                .WithRequired(e => e.Expert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.ProjectQualityPrincipal)
                .WithRequired(e => e.Expert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expert>()
                .HasMany(e => e.StampApplication)
                .WithRequired(e => e.Expert)
                .HasForeignKey(e => e.PrincipalID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExpertAchieveStatistic>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ExpertInfoHistory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Finance>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Finance>()
                .HasMany(e => e.FinanceFundDescend)
                .WithRequired(e => e.Finance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FinanceBak>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<FinanceFundDescend>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<FundAllocation>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<FundAllocation>()
                .HasMany(e => e.FundAllocationStateHistory1)
                .WithRequired(e => e.FundAllocation1)
                .HasForeignKey(e => e.FundAllocationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FundAllocation>()
                .HasMany(e => e.Voucher)
                .WithRequired(e => e.FundAllocation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FundAllocationStateHistory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<FundAllocationStateHistory>()
                .HasMany(e => e.FundAllocation)
                .WithOptional(e => e.FundAllocationStateHistory)
                .HasForeignKey(e => e.CurrentStateID);

            modelBuilder.Entity<FundDescend>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<FundDescend>()
                .HasMany(e => e.FinanceFundDescend)
                .WithRequired(e => e.FundDescend)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FundDescend>()
                .HasMany(e => e.FundAllocation)
                .WithRequired(e => e.FundDescend)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FundDescend>()
                .HasMany(e => e.FundDescendStateHistory1)
                .WithRequired(e => e.FundDescend1)
                .HasForeignKey(e => e.FundDescendID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FundDescendStateHistory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<FundDescendStateHistory>()
                .HasMany(e => e.FundDescend)
                .WithOptional(e => e.FundDescendStateHistory)
                .HasForeignKey(e => e.CurrentStateID);

            modelBuilder.Entity<FundMember>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<FundMember>()
                .HasMany(e => e.PerformanceVoucher)
                .WithRequired(e => e.FundMember)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FundMember>()
                .HasMany(e => e.Voucher)
                .WithRequired(e => e.FundMember)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LiberalArtsPaper>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<LiberalArtsPaper>()
                .Property(e => e.Degree)
                .IsFixedLength();

            modelBuilder.Entity<LiberalArtsPaper>()
                .HasMany(e => e.LiberalArtsPaperAuthor)
                .WithRequired(e => e.LiberalArtsPaper)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LiberalArtsPaperAuthor>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Log>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Magazine>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Magazine>()
                .HasMany(e => e.MagazineInformation)
                .WithRequired(e => e.Magazine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Magazine>()
                .HasMany(e => e.MagazineOccupation)
                .WithRequired(e => e.Magazine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Magazine>()
                .HasMany(e => e.MagazineSubjectClass)
                .WithRequired(e => e.Magazine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MagazineInformation>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<MagazineSubjectClass>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ManagementFees>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Message>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<NoticeText>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Outsourcing>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Outsourcing>()
                .HasMany(e => e.ProjectOut)
                .WithRequired(e => e.Outsourcing)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Outsourcing>()
                .HasMany(e => e.ProjectOutsourcingBudget)
                .WithRequired(e => e.Outsourcing)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Paper>()
                .HasMany(e => e.PaperAuthor)
                .WithRequired(e => e.Paper)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paper>()
                .HasMany(e => e.PaperIndexed)
                .WithRequired(e => e.Paper)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaperAuthor>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<PaperIndexed>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Patent>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Patent>()
                .HasMany(e => e.PatentInventer)
                .WithRequired(e => e.Patent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatentAgency>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<PatentAgency>()
                .HasMany(e => e.Patent)
                .WithOptional(e => e.PatentAgency)
                .HasForeignKey(e => e.AgencyID);

            modelBuilder.Entity<PatentInventer>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<PayPlanItem>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Performance>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Performance>()
                .HasMany(e => e.PerformanceAllocation)
                .WithRequired(e => e.Performance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PerformanceAllocation>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<PerformanceAllocation>()
                .HasMany(e => e.PerformanceAllocationStateHistory1)
                .WithRequired(e => e.PerformanceAllocation1)
                .HasForeignKey(e => e.PerformanceAllocationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PerformanceAllocation>()
                .HasMany(e => e.PerformanceVoucher)
                .WithRequired(e => e.PerformanceAllocation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PerformanceAllocationStateHistory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<PerformanceAllocationStateHistory>()
                .HasMany(e => e.PerformanceAllocation)
                .WithOptional(e => e.PerformanceAllocationStateHistory)
                .HasForeignKey(e => e.CurrentStateID);

            modelBuilder.Entity<PerformanceVoucher>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<PerformanceVoucher>()
                .HasMany(e => e.PerformanceVoucherStateHistory1)
                .WithRequired(e => e.PerformanceVoucher1)
                .HasForeignKey(e => e.PerformanceVoucherID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PerformanceVoucherStateHistory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<PerformanceVoucherStateHistory>()
                .HasMany(e => e.PerformanceVoucher)
                .WithOptional(e => e.PerformanceVoucherStateHistory)
                .HasForeignKey(e => e.CurrentStateID);

            modelBuilder.Entity<Permission>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.UserPermission)
                .WithRequired(e => e.Permission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.UserRolePermission)
                .WithRequired(e => e.Permission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Document)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Performance)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectInfo_Fund1)
                .WithRequired(e => e.Project1)
                .HasForeignKey(e => e.ProjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectInfo_Type1)
                .WithRequired(e => e.Project1)
                .HasForeignKey(e => e.ProjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectMember)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectOut)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectOutsourcingBudget)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectQualityPrincipal)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectStateHistory1)
                .WithRequired(e => e.Project1)
                .HasForeignKey(e => e.ProjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Recovery)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.StampApplication)
                .WithOptional(e => e.Project)
                .HasForeignKey(e => e.StampStuffFromID);

            modelBuilder.Entity<ProjectInfo_Fund>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectInfo_Fund>()
                .HasMany(e => e.FundDescend)
                .WithRequired(e => e.ProjectInfo_Fund)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectInfo_Fund>()
                .HasMany(e => e.PayPlanItem)
                .WithRequired(e => e.ProjectInfo_Fund)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectInfo_Fund>()
                .HasMany(e => e.Project)
                .WithOptional(e => e.ProjectInfo_Fund)
                .HasForeignKey(e => e.FundID);

            modelBuilder.Entity<ProjectInfo_Type>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectInfo_Type>()
                .HasMany(e => e.Project)
                .WithOptional(e => e.ProjectInfo_Type)
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<ProjectMember>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectOut>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectOutsourcingBudget>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectQualityPrincipal>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectRank>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectRank>()
                .HasMany(e => e.ProjectInfo_Type)
                .WithRequired(e => e.ProjectRank)
                .HasForeignKey(e => e.RankID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectRank>()
                .HasMany(e => e.ProjectType)
                .WithRequired(e => e.ProjectRank)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectStateHistory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectStateHistory>()
                .HasMany(e => e.Project)
                .WithOptional(e => e.ProjectStateHistory)
                .HasForeignKey(e => e.CurrentStateID);

            modelBuilder.Entity<ProjectSupportCategory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectSupportCategory>()
                .HasMany(e => e.ProjectInfo_Type)
                .WithOptional(e => e.ProjectSupportCategory)
                .HasForeignKey(e => e.SupportCategoryID);

            modelBuilder.Entity<ProjectSupportField>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectSupportField>()
                .HasMany(e => e.ProjectInfo_Type)
                .WithOptional(e => e.ProjectSupportField)
                .HasForeignKey(e => e.SupportFieldID);

            modelBuilder.Entity<ProjectSupportField>()
                .HasMany(e => e.ProjectSupportSubField)
                .WithRequired(e => e.ProjectSupportField)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectSupportSubField>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectSupportSubField>()
                .HasMany(e => e.ProjectInfo_Type)
                .WithOptional(e => e.ProjectSupportSubField)
                .HasForeignKey(e => e.SupportSubFieldID);

            modelBuilder.Entity<ProjectType>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<ProjectType>()
                .HasMany(e => e.DocumentModel)
                .WithRequired(e => e.ProjectType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectType>()
                .HasMany(e => e.ProjectInfo_Type)
                .WithRequired(e => e.ProjectType)
                .HasForeignKey(e => e.TypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectType>()
                .HasMany(e => e.ProjectSupportCategory)
                .WithRequired(e => e.ProjectType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectType>()
                .HasMany(e => e.ProjectSupportField)
                .WithRequired(e => e.ProjectType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recovery>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Resource>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Stamp>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Stamp>()
                .HasMany(e => e.StuffStamp)
                .WithRequired(e => e.Stamp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StampApplication>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<StampApplication>()
                .HasMany(e => e.StampStateHistory1)
                .WithRequired(e => e.StampApplication1)
                .HasForeignKey(e => e.StampApplicationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StampApplication>()
                .HasMany(e => e.Stuff)
                .WithRequired(e => e.StampApplication)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StampApplicationFirstAdmin>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<StampApplicationSecondAdmin>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<StampApplicationType>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<StampApplicationType>()
                .HasMany(e => e.StampApplicationFirstAdmin)
                .WithRequired(e => e.StampApplicationType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StampApplicationType>()
                .HasMany(e => e.StampApplicationSecondAdmin)
                .WithRequired(e => e.StampApplicationType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StampApplicationTypeGroup>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<StampStateHistory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<StampStateHistory>()
                .HasMany(e => e.StampApplication)
                .WithOptional(e => e.StampStateHistory)
                .HasForeignKey(e => e.CurrentStateID);

            modelBuilder.Entity<Stuff>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Stuff>()
                .HasMany(e => e.StuffStamp)
                .WithRequired(e => e.Stuff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StuffStamp>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<SubjectClassChineseEnglish>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<SubjectFirstLevel>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<SubjectFirstLevel>()
                .HasMany(e => e.Project)
                .WithOptional(e => e.SubjectFirstLevel)
                .HasForeignKey(e => e.FirstLevelSubjectID);

            modelBuilder.Entity<SubjectFirstLevel>()
                .HasMany(e => e.SubjectSecondLevel)
                .WithRequired(e => e.SubjectFirstLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectSecondLevel>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<SubjectSecondLevel>()
                .HasMany(e => e.Expert)
                .WithOptional(e => e.SubjectSecondLevel)
                .HasForeignKey(e => e.MajorCodeID);

            modelBuilder.Entity<SubjectSecondLevel>()
                .HasMany(e => e.Expert1)
                .WithOptional(e => e.SubjectSecondLevel1)
                .HasForeignKey(e => e.ResearchCode1ID);

            modelBuilder.Entity<SubjectSecondLevel>()
                .HasMany(e => e.Expert2)
                .WithOptional(e => e.SubjectSecondLevel2)
                .HasForeignKey(e => e.ResearchCode2ID);

            modelBuilder.Entity<SubjectSecondLevel>()
                .HasMany(e => e.Expert3)
                .WithOptional(e => e.SubjectSecondLevel3)
                .HasForeignKey(e => e.ResearchCode3ID);

            modelBuilder.Entity<SubjectSecondLevel>()
                .HasMany(e => e.Project)
                .WithOptional(e => e.SubjectSecondLevel)
                .HasForeignKey(e => e.SecondLevelSubjectID);

            modelBuilder.Entity<SystemSetting>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.AwardDocument)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AuthorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Expert)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ReceiverID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Message1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.SenderID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Stamp)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.OwnerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.StampApplicationFirstAdmin)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.StampApplicationSecondAdmin)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserLockLog)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserLoginLog)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserPermission)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserLockLog>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<UserLoginLog>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<UserPermission>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<UserRole>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.User)
                .WithRequired(e => e.UserRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.UserRolePermission)
                .WithRequired(e => e.UserRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRolePermission>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<View>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Voucher>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Voucher>()
                .HasMany(e => e.VoucherOut)
                .WithRequired(e => e.Voucher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Voucher>()
                .HasMany(e => e.VoucherStateHistory1)
                .WithRequired(e => e.Voucher1)
                .HasForeignKey(e => e.VoucherID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VoucherOut>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<VoucherStateHistory>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<VoucherStateHistory>()
                .HasMany(e => e.Voucher)
                .WithOptional(e => e.VoucherStateHistory)
                .HasForeignKey(e => e.CurrentStateID);

            modelBuilder.Entity<VoucherT>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<VoucherT>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();
        }
    }
}
