namespace MVCLibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsBooked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "IsBooked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "IsBooked");
        }
    }
}
