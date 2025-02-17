using System.Diagnostics;

namespace CarFactory.Middleware
{
    public class RequestMetricMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMetricMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();

            Console.WriteLine("Time elapsed: {0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
