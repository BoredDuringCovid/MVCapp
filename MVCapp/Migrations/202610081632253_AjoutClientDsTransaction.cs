namespace MVCapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutClientDsTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Usager_Id", c => c.Int());
            CreateIndex("dbo.Transactions", "Usager_Id");
            AddForeignKey("dbo.Transactions", "Usager_Id", "dbo.Usagers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Usager_Id", "dbo.Usagers");
            DropIndex("dbo.Transactions", new[] { "Usager_Id" });
            DropColumn("dbo.Transactions", "Usager_Id");
        }
    }
}
