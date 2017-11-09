namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCounterIdToServicesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "CounterId", c => c.Int());
            CreateIndex("dbo.Services", "CounterId");
            AddForeignKey("dbo.Services", "CounterId", "dbo.Counters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "CounterId", "dbo.Counters");
            DropIndex("dbo.Services", new[] { "CounterId" });
            DropColumn("dbo.Services", "CounterId");
        }
    }
}
