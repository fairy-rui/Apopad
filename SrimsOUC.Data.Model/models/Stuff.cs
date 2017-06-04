namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stuff")]
    public partial class Stuff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stuff()
        {
            StuffStamp = new HashSet<StuffStamp>();
        }

        public int ID { get; set; }

        public int StampApplicationID { get; set; }

        [StringLength(255)]
        public string StuffName { get; set; }

        [StringLength(255)]
        public string StuffType { get; set; }

        public Guid StuffDocument { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual StampApplication StampApplication { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StuffStamp> StuffStamp { get; set; }
    }
}
