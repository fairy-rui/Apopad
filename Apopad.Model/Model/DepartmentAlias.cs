namespace Apopad.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DepartmentAlias
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        [StringLength(256)]
        public string Alias { get; set; }

        public virtual Department Department { get; set; }
    }
}
