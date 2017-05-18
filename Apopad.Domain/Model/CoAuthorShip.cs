using Apopad.Common;

namespace Apopad.Domain.Model
{
    public partial class CoAuthorShip : IEntity<int>
    {
        public int Id { get; set; }
        public int CoauthorId { get; set; }
        public int CollaboratorId { get; set; }
        public double Weight { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual AuthorShip Coauthor { get; set; }
        public virtual AuthorShip Collaborator { get; set; }
    }
}
