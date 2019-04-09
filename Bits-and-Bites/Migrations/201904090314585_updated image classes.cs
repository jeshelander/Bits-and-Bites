namespace Bits_and_Bites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedimageclasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "StoredImage", c => c.Binary());
            AddColumn("dbo.Recipies", "ImageID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipies", "ImageID");
            DropColumn("dbo.Images", "StoredImage");
        }
    }
}
