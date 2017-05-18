using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class AuthorKeyWordEntityConfiguration : EntityTypeConfiguration<AuthorKeyWord>
    {
        public AuthorKeyWordEntityConfiguration()
        {
            ToTable("AuthorKeyWord");

            HasKey(a => a.Id);//设置主键
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Weight)
                .HasColumnType("float")
                .IsOptional();
            Property(a => a.TimeStamp)
                .IsRequired()
                .IsRowVersion()
                .HasMaxLength(8);
        }
    }
}
