namespace MVCapp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVCapp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCapp.Models.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCapp.Models.StoreContext";
        }

        protected override void Seed(MVCapp.Models.StoreContext context)
        {
            context.Usagers.AddOrUpdate(x => x.Id,
                new Usager() { Id = 1, Prenom = "Cedric", NomFam = "Piette", Rue = "6912 36e ave", Ville = "Montreal", Province = "qc", CodePostal = "H1T2Z8", NoTel = "5142341912", TelExt = "1234", Courriel = "test@gmail.com" });

            context.Produits.AddOrUpdate(x => x.ProduitId,
                new Produit() { ProduitId = 1, Nom = "Serveur", QuantiteEnInventaire = 5, Prix = 1999.99, Poids = 25 });

            context.Paniers.AddOrUpdate(x => x.PanierId,
                new Panier() { PanierId = 1, Quantite = 1, status = "pret", PoidsTotal = 25, ProduitId = 1});

            context.CompteClients.AddOrUpdate(x => x.CompteClientId,
                new CompteClient() { CompteClientId = 1, NoCarteCredit = 5258123456789876, Solde = 5000, Suspendu = false, ClientId = 1 });

            context.CompteVendeurs.AddOrUpdate(x => x.CompteVendeurId,
                new CompteVendeur() { CompteVendeurId = 1, NoCompteBanquaire = 1234567891234567, Solde = 2000, Suspendu = false });
        }
    }
}
