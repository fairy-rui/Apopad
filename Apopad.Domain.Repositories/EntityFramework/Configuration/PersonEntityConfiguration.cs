using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class PersonEntityConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonEntityConfiguration()
        {
            ToTable("Person");

            HasKey(p => p.Id);//设置主键
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.PersonNo)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsRequired();
            Property(p => p.NameCN)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();
            Property(p => p.NameEN)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();
            Property(p => p.NameENAbbr)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();
            Property(p => p.Sex)
                .HasColumnType("nvarchar")
                .HasMaxLength(6)
                .IsOptional();
            Property(p => p.Birthday)
                .HasColumnType("date")
                .IsOptional();
            Property(p => p.IDCard)
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsOptional();
            Property(p => p.Mobile)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(p => p.Email)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.Tutor)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(p => p.PersonType)
                .HasColumnType("int")
                .IsRequired();

            HasMany(p => p.Departments)
                .WithRequired(d => d.Person)
                .HasForeignKey(d => d.PersonId)
                .WillCascadeOnDelete(false);
        }
    }
}
