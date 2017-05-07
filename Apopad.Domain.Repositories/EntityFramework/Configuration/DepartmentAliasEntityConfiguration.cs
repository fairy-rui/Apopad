using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class DepartmentAliasEntityConfiguration : EntityTypeConfiguration<DepartmentAlias>
    {
        public DepartmentAliasEntityConfiguration()
        {
            ToTable("DepartmentAlias");

            HasKey(d => d.Id);//设置主键
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Alias)
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
