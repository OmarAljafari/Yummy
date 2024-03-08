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
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> _SystemSetting { get; }
        public IWebHostEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> systemSetting,IWebHostEnvironment host)
        {
            _SystemSetting = systemSetting;
            Host = host;
        }
        // GET: SystemSettingController
        public ActionResult Index()
        {
            return View(_SystemSetting.View());
        }

        
        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingViewModel collection)
        {
            try
            {
                if (collection.FileBook == null)
                {
                    ModelState.AddModelError("", "The file field required");
                    return View();

                }
                if (collection.FileStat == null)
                {
                    ModelState.AddModelError("", "The file field required");
                    return View();

                }

                var obj = new SystemSetting
                {
                    SystemSettingCopyRight = collection.SystemSettingCopyRight,
                    SystemSettingImageBook = UploadImage(collection.FileBook),
                    SystemSettingImageStatistics = UploadImage(collection.FileStat),
                    SystemSettingLogo = collection.SystemSettingLogo,
                    SystemSettingMap = collection.SystemSettingMap,
                    SystemSettingTitleBook = collection.SystemSettingTitleBook,
                    SystemSettingTitleMap = collection.SystemSettingTitleMap,
                    CreateDate = DateTime.Now,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    MomentTitle = collection.MomentTitle,
                    CategoryMenuTitle = collection.CategoryMenuTitle,
                    ChefTitle = collection.ChefTitle,
                    GalleryTitle = collection.GalleryTitle,
                    WhatPeopleSayTitle = collection.WhatPeopleSayTitle,
                };
                _SystemSetting.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _SystemSetting.Find(id);
            var obj = new SystemSettingViewModel
            {
                SystemSettingCopyRight = data.SystemSettingCopyRight,
                SystemSettingLogo = data.SystemSettingLogo, 
                SystemSettingMap = data.SystemSettingMap,
                SystemSettingTitleBook = data.SystemSettingTitleBook,
                SystemSettingTitleMap =  data.SystemSettingTitleMap,
                MomentTitle = data.MomentTitle,
                CategoryMenuTitle= data.CategoryMenuTitle,
                ChefTitle= data.ChefTitle,
                GalleryTitle= data.GalleryTitle,
                WhatPeopleSayTitle= data.WhatPeopleSayTitle,
            };
            return View(obj);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingViewModel collection)
        {
            try
            {
                var data = _SystemSetting.Find(id);
                data.SystemSettingTitleMap = collection.SystemSettingTitleMap;
                data.SystemSettingCopyRight = collection.SystemSettingCopyRight;
                data.SystemSettingMap = collection.SystemSettingMap;
                data.SystemSettingLogo = collection.SystemSettingLogo;
                data.SystemSettingTitleBook = collection.SystemSettingTitleBook;
                data.SystemSettingImageStatistics = (collection.FileStat != null) ? UploadImage(collection.FileStat) : data.SystemSettingImageStatistics;
                data.SystemSettingImageBook = (collection.FileBook != null) ? UploadImage(collection.FileBook) : data.SystemSettingImageBook;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                data.MomentTitle = collection.MomentTitle;
                data.CategoryMenuTitle = collection.CategoryMenuTitle;
                data.ChefTitle = collection.ChefTitle;
                data.GalleryTitle = collection.GalleryTitle;
                data.WhatPeopleSayTitle = collection.WhatPeopleSayTitle;
                _SystemSetting.Update(id, data);    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _SystemSetting.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _SystemSetting.Delete(idDelete, data);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Active(int idActive)
        {
            var data = _SystemSetting.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _SystemSetting.Active(idActive,data);
            return RedirectToAction(nameof(Index));

        }

       public string UploadImage(IFormFile file)
       {
            string image = "";
            if (file != null)
            {
                string path = Path.Combine(Host.WebRootPath,"SystemSettingImg");
                Directory.CreateDirectory(path);
                FileInfo fileInfo = new FileInfo(file.FileName);
                image = Guid.NewGuid()+fileInfo.Extension;
                string FullPath = Path.Combine(path, image);
                file.CopyTo(new FileStream( FullPath, FileMode.Create));
            }
            return image;

       }
    }
}
