namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Announcement")]
    public partial class Announcement
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        public string Content { get; set; }

        public int State { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
    }
}
