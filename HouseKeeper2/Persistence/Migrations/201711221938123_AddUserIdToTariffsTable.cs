namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToTariffsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tariffs", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tariffs", "UserId");
        }
    }
}
