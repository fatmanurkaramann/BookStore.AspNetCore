using BookStore.AspNetCore.ViewModels;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCore.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [Route("/sign-in")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM user)
        {

            if (ModelState.IsValid)
            {
                //_signInManager.PasswordSignInAsync Metodu: Bu metot, kullanıcının girdiği email
                //ve şifreyi alır ve veritabanında bu email adresine sahip bir kullanıcının varlığını kontrol eder.
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Yanlış kullanıcı adı veya şifre!";
                    return View();
                }
            }
            TempData["error"] = "hata";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
