using BookStore.AspNetCore.ViewModels;
using Business.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookRepository;
        private readonly BookAppDbContext _appDb;
        public HomeController(ILogger<HomeController> logger, IBookService bookRepository, BookAppDbContext appDb)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _appDb = appDb;
        }

        public IActionResult Index()
        {
            var vm = _appDb.Books.Select(x => new BookListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImagePath = x.ImagePath
            }
          ).ToList();
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}