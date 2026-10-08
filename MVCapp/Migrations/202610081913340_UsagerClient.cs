namespace MVCapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsagerClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Usager_Id", "dbo.Usagers");
            DropIndex("dbo.Transactions", new[] { "Usager_Id" });
            RenameColumn(table: "dbo.Transactions", name: "Usager_Id", newName: "UsagerId");
            AlterColumn("dbo.Transactions", "UsagerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "UsagerId");
            AddForeignKey("dbo.Transactions", "UsagerId", "dbo.Usagers", "Id", cascadeDelete: true);
            DropColumn("dbo.Transactions", "ClientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "ClientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "UsagerId", "dbo.Usagers");
            DropIndex("dbo.Transactions", new[] { "UsagerId" });
            AlterColumn("dbo.Transactions", "UsagerId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "UsagerId", newName: "Usager_Id");
            CreateIndex("dbo.Transactions", "Usager_Id");
            AddForeignKey("dbo.Transactions", "Usager_Id", "dbo.Usagers", "Id");
        }
    }
}
