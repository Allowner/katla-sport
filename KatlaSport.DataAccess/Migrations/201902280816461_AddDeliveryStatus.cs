namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Migration for description item delivery status
    /// </summary>
    public partial class AddDeliveryStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product_store_items", "deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.product_store_items", "delivered", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.product_store_items", "delivered");
            DropColumn("dbo.product_store_items", "deleted");
        }
    }
}
