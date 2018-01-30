namespace MyUserStory.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHometown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Hometown", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Hometown");
        }
    }
}
