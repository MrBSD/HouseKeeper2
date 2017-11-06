namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTariffsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Tariffs (Name, BeginingDate, Price) Values ('Tariff1', '01-01-2017', 7)");
            Sql("INSERT INTO Tariffs (Name, BeginingDate, Price) Values ('Tariff2', '01-01-2017', 9)");
            Sql("INSERT INTO Tariffs (Name, BeginingDate, Price) Values ('Tariff3', '01-01-2017', 15)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Tariffs WHERE Name IN ('Tariff1', 'Tariff2', 'Tariff3')");
        }
    }
}
