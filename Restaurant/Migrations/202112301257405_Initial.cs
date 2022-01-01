namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.Order_Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Create_Date = c.DateTime(nullable: false),
                        Total_Cost = c.Double(nullable: false),
                        Is_Done = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Group_Id = c.Int(nullable: false),
                        Email = c.String(),
                        UserName = c.String(),
                        PassWord = c.String(maxLength: 100),
                        Active = c.Int(nullable: false),
                        Create_Date = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Deleted = c.String(),
                        Accpet_Admin_Id = c.Int(nullable: false),
                        Accpet_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order_Detail", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Order_Detail", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Order_Detail", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Categories", "Item_Id", "dbo.Items");
            DropIndex("dbo.Order_Detail", new[] { "Item_Id" });
            DropIndex("dbo.Order_Detail", new[] { "User_Id" });
            DropIndex("dbo.Order_Detail", new[] { "Order_Id" });
            DropIndex("dbo.Categories", new[] { "Item_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Order_Detail");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
        }
    }
}
