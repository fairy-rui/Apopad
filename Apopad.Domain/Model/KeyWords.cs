using Apopad.Common;
using System.Collections.Generic;

namespace Apopad.Domain.Model
{
    public partial class KeyWords : IAggregateRoot<int>
    {
        public KeyWords()
        {
            Authors = new HashSet<AuthorKeyWord>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<AuthorKeyWord> Authors { get; set; }
    }
}
