using MVCapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVCapp.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();
        private double fraisLivraison = 10.00;
        private int noPanier = 2;
        // GET: Home
        public ActionResult Index()
        {
            using(db)
            {
                var Panier = ObtenirPanier(db);

                ViewBag.Montant = Session["montant"];
                ViewBag.FraisLivraison = fraisLivraison;
                ViewBag.Taxes = Session["taxes"];
                ViewBag.MontantTotal = Session["montantTotal"];
            }

            return View();
        }

        [HttpPost]
        public ActionResult Save(Usager usager)
        {
            using (db )
            {
                var Panier = Session["Panier"];
                var result = db.Usagers.SingleOrDefault(u => u.Prenom == usager.Prenom && u.NomFam == usager.NomFam);
                if (result == null)
                {
                    var query = from u in db.Usagers
                                orderby u.Id
                                select u;
                    var usagerId = query.Last().Id;
                    usagerId++;

                    usager.Id = usagerId;
                    db.Usagers.Add(usager);

                    CompteClient compte = new CompteClient();
                    compte.NoCarteCredit = 1234567890123456;
                    compte.Solde = 1000.00;
                    compte.Suspendu = false;
                    compte.ClientId = usagerId;
                    db.CompteClients.Add(compte);
                }

                db.SaveChanges();
                Session["acheteur"] = result;
            }
            ViewBag.Montant = Session["montant"];
            ViewBag.FraisLivraison = fraisLivraison;
            ViewBag.Taxes = Session["taxes"];
            ViewBag.MontantTotal = Session["montantTotal"];
            return View("Paiement", usager);
        }
        [HttpPost]
        public ActionResult VerifierBanque(CarteCredit carte)
        {
            Panier achats = (Panier)Session["Panier"];
            Usager acheteur = (Usager)Session["acheteur"];
            string viewName = "Error";
            using (db )
            {
                
                var carteValide = db.CompteClients
                                    .Where(c => c.NoCarteCredit == carte.NoCarteCredit)
                                    .FirstOrDefault();
                var inventaire = db.Produits
                                    .Where(i => i.ProduitId == achats.ProduitId)
                                    .FirstOrDefault();
                if (carteValide == null)
                {
                    ViewBag.MessageErreur = "Désolé, cette carte de crédit n'existe pas";
                    Rollback(db);
                    return View(viewName);
                }
                else if (carteValide.ClientId != acheteur.Id)
                {
                    ViewBag.MessageErreur = "Désolé, cette carte de crédit n'ne vous appartient pas";
                    Rollback(db);
                    return View(viewName);
                }
                else if (carteValide.Solde < (double)Session["montantTotal"])
                {
                    ViewBag.MessageErreur = "Désolé, fonds insufisants";
                    Rollback(db);
                    return View(viewName);
                }
                else if (achats.Quantite > inventaire.QuantiteEnInventaire)
                {
                    ViewBag.MessageErreur = "Désolé, inventaire insufisant";
                    Rollback(db);
                    return View(viewName);
                }
                var compteVendeur = db.CompteVendeurs
                                    .Where(c => c.CompteVendeurId == 1)
                                    .FirstOrDefault();
                compteVendeur.Solde += (double)Session["montantTotal"];
                carteValide.Solde -= (double)Session["montantTotal"];
                Transaction transaction = new Transaction();
                transaction.UsagerId = acheteur.Id;
                transaction.DateTransaction = DateTime.Now;
                transaction.MontantTransaction = (double)Session["montantTotal"];
               // transaction.Usager = acheteur;
                db.Transactions.Add(transaction);
                try
                {
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    ViewBag.MessageErreur = "Désolé, une erreur est survenue";
                    Rollback(db);
                    return View(viewName);
                }
                var ListTransactionsUsager = db.Transactions
                                         .Where(t => t.UsagerId == acheteur.Id)
                                         .Include(t => t.Usager)
                                         .ToList();
                var ListToutesTransacttions = db.Transactions.ToList();
                ViewBag.ListTransactionUsager = ListTransactionsUsager;
                ViewBag.ListToutesTransactions = ListToutesTransacttions;
                ViewBag.SoldeUsager = carteValide.Solde;
                ViewBag.SoldeVendeur = compteVendeur.Solde;
            }
            viewName = "EtatComptes";

            return View(viewName);
        }

        public void Rollback(StoreContext context)
        { 
            var changedEntries = context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public Panier ObtenirPanier(StoreContext db)
        {
            var Panier = db.Paniers.Where(p => p.PanierId == noPanier).Include("Produit").FirstOrDefault();

            double montant = Panier.Produit.Prix;
            double taxes = (montant + fraisLivraison) * 0.15;
            Session["montant"] = montant;
            Session["taxes"] = taxes;
            Session["montantTotal"] = montant + fraisLivraison + taxes;
            Session["Panier"] = Panier;

            return Panier;
        }

    }
}