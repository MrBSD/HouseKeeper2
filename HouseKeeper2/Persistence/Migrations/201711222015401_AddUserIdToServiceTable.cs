namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToServiceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "UserId");
        }
    }
}
