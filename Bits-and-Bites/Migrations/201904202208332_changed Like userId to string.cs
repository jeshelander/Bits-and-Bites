namespace Bits_and_Bites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedLikeuserIdtostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Likes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Likes", "UserId", c => c.Int(nullable: false));
        }
    }
}
