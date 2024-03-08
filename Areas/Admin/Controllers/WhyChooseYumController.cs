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
    public class WhyChooseYumController : Controller
    {
        public IRepository<WhyChooseYum> _WhyChooseYum { get; }

        public WhyChooseYumController(IRepository<WhyChooseYum> whyChooseYum)
        {
            _WhyChooseYum = whyChooseYum;
        }
        // GET: WhyChooseYumController
        public ActionResult Index()
        {
            return View(_WhyChooseYum.View());
        }

        // GET: WhyChooseYumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhyChooseYumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WhyChooseYum collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                _WhyChooseYum.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WhyChooseYumController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_WhyChooseYum.Find(id));
        }

        // POST: WhyChooseYumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WhyChooseYum collection)
        {
            try
            {
                
                var data = _WhyChooseYum.Find(id);
                data.WhyChooseYumLink = collection.WhyChooseYumLink;
                data.WhyChooseYumDescription = collection.WhyChooseYumDescription;
                data.WhyChooseYumTitle  = collection.WhyChooseYumTitle;
                data.EditUser= User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.Now;
                _WhyChooseYum.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WhyChooseYumController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _WhyChooseYum.Find(idDelete);
            data.EditDate= DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _WhyChooseYum.Delete(idDelete,data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            var data = _WhyChooseYum.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _WhyChooseYum.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }


    }
}
