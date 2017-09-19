namespace MVCLibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtherItems : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Books", "Author", c => c.String());
            DropColumn("dbo.Books", "Department");
            DropColumn("dbo.Books", "Month");
            DropColumn("dbo.Books", "Subject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Subject", c => c.String());
            AddColumn("dbo.Books", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Department", c => c.Int(nullable: false));
            DropForeignKey("dbo.QuestionPapers", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.Newspapers", "Item_ItemId", "dbo.Items");
            DropIndex("dbo.QuestionPapers", new[] { "Item_ItemId" });
            DropIndex("dbo.Newspapers", new[] { "Item_ItemId" });
            DropColumn("dbo.Books", "Author");
            DropTable("dbo.QuestionPapers");
            DropTable("dbo.Newspapers");
        }
    }
}
