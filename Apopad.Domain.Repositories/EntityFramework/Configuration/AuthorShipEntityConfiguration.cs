using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class AuthorShipEntityConfiguration : EntityTypeConfiguration<AuthorShip>
    {
        public AuthorShipEntityConfiguration()
        {
            ToTable("AuthorShip");

            HasKey(a => a.Id);//设置主键
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.PersonId)
                .HasColumnType("int")
                .IsOptional();
            Property(a => a.PersonNo)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(a => a.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(a => a.EnglishName)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            //Property(c => c.AuthorKeywords)
            //    .HasColumnType("nvarchar")
            //    .HasMaxLength(1024)
            //    .IsOptional();
            Property(c => c.TimeStamp)
                .IsRequired()
                .IsRowVersion()
                .HasMaxLength(8);

            HasMany(a => a.Coauthors)
                .WithRequired(c => c.Coauthor)
                .HasForeignKey(c => c.CoauthorId)
                .WillCascadeOnDelete(false);
            HasMany(a => a.Collaborators)
                .WithRequired(c => c.Collaborator)
                .HasForeignKey(c => c.CollaboratorId)
                .WillCascadeOnDelete(false);
            HasMany(a => a.Keywords)
                .WithRequired(k => k.Author)
                .HasForeignKey(k => k.AuthorId)
                .WillCascadeOnDelete(false);
        }
    }
}
