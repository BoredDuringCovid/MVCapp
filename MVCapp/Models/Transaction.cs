using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime DateTransaction { get; set; }
        public double MontantTransaction { get; set; }
        public int UsagerId { get; set; }
        public Usager Usager { get; set; }
    }
}