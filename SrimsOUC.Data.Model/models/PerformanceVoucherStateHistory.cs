namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PerformanceVoucherStateHistory")]
    public partial class PerformanceVoucherStateHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PerformanceVoucherStateHistory()
        {
            PerformanceVoucher = new HashSet<PerformanceVoucher>();
        }

        public int ID { get; set; }

        public int PerformanceVoucherID { get; set; }

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
        public virtual ICollection<PerformanceVoucher> PerformanceVoucher { get; set; }

        public virtual PerformanceVoucher PerformanceVoucher1 { get; set; }
    }
}
