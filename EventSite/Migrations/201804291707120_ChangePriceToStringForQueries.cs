namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePriceToStringForQueries : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Price", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Price", c => c.Double(nullable: false));
        }
    }
}
