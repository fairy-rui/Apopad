using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class CandidateEntityConfiguration : EntityTypeConfiguration<Candidate>
    {
        public CandidateEntityConfiguration()
        {
            ToTable("Candidate");

            HasKey(c => c.Id);//设置主键
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.PersonId)
                .HasColumnType("int")
                .IsOptional();
            Property(c => c.PersonNo)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(c => c.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(c => c.Status)
                .HasColumnType("int")
                .IsRequired();
            Property(c => c.Operator)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(c => c.TimeStamp)
                .IsRequired()
                .IsRowVersion()
                .HasMaxLength(8);
        }
    }
}
