namespace MVCLibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIssuedItemMemberAndAccRegisterReal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessionRegisters",
                c => new
                    {
                        AccessionId = c.Int(nullable: false, identity: true),
                        DateOfReceipt = c.DateTime(nullable: false),
                        Source = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Item_ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.AccessionId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId)
                .Index(t => t.Item_ItemId);
            
            CreateTable(
                "dbo.IssuedItems",
                c => new
                    {
                        IssuedItemId = c.Int(nullable: false, identity: true),
                        IssueDate = c.DateTime(nullable: false),
                        LateFeePerDay = c.Int(nullable: false),
                        AccessionRecord_AccessionId = c.Int(),
                        Item_ItemId = c.Int(),
                        Member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.IssuedItemId)
                .ForeignKey("dbo.AccessionRegisters", t => t.AccessionRecord_AccessionId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId)
                .ForeignKey("dbo.Members", t => t.Member_MemberId)
                .Index(t => t.AccessionRecord_AccessionId)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssuedItems", "Member_MemberId", "dbo.Members");
            DropForeignKey("dbo.IssuedItems", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.IssuedItems", "AccessionRecord_AccessionId", "dbo.AccessionRegisters");
            DropForeignKey("dbo.AccessionRegisters", "Item_ItemId", "dbo.Items");
            DropIndex("dbo.IssuedItems", new[] { "Member_MemberId" });
            DropIndex("dbo.IssuedItems", new[] { "Item_ItemId" });
            DropIndex("dbo.IssuedItems", new[] { "AccessionRecord_AccessionId" });
            DropIndex("dbo.AccessionRegisters", new[] { "Item_ItemId" });
            DropTable("dbo.Members");
            DropTable("dbo.IssuedItems");
            DropTable("dbo.AccessionRegisters");
        }
    }
}
