namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StampApplicationFirstAdmin")]
    public partial class StampApplicationFirstAdmin
    {
        public int ID { get; set; }

        public int StampApplicationTypeID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual StampApplicationType StampApplicationType { get; set; }

        public virtual User User { get; set; }
    }
}
