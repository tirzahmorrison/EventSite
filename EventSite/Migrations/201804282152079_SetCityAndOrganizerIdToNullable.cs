namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetCityAndOrganizerIdToNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Events", "OrganizerId", "dbo.Users");
            DropIndex("dbo.Events", new[] { "CityId" });
            DropIndex("dbo.Events", new[] { "OrganizerId" });
            AlterColumn("dbo.Events", "CityId", c => c.Int());
            AlterColumn("dbo.Events", "OrganizerId", c => c.Int());
            CreateIndex("dbo.Events", "CityId");
            CreateIndex("dbo.Events", "OrganizerId");
            AddForeignKey("dbo.Events", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Events", "OrganizerId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "OrganizerId", "dbo.Users");
            DropForeignKey("dbo.Events", "CityId", "dbo.Cities");
            DropIndex("dbo.Events", new[] { "OrganizerId" });
            DropIndex("dbo.Events", new[] { "CityId" });
            AlterColumn("dbo.Events", "OrganizerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "OrganizerId");
            CreateIndex("dbo.Events", "CityId");
            AddForeignKey("dbo.Events", "OrganizerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
