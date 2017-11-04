namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedServicesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Services (Name) VALUES ('Service1')");
            Sql("INSERT INTO Services (Name) VALUES ('Service3')");
            Sql("INSERT INTO Services (Name) VALUES ('Service3')");
           
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Services WHERE Name IN ('Service1', 'Service2', 'Service3')");
        }
    }
}
