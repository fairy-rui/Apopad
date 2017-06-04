namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinanceBak")]
    public partial class FinanceBak
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Abstract { get; set; }

        public DateTime ReceivedDate { get; set; }

        [StringLength(255)]
        public string VoucherNumber { get; set; }

        public long Amount { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
    }
}
