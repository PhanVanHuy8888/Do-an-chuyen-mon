namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category");
            DropForeignKey("dbo.tb_Product", "ProductCategory_Id", "dbo.tb_ProductCategory");
            DropIndex("dbo.tb_Posts", new[] { "Category_Id" });
            DropIndex("dbo.tb_Product", new[] { "ProductCategory_Id" });
            DropColumn("dbo.tb_Posts", "CategoryId");
            DropColumn("dbo.tb_Product", "ProductCategoryId");
            RenameColumn(table: "dbo.tb_Posts", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.tb_Product", name: "ProductCategory_Id", newName: "ProductCategoryId");
            AlterColumn("dbo.tb_Posts", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Posts", "Image", c => c.String(maxLength: 350));
            AlterColumn("dbo.tb_Posts", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Posts", "SeoTitle", c => c.String(maxLength: 350));
            AlterColumn("dbo.tb_Posts", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Posts", "SeoKeyWords", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Product", "Alias", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.tb_Product", "Image", c => c.String(maxLength: 350));
            AlterColumn("dbo.tb_Product", "ProductCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Product", "SeoTitle", c => c.String(maxLength: 350));
            AlterColumn("dbo.tb_Product", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Product", "SeoKeyWords", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "ProductCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Posts", "CategoryId");
            CreateIndex("dbo.tb_Product", "ProductCategoryId");
            AddForeignKey("dbo.tb_Posts", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategory", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.tb_ProductCategory");
            DropForeignKey("dbo.tb_Posts", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Product", new[] { "ProductCategoryId" });
            DropIndex("dbo.tb_Posts", new[] { "CategoryId" });
            AlterColumn("dbo.tb_Product", "ProductCategoryId", c => c.Int());
            AlterColumn("dbo.tb_Product", "SeoKeyWords", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoDescription", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Product", "ProductCategoryId", c => c.String());
            AlterColumn("dbo.tb_Product", "Image", c => c.String());
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String());
            AlterColumn("dbo.tb_Product", "Alias", c => c.String());
            AlterColumn("dbo.tb_Posts", "CategoryId", c => c.Int());
            AlterColumn("dbo.tb_Posts", "SeoKeyWords", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoDescription", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Posts", "CategoryId", c => c.String());
            AlterColumn("dbo.tb_Posts", "Image", c => c.String());
            AlterColumn("dbo.tb_Posts", "Alias", c => c.String());
            RenameColumn(table: "dbo.tb_Product", name: "ProductCategoryId", newName: "ProductCategory_Id");
            RenameColumn(table: "dbo.tb_Posts", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.tb_Product", "ProductCategoryId", c => c.String());
            AddColumn("dbo.tb_Posts", "CategoryId", c => c.String());
            CreateIndex("dbo.tb_Product", "ProductCategory_Id");
            CreateIndex("dbo.tb_Posts", "Category_Id");
            AddForeignKey("dbo.tb_Product", "ProductCategory_Id", "dbo.tb_ProductCategory", "Id");
            AddForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category", "Id");
        }
    }
}
