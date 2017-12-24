namespace Sirius.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTransactions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Status", c => c.String());
            AddColumn("dbo.Transactions", "OrderId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Transactions", "OrderId");
            AddForeignKey("dbo.Transactions", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "OrderId", "dbo.Orders");
            DropIndex("dbo.Transactions", new[] { "OrderId" });
            DropColumn("dbo.Transactions", "OrderId");
            DropColumn("dbo.Transactions", "Status");
        }
    }
}
