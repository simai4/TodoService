using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Todo.Business;

namespace Todo.Api.Infrastructure
{
    public class NotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType().IsAssignableFrom(typeof(NotFoundException)))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
