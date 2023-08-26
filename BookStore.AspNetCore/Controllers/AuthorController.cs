using AutoMapper;
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
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService, ICategoryService categoryService, IBookService bookService, IMapper mapper)
        {
            _authorService = authorService;
            _categoryService = categoryService;
            _bookService = bookService;
            _mapper = mapper;
        }

        [Route("[controller]")]
        public IActionResult Index()
        {
            var books = _bookService.GetAll();
            ViewBag.Books = books;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(CreateAuthorDto authorDto,int bookId)
        {
            
                var addedAuthor = await _authorService.Add(authorDto);
                int newAuthorId = addedAuthor.Id;

                if (newAuthorId > 0)
                {
                    var newAuthor = await _authorService.GetById(newAuthorId);

                    if (newAuthor != null)
                    {
                        var book = await _bookService.NoTrackingGetByIdAsync(bookId);

                        if (book != null)
                        {
                            book.Author = newAuthor;
                            await _bookService.Update(_mapper.Map<BookUpdateDto>(book));
                        }
                    }
                }

                return RedirectToAction("Index", "Book");
        }
    }
}
