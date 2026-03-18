using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ProductManagement.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            Console.WriteLine($"Action Executing: {actionName}");
            Console.WriteLine($"Timestamp: {DateTime.Now}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Executed Successfully");
        }
    }
}