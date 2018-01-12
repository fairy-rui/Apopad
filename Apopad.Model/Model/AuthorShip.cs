namespace Apopad.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AuthorShip")]
    public partial class AuthorShip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AuthorShip()
        {
            AuthorKeyWord = new HashSet<AuthorKeyWord>();
            CoAuthorShip = new HashSet<CoAuthorShip>();
            CoAuthorShip1 = new HashSet<CoAuthorShip>();
        }

        public int Id { get; set; }

        public int? PersonId { get; set; }

        [StringLength(64)]
        public string PersonNo { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string EnglishName { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorKeyWord> AuthorKeyWord { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoAuthorShip> CoAuthorShip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoAuthorShip> CoAuthorShip1 { get; set; }
    }
}
