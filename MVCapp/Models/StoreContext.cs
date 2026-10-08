using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Usager> Usagers { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<CarteCredit> CarteCredits { get; set; }
        public DbSet<CompteClient> CompteClients { get; set; }
        public DbSet<CompteVendeur> CompteVendeurs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}