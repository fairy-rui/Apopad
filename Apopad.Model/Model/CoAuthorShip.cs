namespace Apopad.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoAuthorShip")]
    public partial class CoAuthorShip
    {
        public int Id { get; set; }

        public int CoauthorId { get; set; }

        public int CollaboratorId { get; set; }

        public double? Weight { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual AuthorShip AuthorShip { get; set; }

        public virtual AuthorShip AuthorShip1 { get; set; }
    }
}
