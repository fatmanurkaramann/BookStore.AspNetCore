using Business.Abstract;
using Business.Concrete;
using Business.DTOs;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;
        public AuthorController(IAuthorService authorService, ICategoryService categoryService, IBookService bookService)
        {
            _authorService = authorService;
            _categoryService = categoryService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAll();
            ViewBag.Books = books;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(CreateAuthorDto authorDto)
        {

            await _authorService.Add(authorDto);
            return RedirectToAction("Index");
        }
    }
}
