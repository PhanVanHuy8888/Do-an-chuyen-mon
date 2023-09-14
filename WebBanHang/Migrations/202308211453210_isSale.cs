namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "IsSale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "IsSale");
        }
    }
}
