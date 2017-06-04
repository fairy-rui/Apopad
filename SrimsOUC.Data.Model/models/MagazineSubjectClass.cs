namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MagazineSubjectClass")]
    public partial class MagazineSubjectClass
    {
        public int ID { get; set; }

        public int MagazineID { get; set; }

        [Required]
        [StringLength(255)]
        public string SubjectClass { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Magazine Magazine { get; set; }
    }
}
