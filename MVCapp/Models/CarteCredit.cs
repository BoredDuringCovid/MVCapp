using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class CarteCredit
    {
        [Key]
        public double NoCarteCredit { get; set; }
        public int Mois { get; set; }
        public int Annee { get; set; }
        public int CVV { get; set; }
    }
}