using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Yummy.Areas.Admin.ViewModels;
using Yummy.Models;
using Yummy.Models.Repositories;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ItemMenuController : Controller
    {
        public IRepository<ItemMenu> _ItemMenu { get; }
        public IWebHostEnvironment Host { get; }
        public IRepository<CategoryMenu> _CategoryMenu { get; }

        public ItemMenuController(IRepository<ItemMenu> itemMenu,IWebHostEnvironment host,IRepository<CategoryMenu> categoryMenu)
        {
            _ItemMenu = itemMenu;
            Host = host;
            _CategoryMenu = categoryMenu;
        }
        // GET: ItemMenuController
        public ActionResult Index()
        {
            return View(_ItemMenu.View());
        }


        // GET: ItemMenuController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryMenuList = _CategoryMenu.View();
            return View();
        }

        // POST: ItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemMenuViewModel collection)
        {
            try
            {
                if(collection.File == null) {
                    ModelState.AddModelError("", "The file field is required");
                    return View();
                }
                var obj = new ItemMenu
                {
                    ItemMenuBreef = collection.ItemMenuBreef,
                    ItemMenuName = collection.ItemMenuName,
                    ItemMenuPrice = collection.ItemMenuPrice,
                    ItemMenuImage = UploadImage(collection.File),
                    IsActive = true,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CategoryMenuId = collection.CategoryMenuId,
                };
                _ItemMenu.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryMenuList = _CategoryMenu.View();
            var data = _ItemMenu.Find(id);
            var obj = new ItemMenuViewModel
            {
                ItemMenuBreef = data.ItemMenuBreef,
                ItemMenuName=data.ItemMenuName,
                ItemMenuPrice = data.ItemMenuPrice,
                CategoryMenuId = data.CategoryMenuId
            };
            return View(obj);
        }

        // POST: ItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemMenuViewModel collection)
        {
            try
            {
                var data = _ItemMenu.Find(id);
                data.ItemMenuName = collection.ItemMenuName;
                data.ItemMenuPrice = collection.ItemMenuPrice;
                data.ItemMenuBreef = collection.ItemMenuBreef;
                data.ItemMenuImage = (collection.File != null)? UploadImage(collection.File):data.ItemMenuImage;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.CategoryMenuId = collection.CategoryMenuId;
                _ItemMenu.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _ItemMenu.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _ItemMenu.Delete(idDelete, data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            var data = _ItemMenu.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _ItemMenu.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }

        public string UploadImage(IFormFile file)
        {
            string image = "";
            if(file != null)
            {
                string path = Path.Combine(Host.WebRootPath,"ItemMenuImg");
                Directory.CreateDirectory(path);
                FileInfo fileInfo = new FileInfo(file.FileName);
                image = Guid.NewGuid() + fileInfo.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return image;
        }
    }
}
