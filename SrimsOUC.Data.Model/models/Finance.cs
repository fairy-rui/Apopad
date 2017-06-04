namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Finance")]
    public partial class Finance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Finance()
        {
            FinanceFundDescend = new HashSet<FinanceFundDescend>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Abstract { get; set; }

        public DateTime ReceivedDate { get; set; }

        [StringLength(255)]
        public string VoucherNumber { get; set; }

        public long Amount { get; set; }

        public long DescendAmount { get; set; }

        public bool IsInvoiced { get; set; }

        [StringLength(255)]
        public string InvoiceType { get; set; }

        [StringLength(255)]
        public string InvoiceNumber { get; set; }

        public DateTime? InvoiceTime { get; set; }

        public int? OldID { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinanceFundDescend> FinanceFundDescend { get; set; }
    }
}
