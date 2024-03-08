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
    public class CategoryMenuController : Controller
    {
        public IRepository<CategoryMenu> _CategoryMenu { get; }

        public CategoryMenuController(IRepository<CategoryMenu> categoryMenu)
        {
            _CategoryMenu = categoryMenu;
        }
        // GET: CategoryMenuController
        public ActionResult Index()
        {
            return View(_CategoryMenu.View());
        }


        // GET: CategoryMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryMenu collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                _CategoryMenu.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_CategoryMenu.Find(id));
        }

        // POST: CategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryMenu collection)
        {
            try
            {
                var data = _CategoryMenu.Find(id);
                data.CategoryMenuName = collection.CategoryMenuName;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _CategoryMenu.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _CategoryMenu.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _CategoryMenu.Delete(idDelete,data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            var data = _CategoryMenu.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _CategoryMenu.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }

    }
}
