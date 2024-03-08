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
    public class WhatPeopleSayController : Controller
    {
        public IRepository<WhatPeopleSay> _WhatPeopleSay { get; }
        public IWebHostEnvironment Host { get; }

        public WhatPeopleSayController(IRepository<WhatPeopleSay> whatPeopleSay,IWebHostEnvironment host)
        {
            _WhatPeopleSay = whatPeopleSay;
            Host = host;
        }
        // GET: WhatPeopleSayController
        public ActionResult Index()
        {
            return View(_WhatPeopleSay.View());
        }

      
        // GET: WhatPeopleSayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhatPeopleSayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WhatPeopleSayViewModel collection)
        {
            try
            {
                if(collection.File == null)
                {
                    ModelState.AddModelError("", "The file field required");
                    return View();
                }
                var obj = new WhatPeopleSay
                {
                    WhatPeopleSayDescription = collection.WhatPeopleSayDescription,
                    WhatPeopleSayIconEndOfDesc = collection.WhatPeopleSayIconEndOfDesc,
                    WhatPeopleSayIconRate = collection.WhatPeopleSayIconRate,
                    WhatPeopleSayIconStartOfDesc = collection.WhatPeopleSayIconStartOfDesc,
                    WhatPeopleSayName = collection.WhatPeopleSayName,
                    WhatPeopleSayJob = collection.WhatPeopleSayJob,
                    WhatPeopleSayImage = UploadImage(collection.File),
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                _WhatPeopleSay.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WhatPeopleSayController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _WhatPeopleSay.Find(id);
            var obj = new WhatPeopleSayViewModel
            {
                WhatPeopleSayDescription = data.WhatPeopleSayDescription,
                WhatPeopleSayIconEndOfDesc= data.WhatPeopleSayIconEndOfDesc,
                WhatPeopleSayIconRate= data.WhatPeopleSayIconRate,
                WhatPeopleSayIconStartOfDesc= data.WhatPeopleSayIconStartOfDesc,
                WhatPeopleSayJob= data.WhatPeopleSayJob,
                WhatPeopleSayName= data.WhatPeopleSayName,
            };
            return View(obj);
        }

        // POST: WhatPeopleSayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WhatPeopleSayViewModel collection)
        {
            try
            {
                var data = _WhatPeopleSay.Find(id);
                data.WhatPeopleSayDescription = collection.WhatPeopleSayDescription;
                data.WhatPeopleSayIconEndOfDesc = collection.WhatPeopleSayIconEndOfDesc;
                data.WhatPeopleSayIconRate = collection.WhatPeopleSayIconRate;
                data.WhatPeopleSayIconStartOfDesc = collection.WhatPeopleSayIconStartOfDesc;
                data.WhatPeopleSayJob= collection.WhatPeopleSayJob;
                data.WhatPeopleSayName= collection.WhatPeopleSayName;
                data.WhatPeopleSayImage = (collection.File == null) ? data.WhatPeopleSayImage : UploadImage(collection.File);
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _WhatPeopleSay.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WhatPeopleSayController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _WhatPeopleSay.Find(idDelete);
            data.EditDate= DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier) ;
            _WhatPeopleSay.Delete(idDelete,data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            var data = _WhatPeopleSay.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _WhatPeopleSay.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }

        public string UploadImage(IFormFile file)
        {
            string image = "";

            if (file != null) 
            {
                string path = Path.Combine(Host.WebRootPath,"WhatPeopleSayImg");
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
