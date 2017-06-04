namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recovery")]
    public partial class Recovery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recovery()
        {
            Performance = new HashSet<Performance>();
        }

        public int ID { get; set; }

        public int ProjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string VoucherNumber { get; set; }

        public long ReceivedOverheadExpensesIn { get; set; }

        public long PlanedOverheadExpensesIn { get; set; }

        public DateTime? PrintDateTime { get; set; }

        public bool IsPrint { get; set; }

        public long PlanedPerformancePay { get; set; }

        public string Remark { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public long? ReceivedPerformancePay { get; set; }

        public long? OldOverheadExpensesIn { get; set; }

        public long? NewOverheadExpensesIn { get; set; }

        public long? OldPerformancePay { get; set; }

        public long? NewPerformancePay { get; set; }

        public long? OldFundPlanIn { get; set; }

        public long? NewFundPlanIn { get; set; }

        public long? CurrentAllocationIn { get; set; }

        public DateTime? OperateTime { get; set; }

        [StringLength(50)]
        public string Operator { get; set; }

        public bool? IsCanceled { get; set; }

        public long? ReceivedOverheadExpensesMiddle { get; set; }

        public long? PlanedOverheadExpensesMiddle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Performance> Performance { get; set; }

        public virtual Project Project { get; set; }
    }
}
