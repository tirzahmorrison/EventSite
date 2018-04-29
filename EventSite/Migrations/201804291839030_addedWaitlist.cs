namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedWaitlist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "User_Id1", c => c.Int());
            AddColumn("dbo.Users", "Event_Id1", c => c.Int());
            CreateIndex("dbo.Events", "User_Id1");
            CreateIndex("dbo.Users", "Event_Id1");
            AddForeignKey("dbo.Events", "User_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Event_Id1", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Event_Id1", "dbo.Events");
            DropForeignKey("dbo.Events", "User_Id1", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Event_Id1" });
            DropIndex("dbo.Events", new[] { "User_Id1" });
            DropColumn("dbo.Users", "Event_Id1");
            DropColumn("dbo.Events", "User_Id1");
        }
    }
}
