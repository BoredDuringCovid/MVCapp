namespace MVCapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompteCarteTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarteCredits",
                c => new
                    {
                        NoCarteCredit = c.Double(nullable: false),
                        Mois = c.Int(nullable: false),
                        Annee = c.Int(nullable: false),
                        CVV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoCarteCredit);
            
            CreateTable(
                "dbo.CompteClients",
                c => new
                    {
                        CompteClientId = c.Int(nullable: false, identity: true),
                        NoCarteCredit = c.Double(nullable: false),
                        Solde = c.Double(nullable: false),
                        Suspendu = c.Boolean(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompteClientId);
            
            CreateTable(
                "dbo.CompteVendeurs",
                c => new
                    {
                        CompteVendeurId = c.Int(nullable: false, identity: true),
                        NoCompteBanquaire = c.Double(nullable: false),
                        Solde = c.Double(nullable: false),
                        Suspendu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompteVendeurId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        DateTransaction = c.DateTime(nullable: false),
                        MontantTransaction = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
            DropTable("dbo.CompteVendeurs");
            DropTable("dbo.CompteClients");
            DropTable("dbo.CarteCredits");
        }
    }
}
