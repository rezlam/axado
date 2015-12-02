namespace Axado.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddModelUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new {
                    id = c.Int(nullable: false, identity: true),
                    active = c.Boolean(nullable: false, defaultValue: true),
                    created_at = c.DateTime(nullable: false, precision: 3, storeType: "datetime2", defaultValueSql: "sysutcdatetime()"),
                    updated_at = c.DateTime(precision: 3, storeType: "datetime2"),
                    deleted_at = c.DateTime(precision: 3, storeType: "datetime2"),
                    name = c.String(nullable: false, maxLength: 100, unicode: false),
                    picture = c.String(maxLength: 256, unicode: false),
                }
            )
            .PrimaryKey(t => t.id);
        }

        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
