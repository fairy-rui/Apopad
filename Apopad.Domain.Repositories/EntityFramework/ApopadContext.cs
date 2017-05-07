using Apopad.Domain.Model;
using System.Data.Entity;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class ApopadContext : DbContext
    {
        public ApopadContext()
            : base("ApopadDb")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentAlias> DepartmentAlias { get; set; }
        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonDepartment> PersonDepartments { get; set; }
        //public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorEntityConfiguration())
                .Add(new CandidateEntityConfiguration())
                .Add(new DepartmentEntityConfiguration())
                .Add(new DepartmentAliasEntityConfiguration())
                .Add(new PaperEntityConfiguration())
                .Add(new PersonDepartmentEntityConfiguration())
                .Add(new PersonEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
