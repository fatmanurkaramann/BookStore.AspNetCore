using BookStore.AspNetCore.AppDbContext;
using BookStore.AspNetCore.Models;
using BookStore.AspNetCore.Repositories;
using BookStore.AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly BookStoreDbContext _appDb;
        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository, BookStoreDbContext appDb)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _appDb = appDb;
        }

        public IActionResult Index()
        {
            var vm = _appDb.Books.Select(x => new BookListViewModel()
            {
                Name = x.Name,
                Price = x.Price,
                Author=x.Author,
                ImagePath=x.ImagePath
            }
          ).ToList();
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}