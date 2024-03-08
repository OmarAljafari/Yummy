using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Yummy.Models;
using Yummy.Models.Repositories;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StatisticsController : Controller
    {
        public IRepository<Statistics> _Statistics { get; }

        public StatisticsController(IRepository<Statistics> statistics)
        {
            _Statistics = statistics;
        }
        // GET: StatisticsController
        public ActionResult Index()
        {
            return View(_Statistics.View());
        }

      

        // GET: StatisticsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatisticsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Statistics collection)
        {
            try
            {
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.CreateDate = DateTime.Now;
                collection.IsActive = true;
                _Statistics.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatisticsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_Statistics.Find(id));
        }

        // POST: StatisticsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Statistics collection)
        {
            try
            {
                var data = _Statistics.Find(id);
                data.StatisticsNumber = collection.StatisticsNumber;
                data.StatisticsName = collection.StatisticsName;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.Now;
                _Statistics.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatisticsController/Delete/5
        public ActionResult Delete(int idDelete)
        {

            var data = _Statistics.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Statistics.Delete(idDelete, data);
            return RedirectToAction(nameof(Index));
        }

       public IActionResult Active(int idActive)
        {
            var data = _Statistics.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Statistics.Active(idActive,data);
            return RedirectToAction(nameof(Index));
        }
    }
}
