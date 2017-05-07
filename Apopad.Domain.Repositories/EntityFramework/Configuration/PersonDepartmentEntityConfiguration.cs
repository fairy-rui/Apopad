using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class PersonDepartmentEntityConfiguration : EntityTypeConfiguration<PersonDepartment>
    {
        public PersonDepartmentEntityConfiguration()
        {
            ToTable("PersonDepartment");

            HasKey(pd => pd.Id);//设置主键
            Property(pd => pd.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(pd => pd.ComeDate)
                .HasColumnType("date")
                .IsOptional();

            Property(pd => pd.LeaveDate)
                .HasColumnType("date")
                .IsOptional();
        }
    }
}
