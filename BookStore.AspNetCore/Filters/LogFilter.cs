using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace BookStore.AspNetCore.Filters
{
    public class LogFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action metot çalıştıktan sonra");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action metot çalışmadan önce");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("Action metot sonuç üretilmeden önce");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine("Action metot sonuç üretildikten sonra");
        }
    }
}
