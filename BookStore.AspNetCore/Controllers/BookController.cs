using AutoMapper;
using BookStore.AspNetCore.ViewModels;
using Business.Abstract;
using Business.DTOs;
using DataAccess.Concrete.Book;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookRepository;
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public BookController(IBookService bookRepository, IWebHostEnvironment env, IMapper mapper, ICategoryService categoryService)
        {
            _bookRepository = bookRepository;
            _env = env;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var book = _bookRepository.GetAll();
            List<BookListDto> vm = _mapper.Map<List<BookListDto>>(book);
            return View(vm);
        }
        [HttpGet]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.GetById(id);
            return View(book);
        }
        public IActionResult GetAddPage()
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto book, IFormFile imageFile)
        {

            //Model state: Mvcde bir typeın required,..vs kontrol edip geriye sonuç döndüren property
            ModelState.Remove("ImagePath");

            //diğer doğrulama hatalarını etkilemeden belirli bir özelliğe ait hataları kaldırmak için kullanışlı.
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Path.GetFileName(imageFile.FileName);
                    string imagePath = Path.Combine(_env.WebRootPath, "images", fileName);

                    Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                   
                        imageFile.CopyTo(stream);
                    }

                    book.ImagePath = "images/" + fileName;
                }

               
                await _bookRepository.Add(book);
                TempData["Added"] = "Ürün Başarıyla eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                var categories = _categoryService.GetAll();
                ViewBag.Categories = categories;
                return View("GetAddPage");
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetUpdatePage(int id)
        {
            var book = await _bookRepository.GetById(id);
            BookDto vm = _mapper.Map<BookDto>(book);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookViewModel book, IFormFile imageFile)
        {
            ModelState.Remove("imageFile");
            if (ModelState.IsValid)
            {

                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Path.GetFileName(imageFile.FileName);
                    string imagePath = Path.Combine(_env.WebRootPath, "images", fileName);

                    Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    book.ImagePath = "images/" + fileName;
                }
                else
                {
                    // Eğer imageFile null ise, mevcut ImagePath değerini koruyoruz.
                    var existingBook =await _bookRepository.GetById(book.Id);
                    if (existingBook != null)
                    {
                        book.ImagePath = existingBook.ImagePath;
                    }
                }
               
                _bookRepository.Update(_mapper.Map<BookDto>(book));
                return RedirectToAction("Index");
            }
            else
            {
                return View("GetUpdatePage");
            }
        }


        public IActionResult Remove(int id)
        {
            _bookRepository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
