using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class Produit
    {
        public int ProduitId { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public int QuantiteEnInventaire { get; set; }
        [Required]
        public double Prix { get; set; }
        [Required]
        public double Poids { get; set; }
    }
}