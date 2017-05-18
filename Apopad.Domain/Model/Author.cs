using Apopad.Common;
using System;
using System.Collections.Generic;

namespace Apopad.Domain.Model
{
    public partial class Author : IEntity<int>
    {      
        public Author()
        {
            Candidates = new HashSet<Candidate>();
        }

        public int Id { get; set; }

        public int PaperId { get; set; }

        public int Ordinal { get; set; }

        public string NameEN { get; set; }

        public string NameENAbbr { get; set; }

        public string DepartmentName { get; set; }

        public bool IsCorrespondingAuthor { get; set; }

        public DateTime? PublishDate { get; set; }

        public bool IsOtherUnit { get; set; }

        public int SignOrdinal { get; set; }

        public bool HasCandidate { get; set; }

        public byte[] TimeStamp { get; set; }

        public virtual Paper Paper { get; set; }
        
        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
