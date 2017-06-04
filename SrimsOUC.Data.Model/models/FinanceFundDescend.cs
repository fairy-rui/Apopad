namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinanceFundDescend")]
    public partial class FinanceFundDescend
    {
        public int ID { get; set; }

        public int FinanceID { get; set; }

        public int FundDescendID { get; set; }

        public long Amount { get; set; }

        public bool IsReturn { get; set; }

        public DateTime OperateDateTime { get; set; }

        [StringLength(255)]
        public string Operator { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Finance Finance { get; set; }

        public virtual FundDescend FundDescend { get; set; }
    }
}
