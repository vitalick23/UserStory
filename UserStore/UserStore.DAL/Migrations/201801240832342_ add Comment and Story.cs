namespace UserStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentandStory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        StoriesId = c.String(maxLength: 128),
                        Text = c.String(),
                        TimePublicate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Stories", t => t.StoriesId)
                .Index(t => t.UserId)
                .Index(t => t.StoriesId);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdUser = c.String(maxLength: 128),
                        Theme = c.String(),
                        Stories = c.String(),
                        TimePublicate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUser)
                .Index(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "StoriesId", "dbo.Stories");
            DropForeignKey("dbo.Stories", "IdUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Stories", new[] { "IdUser" });
            DropIndex("dbo.Comments", new[] { "StoriesId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.Stories");
            DropTable("dbo.Comments");
        }
    }
}
