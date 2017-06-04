namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PatentInventer")]
    public partial class PatentInventer
    {
        public int ID { get; set; }

        public int PatentID { get; set; }

        public int? ExpertID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Order { get; set; }

        public bool IsPrincipal { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual Patent Patent { get; set; }
    }
}
