namespace UserStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeintId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "StoriesId", "dbo.Stories");
            DropIndex("dbo.Comments", new[] { "StoriesId" });
            DropPrimaryKey("dbo.Comments");
            DropPrimaryKey("dbo.Stories");
            AlterColumn("dbo.Comments", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Comments", "StoriesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Stories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comments", "Id");
            AddPrimaryKey("dbo.Stories", "Id");
            CreateIndex("dbo.Comments", "StoriesId");
            AddForeignKey("dbo.Comments", "StoriesId", "dbo.Stories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "StoriesId", "dbo.Stories");
            DropIndex("dbo.Comments", new[] { "StoriesId" });
            DropPrimaryKey("dbo.Stories");
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Stories", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "StoriesId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Comments", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Stories", "Id");
            AddPrimaryKey("dbo.Comments", "Id");
            CreateIndex("dbo.Comments", "StoriesId");
            AddForeignKey("dbo.Comments", "StoriesId", "dbo.Stories", "Id");
        }
    }
}
