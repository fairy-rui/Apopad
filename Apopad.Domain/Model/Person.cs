using Apopad.Common;
using System;
using System.Collections.Generic;

namespace Apopad.Domain.Model
{
    public partial class Person : IAggregateRoot<int>
    {        
        public Person()
        {
            Departments = new HashSet<PersonDepartment>();
        }

        public int Id { get; set; }

        public string PersonNo { get; set; }

        public string NameCN { get; set; }

        public string NameEN { get; set; }

        public string NameENAbbr { get; set; }

        public string Sex { get; set; }

        public DateTime? Birthday { get; set; }

        public string IDCard { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Tutor { get; set; }

        public PersonType PersonType { get; set; }

        public virtual ICollection<PersonDepartment> Departments { get; set; }
    }
}
