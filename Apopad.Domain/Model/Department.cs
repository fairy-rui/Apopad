using Apopad.Common;
using System.Collections.Generic;

namespace Apopad.Domain.Model
{
    public partial class Department : IAggregateRoot<int>
    {        
        public Department()
        {
            DepartmentAlias = new HashSet<DepartmentAlias>();
            Children = new HashSet<Department>();
            Papers = new HashSet<Paper>();
            People = new HashSet<PersonDepartment>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string ZipCode { get; set; }

        public int? ParentId { get; set; }

        public DepartmentType? Type { get; set; }

        public virtual ICollection<DepartmentAlias> DepartmentAlias { get; set; }

        public virtual ICollection<Department> Children { get; set; }

        public virtual Department Parent { get; set; }

        public virtual ICollection<Paper> Papers { get; set; }

        public virtual ICollection<PersonDepartment> People { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
