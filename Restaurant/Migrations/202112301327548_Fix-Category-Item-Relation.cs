namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCategoryItemRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Item_Id", "dbo.Items");
            DropIndex("dbo.Categories", new[] { "Item_Id" });
            AddColumn("dbo.Items", "Category_Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Item_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Item_Id");
            CreateIndex("dbo.Items", "Category_Name");
            AddForeignKey("dbo.Items", "Category_Name", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Categories", "Item_Id", "dbo.Items", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Category_Name", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "Category_Name" });
            DropIndex("dbo.Categories", new[] { "Item_Id" });
            AlterColumn("dbo.Categories", "Item_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "Category_Name");
            CreateIndex("dbo.Categories", "Item_Id");
            AddForeignKey("dbo.Categories", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
        }
    }
}
