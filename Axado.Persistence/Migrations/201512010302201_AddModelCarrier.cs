namespace Axado.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddModelCarrier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carriers",
                c => new {
                    id = c.Int(nullable: false, identity: true),
                    active = c.Boolean(nullable: false, defaultValue: true),
                    created_at = c.DateTime(nullable: false, precision: 3, storeType: "datetime2", defaultValueSql: "sysutcdatetime()"),
                    updated_at = c.DateTime(precision: 3, storeType: "datetime2"),
                    deleted_at = c.DateTime(precision: 3, storeType: "datetime2"),
                    name = c.String(nullable: false, maxLength: 100, unicode: false),
                    code = c.String(nullable: false, maxLength: 50, unicode: false),
                    identification = c.String(nullable: false, maxLength: 40, unicode: false),
                    streetaddress = c.String(nullable: false, maxLength: 100, unicode: false),
                    district = c.String(nullable: false, maxLength: 100, unicode: false),
                    locality = c.String(nullable: false, maxLength: 100, unicode: false),
                    region = c.String(nullable: false, maxLength: 3, unicode: false),
                    country = c.String(nullable: false, maxLength: 2, unicode: false),
                    phone_number = c.String(nullable: false, maxLength: 20, unicode: false),
                    url = c.String(maxLength: 256, unicode: false),
                    price_per_km = c.Decimal(nullable: false, precision: 7, scale: 3),
                }
            )
            .PrimaryKey(t => t.id, name: "pk_Carriers")
            .Index(t => t.code, unique: true, name: "ak_Carriers");
        }

        public override void Down()
        {
            DropIndex("dbo.Carriers", "ak_Carriers");
            DropTable("dbo.Carriers");
        }
    }
}
