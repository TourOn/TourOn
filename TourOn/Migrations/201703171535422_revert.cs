namespace TourOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Author_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Comments", "Subject_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "Author_Id");
            CreateIndex("dbo.Comments", "Subject_Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "Subject_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Comments", "AuthorID");
            DropColumn("dbo.Comments", "SubjectID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "SubjectID", c => c.String());
            AddColumn("dbo.Comments", "AuthorID", c => c.String());
            DropForeignKey("dbo.Comments", "Subject_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Subject_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropColumn("dbo.Comments", "Subject_Id");
            DropColumn("dbo.Comments", "Author_Id");
        }
    }
}
