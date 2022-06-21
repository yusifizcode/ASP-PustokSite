using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Areas.Manage.ViewModels;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }


        //CREATE DEFAULT SUPER ADMIN

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        FullName = "Super Admin",
        //        UserName = "SuperAdmin",
        //        IsAdmin = true,
        //    };

        //    var result = await _userManager.CreateAsync(admin, "Admin123");

        //    if (!result.Succeeded)
        //        return Ok(result.Errors);

        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");

        //    return View();
        //}

        public async Task<IActionResult> Roles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(roles);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(role.Name));

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Name", item.Description);
                }
            }

            return RedirectToAction("roles");
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }


        public async Task<IActionResult> CreateAdmin()
        {
            ViewBag.Roles = await _roleManager.Roles.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminViewModel adminVM)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser admin = new AppUser
            {
                FullName = adminVM.FullName,
                UserName = adminVM.UserName,
                Email = adminVM.Email,
                IsAdmin = true
            };

            var result = await _userManager.CreateAsync(admin, adminVM.Password);
            await _userManager.AddToRoleAsync(admin, "Admin");

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                    return View();
                }
            }

            return RedirectToAction("index", "account");
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel admin)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser user = await _userManager.Users.FirstOrDefaultAsync(x=>x.IsAdmin && x.UserName == admin.UserName);


            if(user == null)
            {
                ModelState.AddModelError("", "UserName or Password is not correct!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, admin.Password,false,false);
            
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is not correct!");
                return View();
            }


            return RedirectToAction("index","dashboard");
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }

    }
}
