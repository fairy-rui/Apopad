namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StampApplicationType")]
    public partial class StampApplicationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StampApplicationType()
        {
            StampApplication = new HashSet<StampApplication>();
            StampApplicationFirstAdmin = new HashSet<StampApplicationFirstAdmin>();
            StampApplicationSecondAdmin = new HashSet<StampApplicationSecondAdmin>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsTwiceCancer { get; set; }

        public bool IsProjectRelated { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public int? StampApplicationTypeGroupID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StampApplication> StampApplication { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StampApplicationFirstAdmin> StampApplicationFirstAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StampApplicationSecondAdmin> StampApplicationSecondAdmin { get; set; }

        public virtual StampApplicationTypeGroup StampApplicationTypeGroup { get; set; }
    }
}
