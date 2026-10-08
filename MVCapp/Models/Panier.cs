using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class Panier
    {
        public int PanierId { get; set; }
        [Required]
        public int Quantite { get; set; }
        public String status { get; set; }
        public double PoidsTotal { get; set; }

        //Foreign Key
        public int ProduitId { get; set; }

        //Navigation property
        public Produit Produit { get; set; }
    }
}