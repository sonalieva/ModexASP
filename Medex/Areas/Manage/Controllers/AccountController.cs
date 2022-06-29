using Medex.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Medex.Areas.Manage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Medex.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,  SignInManager<AppUser> signInManager, RoleManager<IdentityRole>roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new AppUser
            {
                FullName = "Seper Admin",
                UserName = "SuperAdmin",

            };
            var result = await _userManager.CreateAsync(admin, "Admin123");
            if (!result.Succeeded)
            {
                return Ok(result.Errors);
            }
            return View();
        }
        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("Member"));
            return Ok();
        }
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel admin)
        {

            if (!ModelState.IsValid)
                return View();
            //AppUser user = await _userManager.FindByNameAsync(admin.UserName);
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == admin.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "UserName or Password is not correct!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, admin.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is not correct!");
                return View();
            }
            return RedirectToAction("index","dashboard");
        }
        public async Task<IActionResult> GetUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                return Content(user.FullName);
            }
            else return Content("Login et!");

        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }



    }
}
