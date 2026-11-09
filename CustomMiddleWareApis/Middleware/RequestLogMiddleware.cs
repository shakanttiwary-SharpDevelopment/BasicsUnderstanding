namespace CustomMiddleWareApis.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var method = request.Method;
            var path = request.Path;
            var queryString = request.QueryString;
            var startTime = DateTime.UtcNow;

            Console.WriteLine($"Request : {method} {path} {queryString}");
            await _next(context);

            var duration = DateTime.UtcNow - startTime;
            Console.WriteLine($"Request : {path} | completed in : {duration.TotalMilliseconds} ms");
        }
    }
}
