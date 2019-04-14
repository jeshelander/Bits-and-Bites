namespace Bits_and_Bites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlikes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        TimeLiked = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipies", "DateSubmitted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipies", "LikeCounter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipies", "LikeCounter");
            DropColumn("dbo.Recipies", "DateSubmitted");
            DropTable("dbo.Likes");
        }
    }
}
