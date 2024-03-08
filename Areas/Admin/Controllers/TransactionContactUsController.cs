using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yummy.Models;
using Yummy.Models.Repositories;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> _TransactionContactUs { get; }

        public TransactionContactUsController(IRepository<TransactionContactUs> transactionContactUs)
        {
            _TransactionContactUs = transactionContactUs;
        }
        // GET: TransactionContactUsController
        public ActionResult Index()
        {
            return View(_TransactionContactUs.View());
        }

        
    }
}
