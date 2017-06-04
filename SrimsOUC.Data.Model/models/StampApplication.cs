namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StampApplication")]
    public partial class StampApplication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StampApplication()
        {
            StampStateHistory1 = new HashSet<StampStateHistory>();
            Stuff = new HashSet<Stuff>();
        }

        public int ID { get; set; }

        public int? StampStuffFromID { get; set; }

        [StringLength(255)]
        public string StampStuffFromName { get; set; }

        public int StuffNumber { get; set; }

        [StringLength(255)]
        public string StampReason { get; set; }

        [StringLength(255)]
        public string KeyWord { get; set; }

        [StringLength(255)]
        public string Manager { get; set; }

        [StringLength(255)]
        public string ManagerPhone { get; set; }

        public int PrincipalID { get; set; }

        public int? CurrentStateID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        [StringLength(255)]
        public string ManagerEmail { get; set; }

        public bool IsDuplexPrint { get; set; }

        public bool SealPerforation { get; set; }

        public bool ExpertPrint { get; set; }

        [StringLength(50)]
        public string Administrator { get; set; }

        public int? StampApplicationTypeID { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual Project Project { get; set; }

        public virtual StampStateHistory StampStateHistory { get; set; }

        public virtual StampApplicationType StampApplicationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StampStateHistory> StampStateHistory1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stuff> Stuff { get; set; }
    }
}
