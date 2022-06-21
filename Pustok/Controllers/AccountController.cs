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


            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var url = Url.Action("ConfirmEmail", "Account", new { email = user.Email, token = token }, Request.Scheme);



            await _userManager.AddToRoleAsync(user, "Member");

            return Ok(new { URL = url });
            return RedirectToAction("index");
        }

        public async Task<IActionResult> ConfirmEmail(string email,string token)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return RedirectToAction("error", "dashboard");

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
                return RedirectToAction("index");
            else
                return RedirectToAction("error", "dashboard");
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

        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forgot(MemberForgotPasswordViewModel memberVM)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser member = await _userManager.FindByEmailAsync(memberVM.Email);

            if(member == null)
            {
                ModelState.AddModelError("", "Email is not exist!");
                return View();
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(member);

            var url = Url.Action("ResetPassword","Account",new {email=member.Email,token=token},Request.Scheme);

            return Ok(new { URL = url });

        }

        public IActionResult ResetPassword(string email,string token)
        {
            MemberResetPasswordViewModel vm = new MemberResetPasswordViewModel
            {
                Email = email,
                Token = token
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(MemberResetPasswordViewModel resetVM)
        {
            if (!ModelState.IsValid) return View();


            AppUser member = await _userManager.Users.FirstOrDefaultAsync(x => !x.IsAdmin && x.NormalizedEmail == resetVM.Email.ToUpper());

            if (member == null)
                return RedirectToAction("error", "dashboard");

            var result = await _userManager.ResetPasswordAsync(member, resetVM.Token, resetVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            return RedirectToAction("index");
        }
    }
}
