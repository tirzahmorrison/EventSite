namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotatedInverses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Events", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Users", "Event_Id1", "dbo.Events");
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropIndex("dbo.Events", new[] { "User_Id1" });
            DropIndex("dbo.Users", new[] { "Event_Id1" });
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Event_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.UserEvent1",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Event_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Event_Id);
            
            AlterColumn("dbo.Comments", "UserId", c => c.Int());
            AlterColumn("dbo.Comments", "EventId", c => c.Int());
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Comments", "EventId");
            AddForeignKey("dbo.Comments", "EventId", "dbo.Events", "Id");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id");
            DropColumn("dbo.Events", "User_Id");
            DropColumn("dbo.Events", "User_Id1");
            DropColumn("dbo.Users", "Event_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Event_Id1", c => c.Int());
            AddColumn("dbo.Events", "User_Id1", c => c.Int());
            AddColumn("dbo.Events", "User_Id", c => c.Int());
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropForeignKey("dbo.UserEvent1", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.UserEvent1", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.UserEvents", "User_Id", "dbo.Users");
            DropIndex("dbo.UserEvent1", new[] { "Event_Id" });
            DropIndex("dbo.UserEvent1", new[] { "User_Id" });
            DropIndex("dbo.UserEvents", new[] { "Event_Id" });
            DropIndex("dbo.UserEvents", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            AlterColumn("dbo.Comments", "EventId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            DropTable("dbo.UserEvent1");
            DropTable("dbo.UserEvents");
            CreateIndex("dbo.Users", "Event_Id1");
            CreateIndex("dbo.Events", "User_Id1");
            CreateIndex("dbo.Events", "User_Id");
            CreateIndex("dbo.Comments", "EventId");
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Event_Id1", "dbo.Events", "Id");
            AddForeignKey("dbo.Events", "User_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.Events", "User_Id", "dbo.Users", "Id");
        }
    }
}
