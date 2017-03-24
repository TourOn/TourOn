namespace TourOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPublisherFieldToCommentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Publisher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Publisher");
        }
    }
}
