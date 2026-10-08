using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class CompteClient
    {
        public int CompteClientId { get; set; }
        public double NoCarteCredit { get; set; }
        public double Solde { get; set; }
        public bool Suspendu { get; set; }
        public int ClientId { get; set; }
    }
}