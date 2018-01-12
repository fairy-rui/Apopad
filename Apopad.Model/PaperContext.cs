namespace Apopad.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PaperContext : DbContext
    {
        public PaperContext()
            : base("name=PaperContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<AuthorKeyWord> AuthorKeyWord { get; set; }
        public virtual DbSet<AuthorShip> AuthorShip { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<CoAuthorShip> CoAuthorShip { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepartmentAlias> DepartmentAlias { get; set; }
        public virtual DbSet<KeyWords> KeyWords { get; set; }
        public virtual DbSet<Paper> Paper { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonDepartment> PersonDepartment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Candidate)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AuthorKeyWord>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<AuthorShip>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<AuthorShip>()
                .HasMany(e => e.AuthorKeyWord)
                .WithRequired(e => e.AuthorShip)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AuthorShip>()
                .HasMany(e => e.CoAuthorShip)
                .WithRequired(e => e.AuthorShip)
                .HasForeignKey(e => e.CoauthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AuthorShip>()
                .HasMany(e => e.CoAuthorShip1)
                .WithRequired(e => e.AuthorShip1)
                .HasForeignKey(e => e.CollaboratorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<CoAuthorShip>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Department1)
                .WithOptional(e => e.Department2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.DepartmentAlias)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.PersonDepartment)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KeyWords>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<KeyWords>()
                .HasMany(e => e.AuthorKeyWord)
                .WithRequired(e => e.KeyWords)
                .HasForeignKey(e => e.KeywordId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.CitedReferences)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Paper>()
                .HasMany(e => e.Author)
                .WithRequired(e => e.Paper)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonDepartment)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);
        }
    }
}
