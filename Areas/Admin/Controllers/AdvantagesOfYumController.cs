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
    public class AdvantagesOfYumController : Controller
    {
        public IRepository<AdvantagesOfYum> _AdvantagesOfYum { get; }

        public AdvantagesOfYumController(IRepository<AdvantagesOfYum> advantagesOfYum)
        {
            _AdvantagesOfYum = advantagesOfYum;
        }
        // GET: AdvantagesOfYumController
        public ActionResult Index()
        {
            return View(_AdvantagesOfYum.View());
        }

     

        // GET: AdvantagesOfYumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvantagesOfYumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdvantagesOfYum collection)
        {
            try
            {
                
                    collection.CreateDate = DateTime.Now;
                    collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    collection.IsActive = true;
                    _AdvantagesOfYum.Add(collection);
                    return RedirectToAction(nameof(Index));
               
               
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvantagesOfYumController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(_AdvantagesOfYum.Find(id));
        }

        // POST: AdvantagesOfYumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdvantagesOfYum collection)
        {
            try
            {
                var data = _AdvantagesOfYum.Find(id);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.AdvantagesOfYumDescription = collection.AdvantagesOfYumDescription;
                data.AdvantagesOfYumBreef = collection.AdvantagesOfYumBreef;
                data.AdvantagesOfYumIcon = collection.AdvantagesOfYumIcon;
                _AdvantagesOfYum.Update(id,data);
                 return RedirectToAction(nameof(Index));

              
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvantagesOfYumController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _AdvantagesOfYum.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _AdvantagesOfYum.Delete(idDelete,data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            var data = _AdvantagesOfYum.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _AdvantagesOfYum.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }
    }
}
