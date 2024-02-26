using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace StandMngmt.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int BuyerID { get; set; }
        public Buyer? Buyer { get; set; }
        public double SellingPrice { get; set; }
        public String SoldCarVIM { get; set; }


    }
}
