using Microsoft.AspNetCore.Mvc.Filters;

namespace NZWalksAPI.CustomActionFilter
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        override public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .ToList()
                    .ForEach(e => Console.WriteLine(e.ErrorMessage));
                context.Result = new Microsoft.AspNetCore.Mvc.BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
