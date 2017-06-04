namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Performance")]
    public partial class Performance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Performance()
        {
            PerformanceAllocation = new HashSet<PerformanceAllocation>();
        }

        public int ID { get; set; }

        public int? FundAllocationID { get; set; }

        public long ArrivedPerformance { get; set; }

        public bool IsAllocated { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public int ProjectID { get; set; }

        public DateTime FoundationTime { get; set; }

        public bool IsCancel { get; set; }

        public long? DescendPerformance { get; set; }

        public int? RecoveryID { get; set; }

        public virtual FundAllocation FundAllocation { get; set; }

        public virtual Project Project { get; set; }

        public virtual Recovery Recovery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerformanceAllocation> PerformanceAllocation { get; set; }
    }
}
