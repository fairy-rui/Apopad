namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoticeText")]
    public partial class NoticeText
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Value { get; set; }

        [StringLength(255)]
        public string ValueSpell { get; set; }

        public int Type { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
    }
}
