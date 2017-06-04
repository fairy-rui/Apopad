namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectSupportCategory")]
    public partial class ProjectSupportCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectSupportCategory()
        {
            ProjectInfo_Type = new HashSet<ProjectInfo_Type>();
        }

        public int ID { get; set; }

        public int ProjectTypeID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsGetOverheadExpense { get; set; }

        public bool IsAvailable { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectInfo_Type> ProjectInfo_Type { get; set; }

        public virtual ProjectType ProjectType { get; set; }
    }
}
