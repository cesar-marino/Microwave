using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microwave.Domain.Exceptions;

namespace Microwave.Presentation.API.Filters
{
    public class ApiGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var details = new ProblemDetails();
            var exception = context.Exception;

            if (exception is ActionNotPermittedException actionNotPermitted)
            {
                details.Title = actionNotPermitted?.Code;
                details.Status = StatusCodes.Status400BadRequest;
                details.Type = actionNotPermitted?.GetType().ToString();
                details.Detail = actionNotPermitted?.Message;
            }
            else if (exception is EntityValidationException entityValidation)
            {
                details.Title = entityValidation?.Code;
                details.Status = StatusCodes.Status422UnprocessableEntity;
                details.Type = entityValidation?.GetType().ToString();
                details.Detail = entityValidation?.Message;
            }
            else if (exception is InvalidPasswordException invalidPassword)
            {
                details.Title = invalidPassword?.Code;
                details.Status = StatusCodes.Status400BadRequest;
                details.Type = invalidPassword?.GetType().ToString();
                details.Detail = invalidPassword?.Message;
            }
            else if (exception is NotFoundException notFound)
            {
                details.Title = notFound?.Code;
                details.Status = StatusCodes.Status404NotFound;
                details.Type = notFound?.GetType().ToString();
                details.Detail = notFound?.Message;
            }
            else if (exception is UsernameInUseException usernameInUse)
            {
                details.Title = usernameInUse?.Code;
                details.Status = StatusCodes.Status400BadRequest;
                details.Type = usernameInUse?.GetType().ToString();
                details.Detail = usernameInUse?.Message;
            }
            else
            {
                details.Title = "unexpected";
                details.Status = StatusCodes.Status500InternalServerError;
                details.Type = "UnexpectedException";
                details.Detail = exception.Message;
                details.Instance = exception.Source;
            }

            context.HttpContext.Response.StatusCode = (int)details.Status!;
            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
