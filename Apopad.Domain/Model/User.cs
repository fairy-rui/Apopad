using Apopad.Common;

namespace Apopad.Domain.Model
{
    public partial class User : IAggregateRoot<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public int? DepartmentId { get; set; }

        //public virtual Department Department { get; set; }
    }
}
