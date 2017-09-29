namespace MVCLibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessionRecord3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessionRecords",
                c => new
                    {
                        AccessionRecordId = c.Int(nullable: false, identity: true),
                        DateOfReceipt = c.DateTime(nullable: false),
                        Source = c.String(),
                        Price = c.Int(nullable: false),
                        Item_ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessionRecordId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId, cascadeDelete: true)
                .Index(t => t.Item_ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccessionRecords", "Item_ItemId", "dbo.Items");
            DropIndex("dbo.AccessionRecords", new[] { "Item_ItemId" });
            DropTable("dbo.AccessionRecords");
        }
    }
}
