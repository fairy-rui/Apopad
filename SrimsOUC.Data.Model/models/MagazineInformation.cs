namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MagazineInformation")]
    public partial class MagazineInformation
    {
        public int ID { get; set; }

        public int MagazineID { get; set; }

        public int? Year { get; set; }

        public int? SubAirer { get; set; }

        public int? InfluenceFactor { get; set; }

        public int? CiteFrequency { get; set; }

        public int? InstantExponent { get; set; }

        public int? PaperCount { get; set; }

        [StringLength(255)]
        public string CiteHalfLife { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Magazine Magazine { get; set; }
    }
}
