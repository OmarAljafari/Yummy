using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Yummy.Areas.Admin.ViewModels;
using Yummy.Models;
using Yummy.Models.Repositories;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class GalleryController : Controller
    {
        public IRepository<Gallery> _Gallery { get; }
        public IWebHostEnvironment Host { get; }

        public GalleryController(IRepository<Gallery> gallery,IWebHostEnvironment host)
        {
            _Gallery = gallery;
            Host = host;
        }
        // GET: GalleryController
        public ActionResult Index()
        {
            return View(_Gallery.View());
        }

       

        // GET: GalleryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GalleryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GalleryViewModel collection)
        {
            try
            {
                if (collection.File == null )
                {

                    ModelState.AddModelError("", "The file field is required ");
                    return View();

                }
                var obj = new Gallery
                {
                    GalleryImage =UploadImage(collection.File),
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true

                };
                _Gallery.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GalleryController/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View();
        }

        // POST: GalleryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GalleryViewModel collection)
        {
            try
            {
                var data = _Gallery.Find(id);
                data.GalleryImage =(collection.File != null)? UploadImage(collection.File):data.GalleryImage;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _Gallery.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GalleryController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _Gallery.Find(idDelete);
            data.EditDate= DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Gallery.Delete(idDelete, data);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int idActive)
        {
            var data = _Gallery.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _Gallery.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }


        public string UploadImage(IFormFile file)
        {
            string image = "";
            if (file != null)
            {
                string path = Path.Combine(Host.WebRootPath,"GalleryImg");
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
