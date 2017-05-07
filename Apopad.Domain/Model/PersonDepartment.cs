using Apopad.Common;
using System;

namespace Apopad.Domain.Model
{
    public partial class PersonDepartment : IEntity<int>
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int DepartmentId { get; set; }

        public DateTime? ComeDate { get; set; }

        public DateTime? LeaveDate { get; set; }

        public virtual Department Department { get; set; }

        public virtual Person Person { get; set; }
    }
}
