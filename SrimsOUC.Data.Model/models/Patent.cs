namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patent")]
    public partial class Patent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patent()
        {
            PatentInventer = new HashSet<PatentInventer>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Number { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? CollegeID { get; set; }

        public DateTime? ApplicationDateTime { get; set; }

        public DateTime? AuthorizeDateTime { get; set; }

        public int LawState { get; set; }

        public DateTime? LawStateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [StringLength(255)]
        public string Category { get; set; }

        [StringLength(255)]
        public string MainCategoryNumber { get; set; }

        [StringLength(255)]
        public string AllCategoryNumber { get; set; }

        public int Type { get; set; }

        public int Level { get; set; }

        public string Introduction { get; set; }

        public int? AgencyID { get; set; }

        [StringLength(50)]
        public string Agent { get; set; }

        public string Remark { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Department Department { get; set; }

        public virtual PatentAgency PatentAgency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatentInventer> PatentInventer { get; set; }
    }
}
