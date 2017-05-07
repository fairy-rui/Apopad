using Apopad.Common;

namespace Apopad.Domain.Model
{
    public partial class DepartmentAlias : IAggregateRoot<int>
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string Alias { get; set; }

        public virtual Department Department { get; set; }
    }
}
