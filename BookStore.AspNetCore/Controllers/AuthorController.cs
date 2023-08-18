using Business.Abstract;
using Business.DTOs;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(CreateAuthorDto authorDto)
        {
            
            await _authorService.Add(authorDto);
            return View("Index","Author");
        }
    }
}
