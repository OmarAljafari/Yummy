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
    public class FrontOfPageController : Controller
    {
        public IRepository<FrontOfPage> _FrontOfPage { get; }
        public IHostingEnvironment Host { get; }

        public FrontOfPageController(IRepository<FrontOfPage> frontOfPage,IHostingEnvironment host)
        {
            _FrontOfPage = frontOfPage;
            Host = host;
        }
        // GET: FrontOfPageController
        public ActionResult Index()
        {
            return View(_FrontOfPage.View());
        }


        // GET: FrontOfPageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FrontOfPageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FrontOfPageViewModel collection)
        {
            try
            {
                if (collection.File == null)
                {

                    ModelState.AddModelError("", "The file field is required ");
                    return View();

                }
                var obj = new FrontOfPage
                {
                    FrontOfPageDescription = collection.FrontOfPageDescription,
                    FrontOfPageLink1 = collection.FrontOfPageLink1,
                    FrontOfPageLink2 = collection.FrontOfPageLink2,
                    FrontOfPageTitle = collection.FrontOfPageTitle,
                    FrontOfPageImage = UplaodImage(collection.File),
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                };
                _FrontOfPage.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FrontOfPageController/Edit/5
        public ActionResult Edit(int id)
        {

            var data = _FrontOfPage.Find(id);
            var obj = new FrontOfPageViewModel
            {
                FrontOfPageDescription = data.FrontOfPageDescription,
                FrontOfPageLink1 = data.FrontOfPageLink1,   
                FrontOfPageTitle = data.FrontOfPageTitle,
                FrontOfPageLink2 = data.FrontOfPageLink2,
            };
            return View(obj);
        }

        // POST: FrontOfPageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FrontOfPageViewModel collection)
        {
            try
            {

              
                var data = _FrontOfPage.Find(id);
                data.FrontOfPageLink1 = collection.FrontOfPageLink1;
                data.FrontOfPageLink2 = collection.FrontOfPageLink2;
                data.FrontOfPageTitle = collection.FrontOfPageTitle;
                data.FrontOfPageDescription = collection.FrontOfPageDescription;
                data.FrontOfPageImage = (collection.File !=null)?UplaodImage(collection.File):data.FrontOfPageImage;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _FrontOfPage.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FrontOfPageController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _FrontOfPage.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _FrontOfPage.Delete(idDelete,data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            var data = _FrontOfPage.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _FrontOfPage.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }


        public string UplaodImage(IFormFile file)
        {
            string image = "";
            if (file != null)
            {
                string path = Path.Combine(Host.WebRootPath,"FrontOfPageImg");
                FileInfo info  = new FileInfo(file.FileName);
                image = Guid.NewGuid() +info.Extension;
                string FullPath = Path.Combine(path,image);
                file.CopyTo(new FileStream( FullPath, FileMode.Create));
            }
            return image;
        }
    }
}
