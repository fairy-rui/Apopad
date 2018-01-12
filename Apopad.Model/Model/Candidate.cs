namespace Apopad.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Candidate")]
    public partial class Candidate
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int? PersonId { get; set; }

        [StringLength(64)]
        public string PersonNo { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        public CandidateStatus Status { get; set; }

        [StringLength(64)]
        public string Operator { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual Author Author { get; set; }

        public virtual Person Person { get; set; }
    }
}
