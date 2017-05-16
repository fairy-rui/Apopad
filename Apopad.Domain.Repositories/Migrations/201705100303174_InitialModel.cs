namespace Apopad.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paper", t => t.PaperId)
                .Index(t => t.PaperId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.Author", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.PersonId);
            
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
                "dbo.Paper",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PressType = c.String(maxLength: 255),
                        AuthorsShort = c.String(nullable: false),
                        AuthorsFull = c.String(nullable: false),
                        ChineseName = c.String(),
                        FirstAuthorSignUnit = c.String(maxLength: 1024),
                        SignOrder = c.Int(),
                        DepartmentName = c.String(maxLength: 512),
                        LabName = c.String(maxLength: 512),
                        PaperName = c.String(),
                        JournalName = c.String(maxLength: 512),
                        Series = c.String(maxLength: 255),
                        Language = c.String(maxLength: 64),
                        PaperType = c.String(maxLength: 64),
                        AuthorKeyWord = c.String(),
                        KeyWords = c.String(),
                        Abstract = c.String(),
                        AuthorsAddress = c.String(),
                        ReprintAddress = c.String(maxLength: 1024),
                        ReprintAuthor = c.String(maxLength: 1024),
                        CorrespondenceSignUnit = c.String(maxLength: 1024),
                        EmailAddress = c.String(maxLength: 1024),
                        Reference = c.String(unicode: false, storeType: "text"),
                        ReferenceCount = c.Int(),
                        CitedCount = c.Int(),
                        Press = c.String(maxLength: 512),
                        City = c.String(maxLength: 512),
                        PressAddress = c.String(maxLength: 512),
                        ISSN = c.String(maxLength: 128),
                        DI = c.String(maxLength: 128),
                        StandardJournalAbbr = c.String(maxLength: 512),
                        ISIJournalAbbr = c.String(maxLength: 512),
                        PublishDate = c.DateTime(storeType: "date"),
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
                        SubjectCategory = c.String(maxLength: 1024),
                        IncludeType = c.String(maxLength: 128),
                        ISIDeliveryNo = c.String(maxLength: 255),
                        ISIArticleIdentifier = c.String(maxLength: 128),
                        Status = c.Int(nullable: false),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidate", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.PersonDepartment", "PersonId", "dbo.Person");
            DropForeignKey("dbo.PersonDepartment", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Paper", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Author", "PaperId", "dbo.Paper");
            DropForeignKey("dbo.DepartmentAlias", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "ParentId", "dbo.Department");
            DropForeignKey("dbo.Candidate", "PersonId", "dbo.Person");
            DropIndex("dbo.Paper", new[] { "DepartmentId" });
            DropIndex("dbo.DepartmentAlias", new[] { "DepartmentId" });
            DropIndex("dbo.Department", new[] { "ParentId" });
            DropIndex("dbo.PersonDepartment", new[] { "DepartmentId" });
            DropIndex("dbo.PersonDepartment", new[] { "PersonId" });
            DropIndex("dbo.Candidate", new[] { "PersonId" });
            DropIndex("dbo.Candidate", new[] { "AuthorId" });
            DropIndex("dbo.Author", new[] { "PaperId" });
            DropTable("dbo.Paper");
            DropTable("dbo.DepartmentAlias");
            DropTable("dbo.Department");
            DropTable("dbo.PersonDepartment");
            DropTable("dbo.Person");
            DropTable("dbo.Candidate");
            DropTable("dbo.Author");
        }
    }
}
