namespace Axado.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyPickUpTimeToModelCarrier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carriers", "pickup_time", c => c.Time(precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carriers", "pickup_time");
        }
    }
}
