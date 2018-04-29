namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventIdToCommentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            AddColumn("dbo.Events", "AttendeeCount", c => c.Int());
            AddColumn("dbo.Messages", "ToUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "FromUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Messages", "From");
            DropColumn("dbo.Messages", "To");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "To", c => c.String());
            AddColumn("dbo.Messages", "From", c => c.String());
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.Messages", "FromUserId");
            DropColumn("dbo.Messages", "ToUserId");
            DropColumn("dbo.Events", "AttendeeCount");
            DropTable("dbo.Comments");
        }
    }
}
