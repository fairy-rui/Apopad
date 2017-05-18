using Apopad.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public class PaperEntityConfiguration : EntityTypeConfiguration<Paper>
    {
        public PaperEntityConfiguration()
        {
            ToTable("Paper");

            HasKey(p => p.Id);//设置主键
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.PublicationType)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsOptional();
            Property(p => p.AuthorName)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            Property(p => p.AuthorFullName)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            //Property(p => p.ChineseName)
            //    .HasColumnType("nvarchar(max)")
            //    .IsOptional();
            //Property(p => p.FirstAuthorSignUnit)
            //    .HasColumnType("nvarchar")
            //    .HasMaxLength(1024)
            //    .IsOptional();
            //Property(p => p.SignOrder)
            //    .HasColumnType("int")
            //    .IsOptional();
            //Property(p => p.DepartmentName)
            //    .HasColumnType("nvarchar")
            //    .HasMaxLength(512)
            //    .IsOptional();
            //Property(p => p.LabName)
            //    .HasColumnType("nvarchar")
            //    .HasMaxLength(512)
            //    .IsOptional();
            Property(p => p.DocumentTitle)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.PublicationName)
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
            Property(p => p.DocumentType)
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(p => p.AuthorKeywords)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.Keywords)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.Abstract)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.AuthorAddress)
                .HasColumnType("nvarchar(max)")
                .IsOptional();
            Property(p => p.ReprintAddress)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            //Property(p => p.ReprintAuthor)
            //    .HasColumnType("nvarchar")
            //    .HasMaxLength(1024)
            //    .IsOptional();
            //Property(p => p.CorrespondenceSignUnit)
            //    .HasColumnType("nvarchar")
            //    .HasMaxLength(1024)
            //    .IsOptional();
            Property(p => p.EmailAddress)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            Property(p => p.CitedReferences)
                .HasColumnType("text")
                .IsOptional();
            Property(p => p.CitedReferenceCount)
                .HasColumnType("int")
                .IsOptional();
            Property(p => p.TotalCitedCount)
                .HasColumnType("int")
                .IsOptional();
            Property(p => p.Publisher)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.PublisherCity)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.PublisherAddress)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.ISSN)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(p => p.DOI)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(p => p.SourceAbbreviation)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.ISOSourceAbbreviation)
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsOptional();
            Property(p => p.PublicationDate)
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
            Property(p => p.Categories)
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            //Property(p => p.IncludeType)
            //    .HasColumnType("nvarchar")
            //    .HasMaxLength(128)
            //    .IsOptional();
            Property(p => p.DeliveryNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsOptional();
            Property(p => p.AccessionNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(p => p.Status)
                .HasColumnType("int")
                .IsRequired();
            Property(p => p.TimeStamp)
                .IsRequired()
                .IsRowVersion()
                .HasMaxLength(8);

            HasMany(p => p.Authors)
                .WithRequired(a => a.Paper)
                .HasForeignKey(a => a.PaperId)
                .WillCascadeOnDelete(false);
        }
    }
}
