using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Yummy.Areas.Admin.ViewModels;
using Yummy.Models;
using Yummy.Models.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ChefController : Controller
    {
        public IRepository<Chef> _Chef { get; }
        public IHostingEnvironment Host { get; }

        public ChefController(IRepository<Chef> chef,IHostingEnvironment host)
        {
            _Chef = chef;
            Host = host;
        }
        // GET: ChefController
        public ActionResult Index()
        {
            return View(_Chef.View());
        }


        // GET: ChefController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChefController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChefViewModel collection)
        {
            try
            {
                if (collection.File == null)
                {
                    
                    ModelState.AddModelError("","The file field is required ");
                    return View();

                }
                var obj = new Chef
                {
                    ChefDescription = collection.ChefDescription,
                    ChefName = collection.ChefName,
                    ChefJob = collection.ChefJob,
                    ChefImage = UploadImage(collection.File),
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                _Chef.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChefController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _Chef.Find(id);
            var obj = new ChefViewModel
            {
                ChefDescription=data.ChefDescription,
                ChefName=data.ChefName,
                ChefJob=data.ChefJob,
            };
            return View(obj);
        }

        // POST: ChefController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ChefViewModel collection)
        {
            try
            {
                var data = _Chef.Find(id);
                data.ChefDescription = collection.ChefDescription;
                data.ChefJob = collection.ChefJob;
                data.ChefName = collection.ChefName;
                data.ChefImage = (collection.File !=null)?UploadImage(collection.File):data.ChefImage;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.Now;
                _Chef.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChefController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _Chef.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Chef.Delete(idDelete,data);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int idActive)
        {
            var data = _Chef.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Chef.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }


        public string UploadImage(IFormFile file)
        {
            var image = "";
            if(file != null)
            {
                var path = Path.Combine(Host.WebRootPath, "ChefImg");
                FileInfo info = new FileInfo(file.FileName);
                image = Guid.NewGuid() + info.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            

            return image;
        }
              
    }
}
