namespace MVCLibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Department = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Subject = c.String(),
                        BookType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
            DropTable("dbo.Books");
        }
    }
}
