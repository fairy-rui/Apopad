namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PerformanceVoucher")]
    public partial class PerformanceVoucher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PerformanceVoucher()
        {
            PerformanceVoucherStateHistory1 = new HashSet<PerformanceVoucherStateHistory>();
        }

        public int ID { get; set; }

        public int PerformanceAllocationID { get; set; }

        public int FundMemberID { get; set; }

        [StringLength(255)]
        public string VoucherNumber { get; set; }

        [StringLength(255)]
        public string AccountBookNumber { get; set; }

        public long PerformancePay { get; set; }

        public bool IsRead { get; set; }

        public int? CurrentStateID { get; set; }

        [StringLength(255)]
        public string FinanceNumber { get; set; }

        public DateTime? FinanceAllocateDateTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public long? OverheadExpensesExpert { get; set; }

        public virtual FundMember FundMember { get; set; }

        public virtual PerformanceAllocation PerformanceAllocation { get; set; }

        public virtual PerformanceVoucherStateHistory PerformanceVoucherStateHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerformanceVoucherStateHistory> PerformanceVoucherStateHistory1 { get; set; }
    }
}
