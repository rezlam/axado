namespace Axado.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddModelCarrierRating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarrierRatings",
                c => new {
                    id = c.Int(nullable: false, identity: true),
                    active = c.Boolean(nullable: false, defaultValue: true),
                    created_at = c.DateTime(nullable: false, precision: 3, storeType: "datetime2", defaultValueSql: "sysutcdatetime()"),
                    updated_at = c.DateTime(precision: 3, storeType: "datetime2"),
                    deleted_at = c.DateTime(precision: 3, storeType: "datetime2"),
                    carrier_id = c.Int(nullable: false),
                    user_id = c.Int(nullable: false),
                    rating = c.Int(nullable: false),
                }
            )
            .PrimaryKey(t => t.id, name: "pk_CarrierRatings")
            .ForeignKey("dbo.Carriers", t => t.carrier_id, name: "fk_CarrierRatings_Carriers")
            .ForeignKey("dbo.Users", t => t.user_id, name: "fk_CarrierRatings_Users")
            .Index(t => new { t.carrier_id, t.user_id }, unique: true, name: "ak_CarrierRatings");
        }

        public override void Down()
        {
            DropForeignKey("dbo.CarrierRatings", "carrier_id", "dbo.Carriers");
            DropForeignKey("dbo.CarrierRatings", "user_id", "dbo.Users");
            DropIndex("dbo.CarrierRatings", "ak_CarrierRatings");
            DropTable("dbo.CarrierRatings");
        }
    }
}
