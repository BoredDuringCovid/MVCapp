using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class Usager
    {
        public int Id { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string NomFam { get; set; }
        [Required]
        public string Rue { get; set; }
        [Required]
        public string Ville { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string CodePostal { get; set; }
        [Required]
        public string NoTel { get; set; }
        public string TelExt { get; set; }
        [Required]
        public string Courriel { get; set; }
    }
}