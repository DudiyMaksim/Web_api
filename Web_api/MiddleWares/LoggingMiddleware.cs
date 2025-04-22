using static System.Net.Mime.MediaTypeNames;

namespace Web_api.MiddleWares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var url = context.Request.Path;
            var method = context.Request.Method;
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            _logger.LogInformation($"Request: {method} {url} at {timestamp}");

            await _next(context);
        }
    }
}
