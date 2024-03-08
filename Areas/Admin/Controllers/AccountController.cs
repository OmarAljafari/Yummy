using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Yummy.Areas.Admin.ViewModels;
using Yummy.Models;

namespace Yummy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }

        [Authorize]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(Register collection)
        {
           
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fill out all information");
                return View();
            }
            var UserExist = await UserManager.FindByNameAsync(collection.UserName);
            if (UserExist == null )
            {
                var obj = new User
                {
                    Email = collection.Email,
                    UserName = collection.UserName,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CreateDate = DateTime.Now,
                    IsActive = true
                };
                var result = await UserManager.CreateAsync(obj, collection.Password);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.ToString());
                    return View();
                }
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "The user is already exist");
                return View();
            }
            
           
           
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Login(Login collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Full out all information");
                return View();
            }
            var result = await SignInManager.PasswordSignInAsync(collection.UserName, collection.Password,false,false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            ModelState.AddModelError("",result.ToString()+" Check your information");
            return View();

        }

        public IActionResult Logout()
        {
            SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
