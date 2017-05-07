using Apopad.Common;
using System;
using System.Collections.Generic;

namespace Apopad.Domain.Model
{
    public partial class Paper : IAggregateRoot<int>
    {       
        public Paper()
        {
            Authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        public string PressType { get; set; }

        public string AuthorsShort { get; set; }

        public string AuthorsFull { get; set; }

        public string ChineseName { get; set; }

        public string FirstAuthorSignUnit { get; set; }

        public int? SignOrder { get; set; }

        public string DepartmentName { get; set; }

        public string LabName { get; set; }

        public string PaperName { get; set; }

        public string JournalName { get; set; }

        public string Series { get; set; }

        public string Language { get; set; }

        public string PaperType { get; set; }

        public string AuthorKeyWord { get; set; }

        public string KeyWords { get; set; }

        public string Abstract { get; set; }

        public string AuthorsAddress { get; set; }

        public string CorrespondenceEN { get; set; }

        public string CorrespondenceCN { get; set; }

        public string CorrespondenceSignUnit { get; set; }

        public string EmailAddress { get; set; }

        public string Reference { get; set; }

        public int? ReferenceCount { get; set; }

        public int? CitedCount { get; set; }

        public string Press { get; set; }

        public string City { get; set; }

        public string PressAddress { get; set; }

        public string ISSN { get; set; }

        public string DI { get; set; }

        public string StandardJournalAbbr { get; set; }

        public string ISIJournalAbbr { get; set; }

        public DateTime? PublishDate { get; set; }

        public int? Year { get; set; }

        public string Volume { get; set; }

        public string Issue { get; set; }

        public string PartNumber { get; set; }

        public bool? Supplement { get; set; }

        public string SpecialIssue { get; set; }

        public int? StartPage { get; set; }

        public int? EndPage { get; set; }

        public int? PageCount { get; set; }

        public string ArticleNumber { get; set; }

        public string SubjectCategory { get; set; }

        public string IncludeType { get; set; }

        public string ISIDeliveryNo { get; set; }

        public string ISIArticleIdentifier { get; set; }

        public PaperStatus status { get; set; }

        public int? PaperDepartmentId { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual Department Department { get; set; }
    }
}
