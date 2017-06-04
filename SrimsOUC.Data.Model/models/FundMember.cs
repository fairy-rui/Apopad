namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FundMember")]
    public partial class FundMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FundMember()
        {
            PerformanceVoucher = new HashSet<PerformanceVoucher>();
            Voucher = new HashSet<Voucher>();
        }

        public int ID { get; set; }

        public int? ProjectInfo_FundID { get; set; }

        public int? ExpertID { get; set; }

        [StringLength(255)]
        public string AccountBookNumber { get; set; }

        public int? OldID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public bool? IsExpertSecondCollege { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual ProjectInfo_Fund ProjectInfo_Fund { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerformanceVoucher> PerformanceVoucher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
