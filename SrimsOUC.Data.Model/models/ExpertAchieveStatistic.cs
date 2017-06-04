namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExpertAchieveStatistic")]
    public partial class ExpertAchieveStatistic
    {
        public int ID { get; set; }

        public int ExpertID { get; set; }

        public long? FundTotal { get; set; }

        public int? ProjectCount { get; set; }

        public int? PaperCount { get; set; }

        public int? PatentCount { get; set; }

        public int? AwardCount { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Expert Expert { get; set; }
    }
}
