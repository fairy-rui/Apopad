namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PerformanceAllocation")]
    public partial class PerformanceAllocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PerformanceAllocation()
        {
            PerformanceAllocationStateHistory1 = new HashSet<PerformanceAllocationStateHistory>();
            PerformanceVoucher = new HashSet<PerformanceVoucher>();
        }

        public int ID { get; set; }

        public int PerformanceID { get; set; }

        public long ArrivedPerformance { get; set; }

        public int? CurrentStateID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public bool? CanAllocate { get; set; }

        public long ArrivedOverheadexpensesExpert { get; set; }

        public virtual Performance Performance { get; set; }

        public virtual PerformanceAllocationStateHistory PerformanceAllocationStateHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerformanceAllocationStateHistory> PerformanceAllocationStateHistory1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerformanceVoucher> PerformanceVoucher { get; set; }
    }
}
