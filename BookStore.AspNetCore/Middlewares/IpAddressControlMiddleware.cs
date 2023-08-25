using System.Net;

namespace BookStore.AspNetCore.Middlewares
{
    public class IpAddressControlMiddleware
    {
        //middleware olabilmesi için 1.ctorunda mutlaka delegate olmalı 2. invoke async
        private readonly RequestDelegate _requestDelegate;
        private const string IpAddress = "::1";
        public IpAddressControlMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var requestIpAddress = httpContext.Connection.RemoteIpAddress;

            bool anyIpAddress = IPAddress.Parse(IpAddress).Equals(requestIpAddress);

            if(anyIpAddress)
            {
                await _requestDelegate(httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();
                await httpContext.Response.WriteAsync("forbidden");
            }
        }
    }
}
