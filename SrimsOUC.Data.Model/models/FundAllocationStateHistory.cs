namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FundAllocationStateHistory")]
    public partial class FundAllocationStateHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FundAllocationStateHistory()
        {
            FundAllocation = new HashSet<FundAllocation>();
        }

        public int ID { get; set; }

        public int FundAllocationID { get; set; }

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
        public virtual ICollection<FundAllocation> FundAllocation { get; set; }

        public virtual FundAllocation FundAllocation1 { get; set; }
    }
}
