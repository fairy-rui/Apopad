namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Paper")]
    public partial class Paper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paper()
        {
            PaperAuthor = new HashSet<PaperAuthor>();
            PaperIndexed = new HashSet<PaperIndexed>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? MagazineID { get; set; }

        [StringLength(255)]
        public string ResourceName { get; set; }

        public int Type { get; set; }

        public int? CiteFrequency { get; set; }

        public int? PublishDateYear { get; set; }

        [StringLength(255)]
        public string PublishDate { get; set; }

        [StringLength(255)]
        public string DocumentNumber { get; set; }

        [StringLength(255)]
        public string Volume { get; set; }

        public int? StartPage { get; set; }

        public int? EndPage { get; set; }

        public int? Pages { get; set; }

        public int? SubAirer { get; set; }

        public int? InfluenceFactor { get; set; }

        [StringLength(255)]
        public string AuthorKeyWord { get; set; }

        [StringLength(255)]
        public string KeyWord { get; set; }

        public string Abstract { get; set; }

        public string LinkManAddress { get; set; }

        [StringLength(255)]
        public string LinkManEmail { get; set; }

        public int LinkManSignUnit { get; set; }

        public int FirstAuthorSignUnit { get; set; }

        public int? SignOrder { get; set; }

        public int? CollegeID { get; set; }

        [StringLength(255)]
        public string Lab { get; set; }

        [StringLength(255)]
        public string ISIUniqueArticleIdentifier { get; set; }

        public string Remark { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Department Department { get; set; }

        public virtual Magazine Magazine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaperAuthor> PaperAuthor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaperIndexed> PaperIndexed { get; set; }
    }
}
