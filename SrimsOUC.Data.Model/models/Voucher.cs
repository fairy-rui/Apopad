namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Voucher")]
    public partial class Voucher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Voucher()
        {
            VoucherOut = new HashSet<VoucherOut>();
            VoucherStateHistory1 = new HashSet<VoucherStateHistory>();
        }

        public int ID { get; set; }

        public int FundAllocationID { get; set; }

        public int FundMemberID { get; set; }

        [StringLength(255)]
        public string VoucherNumber { get; set; }

        [StringLength(255)]
        public string AccountBookNumber { get; set; }

        public long AllocationIn { get; set; }

        public long AllocationOut { get; set; }

        public long AllocationHardware { get; set; }

        public long OverheadExpensesIn { get; set; }

        public long OverheadExpensesOut { get; set; }

        public bool IsRead { get; set; }

        public int? CurrentStateID { get; set; }

        [StringLength(255)]
        public string FinanceNumber { get; set; }

        public DateTime? FinanceAllocateDateTime { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public long? PerformancePay { get; set; }

        [StringLength(255)]
        public string PerformanceAccountBookNumber { get; set; }

        public long? OverheadPerformancePay { get; set; }

        public long? OverheadExpensesMiddle { get; set; }

        public long? OverheadExpensesExpert { get; set; }

        public virtual FundAllocation FundAllocation { get; set; }

        public virtual FundMember FundMember { get; set; }

        public virtual VoucherStateHistory VoucherStateHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VoucherOut> VoucherOut { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VoucherStateHistory> VoucherStateHistory1 { get; set; }
    }
}
