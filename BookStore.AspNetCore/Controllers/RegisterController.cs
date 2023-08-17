//using AutoMapper;
//using BookStore.AspNetCore.Models;
//using BookStore.AspNetCore.ViewModels;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace BookStore.AspNetCore.Controllers
//{
//    public class RegisterController : Controller
//    {
//        private readonly UserManager<AppUser> _userManager;
//        //UserManager sınıfı Identity sisteminin bir parçası olarak, kullanıcı işlemlerini yönetmek için
//        //kullanılan bir sınıftır. Kimlik doğrulama ve yetkilendirme işlemlerini kolaylaştırmak
//        //ve kullanıcıların yönetimini sağlamak için ASP.NET Core uygulamalarında kullanılır.

//        private readonly IMapper _mapper;
//        public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
//        {
//            _userManager = userManager;
//            _mapper = mapper;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Index(UserSignUpVM vm)
//        {
//            if (ModelState.IsValid)
//            {
//                AppUser user = _mapper.Map<AppUser>(vm); //ViewModel'i AppUser'a dönüştürme
//                var result = await _userManager.CreateAsync(user,vm.Password);
//                //_userManager.CreateAsync metoduna vm.Password'u vermek yerine
//                //genellikle şifrenin önce hashlenmesi gerekir. Bu hashlenmiş şifre daha sonra
//                //_userManager.CreateAsync metoduna geçilir. Bu sayede şifrelerin güvende tutulması
//                //ve doğru güvenlik önlemlerinin alınması sağlanır.

//                if (result.Succeeded)
//                {
//                    Console.WriteLine("başarılı");
//                    return RedirectToAction("Index","Login");
//                }
//                else
//                {
//                    foreach (var item in result.Errors)
//                    {
//                        ModelState.AddModelError("",item.Description);

//                    }
//                }

//            }
//            return View(vm);
//        }
//    }
//}
