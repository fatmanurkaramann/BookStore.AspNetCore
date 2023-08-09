using AutoMapper;
using BookStore.AspNetCore.Models;
using BookStore.AspNetCore.Repositories;
using BookStore.AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public BookController(IBookRepository bookRepository, IWebHostEnvironment env, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _env = env;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
          var book=  _bookRepository.GetAll();
            List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(book);
            return View(vm);
        }

        public IActionResult GetAddPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookViewModel book,IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Resim dosyasını kaydetme
                string fileName = Path.GetFileName(imageFile.FileName);
                string imagePath = Path.Combine(_env.WebRootPath, "images", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                // Resmin dosya yolunu modele ekleme
                book.ImagePath = "images/" + fileName;
            }
            _bookRepository.Add(_mapper.Map<Book>(book));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetUpdatePage(int id)
        {
           var book = _bookRepository.Get(id);
            BookViewModel vm = _mapper.Map<BookViewModel>(book);
            return View(vm);
        }
        [HttpPost]
        public IActionResult UpdateBook(BookViewModel book,IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Resim dosyasını kaydetme
                string fileName = Path.GetFileName(imageFile.FileName);
                string imagePath = Path.Combine(_env.WebRootPath, "images", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                // Resmin dosya yolunu modele ekleme
                book.ImagePath = "images/" + fileName;
            }
            _bookRepository.Update(_mapper.Map<Book>(book));
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            _bookRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
