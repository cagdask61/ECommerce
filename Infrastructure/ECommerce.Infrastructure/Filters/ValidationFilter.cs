using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(m => m.Value.Errors.Any())
                    .ToDictionary(m => m.Key, c => c.Value.Errors
                    .Select(model => model.ErrorMessage))
                    .ToList();
                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }
    }
}
