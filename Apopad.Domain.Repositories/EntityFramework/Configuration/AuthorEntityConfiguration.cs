using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class AuthorEntityConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorEntityConfiguration()
        {
            ToTable("Author");

            HasKey(a => a.Id);//设置主键
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Ordinal)
                .HasColumnType("int")
                .IsRequired();
            Property(a => a.NameEN)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(a => a.NameENAbbr)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(a => a.DepartmentName)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            Property(a => a.IsCorrespondingAuthor)
                .HasColumnType("bit")
                .IsRequired();
            Property(a => a.PublishDate)
                .HasColumnType("date")
                .IsOptional();
            Property(a => a.IsOtherUnit)
                .HasColumnType("bit")
                .IsRequired();
            Property(a => a.SignOrdinal)
                .HasColumnType("int")
                .IsRequired();
            Property(a => a.HasCandidate)
                .HasColumnType("bit")
                .IsRequired();

            HasMany(a => a.Candidates)
                .WithRequired(c => c.Author)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);
        }
    }
}
