namespace CustomMiddleWareApis.Middleware
{
    public static class RequestLoggingMiddlewareExtention
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }
        
    }
}
