namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VoucherT")]
    public partial class VoucherT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int AllocationId { get; set; }

        public int? InnerMissionId { get; set; }

        public int? OuterMissionId { get; set; }

        public int Amount { get; set; }

        public int? OverheadPerformancePay { get; set; }

        public int? A1 { get; set; }

        public int? A2 { get; set; }

        public int? A3 { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public int? PI_VoucherId { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
    }
}
