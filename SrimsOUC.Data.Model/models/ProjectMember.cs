namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectMember")]
    public partial class ProjectMember
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public int ExpertID { get; set; }

        public int Order { get; set; }

        [StringLength(255)]
        public string TaskNo { get; set; }

        [StringLength(255)]
        public string TaskName { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public bool? IsExpertSecondCollege { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual Project Project { get; set; }
    }
}
