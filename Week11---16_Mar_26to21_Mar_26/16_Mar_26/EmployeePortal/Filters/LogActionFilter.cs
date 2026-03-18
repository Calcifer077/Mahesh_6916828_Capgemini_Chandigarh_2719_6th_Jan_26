using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeePortal.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.ActionDescriptor.DisplayName;
            var time = DateTime.Now;

            Console.WriteLine($"Action: {action}");
            Console.WriteLine($"Time: {time}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Finished");
        }
    }
}