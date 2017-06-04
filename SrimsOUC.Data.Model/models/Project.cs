namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            Contract = new HashSet<Contract>();
            Document = new HashSet<Document>();
            Performance = new HashSet<Performance>();
            ProjectInfo_Fund1 = new HashSet<ProjectInfo_Fund>();
            ProjectInfo_Type1 = new HashSet<ProjectInfo_Type>();
            ProjectMember = new HashSet<ProjectMember>();
            ProjectOut = new HashSet<ProjectOut>();
            ProjectOutsourcingBudget = new HashSet<ProjectOutsourcingBudget>();
            ProjectQualityPrincipal = new HashSet<ProjectQualityPrincipal>();
            ProjectStateHistory1 = new HashSet<ProjectStateHistory>();
            Recovery = new HashSet<Recovery>();
            StampApplication = new HashSet<StampApplication>();
        }

        public int ID { get; set; }

        public int? TypeID { get; set; }

        public int? FundID { get; set; }

        [StringLength(255)]
        public string Number { get; set; }

        [StringLength(255)]
        public string SerialNumber { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string NameSpell { get; set; }

        public int PrincipalID { get; set; }

        public int? PrincipalDelegateID { get; set; }

        public int? PrincipalQualityID { get; set; }

        public int Level { get; set; }

        public int? FirstLevelSubjectID { get; set; }

        public int? SecondLevelSubjectID { get; set; }

        [StringLength(255)]
        public string ResearchType { get; set; }

        public bool IsSecret { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(255)]
        public string CooperationType { get; set; }

        public int? BaseID { get; set; }

        [StringLength(255)]
        public string TaskComingFrom { get; set; }

        [StringLength(255)]
        public string CorporationPlace { get; set; }

        public int? CurrentStateID { get; set; }

        [StringLength(255)]
        public string Creator { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public bool? IsPrincipalSecondCollege { get; set; }

        public bool? IsAdjust { get; set; }

        public virtual Base Base { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Document { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual Expert Expert1 { get; set; }

        public virtual Expert Expert2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Performance> Performance { get; set; }

        public virtual ProjectStateHistory ProjectStateHistory { get; set; }

        public virtual SubjectFirstLevel SubjectFirstLevel { get; set; }

        public virtual ProjectInfo_Fund ProjectInfo_Fund { get; set; }

        public virtual SubjectSecondLevel SubjectSecondLevel { get; set; }

        public virtual ProjectInfo_Type ProjectInfo_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectInfo_Fund> ProjectInfo_Fund1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectInfo_Type> ProjectInfo_Type1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectMember> ProjectMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectOut> ProjectOut { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectOutsourcingBudget> ProjectOutsourcingBudget { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectQualityPrincipal> ProjectQualityPrincipal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectStateHistory> ProjectStateHistory1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recovery> Recovery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StampApplication> StampApplication { get; set; }
    }
}
