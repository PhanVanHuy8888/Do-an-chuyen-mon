namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update12 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_Posts", newName: "tb_News");
            CreateTable(
                "dbo.tb_Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(maxLength: 150),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(maxLength: 250),
                        CategoryId = c.Int(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        SeoDescription = c.String(maxLength: 500),
                        SeoKeywords = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.tb_Category", "SeoTitle", c => c.String(maxLength: 150));
            AddColumn("dbo.tb_Category", "SeoDescription", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Category", "SeoKeywords", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_News", "Alias", c => c.String());
            AlterColumn("dbo.tb_News", "Image", c => c.String());
            AlterColumn("dbo.tb_News", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_News", "SeoDescription", c => c.String());
            AlterColumn("dbo.tb_News", "SeoKeywords", c => c.String());
        }
        
        public override void Down()
        {
            DropIndex("dbo.tb_Posts", new[] { "CategoryId" });
            AlterColumn("dbo.tb_News", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_News", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_News", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_News", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_News", "Alias", c => c.String(maxLength: 150));
            DropColumn("dbo.tb_Category", "SeoKeywords");
            DropColumn("dbo.tb_Category", "SeoDescription");
            DropColumn("dbo.tb_Category", "SeoTitle");
            DropTable("dbo.tb_Posts");
            RenameTable(name: "dbo.tb_News", newName: "tb_Posts");
        }
    }
}
