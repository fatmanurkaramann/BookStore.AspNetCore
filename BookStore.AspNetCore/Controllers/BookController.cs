using AutoMapper;
using BookStore.AspNetCore.Models;
using BookStore.AspNetCore.Repositories;
using BookStore.AspNetCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
          var book=  _bookRepository.GetAll();
            List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(book);
            return View(vm);
        }
        [Authorize]
        public IActionResult GetAddPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookViewModel book,IFormFile imageFile)
        {
            //Model state: Mvcde bir typeın required,..vs kontrol edip geriye sonuç döndüren property
            if (ModelState.IsValid)
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
                TempData["Added"] = "Ürün Başarıyla eklendi";
                return RedirectToAction("Index");
            }
            return View("GetAddPage");
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetUpdatePage(int id)
        {
           var book = _bookRepository.Get(id);

            BookViewModel vm = _mapper.Map<BookViewModel>(book);
            return View(vm);
        }
        [HttpPost]
        public IActionResult UpdateBook(BookViewModel book,IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Resim dosyasını kaydetme

                    //Yüklenen Resim dosyasının adını alma
                    string fileName = Path.GetFileName(imageFile.FileName);


                    //_env, ASP.NET Core uygulamalarında IWebHostEnvironment tipini temsil eden bir servistir.
                    //_env.WebRootPath kullanarak, statik içeriğin (örneğin resimler) depolandığı dizinin
                    //fiziksel yolunu alabilirsiniz. Bu, kullanıcıların tarayıcıda görüntüleyebileceği
                    //ve erişebileceği statik dosyaların nerede depolandığını belirlemek için kullanılır.
                    //Resim dosyasının kaydedileceği yolun oluşturulması
                    string imagePath = Path.Combine(_env.WebRootPath, "images", fileName);

                    //Gerektiğinde klasörlerin oluşturulması
                    Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
                    // Resim dosyasını akışa kopyalama
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        //, resim veya dosya gibi içerikleri diskte saklamak
                        //için CopyTo veya benzeri işlemler kullanılması önemlidir.
                        imageFile.CopyTo(stream);
                    }

                    // Resmin dosya yolunu modele ekleme
                    book.ImagePath = "images/" + fileName;
                }
                _bookRepository.Update(_mapper.Map<Book>(book));
                return RedirectToAction("Index");
            }
            else
            {

                return View("GetUpdatePage");

            }
        }

        public IActionResult Remove(int id)
        {
            _bookRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
