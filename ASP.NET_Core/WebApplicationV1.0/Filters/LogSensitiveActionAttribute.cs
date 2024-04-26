using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApplicationV1._0.Filters
{
    public class LogSensitiveActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine($"Sensititve Action Executed !!!!!!!!!!!!!!!!!!!"); 
        }
    }
}
