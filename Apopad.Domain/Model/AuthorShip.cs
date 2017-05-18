using Apopad.Common;
using System.Collections.Generic;

namespace Apopad.Domain.Model
{
    public partial class AuthorShip : IAggregateRoot<int>
    {
        public AuthorShip()
        {
            Coauthors = new HashSet<CoAuthorShip>();
            Collaborators = new HashSet<CoAuthorShip>();
            Keywords = new HashSet<AuthorKeyWord>();
        }

        public int Id { get; set; }
        public int? PersonId { get; set; }
        public string PersonNo { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        //public string AuthorKeywords { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<CoAuthorShip> Coauthors { get; set; }
        public virtual ICollection<CoAuthorShip> Collaborators { get; set; }
        public virtual ICollection<AuthorKeyWord> Keywords { get; set; }
    }
}
