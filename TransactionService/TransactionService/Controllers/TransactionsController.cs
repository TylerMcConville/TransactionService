using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public HttpResponseMessage PostTransaction(Models.Transaction transaction)
        {
            using (var context = new TransactionDataContext())
            {
                context.Transactions.InsertOnSubmit(transaction.ToDataAccessTransaction());
                context.SubmitChanges();
            }

            var response = Request.CreateResponse(HttpStatusCode.Created, transaction);

//            var uri = Url.Link("DefaultApi", new { id = transaction.Id });
//            response.Headers.Location = new Uri(uri);

            return response;
        }
    }
}
