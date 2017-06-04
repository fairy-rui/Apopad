namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Outsourcing")]
    public partial class Outsourcing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Outsourcing()
        {
            ProjectOut = new HashSet<ProjectOut>();
            ProjectOutsourcingBudget = new HashSet<ProjectOutsourcingBudget>();
            VoucherOut = new HashSet<VoucherOut>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string LegalRepresentativeName { get; set; }

        [StringLength(255)]
        public string RegisteredCapital { get; set; }

        [StringLength(255)]
        public string RegisteredCardNumber { get; set; }

        [StringLength(255)]
        public string OrganizationCode { get; set; }

        [StringLength(255)]
        public string TaxNumber { get; set; }

        [StringLength(255)]
        public string CompanyType { get; set; }

        [StringLength(255)]
        public string ManagementType { get; set; }

        public string BusinessScope { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? DealDateTimeStart { get; set; }

        public DateTime? DealDateTimeEnd { get; set; }

        [StringLength(255)]
        public string IsVerify { get; set; }

        [StringLength(255)]
        public string CompanyCard { get; set; }

        [StringLength(255)]
        public string GroupCard { get; set; }

        [StringLength(255)]
        public string TaxCard { get; set; }

        public string Remark { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public int? AdderID { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public virtual Expert Expert { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectOut> ProjectOut { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectOutsourcingBudget> ProjectOutsourcingBudget { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VoucherOut> VoucherOut { get; set; }
    }
}
