namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCountersAndMeasurements : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Measurements", "CounterId", "dbo.Counters");
            DropForeignKey("dbo.Services", "CounterId", "dbo.Counters");
            DropIndex("dbo.Measurements", new[] { "CounterId" });
            DropIndex("dbo.Services", new[] { "CounterId" });
            AddColumn("dbo.ServiceBills", "Period", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceBills", "Measurement", c => c.Int(nullable: false));
            DropColumn("dbo.Services", "CounterId");
            DropColumn("dbo.ServiceBills", "Month");
            DropColumn("dbo.ServiceBills", "Year");
            DropTable("dbo.Counters");
            DropTable("dbo.Measurements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CounterId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Display = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Counters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        SerialNumber = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ServiceBills", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceBills", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "CounterId", c => c.Int());
            DropColumn("dbo.ServiceBills", "Measurement");
            DropColumn("dbo.ServiceBills", "Period");
            CreateIndex("dbo.Services", "CounterId");
            CreateIndex("dbo.Measurements", "CounterId");
            AddForeignKey("dbo.Services", "CounterId", "dbo.Counters", "Id");
            AddForeignKey("dbo.Measurements", "CounterId", "dbo.Counters", "Id", cascadeDelete: true);
        }
    }
}
