using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var endpoint = context.HttpContext.GetEndpoint()?.DisplayName;
            _logger.LogInformation($"Requisição recebida para o Endpoint: {endpoint}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var endpoint = context.HttpContext.GetEndpoint()?.DisplayName;
            _logger.LogInformation($"Resposta enviada para o Endpoint: {endpoint}");
        }
    }
}
