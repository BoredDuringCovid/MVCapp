namespace MVCapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProduitPanier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        PanierId = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        status = c.String(),
                        PoidsTotal = c.Double(nullable: false),
                        ProduitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PanierId)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .Index(t => t.ProduitId);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        ProduitId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        QuantiteEnInventaire = c.Int(nullable: false),
                        Prix = c.Double(nullable: false),
                        Poids = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProduitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paniers", "ProduitId", "dbo.Produits");
            DropIndex("dbo.Paniers", new[] { "ProduitId" });
            DropTable("dbo.Produits");
            DropTable("dbo.Paniers");
        }
    }
}
