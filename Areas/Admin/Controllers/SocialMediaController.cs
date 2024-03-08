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
    public class SocialMediaController : Controller
    {
        public IRepository<SocialMedia> _SocialMedia { get; }

        public SocialMediaController(IRepository<SocialMedia> socialMedia)
        {
            _SocialMedia = socialMedia;
        }
        // GET: SocialMediaController
        public ActionResult Index()
        {
            return View(_SocialMedia.View());
        }


        // GET: SocialMediaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SocialMedia collection)
        {
            try
            {
                collection.CreateDate  = DateTime.Now;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                _SocialMedia.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_SocialMedia.Find(id));
        }

        // POST: SocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SocialMedia collection)
        {
            try
            {
                var data = _SocialMedia.Find(id);
                data.SocialMediaLink = collection.SocialMediaLink;
                data.SocialMediaRedirect = collection.SocialMediaRedirect;
                data.SocialMediaIcon = collection.SocialMediaIcon;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _SocialMedia.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialMediaController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            var data = _SocialMedia.Find(idDelete);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _SocialMedia.Delete(idDelete,data);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int idActive)
        {
            var data = _SocialMedia.Find(idActive);
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _SocialMedia.Active(idActive, data);
            return RedirectToAction(nameof(Index));
        }
    }
}
