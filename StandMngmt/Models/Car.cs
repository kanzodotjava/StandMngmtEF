namespace StandMngmt.Models
{
    public class Car
    {
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public Model Model { get; set; }
        public string LicensePlate { get; set; }
        public int NumberOfSeats { get; set; }
        public string Traction { get; set; }
        public string Fuel { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public Seller Seller { get; set; }
        public int NumberOfDoors { get; set; }
        public string Status { get; set; }
        public double Kilometers { get; set; }
        public string Vim { get; set; }
        public int BuyerID { get; set; }
        public int TransactionID { get; set; }
    }
}
