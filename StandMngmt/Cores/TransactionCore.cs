using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using StandMngmt.Data;
using StandMngmt.Models;
using System.Diagnostics.Metrics;

namespace Program.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionCore
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DatabaseContext dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TransactionCore(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllTransactions()
        {
            var transactions = dbContext.Transactions.Include(t => t.Buyer).ToList();
            return transactions;
        }


        public Transaction GetTransaction(int id)
        {
            return dbContext.Transactions.Find(id);
        }

        public Transaction AddTransaction(Transaction transaction)
        {
            Buyer buyer = dbContext.Buyers.FirstOrDefault(m => m.Id == transaction.Buyer.Id);
            if (buyer != null)
            {
                transaction.Buyer = buyer;

                dbContext.Transactions.Add(transaction); 
                dbContext.SaveChanges();

                return transaction;
            }
            else
            {
                throw new Exception("Model with the specified ID not found.");
            }
        }

        public Transaction UpdateTransaction(int id)

        {
            var transaction = dbContext.Transactions.Find(id);
            dbContext.Entry(transaction).State = EntityState.Modified;
            dbContext.SaveChanges();
            return transaction;
        }


        public void DeleteTransaction(int id)
        {
            Transaction transaction = dbContext.Transactions.Find(id);
            dbContext.Transactions.Remove(transaction);
        }

        



    }
}
