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
    public class PaperEntityConfiguration : EntityTypeConfiguration<Paper>
    {
        public PaperEntityConfiguration()
        {
            ToTable("Paper");

            HasKey(p => p.Id);//设置主键
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.PressType)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsOptional();
            Property(p => p.AuthorsShort)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            Property(p => p.AuthorsFull)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            Property(p => p.ChineseName)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.FirstAuthorSignUnit)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            Property(p => p.SignOrder)
                .HasColumnType("int")
                .IsOptional();
            Property(p => p.DepartmentName)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.LabName)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.PaperName)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.JournalName)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.Series)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsOptional();
            Property(p => p.Language)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(p => p.PaperType)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(p => p.AuthorKeyWord)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.KeyWords)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.Abstract)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.AuthorsAddress)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.CorrespondenceEN)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            Property(p => p.CorrespondenceCN)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            Property(p => p.CorrespondenceSignUnit)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            Property(p => p.EmailAddress)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            Property(p => p.Reference)
                .HasColumnType("text")
                .IsOptional();
            Property(p => p.ReferenceCount)
                .HasColumnType("int")
                .IsOptional();
            Property(p => p.CitedCount)
                .HasColumnType("int")
                .IsOptional();
            Property(p => p.Press)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.City)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.PressAddress)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.ISSN)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(p => p.DI)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(p => p.StandardJournalAbbr)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.ISIJournalAbbr)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.PublishDate)
                .HasColumnType("date")
                .IsOptional();
            Property(p => p.Year)
                .HasColumnType("int")
                .IsOptional();
            Property(p => p.Volume)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(p => p.Issue)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(p => p.PartNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(p => p.Supplement)
                .HasColumnType("bit")      
                .IsOptional();
            Property(p => p.SpecialIssue)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsOptional();
            Property(p => p.StartPage)
                .HasColumnType("int")
                .IsOptional();
            Property(p => p.EndPage)
                .HasColumnType("int")
                .IsOptional();
            Property(p => p.PageCount)
                .HasColumnType("int")
                .IsOptional();
            Property(p => p.ArticleNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsOptional();
            Property(p => p.SubjectCategory)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            Property(p => p.IncludeType)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(p => p.ISIDeliveryNo)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsOptional();
            Property(p => p.ISIArticleIdentifier)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(p => p.status)
                .HasColumnType("int")
                .IsRequired();

            HasMany(p => p.Authors)
                .WithRequired(a => a.Paper)
                .HasForeignKey(a => a.PaperId)
                .WillCascadeOnDelete(false);
        }
    }
}
