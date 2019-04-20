namespace Bits_and_Bites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Idontnowwhatididhere : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipies", "SubmittedByID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipies", "SubmittedByID");
        }
    }
}
