namespace Apopad.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            AuthorShip = new HashSet<AuthorShip>();
            Candidate = new HashSet<Candidate>();
            PersonDepartment = new HashSet<PersonDepartment>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string PersonNo { get; set; }

        [Required]
        [StringLength(128)]
        public string NameCN { get; set; }

        [Required]
        [StringLength(128)]
        public string NameEN { get; set; }

        [Required]
        [StringLength(128)]
        public string NameENAbbr { get; set; }

        [StringLength(6)]
        public string Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [StringLength(256)]
        public string IDCard { get; set; }

        [StringLength(64)]
        public string Mobile { get; set; }

        [StringLength(512)]
        public string Email { get; set; }

        [StringLength(128)]
        public string Tutor { get; set; }

        public int PersonType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorShip> AuthorShip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Candidate> Candidate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDepartment> PersonDepartment { get; set; }
    }
}
