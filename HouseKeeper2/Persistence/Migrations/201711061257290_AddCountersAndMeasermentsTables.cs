namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountersAndMeasermentsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Counters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        SerialNumber = c.String(maxLength: 255),
                        CurrentMeasurement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Measurements", t => t.CurrentMeasurement_Id)
                .Index(t => t.CurrentMeasurement_Id);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CounterId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Counter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Counters", t => t.CounterId, cascadeDelete: true)
                .ForeignKey("dbo.Counters", t => t.Counter_Id)
                .Index(t => t.CounterId)
                .Index(t => t.Counter_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Measurements", "Counter_Id", "dbo.Counters");
            DropForeignKey("dbo.Counters", "CurrentMeasurement_Id", "dbo.Measurements");
            DropForeignKey("dbo.Measurements", "CounterId", "dbo.Counters");
            DropIndex("dbo.Measurements", new[] { "Counter_Id" });
            DropIndex("dbo.Measurements", new[] { "CounterId" });
            DropIndex("dbo.Counters", new[] { "CurrentMeasurement_Id" });
            DropTable("dbo.Measurements");
            DropTable("dbo.Counters");
        }
    }
}
