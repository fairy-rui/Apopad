using Apopad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Apopad.Domain.Model
{
    public partial class Paper : IAggregateRoot<int>
    {
        #region Ctor
        public Paper()
        {
            Authors = new HashSet<Author>();
        }
        #endregion

        #region Properties
        public int Id { get; set; }

        public string PublicationType { get; set; }

        public string AuthorName { get; set; }

        public string AuthorFullName { get; set; }

        //public string ChineseName { get; set; }

        //public string FirstAuthorSignUnit { get; set; }

        //public int? SignOrder { get; set; }

        //public string DepartmentName { get; set; }

        //public string LabName { get; set; }

        public string DocumentTitle { get; set; }

        public string PublicationName { get; set; }

        public string Series { get; set; }

        public string Language { get; set; }

        public string DocumentType { get; set; }

        public string AuthorKeywords { get; set; }

        public string Keywords { get; set; }

        public string Abstract { get; set; }

        public string AuthorAddress { get; set; }

        public string ReprintAddress { get; set; }

        //public string ReprintAuthor { get; set; }

        //public string CorrespondenceSignUnit { get; set; }

        public string EmailAddress { get; set; }

        public string CitedReferences { get; set; }

        public int? CitedReferenceCount { get; set; }

        public int? TotalCitedCount { get; set; }

        public string Publisher { get; set; }

        public string PublisherCity { get; set; }

        public string PublisherAddress { get; set; }

        public string ISSN { get; set; }

        public string DOI { get; set; }

        public string SourceAbbreviation { get; set; }

        public string ISOSourceAbbreviation { get; set; }

        public DateTime? PublicationDate { get; set; }

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

        public string Categories { get; set; }

        //public string IncludeType { get; set; }

        public string DeliveryNumber { get; set; }

        public string AccessionNumber { get; set; }

        public PaperStatus Status { get; set; }

        public int? DepartmentId { get; set; }

        public byte[] TimeStamp { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual Department Department { get; set; }
        #endregion

        #region Public Methods
        public string[] getAuthorOriginalName()
        {
            return AuthorFullName.Split(';').Select(t => t.Trim()).ToArray();
        }

        public string[] getAuthorAbbrName()
        {
            return AuthorName.Split(';').Select(t => t.Trim()).ToArray();
        }
        public string[] extractAuthorFromAddress()
        {
            //匹配方括号中的作者名字
            string pattern = @"(?<=\[)[^]]*(?=\])";
            string[] ary = Regex.Matches(AuthorAddress, pattern).Cast<Match>().Select(t => t.Value.Trim()).ToArray();

            //作者地址中仅有作者单位
            if(ary.Count() == 0)
            {
                ary = new string[1] { AuthorFullName.Trim() };
            }

            return ary;
        }
        public string[] extractAuthorAddress()
        {
            //匹配C1中的作者地址
            string pattern = @"(?<=\[.+\])[^[]*(?=\[|$)";
            string[] ary = Regex.Matches(AuthorAddress, pattern).Cast<Match>().Select(t => t.Value.Trim()).ToArray();

            //作者地址中仅有作者单位
            if (ary.Count() == 0)
            {
                ary = new string[1] { AuthorAddress.Trim() };
            }

            return ary;
        }
        public string extractReprintAuthor()
        {
            //匹配通信作者
            string pattern = @"(?<=^)[^(]*(?=\()";
            return Regex.Match(ReprintAddress, pattern).Value.Trim();
        }

        #endregion
    }
}
