namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceBillsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        TariffId = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        TotalForPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Tariffs", t => t.TariffId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.TariffId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceBills", "TariffId", "dbo.Tariffs");
            DropForeignKey("dbo.ServiceBills", "ServiceId", "dbo.Services");
            DropIndex("dbo.ServiceBills", new[] { "TariffId" });
            DropIndex("dbo.ServiceBills", new[] { "ServiceId" });
            DropTable("dbo.ServiceBills");
        }
    }
}
