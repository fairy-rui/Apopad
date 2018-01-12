namespace Apopad.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonDepartment")]
    public partial class PersonDepartment
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int DepartmentId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ComeDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LeaveDate { get; set; }

        public virtual Department Department { get; set; }

        public virtual Person Person { get; set; }
    }
}
