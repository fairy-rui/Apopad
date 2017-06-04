namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("View")]
    public partial class View
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int Type { get; set; }

        public string Definition { get; set; }

        public int Order { get; set; }

        public bool IsPublic { get; set; }

        public int? UserID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual User User { get; set; }
    }
}
