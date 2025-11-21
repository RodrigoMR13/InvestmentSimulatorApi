using Application.Telemetry;
using System.Diagnostics;

namespace WebApi.Middleware
{
    public class RequestMetricsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMetricsService _metricsService;

        public RequestMetricsMiddleware(
            RequestDelegate next,
            IMetricsService metricsService)
        {
            _next = next;
            _metricsService = metricsService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            await _next(context);
            sw.Stop();

            var rota = context.Request.Path.Value?.Trim('/').ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(rota))
            {
                _metricsService.RegistrarChamada(rota, sw.ElapsedMilliseconds);
            }
        }
    }
}
