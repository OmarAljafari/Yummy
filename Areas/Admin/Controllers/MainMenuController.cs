using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;
using Yummy.Models;
using Yummy.Models.Repositories;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MainMenuController : Controller
    {
        public IRepository<MainMenu> _MainMenu { get; }

        public MainMenuController(IRepository<MainMenu> mainMenu)
        {
            _MainMenu = mainMenu;
        }
        // GET: MainMenuController
        public ActionResult Index()
        {
            return View(_MainMenu.View());
        }

       

        // GET: MainMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MainMenu collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                _MainMenu.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_MainMenu.Find(id));
        }

        // POST: MainMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MainMenu collection)
        {
            try
            {
                var data = _MainMenu.Find(id);
                data.MainMenuIconUrl = collection.MainMenuIconUrl;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _MainMenu.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _MainMenu.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _MainMenu.Delete(idDelete, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            var data = _MainMenu.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _MainMenu.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }
    }
}
