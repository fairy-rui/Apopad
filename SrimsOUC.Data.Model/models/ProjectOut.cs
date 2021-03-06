namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectOut")]
    public partial class ProjectOut
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public long Amount { get; set; }

        public int OutsourcingID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Outsourcing Outsourcing { get; set; }

        public virtual Project Project { get; set; }
    }
}
