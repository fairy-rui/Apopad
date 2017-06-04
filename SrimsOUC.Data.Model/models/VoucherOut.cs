namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VoucherOut")]
    public partial class VoucherOut
    {
        public int ID { get; set; }

        public int VoucherID { get; set; }

        public long Amount { get; set; }

        [StringLength(255)]
        public string Corporation { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public int? OutsourcingID { get; set; }

        public virtual Outsourcing Outsourcing { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
