using Apopad.Common;

namespace Apopad.Domain.Model
{
    public partial class Candidate : IEntity<int>
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int PersonId { get; set; }

        public string PersonNo { get; set; }

        public string Name { get; set; }

        public CandidateStatus status { get; set; }

        public string Operator { get; set; }

        public virtual Author Author { get; set; }
    }
}
