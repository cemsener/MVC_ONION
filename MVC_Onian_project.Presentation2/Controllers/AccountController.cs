using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Onian_project.Presentation2.Models;

namespace MVC_Onian_project.Presentation2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                Console.WriteLine("Email veya şifre hatalı.");
                return View(model);
            }

            var checkPass = await _signInManager.PasswordSignInAsync(user,model.Password,false,false);

            if (!checkPass.Succeeded)
            {
                Console.WriteLine("Email veya şifre hatalı.");
                return View(model);
            }

            var userRole = await _userManager.GetRolesAsync(user);
            if (userRole is null)
            {
                Console.WriteLine("Kullanıcıya ait rol bulunamadı.");
                return View(model);
            }

            return RedirectToAction("Index", "Home", new {Area = userRole[0].ToString() });

        }
    }
}
