namespace Apopad.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int Id { get; set; }

        public int PaperId { get; set; }

        public int Ordinal { get; set; }

        [StringLength(128)]
        public string NameEN { get; set; }

        [StringLength(128)]
        public string NameENAbbr { get; set; }

        [StringLength(1024)]
        public string DepartmentName { get; set; }

        public bool IsCorrespondingAuthor { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PublishDate { get; set; }

        public bool IsOtherUnit { get; set; }

        public int SignOrdinal { get; set; }

        public bool HasCandidate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual Paper Paper { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
