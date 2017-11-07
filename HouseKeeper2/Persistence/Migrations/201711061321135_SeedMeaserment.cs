using System.Web.UI.WebControls;

namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMeaserment : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Measurements (CounterId, Date) Values (1, '01-01-2017')");
        }
        
        public override void Down()
        {
            
        }
    }
}
