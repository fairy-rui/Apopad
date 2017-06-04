namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expert")]
    public partial class Expert
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expert()
        {
            AwardWinner = new HashSet<AwardWinner>();
            Base = new HashSet<Base>();
            Base1 = new HashSet<Base>();
            ExpertAchieveStatistic = new HashSet<ExpertAchieveStatistic>();
            ExpertInfoHistory = new HashSet<ExpertInfoHistory>();
            FundMember = new HashSet<FundMember>();
            LiberalArtsPaperAuthor = new HashSet<LiberalArtsPaperAuthor>();
            MagazineOccupation = new HashSet<MagazineOccupation>();
            Outsourcing = new HashSet<Outsourcing>();
            PaperAuthor = new HashSet<PaperAuthor>();
            PatentInventer = new HashSet<PatentInventer>();
            Project = new HashSet<Project>();
            Project1 = new HashSet<Project>();
            Project2 = new HashSet<Project>();
            ProjectMember = new HashSet<ProjectMember>();
            ProjectQualityPrincipal = new HashSet<ProjectQualityPrincipal>();
            StampApplication = new HashSet<StampApplication>();
        }

        public int ID { get; set; }

        public int UserID { get; set; }

        [StringLength(255)]
        public string Number { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string NameSpell { get; set; }

        public int Sex { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(255)]
        public string Nation { get; set; }

        [StringLength(255)]
        public string Policy { get; set; }

        public int? MajorCodeID { get; set; }

        [StringLength(255)]
        public string IDCardNumber { get; set; }

        public DateTime? ComeDate { get; set; }

        [StringLength(255)]
        public string FileNumber { get; set; }

        [StringLength(255)]
        public string AcademyDegree { get; set; }

        [StringLength(255)]
        public string PostOld { get; set; }

        [StringLength(255)]
        public string PostNew { get; set; }

        public int? PostLevel { get; set; }

        [StringLength(255)]
        public string Occupation { get; set; }

        public int? VocationLevel { get; set; }

        public bool? IsDoctorDirector { get; set; }

        public bool? IsOnjob { get; set; }

        public bool? IsChinese { get; set; }

        [StringLength(255)]
        public string MobilePhone { get; set; }

        [StringLength(255)]
        public string OfficePhone { get; set; }

        [StringLength(255)]
        public string HomePhone { get; set; }

        [StringLength(255)]
        public string Fax { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Zip { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public int? CollegeID { get; set; }

        public int? DepartmentID { get; set; }

        [StringLength(255)]
        public string Specialty { get; set; }

        public Guid? Photo { get; set; }

        public int? ResearchCode1ID { get; set; }

        public int? ResearchCode2ID { get; set; }

        public int? ResearchCode3ID { get; set; }

        [StringLength(255)]
        public string Language1 { get; set; }

        [StringLength(255)]
        public string LanguageLevel1 { get; set; }

        [StringLength(255)]
        public string Language2 { get; set; }

        [StringLength(255)]
        public string LanguageLevel2 { get; set; }

        [StringLength(255)]
        public string SocietyPost { get; set; }

        public string WorkExperience { get; set; }

        public string ResearchExperience { get; set; }

        public bool IsAgreeLicence { get; set; }

        public DateTime? AgreeLicenceDateTime { get; set; }

        [StringLength(255)]
        public string AgreeLicenceIP { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public int? College2ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AwardWinner> AwardWinner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Base> Base { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Base> Base1 { get; set; }

        public virtual Department Department { get; set; }

        public virtual Department Department1 { get; set; }

        public virtual Department Department2 { get; set; }

        public virtual SubjectSecondLevel SubjectSecondLevel { get; set; }

        public virtual SubjectSecondLevel SubjectSecondLevel1 { get; set; }

        public virtual SubjectSecondLevel SubjectSecondLevel2 { get; set; }

        public virtual SubjectSecondLevel SubjectSecondLevel3 { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpertAchieveStatistic> ExpertAchieveStatistic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpertInfoHistory> ExpertInfoHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FundMember> FundMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LiberalArtsPaperAuthor> LiberalArtsPaperAuthor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MagazineOccupation> MagazineOccupation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outsourcing> Outsourcing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaperAuthor> PaperAuthor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatentInventer> PatentInventer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectMember> ProjectMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectQualityPrincipal> ProjectQualityPrincipal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StampApplication> StampApplication { get; set; }
    }
}
