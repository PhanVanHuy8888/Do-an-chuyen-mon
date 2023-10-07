namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_News", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_News", "SeoDescription", c => c.String());
            AddColumn("dbo.tb_News", "SeoKeywords", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_News", "SeoKeywords");
            DropColumn("dbo.tb_News", "SeoDescription");
            DropColumn("dbo.tb_News", "SeoTitle");
        }
    }
}
