using System.Diagnostics;

namespace WebApplicationV1._0.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate next;
        private static byte requests = 0;
        private static DateTime lastRequestDate = DateTime.Now;

        public RateLimitingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            ++requests;
            if (DateTime.Now.Subtract(lastRequestDate).Seconds > 10)
            {
                requests = 1;
                lastRequestDate = DateTime.Now;
                await next(context);
            }
            else
            {
                if (requests > 5)
                {
                    lastRequestDate = DateTime.Now;
                    await context.Response.WriteAsync("Rate Limit Exceeded");
                }
                else
                {
                    lastRequestDate = DateTime.Now;
                    await next(context);
                }
            }

        }
    }
}
