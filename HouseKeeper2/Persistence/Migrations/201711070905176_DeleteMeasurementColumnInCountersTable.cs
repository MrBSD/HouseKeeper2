namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMeasurementColumnInCountersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Counters", "CurrentMeasurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.Measurements", "Counter_Id", "dbo.Counters");
            DropIndex("dbo.Counters", new[] { "CurrentMeasurement_Id" });
            DropIndex("dbo.Measurements", new[] { "Counter_Id" });
            DropColumn("dbo.Counters", "CurrentMeasurement_Id");
            DropColumn("dbo.Measurements", "Counter_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Measurements", "Counter_Id", c => c.Int());
            AddColumn("dbo.Counters", "CurrentMeasurement_Id", c => c.Int());
            CreateIndex("dbo.Measurements", "Counter_Id");
            CreateIndex("dbo.Counters", "CurrentMeasurement_Id");
            AddForeignKey("dbo.Measurements", "Counter_Id", "dbo.Counters", "Id");
            AddForeignKey("dbo.Counters", "CurrentMeasurement_Id", "dbo.Measurements", "Id");
        }
    }
}
