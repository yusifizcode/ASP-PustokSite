using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using Pustok.ViewModels;
using System.Threading.Tasks;

namespace Pustok.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            AccountIndexViewModel indexVM = new AccountIndexViewModel
            {
                LoginVM = new MemberLoginViewModel(),
                RegisterVM = new MemberRegisterViewModel()
            };
            return View(indexVM);
        }

        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel member)
        {
            if(!ModelState.IsValid)
                return View("index", new AccountIndexViewModel { RegisterVM = member, LoginVM = new MemberLoginViewModel() }) ;

            AppUser user = new AppUser
            {
                FullName = member.FullName,
                Email = member.Email,
                UserName = member.RegisterUserName,
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(user,member.RegisterPassword);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("index", new AccountIndexViewModel { RegisterVM = member, LoginVM = new MemberLoginViewModel() }) ;
            }

            await _userManager.AddToRoleAsync(user, "Member");

            return RedirectToAction("index");
        }
        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginViewModel member)
        {
            if(!ModelState.IsValid)
                return View("index", new AccountIndexViewModel { LoginVM = member, RegisterVM = new MemberRegisterViewModel() }) ;


            AppUser user = await _userManager.Users.FirstOrDefaultAsync(x=> !x.IsAdmin && x.UserName == member.LoginUserName);

            if (user == null)
            {
                ModelState.AddModelError("", "UserName or Password is not correct!");
                return View("index", new AccountIndexViewModel { LoginVM = member, RegisterVM = new MemberRegisterViewModel() }) ;
            }

            var result = await _signInManager.PasswordSignInAsync(user,member.LoginPassword,false,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is not correct!");
                return View("index", new AccountIndexViewModel { LoginVM = member, RegisterVM = new MemberRegisterViewModel() });
            }

            return RedirectToAction("index","home");
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
