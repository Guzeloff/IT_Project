namespace IT_PROJECT_OnlineStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartPKChanged : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "CartID", c => c.String());
            AlterColumn("dbo.Carts", "RecordID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Carts", "RecordID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "RecordID", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "CartID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Carts", "CartID");
        }
    }
}
