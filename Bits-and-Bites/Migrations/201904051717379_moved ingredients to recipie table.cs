namespace Bits_and_Bites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movedingredientstorecipietable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipies", "Ingredients", c => c.String());
            DropTable("dbo.Ingredients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                        RecipieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Recipies", "Ingredients");
        }
    }
}
