using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class CoAuthorShipEntityConfiguration : EntityTypeConfiguration<CoAuthorShip>
    {
        public CoAuthorShipEntityConfiguration()
        {
            ToTable("CoAuthorShip");

            HasKey(c => c.Id);//设置主键
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Weight)
                .HasColumnType("float")
                .IsOptional();
            Property(c => c.TimeStamp)
                .IsRequired()
                .IsRowVersion()
                .HasMaxLength(8);
        }
    }
}
