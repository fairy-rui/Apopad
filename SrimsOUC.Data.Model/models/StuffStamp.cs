namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StuffStamp")]
    public partial class StuffStamp
    {
        public int ID { get; set; }

        public int StuffID { get; set; }

        public int StampID { get; set; }

        public int Number { get; set; }

        public bool IsStamped { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [Required]
        [StringLength(255)]
        public string Pagination { get; set; }

        public virtual Stamp Stamp { get; set; }

        public virtual Stuff Stuff { get; set; }
    }
}
