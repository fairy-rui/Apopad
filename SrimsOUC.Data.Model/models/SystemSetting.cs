namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemSetting")]
    public partial class SystemSetting
    {
        public int ID { get; set; }

        public int? FundOutRatio { get; set; }

        public int HorizontalVoucher { get; set; }

        public int VerticalVoucher { get; set; }

        public int DefaultOverheadExpenseInRateHorizonal { get; set; }

        public int DefaultOverheadExpenseOutRateHorizonal { get; set; }

        public int DefaultOverheadExpenseInRateVertical { get; set; }

        public int DefaultOverheadExpenseOutRateVertical { get; set; }

        public string LogType { get; set; }

        [StringLength(255)]
        public string EmailAddress { get; set; }

        [StringLength(255)]
        public string SmtpHost { get; set; }

        public int? SmtpPort { get; set; }

        [StringLength(255)]
        public string SmtpPassword { get; set; }

        [StringLength(255)]
        public string SmtpUsername { get; set; }

        [StringLength(255)]
        public string FinanceWebAddress { get; set; }

        [StringLength(255)]
        public string ExpertWebAddress { get; set; }

        [StringLength(255)]
        public string WindowsServiceType { get; set; }

        [StringLength(255)]
        public string PaperDescription { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public int HorizontalPerformanceVoucher { get; set; }

        public int VPV { get; set; }
    }
}
