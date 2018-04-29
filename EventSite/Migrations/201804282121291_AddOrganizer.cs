namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrganizer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CityZip = c.String(),
                        CityState = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Tagline = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        AgeGroup = c.Int(nullable: false),
                        KeyWord = c.String(),
                        CityId = c.Int(nullable: false),
                        OrganizerId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.OrganizerId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.OrganizerId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "OrganizerId", "dbo.Users");
            DropForeignKey("dbo.Events", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Events", "CityId", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropIndex("dbo.Events", new[] { "OrganizerId" });
            DropIndex("dbo.Events", new[] { "CityId" });
            DropTable("dbo.Users");
            DropTable("dbo.Events");
            DropTable("dbo.Cities");
        }
    }
}
