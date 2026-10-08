using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class CompteVendeur
    {
        public int CompteVendeurId { get; set; }
        public double NoCompteBanquaire { get; set; }
        public double Solde { get; set; }
        public bool Suspendu { get; set; }
    }
}