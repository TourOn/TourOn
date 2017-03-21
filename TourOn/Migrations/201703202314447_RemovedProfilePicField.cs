namespace TourOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedProfilePicField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.Binary());
        }
    }
}
