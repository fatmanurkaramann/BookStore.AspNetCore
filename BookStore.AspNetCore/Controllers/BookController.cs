using AutoMapper;
using BookStore.AspNetCore.Filters;
using BookStore.AspNetCore.ViewModels;
using Business.Abstract;
using Business.DTOs;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BookStore.AspNetCore.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookRepository;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        
        public BookController(IBookService bookRepository, IWebHostEnvironment env, IMapper mapper, ICategoryService categoryService, IAuthorService authorService)
        {
            _bookRepository = bookRepository;
            _env = env;
            _mapper = mapper;
            _categoryService = categoryService;
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Index(int page =1, int pageSize=3)
        {
            var bookPagedList = _bookRepository.GetAll().ToPagedList(page,pageSize);
            List<Book> books = bookPagedList.ToList();

            List<BookListDto> bookListDtos = _mapper.Map<List<BookListDto>>(books);
            IPagedList<BookListDto> pagedBookListDtos = new StaticPagedList<BookListDto>(bookListDtos, bookPagedList.GetMetaData());

            return View(pagedBookListDtos);
        }
       
        [HttpGet]
        [Route("[controller]/{id}")]
        //parametre aldığı için böyle tanımlandı
        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            await _categoryService.GetById(book.CategoryId);
            var authors = _authorService.GetAllAuthor();
            BookListDto vm = _mapper.Map<BookListDto>(book);
            return View(vm);
        }

        [Route("/add-book",Name ="addProduct")]
        public IActionResult GetAddPage()
        {
            var authors = _authorService.GetAllAuthor();
            var categories = _categoryService.GetAll();

            ViewBag.Authors = authors;
            ViewBag.Categories = categories;

            return View();

        }
        [HttpPost]
        [Route("/add-book", Name = "addProduct")]
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
                var authors = _authorService.GetAllAuthor();
                ViewBag.Authors = authors;
                var categories = _categoryService.GetAll();
                ViewBag.Categories = categories;
                return View("GetAddPage");
            }

        }
        [HttpGet]
        [Route("/edit-book/{id}")]
        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> GetUpdatePage(int id)
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = categories;
            var authors = _authorService.GetAllAuthor();
            var book = await _bookRepository.GetByIdAsync(id);
            BookUpdateDto vm = _mapper.Map<BookUpdateDto>(book);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookUpdateDto book, IFormFile imageFile)
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
                    var existingBook =await _bookRepository.NoTrackingGetByIdAsync(book.Id);
                    if (existingBook != null)
                    {
                        book.ImagePath = existingBook.ImagePath;
                    }
                }
               await _bookRepository.Update(book);
                return RedirectToAction("Index");
            }
            else
            {
                var categories = _categoryService.GetAll();
                ViewBag.Categories = categories;
                return View("GetUpdatePage",book);
            }
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Remove(int id)
        {
            _bookRepository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
