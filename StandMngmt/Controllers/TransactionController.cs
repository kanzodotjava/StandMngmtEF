using Microsoft.AspNetCore.Mvc;
using StandMngmt.Data;
using StandMngmt.Models;
using StandMngmt.Cores; 
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace StandMngmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly CarCore _carCore;

        public TransactionController(DatabaseContext context, CarCore carCore)
        {
            _context = context;
            _carCore = carCore;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllTransactions()
        {
            var transactions = _context.Transactions.Include(t => t.Buyer).ToList();
            return transactions;
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransaction(int id)
        {
            var transaction = _context.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> AddTransaction(Transaction transaction)
        {
            try
            {
                await _carCore.UpdateCarSellingPriceByVIMAsync(transaction.SoldCarVIM, transaction.SellingPrice.ToString());

                var buyer = _context.Buyers.Find(transaction.BuyerID);
                if (buyer == null)
                {
                    return NotFound($"Buyer with ID {transaction.BuyerID} not found.");
                }

                transaction.Buyer = buyer;

                transaction.Date = DateTime.Now;

                _context.Transactions.Add(transaction);
                _context.SaveChanges();

                await _carCore.UpdateCarDateByVIMAsync(transaction.SoldCarVIM);

                await _carCore.UpdateTransactionIdByVIMAsync(transaction.SoldCarVIM,transaction.Id);
                 
                await _carCore.UpdateBuyerIdByVIMAsync(transaction.SoldCarVIM, transaction.BuyerID);


                return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
