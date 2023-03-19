using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjetoApi1.Filters
{
    public class ApilogginFilter : IActionFilter
    {
        private readonly ILogger<ApilogginFilter> _logger;
        public ApilogginFilter(ILogger<ApilogginFilter> logger)
        {
            _logger= logger;
        }
        //executa antes da Action
        public void OnActionExecuted(ActionExecutedContext context)
        {

            _logger.LogInformation("### Executando -> OnActionExecuting");
            _logger.LogInformation("##################################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
            _logger.LogInformation("##################################################");
        }
        //executa depois da Action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("### Executando -> OnActionExecuted");
            _logger.LogInformation("##################################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation("##################################################");
        }
    }
}
