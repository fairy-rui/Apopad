namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FundDescend")]
    public partial class FundDescend
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FundDescend()
        {
            FinanceFundDescend = new HashSet<FinanceFundDescend>();
            FundAllocation = new HashSet<FundAllocation>();
            FundDescendStateHistory1 = new HashSet<FundDescendStateHistory>();
        }

        public int ID { get; set; }

        public int ProjectInfo_FundID { get; set; }

        public DateTime DescendDateTime { get; set; }

        public long Amount { get; set; }

        public long ReceivedAmount { get; set; }

        [StringLength(255)]
        public string Operator { get; set; }

        public int? CurrentStateID { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinanceFundDescend> FinanceFundDescend { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FundAllocation> FundAllocation { get; set; }

        public virtual FundDescendStateHistory FundDescendStateHistory { get; set; }

        public virtual ProjectInfo_Fund ProjectInfo_Fund { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FundDescendStateHistory> FundDescendStateHistory1 { get; set; }
    }
}
