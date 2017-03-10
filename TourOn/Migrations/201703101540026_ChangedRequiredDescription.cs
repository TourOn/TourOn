namespace TourOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRequiredDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Description", c => c.String(nullable: false));
        }
    }
}
