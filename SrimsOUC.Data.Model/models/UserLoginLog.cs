namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserLoginLog")]
    public partial class UserLoginLog
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public Guid Token { get; set; }

        [StringLength(255)]
        public string LoingIP { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime LastActiveTime { get; set; }

        public bool IsLogout { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual User User { get; set; }
    }
}
