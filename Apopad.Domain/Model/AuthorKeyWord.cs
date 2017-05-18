using Apopad.Common;

namespace Apopad.Domain.Model
{
    public partial class AuthorKeyWord : IEntity<int>
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int KeywordId { get; set; }
        public double Weight { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual AuthorShip Author { get; set; }
        public virtual KeyWords Keyword { get; set; }
    }
}
