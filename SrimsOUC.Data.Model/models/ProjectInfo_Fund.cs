namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProjectInfo_Fund
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectInfo_Fund()
        {
            FundDescend = new HashSet<FundDescend>();
            FundMember = new HashSet<FundMember>();
            PayPlanItem = new HashSet<PayPlanItem>();
            Project = new HashSet<Project>();
        }

        public int ID { get; set; }

        public int ProjectID { get; set; }

        [StringLength(255)]
        public string AccountBookNumber { get; set; }

        public int AccountBookNumberCount { get; set; }

        [StringLength(255)]
        public string FundFrom { get; set; }

        [StringLength(255)]
        public string FundFromUnit { get; set; }

        [StringLength(255)]
        public string FundFromUnitAddress { get; set; }

        public long FundContract { get; set; }

        public long FundTotal { get; set; }

        public long FundPlanOut { get; set; }

        public long FundPlanHardware { get; set; }

        public long FundReceived { get; set; }

        public long FundAlreadyIn { get; set; }

        public long FundAlreadyOut { get; set; }

        public long FundAlreadyHardware { get; set; }

        public long OverheadExpenseInTotal { get; set; }

        public long OverheadExpenseOutTotal { get; set; }

        public long OverheadExpensesAlreadyIn { get; set; }

        public long OverheadExpensesAlreadyOut { get; set; }

        public long BorrowAmount { get; set; }

        public long ReturnAmount { get; set; }

        public int? FundManageProportion { get; set; }

        public long? PerformancePay { get; set; }

        public long? PerformancePayAlready { get; set; }

        public long? FundAdjust { get; set; }

        public long? EquipmentCost { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public long? IndirectCosts { get; set; }

        public long? ProjectPerformancePay { get; set; }

        [StringLength(255)]
        public string PerformanceAccountBookNumber { get; set; }

        public int? PerformanceAccountBookNumberCount { get; set; }

        public long? OverHeadExpenseInStandard { get; set; }

        public long? PerformanceInStandard { get; set; }

        public long? OverheadExpenseMiddleTotal { get; set; }

        public long? OverheadExpenseExpertTotal { get; set; }

        public long? CampusIndirectCosts { get; set; }

        public long? OverheadExpensesAlreadyMiddle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FundDescend> FundDescend { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FundMember> FundMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayPlanItem> PayPlanItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project { get; set; }

        public virtual Project Project1 { get; set; }
    }
}
