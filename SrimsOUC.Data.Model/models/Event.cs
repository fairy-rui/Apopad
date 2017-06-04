namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public int ID { get; set; }

        public Guid Guid { get; set; }

        public int Type { get; set; }

        [StringLength(255)]
        public string Parameter { get; set; }

        [StringLength(255)]
        public string CreateUser { get; set; }

        public DateTime CreateDateTime { get; set; }

        public bool IsComplete { get; set; }

        [StringLength(255)]
        public string CompleteUser { get; set; }

        public DateTime? CompleteDateTime { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
    }
}
