namespace SrimsOUC.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRolePermission")]
    public partial class UserRolePermission
    {
        public int ID { get; set; }

        public int UserRoleID { get; set; }

        public int PermissionID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
