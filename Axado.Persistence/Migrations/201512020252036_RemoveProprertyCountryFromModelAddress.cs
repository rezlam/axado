namespace Axado.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProprertyCountryFromModelAddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carriers", "country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carriers", "country", c => c.String(nullable: false, maxLength: 2, unicode: false));
        }
    }
}
