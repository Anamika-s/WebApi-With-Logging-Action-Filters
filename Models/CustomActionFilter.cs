using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi__Demo.Models
{
    public class CustomActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Trace.WriteLine(string.Format("Action Method executed at {0}",  DateTime.Now.ToShortDateString()), "Web API Logs");

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Trace.WriteLine(string.Format("Action Method executing at {0}", context.ActionDescriptor, DateTime.Now.ToShortDateString()), "Web API Logs");

        }
    }
}
