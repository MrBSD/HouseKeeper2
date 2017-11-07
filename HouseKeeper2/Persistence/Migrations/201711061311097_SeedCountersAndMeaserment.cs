namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCountersAndMeaserment : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Counters (Name, SerialNumber) Values ('Counter1', '12345')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Counters WHERE Name IN ('Counter1')");
        }
    }
}
