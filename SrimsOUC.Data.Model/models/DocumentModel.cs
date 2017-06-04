namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocumentModel")]
    public partial class DocumentModel
    {
        public int ID { get; set; }

        public int ProjectTypeID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public Guid Resource { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual ProjectType ProjectType { get; set; }
    }
}
