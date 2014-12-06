using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TransactionService.Data_Access;

namespace TransactionService.Controllers
{
    public class TransactionsController : ApiController
    {
        public IHttpActionResult GetTransaction(int id)
        {
            using (var context = new TransactionDataContext())
            {
                var transaction = context.Transactions.FirstOrDefault(x => x.Id == id);

                if (transaction == null)
                {
                    return NotFound();
                }

                return Ok(transaction);
            }
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            using (var context = new TransactionDataContext())
            {
                return context.Transactions.Select(x => x).ToList();
            }
        }
    }
}
