namespace Infinite.MVC5.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fruits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Int(nullable: false),
                        PackSizeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.PackSizes", t => t.PackSizeId, cascadeDelete: true)
                .Index(t => t.PackSizeId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.PackSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackSizeName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fruits", "PackSizeId", "dbo.PackSizes");
            DropForeignKey("dbo.Fruits", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Fruits", new[] { "CategoryId" });
            DropIndex("dbo.Fruits", new[] { "PackSizeId" });
            DropTable("dbo.PackSizes");
            DropTable("dbo.Fruits");
            DropTable("dbo.Categories");
        }
    }
}
