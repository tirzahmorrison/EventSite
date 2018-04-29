namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLongitudeAndLatitude : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Events", "Longitude", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Longitude");
            DropColumn("dbo.Events", "Latitude");
        }
    }
}
