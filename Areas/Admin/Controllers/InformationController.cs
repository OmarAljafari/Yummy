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
    public class InformationController : Controller
    {
        public IRepository<Information> _Information { get; }

        public InformationController(IRepository<Information> information)
        {
            _Information = information;
        }
        // GET: InformationController
        public ActionResult Index()
        {
            return View(_Information.View());
        }


        // GET: InformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Information collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                _Information.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InformationController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _Information.Find(id);
            return View(data);
        }

        // POST: InformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Information collection)
        {
            try
            {
                var data = _Information.Find(id);
                data.InformationName = collection.InformationName;
                data.InformationRedirect = collection.InformationRedirect;
                data.InformationDescription = collection.InformationDescription;
                data.InformationIcon = collection.InformationIcon;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _Information.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InformationController/Delete/5
        public ActionResult Delete(int idDelete)
        {
           var data = _Information.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Information.Delete(idDelete, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            var data = _Information.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Information.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }

    }
}
