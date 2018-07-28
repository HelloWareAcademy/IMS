namespace IMS_2018_07_25.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ItemId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemId, t.LocationId })
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Markups",
                c => new
                    {
                        ItemId = c.Int(nullable: false),
                        PricingId = c.Int(nullable: false),
                        MarkupPercentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemId, t.PricingId })
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Pricings", t => t.PricingId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.PricingId);
            
            CreateTable(
                "dbo.Pricings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Markups", "PricingId", "dbo.Pricings");
            DropForeignKey("dbo.Markups", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Inventories", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Inventories", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Markups", new[] { "PricingId" });
            DropIndex("dbo.Markups", new[] { "ItemId" });
            DropIndex("dbo.Inventories", new[] { "LocationId" });
            DropIndex("dbo.Inventories", new[] { "ItemId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "StatusId" });
            DropTable("dbo.Status");
            DropTable("dbo.Pricings");
            DropTable("dbo.Markups");
            DropTable("dbo.Locations");
            DropTable("dbo.Inventories");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
