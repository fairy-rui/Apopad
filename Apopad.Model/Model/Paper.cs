namespace Apopad.Model
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
            Author = new HashSet<Author>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string PublicationType { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string AuthorFullName { get; set; }

        public string DocumentTitle { get; set; }

        [StringLength(512)]
        public string PublicationName { get; set; }

        [StringLength(255)]
        public string Series { get; set; }

        [StringLength(64)]
        public string Language { get; set; }

        [StringLength(64)]
        public string DocumentType { get; set; }

        public string AuthorKeywords { get; set; }

        public string Keywords { get; set; }

        public string Abstract { get; set; }

        public string AuthorAddress { get; set; }

        [StringLength(1024)]
        public string ReprintAddress { get; set; }

        [StringLength(1024)]
        public string EmailAddress { get; set; }

        [Column(TypeName = "text")]
        public string CitedReferences { get; set; }

        public int? CitedReferenceCount { get; set; }

        public int? TotalCitedCount { get; set; }

        [StringLength(512)]
        public string Publisher { get; set; }

        [StringLength(512)]
        public string PublisherCity { get; set; }

        [StringLength(512)]
        public string PublisherAddress { get; set; }

        [StringLength(128)]
        public string ISSN { get; set; }

        [StringLength(128)]
        public string DOI { get; set; }

        [StringLength(512)]
        public string SourceAbbreviation { get; set; }

        [StringLength(512)]
        public string ISOSourceAbbreviation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PublicationDate { get; set; }

        public int? Year { get; set; }

        [StringLength(64)]
        public string Volume { get; set; }

        [StringLength(64)]
        public string Issue { get; set; }

        [StringLength(64)]
        public string PartNumber { get; set; }

        public bool? Supplement { get; set; }

        [StringLength(255)]
        public string SpecialIssue { get; set; }

        public int? StartPage { get; set; }

        public int? EndPage { get; set; }

        public int? PageCount { get; set; }

        [StringLength(255)]
        public string ArticleNumber { get; set; }

        [StringLength(1024)]
        public string Categories { get; set; }

        [StringLength(255)]
        public string DeliveryNumber { get; set; }

        [StringLength(128)]
        public string AccessionNumber { get; set; }

        public PaperStatus Status { get; set; }

        public int? DepartmentId { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Author> Author { get; set; }

        public virtual Department Department { get; set; }
    }
}
