namespace MVCLibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class justwork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        BookType = c.Int(nullable: false),
                        Item_ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId)
                .Index(t => t.Item_ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.IssuedItems",
                c => new
                    {
                        IssuedItemId = c.Int(nullable: false, identity: true),
                        IssueDate = c.DateTime(nullable: false),
                        LateFeePerDay = c.Int(nullable: false),
                        Item_ItemId = c.Int(),
                        Member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.IssuedItemId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId)
                .ForeignKey("dbo.Members", t => t.Member_MemberId)
                .Index(t => t.Item_ItemId)
                .Index(t => t.Member_MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MemberType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Newspapers",
                c => new
                    {
                        NewspaperId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Category = c.Int(nullable: false),
                        Item_ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.NewspaperId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId)
                .Index(t => t.Item_ItemId);
            
            CreateTable(
                "dbo.QuestionPapers",
                c => new
                    {
                        QuestionPaperId = c.Int(nullable: false, identity: true),
                        Department = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Subject = c.String(),
                        Item_ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionPaperId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId)
                .Index(t => t.Item_ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionPapers", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.Newspapers", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.IssuedItems", "Member_MemberId", "dbo.Members");
            DropForeignKey("dbo.IssuedItems", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.Books", "Item_ItemId", "dbo.Items");
            DropIndex("dbo.QuestionPapers", new[] { "Item_ItemId" });
            DropIndex("dbo.Newspapers", new[] { "Item_ItemId" });
            DropIndex("dbo.IssuedItems", new[] { "Member_MemberId" });
            DropIndex("dbo.IssuedItems", new[] { "Item_ItemId" });
            DropIndex("dbo.Books", new[] { "Item_ItemId" });
            DropTable("dbo.QuestionPapers");
            DropTable("dbo.Newspapers");
            DropTable("dbo.Members");
            DropTable("dbo.IssuedItems");
            DropTable("dbo.Items");
            DropTable("dbo.Books");
        }
    }
}
