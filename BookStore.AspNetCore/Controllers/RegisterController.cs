using BookStore.AspNetCore.Models;
using BookStore.AspNetCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpVM vm)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = vm.Email,
                    NameSurname = vm.NameSurname,
                    UserName=vm.Username
                };
                var result = await _userManager.CreateAsync(user,vm.Password);

                if(result.Succeeded)
                {
                    Console.WriteLine("başarılı");
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);

                    }
                }

            }
            return View(vm);
        }
    }
}
