namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectQualityPrincipal")]
    public partial class ProjectQualityPrincipal
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public int ExpertID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual Project Project { get; set; }
    }
}
