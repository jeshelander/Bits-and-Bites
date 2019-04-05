namespace Bits_and_Bites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcooktimetokeywords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipies", "Keywords", c => c.String());
            DropColumn("dbo.Recipies", "CookTemp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipies", "CookTemp", c => c.String());
            DropColumn("dbo.Recipies", "Keywords");
        }
    }
}
