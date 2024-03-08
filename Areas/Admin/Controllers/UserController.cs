using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Yummy.Areas.Admin.ViewModels;
using Yummy.Models;
using Yummy.Models.Repositories;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        public UserManager<User> _UserManager { get; }

        public UserController(UserManager<User> userManager)
        {
            _UserManager = userManager;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View(_UserManager.Users.Where(x =>x.IsDelete == false).ToList());
        }


        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public  ActionResult Edit(string id)
        {
            var data =  _UserManager.Users.SingleOrDefault(x => x.Id == id);
            var obj = new Register
            {
                Email = data.Email,
                UserName = data.UserName,
            };
            return View(obj);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Register collection)
        {
            try
            {
                if (_UserManager.Users.SingleOrDefault(x => x.Email.ToUpper() == collection.Email.ToUpper() && x.Id !=id) !=null)
                {
                    ModelState.AddModelError("","The email is used");
                    return View(collection);
                }
                var data =await _UserManager.FindByIdAsync(id);
                data.UserName = collection.UserName;
                data.Email = collection.Email;
                data.EditDate = DateTime.Now;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _UserManager.UpdateAsync(data);
                
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task <ActionResult> Delete(string idDelete)
        {
            var data = await _UserManager.FindByIdAsync(idDelete);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _UserManager.UpdateAsync(data);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Active(string idActive)
        {
           var data = await _UserManager.FindByIdAsync(idActive);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _UserManager.UpdateAsync(data);
            return RedirectToAction(nameof(Index));

        }
    }
}
