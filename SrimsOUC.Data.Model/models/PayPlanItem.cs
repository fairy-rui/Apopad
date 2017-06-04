namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayPlanItem")]
    public partial class PayPlanItem
    {
        public int ID { get; set; }

        public int ProjectInfo_FundID { get; set; }

        public DateTime DateTime { get; set; }

        public long Amount { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual ProjectInfo_Fund ProjectInfo_Fund { get; set; }
    }
}
