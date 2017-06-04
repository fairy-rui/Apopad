namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Award")]
    public partial class Award
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Award()
        {
            AwardDocument = new HashSet<AwardDocument>();
            AwardWinner1 = new HashSet<AwardWinner>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? Year { get; set; }

        [StringLength(255)]
        public string Rank { get; set; }

        public int? CollegeID { get; set; }

        public int? FirstWinnerID { get; set; }

        [StringLength(255)]
        public string Class { get; set; }

        [Required]
        [StringLength(255)]
        public string AttendType { get; set; }

        [StringLength(255)]
        public string Project { get; set; }

        public string Introduction { get; set; }

        [StringLength(255)]
        public string AuthorisedUnit { get; set; }

        public int SubjectNature { get; set; }

        [StringLength(255)]
        public string Classification { get; set; }

        public string Remark { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Department Department { get; set; }

        public virtual AwardWinner AwardWinner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AwardDocument> AwardDocument { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AwardWinner> AwardWinner1 { get; set; }
    }
}
