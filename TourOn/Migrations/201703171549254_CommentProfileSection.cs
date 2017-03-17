namespace TourOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentProfileSection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Subject_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.Comments", new[] { "Subject_Id" });
            AddColumn("dbo.Comments", "AuthorID", c => c.String());
            AddColumn("dbo.Comments", "SubjectID", c => c.String());
            DropColumn("dbo.Comments", "Author_Id");
            DropColumn("dbo.Comments", "Subject_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Subject_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Comments", "Author_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Comments", "SubjectID");
            DropColumn("dbo.Comments", "AuthorID");
            CreateIndex("dbo.Comments", "Subject_Id");
            CreateIndex("dbo.Comments", "Author_Id");
            AddForeignKey("dbo.Comments", "Subject_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
