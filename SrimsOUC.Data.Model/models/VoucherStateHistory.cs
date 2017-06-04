namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VoucherStateHistory")]
    public partial class VoucherStateHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VoucherStateHistory()
        {
            Voucher = new HashSet<Voucher>();
        }

        public int ID { get; set; }

        public int VoucherID { get; set; }

        public int State { get; set; }

        [StringLength(255)]
        public string Operator { get; set; }

        public DateTime DateTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voucher> Voucher { get; set; }

        public virtual Voucher Voucher1 { get; set; }
    }
}
