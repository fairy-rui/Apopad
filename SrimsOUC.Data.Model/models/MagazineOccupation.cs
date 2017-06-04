namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MagazineOccupation")]
    public partial class MagazineOccupation
    {
        public int ID { get; set; }

        public int MagazineID { get; set; }

        public int ExpertID { get; set; }

        [Required]
        [StringLength(255)]
        public string Occupation { get; set; }

        public int? EngageStartYear { get; set; }

        [StringLength(255)]
        public string EngageEndYear { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual Magazine Magazine { get; set; }
    }
}
