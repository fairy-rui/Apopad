namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Document")]
    public partial class Document
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Author { get; set; }

        public DateTime? SubmitDateTime { get; set; }

        public DateTime? Deadline { get; set; }

        public int State { get; set; }

        [StringLength(255)]
        public string Censor { get; set; }

        public DateTime? CensorDateTime { get; set; }

        public bool IsRequire { get; set; }

        public Guid? DocumentResource { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Project Project { get; set; }
    }
}
