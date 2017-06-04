namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectType")]
    public partial class ProjectType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectType()
        {
            DocumentModel = new HashSet<DocumentModel>();
            ProjectInfo_Type = new HashSet<ProjectInfo_Type>();
            ProjectSupportCategory = new HashSet<ProjectSupportCategory>();
            ProjectSupportField = new HashSet<ProjectSupportField>();
        }

        public int ID { get; set; }

        public int ProjectRankID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string NameSpell { get; set; }

        [StringLength(255)]
        public string ShortName { get; set; }

        [StringLength(255)]
        public string Administration { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(255)]
        public string PerCode { get; set; }

        [StringLength(255)]
        public string BakCode { get; set; }

        public int ProjectComingFrom { get; set; }

        public bool IsBudget { get; set; }

        public bool IsExploit { get; set; }

        public int OverheadExpenseInRate { get; set; }

        public int OverheadExpenseOutRate { get; set; }

        public int SubjectNature { get; set; }

        public bool IsAvailable { get; set; }

        [StringLength(255)]
        public string ManagementFeesType { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentModel> DocumentModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectInfo_Type> ProjectInfo_Type { get; set; }

        public virtual ProjectRank ProjectRank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectSupportCategory> ProjectSupportCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectSupportField> ProjectSupportField { get; set; }
    }
}
