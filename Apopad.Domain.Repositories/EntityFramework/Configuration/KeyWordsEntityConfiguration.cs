using Apopad.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class KeyWordsEntityConfiguration : EntityTypeConfiguration<KeyWords>
    {
        public KeyWordsEntityConfiguration()
        {
            ToTable("KeyWords");

            HasKey(k => k.Id);//设置主键
            Property(k => k.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(k => k.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsRequired();
            Property(c => c.TimeStamp)
                .IsRequired()
                .IsRowVersion()
                .HasMaxLength(8);

            HasMany(k => k.Authors)
                .WithRequired(a => a.Keyword)
                .HasForeignKey(a => a.KeywordId)
                .WillCascadeOnDelete(false);
        }
    }
}
