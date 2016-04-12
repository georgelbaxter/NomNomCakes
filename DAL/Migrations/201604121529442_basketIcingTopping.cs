namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class basketIcingTopping : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketItems", "IcingID", c => c.Int(nullable: false));
            AddColumn("dbo.BasketItems", "ToppingID", c => c.Int(nullable: false));
            CreateIndex("dbo.BasketItems", "IcingID");
            CreateIndex("dbo.BasketItems", "ToppingID");
            AddForeignKey("dbo.BasketItems", "IcingID", "dbo.Icings", "IcingID", cascadeDelete: true);
            AddForeignKey("dbo.BasketItems", "ToppingID", "dbo.Toppings", "ToppingID", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "ToppingID", "dbo.Toppings");
            DropForeignKey("dbo.BasketItems", "IcingID", "dbo.Icings");
            DropIndex("dbo.BasketItems", new[] { "ToppingID" });
            DropIndex("dbo.BasketItems", new[] { "IcingID" });
            DropColumn("dbo.BasketItems", "ToppingID");
            DropColumn("dbo.BasketItems", "IcingID");
        }
    }
}
