using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yummy.Models;
using Yummy.Models.Repositories;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class TransactionBookController : Controller
    {
        public IRepository<TransactionBook> _TransactionBook { get; }

        public TransactionBookController(IRepository<TransactionBook> transactionBook)
        {
            _TransactionBook = transactionBook;
        }
        // GET: TransactionBookController
        public ActionResult Index()
        {
            return View(_TransactionBook.View());
        }

        


      
    }
}
