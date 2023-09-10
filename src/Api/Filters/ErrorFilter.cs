using EasyBooking.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public  class ErrorFilter : IActionFilter
{
    private readonly IErrorBagService errorBag;

    public ErrorFilter(IErrorBagService errorBag)
    {
        this.errorBag = errorBag;
    }

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if(errorBag is not null && errorBag.HasError()) 
        {
            context.Result = new ObjectResult(new BadRequestResponse(errorBag.Raise())) 
            {
                StatusCode = 400
            };

            context.ExceptionHandled = true;
        }else if(context.Exception is Exception) {
            context.Result = new ObjectResult(new ErrorResponse("Internal Server Error")) 
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}

public class BadRequestResponse : Dictionary<string, string>
{
    public BadRequestResponse(Dictionary<string,string> validationResult)
    {
        foreach (var (key, value) in validationResult)
            TryAdd(key, value);
    }
}

public class ErrorResponse
{
    public ErrorResponse(string error) => Message = error;
    public string Message { get; }
}