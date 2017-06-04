namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LiberalArtsPaper")]
    public partial class LiberalArtsPaper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LiberalArtsPaper()
        {
            LiberalArtsPaperAuthor = new HashSet<LiberalArtsPaperAuthor>();
        }

        public int ID { get; set; }

        public int PublishDateYear { get; set; }

        [StringLength(255)]
        public string SerialNumbe { get; set; }

        [Required]
        [StringLength(255)]
        public string ResultsName { get; set; }

        public int Type { get; set; }

        [StringLength(255)]
        public string EnglishName { get; set; }

        [StringLength(255)]
        public string ResultsForm { get; set; }

        [StringLength(255)]
        public string Fund { get; set; }

        [Required]
        [StringLength(255)]
        public string Publisher { get; set; }

        [StringLength(255)]
        public string ISSN { get; set; }

        [StringLength(255)]
        public string FirstOrganization { get; set; }

        public int? OurSchoolSignRank { get; set; }

        [StringLength(255)]
        public string OrganizationName { get; set; }

        [StringLength(255)]
        public string Region { get; set; }

        [StringLength(255)]
        public string SubjectClass { get; set; }

        public int? CollegeID { get; set; }

        [StringLength(255)]
        public string CODEN { get; set; }

        [StringLength(255)]
        public string IssuesDate { get; set; }

        [StringLength(255)]
        public string KeyWord { get; set; }

        [StringLength(255)]
        public string Mark { get; set; }

        [StringLength(255)]
        public string DegreeType { get; set; }

        [StringLength(255)]
        public string FundType { get; set; }

        public string References { get; set; }

        public int? CiteTime { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [StringLength(255)]
        public string Degree { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LiberalArtsPaperAuthor> LiberalArtsPaperAuthor { get; set; }
    }
}
