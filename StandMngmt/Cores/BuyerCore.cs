using Microsoft.EntityFrameworkCore;
using StandMngmt.Data;
using StandMngmt.Models;

namespace StandMngmt.Cores
{
    public class BuyerCore
    {
        private readonly DatabaseContext dbContext;
        public BuyerCore(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Buyer> getAllBuyers()
        {
            return dbContext.Buyers.ToList();
        }

        public Buyer addBuyer(Buyer buyer)
        {
            dbContext.Buyers.Add(buyer);
            dbContext.SaveChanges();
            return buyer;
        }

        public Buyer getBuyerById(int id)
        {
            return dbContext.Buyers.Find(id);
        }

        public Buyer EditBuyerById(int id)
        {
            var buyer = dbContext.Buyers.Find(id);
            dbContext.Entry(buyer).State = EntityState.Modified;
            dbContext.SaveChanges();
            return buyer;
        }

        public Buyer DeleteBuyerById(int id)
        {
            var buyer = dbContext.Buyers.Find(id);
            dbContext.Buyers.Remove(buyer);
            dbContext.SaveChanges();
            return buyer;
        }

    }
}
