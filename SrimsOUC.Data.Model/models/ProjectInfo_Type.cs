namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProjectInfo_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectInfo_Type()
        {
            Project = new HashSet<Project>();
        }

        public int ID { get; set; }

        public int ProjectID { get; set; }

        public int RankID { get; set; }

        public int TypeID { get; set; }

        public int? SupportFieldID { get; set; }

        public int? SupportSubFieldID { get; set; }

        public int? SupportCategoryID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project { get; set; }

        public virtual Project Project1 { get; set; }

        public virtual ProjectRank ProjectRank { get; set; }

        public virtual ProjectSupportCategory ProjectSupportCategory { get; set; }

        public virtual ProjectSupportField ProjectSupportField { get; set; }

        public virtual ProjectSupportSubField ProjectSupportSubField { get; set; }

        public virtual ProjectType ProjectType { get; set; }
    }
}
