using AutoMapper;
using Business.DTOs;
using DataAccess.Concrete;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCore.Controllers
{
    public class VisitorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly BookAppDbContext _dbContext;
        public VisitorController(IMapper mapper, BookAppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult VisitorCommendList()
        {
            var visitors = _dbContext.Users.ToList();
            return Json(visitors);
        }
        [HttpPost]
        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)
        {
            var appUser = _dbContext.Users.SingleOrDefault(x => x.NameSurname == visitorViewModel.NameSurname);
            if (appUser == null)
            {
                 appUser = _mapper.Map<AppUser>(visitorViewModel);
                appUser.Comments = visitorViewModel.Comment;
                _dbContext.Add(appUser);
                _dbContext.SaveChanges();
            }
            else
            {
                appUser.Comments = visitorViewModel.Comment;
            }
            _dbContext.SaveChanges();

            return Json(new { IsSuccess="true" });
        }
    }
}
