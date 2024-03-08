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
    public class AboutUsController : Controller
    {
        public IRepository<AboutUs> _AboutUs { get; }
        public IHostingEnvironment Host { get; }

        public AboutUsController(IRepository<AboutUs> aboutUs,IHostingEnvironment host)
        {
            _AboutUs = aboutUs;
            Host = host;
        }
        // GET: AboutUsController
        public ActionResult Index()
        {
            return View(_AboutUs.View());
        }

        

        // GET: AboutUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AboutUsViewModel collection)
        {
            try
            {
                

                if (collection.File1 == null)
                {
                    ModelState.AddModelError("", "The file field required");
                    return View();

                }
                if (collection.File2 == null)
                {
                    ModelState.AddModelError("", "The file field required");
                    return View();

                }
                var obj = new AboutUs
                    {
                        AboutUsParagraph1 = collection.AboutUsParagraph1,
                        AboutUsParagraph2 = collection.AboutUsParagraph2,
                        AboutUsPoint1 = collection.AboutUsPoint1,
                        AboutUsPoint2 = collection.AboutUsPoint2,
                        AboutUsPoint3 = collection.AboutUsPoint3,
                        AboutUsLink = collection.AboutUsLink,
                        AboutUsPhoneNote = collection.AboutUsPhoneNote,
                        AboutUsTitle = collection.AboutUsTitle,
                        AboutUsImage1 = UploadImage(collection.File1),
                        AboutUsImage2 = UploadImage(collection.File2),
                        CreateDate = DateTime.Now,
                        CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                        IsActive = true,
                    };
                    _AboutUs.Add(obj);
                    return RedirectToAction(nameof(Index));
                //}
                //ModelState.AddModelError("", "Full out all Information");
                //return View();                
            }
            catch
            {
                return View();
            }
        }

        // GET: AboutUsController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _AboutUs.Find(id);
            var obj = new AboutUsViewModel
            {
                AboutUsParagraph1 = data.AboutUsParagraph1,
                AboutUsParagraph2 = data.AboutUsParagraph2,
                AboutUsPoint1 = data.AboutUsPoint1,
                AboutUsPoint2 = data.AboutUsPoint2,
                AboutUsPoint3 = data.AboutUsPoint3,
                AboutUsLink = data.AboutUsLink,
                AboutUsTitle= data.AboutUsTitle,
                AboutUsPhoneNote= data.AboutUsPhoneNote,
            };
            return View(obj);
        }

        // POST: AboutUsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AboutUsViewModel collection)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    var data = _AboutUs.Find(id);
                    data.AboutUsLink = collection.AboutUsLink;
                    data.AboutUsTitle = collection.AboutUsTitle;
                    data.AboutUsParagraph1 = collection.AboutUsParagraph1;
                    data.AboutUsParagraph2 = collection.AboutUsParagraph2;
                    data.AboutUsPoint1 = collection.AboutUsPoint1;
                    data.AboutUsPoint2 = collection.AboutUsPoint2;
                    data.AboutUsPoint3 = collection.AboutUsPoint3;
                    data.AboutUsPhoneNote = collection.AboutUsPhoneNote;
                    data.AboutUsImage1 = (collection.File1 != null)?UploadImage(collection.File1):data.AboutUsImage1;
                    data.AboutUsImage2 = (collection.File2 != null) ? UploadImage(collection.File2) : data.AboutUsImage2;
                    data.EditDate = DateTime.Now;
                    data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _AboutUs.Update(id,data);
                    return RedirectToAction(nameof(Index));
                //}
                //ModelState.AddModelError("","Full out all information");
                //return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AboutUsController/Delete/5
        public IActionResult Delete(int idDelete)
        {
            var data = _AboutUs.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _AboutUs.Delete(idDelete,data);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Active(int idActive)
        {
            var data = _AboutUs.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier) ;
            _AboutUs.Active(idActive,data);
            return RedirectToAction(nameof(Index));
        }


        public string UploadImage(IFormFile file)
        {
            string image = "";

            if (file != null)
            {
                string path = Path.Combine(Host.WebRootPath,"AboutUsImg");
                FileInfo info = new FileInfo(file.FileName);
                image = Guid.NewGuid() + info.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream(FullPath,FileMode.Create));
            }

            return image;
        }
    }
}
