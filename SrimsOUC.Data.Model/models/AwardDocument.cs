namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AwardDocument")]
    public partial class AwardDocument
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int AwardID { get; set; }

        public int AuthorID { get; set; }

        public DateTime? SubmitDateTime { get; set; }

        public int State { get; set; }

        [StringLength(255)]
        public string Censor { get; set; }

        public DateTime? CensorDateTime { get; set; }

        public Guid Resource { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Award Award { get; set; }

        public virtual User User { get; set; }
    }
}
