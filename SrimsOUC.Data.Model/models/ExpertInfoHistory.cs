namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExpertInfoHistory")]
    public partial class ExpertInfoHistory
    {
        public int ID { get; set; }

        public int ExpertID { get; set; }

        [StringLength(255)]
        public string PropertyName { get; set; }

        public int PropertyValueType { get; set; }

        [StringLength(255)]
        public string PropertyStringValue { get; set; }

        public int? PropertyIntValue { get; set; }

        public DateTime? PropertyDateTimeValue { get; set; }

        public Guid? PropertyGuildValue { get; set; }

        public bool? PropertyBooleanValue { get; set; }

        public string PropertyLongStringValue { get; set; }

        public DateTime SubmitTime { get; set; }

        [StringLength(255)]
        public string SubmitOperator { get; set; }

        public DateTime? CensorTime { get; set; }

        [StringLength(255)]
        public string CensorOperator { get; set; }

        public int? CensorState { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Expert Expert { get; set; }
    }
}
