using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Core;
using System.Security.Claims;
using Yummy.Areas.Admin.ViewModels;
using Yummy.Models;
using Yummy.Models.Repositories;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MomentController : Controller
    {
        public IRepository<Moment> _Moment { get; }
        public IWebHostEnvironment Host { get; }

        public MomentController(IRepository<Moment> moment,IWebHostEnvironment host)
        {
            _Moment = moment;
            Host = host;
        }
        // GET: MomentController
        public ActionResult Index()
        {
            return View(_Moment.View());
        }

        

        // GET: MomentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MomentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MomentViewModel collection)
        {
            try
            {
                if(collection.File == null)
                {
                    ModelState.AddModelError("", "The file field is required");
                    return View();
                }
                var obj = new Moment
                {
                    MomentDescription = collection.MomentDescription,
                    MomentName = collection.MomentName,
                    MomentPrice = collection.MomentPrice,
                    MomentImage = UploadImage(collection.File),
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                };
                _Moment.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MomentController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _Moment.Find(id);
            var obj = new MomentViewModel
            {
                MomentDescription = data.MomentDescription,
                MomentName= data.MomentName,
                MomentPrice= data.MomentPrice,
            };
            return View(obj);
        }

        // POST: MomentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MomentViewModel collection)
        {
            try
            {
                var data = _Moment.Find(id);
                data.MomentDescription = collection.MomentDescription;
                data.MomentName = collection.MomentName;
                data.MomentPrice = collection.MomentPrice;  
                data.MomentImage = (collection.File !=null)? UploadImage(collection.File):data.MomentImage;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.EditDate = DateTime.Now;
                _Moment.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MomentController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _Moment.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Moment.Delete(idDelete,data);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int idActive)
        {
            var data = _Moment.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Moment.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }

        public string UploadImage(IFormFile file)
        {
            string image = "";
            if (file != null)
            {
                string path = Path.Combine(Host.WebRootPath,"MomentImg");
                Directory.CreateDirectory(path);
                FileInfo fileInfo = new FileInfo(file.FileName);
                image = Guid.NewGuid()+fileInfo.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return image;

        }
    }
}
