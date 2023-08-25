using BookStore.AspNetCore.ViewModels;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.AspNetCore.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly BookAppDbContext _context;

        public NotFoundFilter(BookAppDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idValue = context.ActionArguments.Values.First();

            var id = (int)idValue;

            var hasProduct = _context.Books.Any(x => x.Id == id);
            if(hasProduct==false)
            {
                context.Result = new RedirectToActionResult("Error", "Home",new ErrorViewModel()
                { Errors = new List<string>()
                {
                    $"Id ({id})ye sahip ürün bulunamadı."
                }
                });
            }
        }
    }
}
