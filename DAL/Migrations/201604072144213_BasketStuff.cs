namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class BasketStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketItems", "CakeID", c => c.Int(nullable: false));
            AddColumn("dbo.Cakes", "ImageUrl", c => c.String(maxLength: 255));
            AddColumn("dbo.Cakes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.BasketItems", "BasketID");
            CreateIndex("dbo.BasketItems", "CakeID");
            CreateIndex("dbo.BasketCoupons", "BasketID");
            AddForeignKey("dbo.BasketItems", "CakeID", "dbo.Cakes", "CakeID", cascadeDelete: true);
            AddForeignKey("dbo.BasketCoupons", "BasketID", "dbo.Baskets", "BasketID", cascadeDelete: true);
            AddForeignKey("dbo.BasketItems", "BasketID", "dbo.Baskets", "BasketID", cascadeDelete: true);
            DropColumn("dbo.BasketItems", "ProductID");
        }

        public override void Down()
        {
            AddColumn("dbo.BasketItems", "ProductID", c => c.Int(nullable: false));
            DropForeignKey("dbo.BasketItems", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.BasketCoupons", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "CakeID", "dbo.Cakes");
            DropIndex("dbo.BasketCoupons", new[] { "BasketID" });
            DropIndex("dbo.BasketItems", new[] { "CakeID" });
            DropIndex("dbo.BasketItems", new[] { "BasketID" });
            DropColumn("dbo.Cakes", "Price");
            DropColumn("dbo.Cakes", "ImageUrl");
            DropColumn("dbo.BasketItems", "CakeID");
        }
    }
}
