namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserLockLog")]
    public partial class UserLockLog
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Operator { get; set; }

        public DateTime OperateDateTime { get; set; }

        [StringLength(255)]
        public string Reason { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual User User { get; set; }
    }
}
