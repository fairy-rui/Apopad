using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class DepartmentEntityConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentEntityConfiguration()
        {
            ToTable("Department");

            HasKey(d => d.Id);//设置主键
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsOptional();
            Property(d => d.Code)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(d => d.ZipCode)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(d => d.Type)
                .HasColumnType("int")
                .IsOptional();

            HasMany(d => d.DepartmentAlias)
                .WithRequired(a => a.Department)
                .HasForeignKey(a => a.DepartmentId)
                .WillCascadeOnDelete(false);

            HasMany(d => d.Children)
                .WithOptional(c => c.Parent)
                .HasForeignKey(c => c.ParentId)
                .WillCascadeOnDelete(false);

            HasMany(d => d.Papers)
                .WithOptional(p => p.Department)
                .HasForeignKey(p => p.DepartmentId)
                .WillCascadeOnDelete(false);

            HasMany(d => d.People)
                .WithRequired(p => p.Department)
                .HasForeignKey(p => p.DepartmentId)
                .WillCascadeOnDelete(false);

            //HasMany(d => d.Users)
            //    .WithOptional(u => u.Department)
            //    .HasForeignKey(u => u.DepartmentId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
