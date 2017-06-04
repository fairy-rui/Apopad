namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FundAllocation")]
    public partial class FundAllocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FundAllocation()
        {
            FundAllocationStateHistory1 = new HashSet<FundAllocationStateHistory>();
            Performance = new HashSet<Performance>();
            Voucher = new HashSet<Voucher>();
        }

        public int ID { get; set; }

        public int FundDescendID { get; set; }

        public long AllocationIn { get; set; }

        public long AllocationOut { get; set; }

        public long AllocationHardware { get; set; }

        public long OverheadExpensesIn { get; set; }

        public long OverheadExpensesOut { get; set; }

        public int? CurrentStateID { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public long? PerformancePay { get; set; }

        public long? OverheadPerformancePay { get; set; }

        public long? AllocationWantOut { get; set; }

        public long? OverheadExpensesMiddle { get; set; }

        public long? OverheadExpensesExpert { get; set; }

        public virtual FundAllocationStateHistory FundAllocationStateHistory { get; set; }

        public virtual FundDescend FundDescend { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FundAllocationStateHistory> FundAllocationStateHistory1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Performance> Performance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
