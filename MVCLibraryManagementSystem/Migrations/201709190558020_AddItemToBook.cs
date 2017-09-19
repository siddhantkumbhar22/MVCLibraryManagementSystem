namespace MVCLibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Item_ItemId", c => c.Int());
            CreateIndex("dbo.Books", "Item_ItemId");
            AddForeignKey("dbo.Books", "Item_ItemId", "dbo.Items", "ItemId");
            DropColumn("dbo.Books", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ItemId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Books", "Item_ItemId", "dbo.Items");
            DropIndex("dbo.Books", new[] { "Item_ItemId" });
            DropColumn("dbo.Books", "Item_ItemId");
        }
    }
}
