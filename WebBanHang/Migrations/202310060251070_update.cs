namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Posts", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Posts", new[] { "CategoryId" });
            DropTable("dbo.tb_Adv");
            DropTable("dbo.tb_Posts");
            DropTable("dbo.tb_Subscribe");
            DropTable("dbo.tb_SystemSetting");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_SystemSetting",
                c => new
                    {
                        SettingKey = c.String(nullable: false, maxLength: 50),
                        SettingValue = c.String(maxLength: 4000),
                        SettingDescription = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.SettingKey);
            
            CreateTable(
                "dbo.tb_Subscribe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(maxLength: 150),
                        Description = c.String(),
                        Detail = c.String(),
                        Image = c.String(maxLength: 350),
                        CategoryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Adv",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 500),
                        Link = c.String(maxLength: 500),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tb_Posts", "CategoryId");
            AddForeignKey("dbo.tb_Posts", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}
