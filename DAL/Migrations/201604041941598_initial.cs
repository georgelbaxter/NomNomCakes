namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        BasketItemID = c.Int(nullable: false, identity: true),
                        BasketID = c.Guid(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketItemID);

            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        BasketID = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BasketID);

            CreateTable(
                "dbo.Cakes",
                c => new
                    {
                        CakeID = c.Int(nullable: false, identity: true),
                        CakeDescription = c.String(),
                    })
                .PrimaryKey(t => t.CakeID);

            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponId = c.Int(nullable: false, identity: true),
                        CouponCode = c.String(maxLength: 10),
                        CouponTypeId = c.Int(nullable: false),
                        CouponDescription = c.String(maxLength: 150),
                        AppliesToProductId = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinSpend = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MultipleUse = c.Boolean(nullable: false),
                        AssignedTo = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CouponId);

            CreateTable(
                "dbo.CouponTypes",
                c => new
                    {
                        CouponTypeId = c.Int(nullable: false, identity: true),
                        CouponModule = c.String(),
                        Type = c.String(maxLength: 30),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.CouponTypeId);

            CreateTable(
                "dbo.BasketCoupons",
                c => new
                    {
                        BasketCouponID = c.Int(nullable: false, identity: true),
                        CouponID = c.Int(nullable: false),
                        BasketID = c.Guid(nullable: false),
                        CouponCode = c.String(maxLength: 10),
                        CouponType = c.String(maxLength: 100),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CouponDescription = c.String(maxLength: 150),
                        AppliesToProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketCouponID);

            CreateTable(
                "dbo.Icings",
                c => new
                    {
                        IcingID = c.Int(nullable: false, identity: true),
                        IcingDescription = c.String(),
                    })
                .PrimaryKey(t => t.IcingID);

            CreateTable(
                "dbo.Toppings",
                c => new
                    {
                        ToppingID = c.Int(nullable: false, identity: true),
                        ToppingDescription = c.String(),
                    })
                .PrimaryKey(t => t.ToppingID);

        }

        public override void Down()
        {
            DropTable("dbo.Toppings");
            DropTable("dbo.Icings");
            DropTable("dbo.BasketCoupons");
            DropTable("dbo.CouponTypes");
            DropTable("dbo.Coupons");
            DropTable("dbo.Cakes");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
