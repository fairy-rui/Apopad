namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AwardWinner")]
    public partial class AwardWinner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AwardWinner()
        {
            Award = new HashSet<Award>();
        }

        public int ID { get; set; }

        public int AwardID { get; set; }

        public int? ExpertID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Order { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Award> Award { get; set; }

        public virtual Award Award1 { get; set; }

        public virtual Expert Expert { get; set; }
    }
}
