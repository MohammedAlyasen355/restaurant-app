namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Category_Name", "dbo.Categories");
            DropForeignKey("dbo.Order_Detail", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Order_Detail", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Order_Detail", "User_Id", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "Category_Name" });
            DropIndex("dbo.Order_Detail", new[] { "Order_Id" });
            DropIndex("dbo.Order_Detail", new[] { "User_Id" });
            DropIndex("dbo.Order_Detail", new[] { "Item_Id" });
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        Bill = c.Double(nullable: false),
                        Description = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Orders", "InvoiceID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ApprovedAdminID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "ApprovedDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Orders", "InvoiceID");
            CreateIndex("dbo.Orders", "UserID");
            CreateIndex("dbo.Orders", "ProductID");
            AddForeignKey("dbo.Orders", "InvoiceID", "dbo.Invoices", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            DropColumn("dbo.Categories", "Item_Id");
            DropColumn("dbo.Orders", "Create_Date");
            DropColumn("dbo.Orders", "Total_Cost");
            DropColumn("dbo.Orders", "Is_Done");
            DropColumn("dbo.Users", "Group_Id");
            DropColumn("dbo.Users", "Create_Date");
            DropColumn("dbo.Users", "Accpet_Admin_Id");
            DropColumn("dbo.Users", "Accpet_Date");
            DropTable("dbo.Items");
            DropTable("dbo.Order_Detail");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Order_Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        Category_Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Accpet_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Accpet_Admin_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Create_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Group_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Is_Done", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Total_Cost", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Create_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "Item_Id", c => c.Int());
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "ProductID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Orders", new[] { "InvoiceID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropColumn("dbo.Users", "ApprovedDate");
            DropColumn("dbo.Users", "ApprovedAdminID");
            DropColumn("dbo.Users", "CreateDate");
            DropColumn("dbo.Orders", "ProductID");
            DropColumn("dbo.Orders", "UserID");
            DropColumn("dbo.Orders", "InvoiceID");
            DropTable("dbo.Invoices");
            DropTable("dbo.Products");
            CreateIndex("dbo.Order_Detail", "Item_Id");
            CreateIndex("dbo.Order_Detail", "User_Id");
            CreateIndex("dbo.Order_Detail", "Order_Id");
            CreateIndex("dbo.Items", "Category_Name");
            CreateIndex("dbo.Categories", "Item_Id");
            AddForeignKey("dbo.Order_Detail", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Order_Detail", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Order_Detail", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Items", "Category_Name", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Categories", "Item_Id", "dbo.Items", "Id");
        }
    }
}
