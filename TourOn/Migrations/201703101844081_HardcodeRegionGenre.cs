namespace TourOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HardcodeRegionGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Region", c => c.String());
            AddColumn("dbo.AspNetUsers", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Genre");
            DropColumn("dbo.AspNetUsers", "Region");
        }
    }
}
