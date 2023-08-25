using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.AspNetCore.Filters
{
    public class CacheResourceFilter : Attribute, IResourceFilter
    {
        private static IActionResult _result;
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _result = context.Result;

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
           if(_result !=null)
            {
                context.Result = _result;
            }
        }
    }
}
