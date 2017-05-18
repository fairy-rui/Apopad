using Apopad.Domain.Model;
using System.Data.Entity;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class ApopadContext : DbContext
    {
        public ApopadContext()
            : base("ApopadContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentAlias> DepartmentAlias { get; set; }
        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonDepartment> PersonDepartments { get; set; }
        public virtual DbSet<AuthorShip> AuthorShip { get; set; }
        public virtual DbSet<CoAuthorShip> CoAuthorShip { get; set; }
        public virtual DbSet<KeyWords> KeyWords { get; set; }
        public virtual DbSet<AuthorKeyWord> AuthorKeyWords { get; set; }
        //public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorEntityConfiguration())
                .Add(new CandidateEntityConfiguration())
                .Add(new DepartmentEntityConfiguration())
                .Add(new DepartmentAliasEntityConfiguration())
                .Add(new PaperEntityConfiguration())
                .Add(new PersonDepartmentEntityConfiguration())
                .Add(new PersonEntityConfiguration())
                .Add(new AuthorShipEntityConfiguration())
                .Add(new CoAuthorShipEntityConfiguration())
                .Add(new KeyWordsEntityConfiguration())
                .Add(new AuthorKeyWordEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
