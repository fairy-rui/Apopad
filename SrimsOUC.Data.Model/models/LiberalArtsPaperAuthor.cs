namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LiberalArtsPaperAuthor")]
    public partial class LiberalArtsPaperAuthor
    {
        public int ID { get; set; }

        public int LiberalArtsPaperID { get; set; }

        public int? ExpertID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string EnglishName { get; set; }

        public int Order { get; set; }

        public bool IsLinkMan { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual LiberalArtsPaper LiberalArtsPaper { get; set; }
    }
}
