namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refesh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "Link", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_ProductCategory", "Description", c => c.String());
            AlterColumn("dbo.tb_ProductCategory", "Icon", c => c.String(maxLength: 250));
            DropColumn("dbo.tb_Category", "SeoTitle");
            DropColumn("dbo.tb_Category", "SeoDescription");
            DropColumn("dbo.tb_Category", "SeoKeyWords");
            DropColumn("dbo.tb_News", "SeoTitle");
            DropColumn("dbo.tb_News", "SeoDescription");
            DropColumn("dbo.tb_News", "SeoKeyWords");
            DropColumn("dbo.tb_Posts", "SeoTitle");
            DropColumn("dbo.tb_Posts", "SeoDescription");
            DropColumn("dbo.tb_Posts", "SeoKeyWords");
            DropColumn("dbo.tb_Product", "IsFeature");
            DropColumn("dbo.tb_Product", "IsHot");
            DropColumn("dbo.tb_Product", "SeoDescription");
            DropColumn("dbo.tb_Product", "SeoKeyWords");
            DropColumn("dbo.tb_ProductCategory", "SeoTitle");
            DropColumn("dbo.tb_ProductCategory", "SeoDescription");
            DropColumn("dbo.tb_ProductCategory", "SeoKeyWords");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_ProductCategory", "SeoKeyWords", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_ProductCategory", "SeoDescription", c => c.String(maxLength: 500));
            AddColumn("dbo.tb_ProductCategory", "SeoTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Product", "SeoKeyWords", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Product", "SeoDescription", c => c.String(maxLength: 500));
            AddColumn("dbo.tb_Product", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "IsFeature", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Posts", "SeoKeyWords", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Posts", "SeoDescription", c => c.String(maxLength: 500));
            AddColumn("dbo.tb_Posts", "SeoTitle", c => c.String(maxLength: 350));
            AddColumn("dbo.tb_News", "SeoKeyWords", c => c.String());
            AddColumn("dbo.tb_News", "SeoDescription", c => c.String());
            AddColumn("dbo.tb_News", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_Category", "SeoKeyWords", c => c.String(maxLength: 150));
            AddColumn("dbo.tb_Category", "SeoDescription", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Category", "SeoTitle", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_ProductCategory", "Icon", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_ProductCategory", "Description", c => c.String(maxLength: 350));
            AlterColumn("dbo.tb_Product", "SeoTitle", c => c.String(maxLength: 350));
            DropColumn("dbo.tb_Category", "Link");
        }
    }
}
