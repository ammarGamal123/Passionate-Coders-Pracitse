using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace WebApplicationV1._0.Filters
{
    public class LogActivityFilter : IAsyncActionFilter
    {
        private readonly ILogger<LogActivityFilter> logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            this.logger = logger;
        }
/*        public void OnActionExecuting(ActionExecutingContext context)
        {

            logger.LogInformation($"Executing action {context.ActionDescriptor.DisplayName}" +
                $"  on controller {context.Controller} " +
                $"With Arguments {JsonSerializer.Serialize(context.ActionArguments)}");

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

            logger.LogInformation($"Action {context.ActionDescriptor.DisplayName}" +
                $"Finished Execution on Controller {context.Controller}");
        }
*/
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                           ActionExecutionDelegate next)
        {
             logger.LogInformation($"(Async) Executing action {context.ActionDescriptor.DisplayName}" +
                $"  on controller {context.Controller} " +
                $"With Arguments {JsonSerializer.Serialize(context.ActionArguments)}");


            logger.LogInformation($"(Async) Action {context.ActionDescriptor.DisplayName}" +
                $"Finished Execution on Controller {context.Controller}");


        }
    }
}
