namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class priceImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Icings", "ImageUrl", c => c.String());
            AddColumn("dbo.Icings", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Toppings", "ImageUrl", c => c.String());
            AddColumn("dbo.Toppings", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }

        public override void Down()
        {
            DropColumn("dbo.Toppings", "Price");
            DropColumn("dbo.Toppings", "ImageUrl");
            DropColumn("dbo.Icings", "Price");
            DropColumn("dbo.Icings", "ImageUrl");
        }
    }
}
