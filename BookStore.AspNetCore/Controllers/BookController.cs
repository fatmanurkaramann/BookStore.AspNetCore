using BookStore.AspNetCore.Models;
using BookStore.AspNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IWebHostEnvironment _env;
        public BookController(IBookRepository bookRepository, IWebHostEnvironment env)
        {
            _bookRepository = bookRepository;
            _env = env;
        }
        [HttpGet]
        public IActionResult Index()
        {
          List<Book> vm=  _bookRepository.GetAll();
            return View(vm);
        }

        public IActionResult GetAddPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book,IFormFile imageFile)
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
            _bookRepository.Add(book);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetUpdatePage(int id)
        {
           var book = _bookRepository.Get(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult UpdateBook(Book book,IFormFile imageFile)
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
            _bookRepository.Update(book);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            _bookRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
