namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCityListName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Zip", c => c.String());
            AddColumn("dbo.Cities", "State", c => c.String());
            DropColumn("dbo.Cities", "CityZip");
            DropColumn("dbo.Cities", "CityState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "CityState", c => c.String());
            AddColumn("dbo.Cities", "CityZip", c => c.String());
            DropColumn("dbo.Cities", "State");
            DropColumn("dbo.Cities", "Zip");
        }
    }
}
