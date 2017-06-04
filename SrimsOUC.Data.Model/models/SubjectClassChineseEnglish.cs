namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubjectClassChineseEnglish")]
    public partial class SubjectClassChineseEnglish
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string ChineseName { get; set; }

        [StringLength(255)]
        public string EnglishName { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
    }
}
