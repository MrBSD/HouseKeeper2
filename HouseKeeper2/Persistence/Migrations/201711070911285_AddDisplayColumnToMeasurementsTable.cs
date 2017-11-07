namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisplayColumnToMeasurementsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measurements", "Display", c => c.Int(nullable: false));
            Sql("UPDATE Measurements SET Display=0001 WHERE Id=1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Measurements", "Display");
        }
    }
}
