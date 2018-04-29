namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateventable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Event_Id", "dbo.Events");
            DropIndex("dbo.Users", new[] { "Event_Id" });
            DropColumn("dbo.Users", "Event_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Event_Id", c => c.Int());
            CreateIndex("dbo.Users", "Event_Id");
            AddForeignKey("dbo.Users", "Event_Id", "dbo.Events", "Id");
        }
    }
}
