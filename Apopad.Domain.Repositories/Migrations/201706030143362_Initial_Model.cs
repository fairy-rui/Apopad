namespace Apopad.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorKeyWord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        KeywordId = c.Int(nullable: false),
                        Weight = c.Double(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuthorShip", t => t.AuthorId)
                .ForeignKey("dbo.KeyWords", t => t.KeywordId)
                .Index(t => t.AuthorId)
                .Index(t => t.KeywordId);
            
            CreateTable(
                "dbo.AuthorShip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(),
                        PersonNo = c.String(maxLength: 64),
                        Name = c.String(maxLength: 128),
                        EnglishName = c.String(maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.CoAuthorShip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoauthorId = c.Int(nullable: false),
                        CollaboratorId = c.Int(nullable: false),
                        Weight = c.Double(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuthorShip", t => t.CoauthorId)
                .ForeignKey("dbo.AuthorShip", t => t.CollaboratorId)
                .Index(t => t.CoauthorId)
                .Index(t => t.CollaboratorId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonNo = c.String(nullable: false, maxLength: 64),
                        NameCN = c.String(nullable: false, maxLength: 128),
                        NameEN = c.String(nullable: false, maxLength: 128),
                        NameENAbbr = c.String(nullable: false, maxLength: 128),
                        Sex = c.String(maxLength: 6),
                        Birthday = c.DateTime(storeType: "date"),
                        IDCard = c.String(maxLength: 256),
                        Mobile = c.String(maxLength: 64),
                        Email = c.String(maxLength: 512),
                        Tutor = c.String(maxLength: 128),
                        PersonType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candidate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        PersonId = c.Int(),
                        PersonNo = c.String(maxLength: 64),
                        Name = c.String(maxLength: 128),
                        Status = c.Int(nullable: false),
                        Operator = c.String(maxLength: 64),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.AuthorId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.AuthorId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaperId = c.Int(nullable: false),
                        Ordinal = c.Int(nullable: false),
                        NameEN = c.String(maxLength: 128),
                        NameENAbbr = c.String(maxLength: 128),
                        DepartmentName = c.String(maxLength: 1024),
                        IsCorrespondingAuthor = c.Boolean(nullable: false),
                        PublishDate = c.DateTime(storeType: "date"),
                        IsOtherUnit = c.Boolean(nullable: false),
                        SignOrdinal = c.Int(nullable: false),
                        HasCandidate = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paper", t => t.PaperId)
                .Index(t => t.PaperId);
            
            CreateTable(
                "dbo.Paper",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicationType = c.String(maxLength: 255),
                        AuthorName = c.String(nullable: false),
                        AuthorFullName = c.String(nullable: false),
                        DocumentTitle = c.String(),
                        PublicationName = c.String(maxLength: 512),
                        Series = c.String(maxLength: 255),
                        Language = c.String(maxLength: 64),
                        DocumentType = c.String(maxLength: 64),
                        AuthorKeywords = c.String(),
                        Keywords = c.String(),
                        Abstract = c.String(),
                        AuthorAddress = c.String(),
                        ReprintAddress = c.String(maxLength: 1024),
                        EmailAddress = c.String(maxLength: 1024),
                        CitedReferences = c.String(unicode: false, storeType: "text"),
                        CitedReferenceCount = c.Int(),
                        TotalCitedCount = c.Int(),
                        Publisher = c.String(maxLength: 512),
                        PublisherCity = c.String(maxLength: 512),
                        PublisherAddress = c.String(maxLength: 512),
                        ISSN = c.String(maxLength: 128),
                        DOI = c.String(maxLength: 128),
                        SourceAbbreviation = c.String(maxLength: 512),
                        ISOSourceAbbreviation = c.String(maxLength: 512),
                        PublicationDate = c.DateTime(storeType: "date"),
                        Year = c.Int(),
                        Volume = c.String(maxLength: 64),
                        Issue = c.String(maxLength: 64),
                        PartNumber = c.String(maxLength: 64),
                        Supplement = c.Boolean(),
                        SpecialIssue = c.String(maxLength: 255),
                        StartPage = c.Int(),
                        EndPage = c.Int(),
                        PageCount = c.Int(),
                        ArticleNumber = c.String(maxLength: 255),
                        Categories = c.String(maxLength: 1024),
                        DeliveryNumber = c.String(maxLength: 255),
                        AccessionNumber = c.String(maxLength: 128),
                        Status = c.Int(nullable: false),
                        DepartmentId = c.Int(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Code = c.String(maxLength: 64),
                        ZipCode = c.String(maxLength: 64),
                        ParentId = c.Int(),
                        Type = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.DepartmentAlias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        Alias = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.PersonDepartment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        ComeDate = c.DateTime(storeType: "date"),
                        LeaveDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.KeyWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1024),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorKeyWord", "KeywordId", "dbo.KeyWords");
            DropForeignKey("dbo.AuthorShip", "PersonId", "dbo.Person");
            DropForeignKey("dbo.PersonDepartment", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Candidate", "PersonId", "dbo.Person");
            DropForeignKey("dbo.PersonDepartment", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Paper", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.DepartmentAlias", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "ParentId", "dbo.Department");
            DropForeignKey("dbo.Author", "PaperId", "dbo.Paper");
            DropForeignKey("dbo.Candidate", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.AuthorKeyWord", "AuthorId", "dbo.AuthorShip");
            DropForeignKey("dbo.CoAuthorShip", "CollaboratorId", "dbo.AuthorShip");
            DropForeignKey("dbo.CoAuthorShip", "CoauthorId", "dbo.AuthorShip");
            DropIndex("dbo.PersonDepartment", new[] { "DepartmentId" });
            DropIndex("dbo.PersonDepartment", new[] { "PersonId" });
            DropIndex("dbo.DepartmentAlias", new[] { "DepartmentId" });
            DropIndex("dbo.Department", new[] { "ParentId" });
            DropIndex("dbo.Paper", new[] { "DepartmentId" });
            DropIndex("dbo.Author", new[] { "PaperId" });
            DropIndex("dbo.Candidate", new[] { "PersonId" });
            DropIndex("dbo.Candidate", new[] { "AuthorId" });
            DropIndex("dbo.CoAuthorShip", new[] { "CollaboratorId" });
            DropIndex("dbo.CoAuthorShip", new[] { "CoauthorId" });
            DropIndex("dbo.AuthorShip", new[] { "PersonId" });
            DropIndex("dbo.AuthorKeyWord", new[] { "KeywordId" });
            DropIndex("dbo.AuthorKeyWord", new[] { "AuthorId" });
            DropTable("dbo.KeyWords");
            DropTable("dbo.PersonDepartment");
            DropTable("dbo.DepartmentAlias");
            DropTable("dbo.Department");
            DropTable("dbo.Paper");
            DropTable("dbo.Author");
            DropTable("dbo.Candidate");
            DropTable("dbo.Person");
            DropTable("dbo.CoAuthorShip");
            DropTable("dbo.AuthorShip");
            DropTable("dbo.AuthorKeyWord");
        }
    }
}
