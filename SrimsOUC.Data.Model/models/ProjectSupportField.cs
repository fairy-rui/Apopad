namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectSupportField")]
    public partial class ProjectSupportField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectSupportField()
        {
            ProjectInfo_Type = new HashSet<ProjectInfo_Type>();
            ProjectSupportSubField = new HashSet<ProjectSupportSubField>();
        }

        public int ID { get; set; }

        public int ProjectTypeID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsAvailable { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectInfo_Type> ProjectInfo_Type { get; set; }

        public virtual ProjectType ProjectType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectSupportSubField> ProjectSupportSubField { get; set; }
    }
}
