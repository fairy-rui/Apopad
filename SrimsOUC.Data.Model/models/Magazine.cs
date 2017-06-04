namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Magazine")]
    public partial class Magazine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Magazine()
        {
            MagazineInformation = new HashSet<MagazineInformation>();
            MagazineOccupation = new HashSet<MagazineOccupation>();
            MagazineSubjectClass = new HashSet<MagazineSubjectClass>();
            Paper = new HashSet<Paper>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string ShortName { get; set; }

        [Required]
        [StringLength(255)]
        public string ISSN { get; set; }

        [StringLength(255)]
        public string SubjectRank { get; set; }

        public int PublishType { get; set; }

        public int Language { get; set; }

        [StringLength(255)]
        public string PublishCompany { get; set; }

        [StringLength(255)]
        public string PublishCompanyAddress { get; set; }

        [StringLength(255)]
        public string PublishCompanyCity { get; set; }

        public bool IsDelete { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MagazineInformation> MagazineInformation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MagazineOccupation> MagazineOccupation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MagazineSubjectClass> MagazineSubjectClass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paper> Paper { get; set; }
    }
}
