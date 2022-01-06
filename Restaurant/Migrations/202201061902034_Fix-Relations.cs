namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Orders", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "InvoiceID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Orders", new[] { "ProductID" });
            AddColumn("dbo.Products", "OrderID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "OrderID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "OrderID");
            CreateIndex("dbo.Invoices", "OrderID");
            CreateIndex("dbo.Users", "OrderID");
            AddForeignKey("dbo.Invoices", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
            DropColumn("dbo.Orders", "InvoiceID");
            DropColumn("dbo.Orders", "UserID");
            DropColumn("dbo.Orders", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "InvoiceID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Users", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Invoices", "OrderID", "dbo.Orders");
            DropIndex("dbo.Users", new[] { "OrderID" });
            DropIndex("dbo.Invoices", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "OrderID" });
            DropColumn("dbo.Users", "OrderID");
            DropColumn("dbo.Invoices", "OrderID");
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Products", "OrderID");
            CreateIndex("dbo.Orders", "ProductID");
            CreateIndex("dbo.Orders", "UserID");
            CreateIndex("dbo.Orders", "InvoiceID");
            AddForeignKey("dbo.Orders", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "InvoiceID", "dbo.Invoices", "ID", cascadeDelete: true);
        }
    }
}
