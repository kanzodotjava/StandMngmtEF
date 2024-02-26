using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Program.Core;
using StandMngmt.Cores;
using StandMngmt.Data;
using StandMngmt.Models;

namespace StandMngmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : Controller
    {

        private readonly BuyerCore core;

        public BuyerController(DatabaseContext dbContext)
        {
            this.core = new BuyerCore(dbContext);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllBuyers()
        {
            return Ok(core.getAllBuyers());
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetBuyerById(int id)
        {
            return Ok(core.getBuyerById(id));
        }

        [HttpPost]
        public ActionResult<Transaction> AddBuyer(Buyer buyer)
        {
            return Ok(core.addBuyer(buyer));
        }
    }
}

