using FluentValidation.Results;

namespace EasyBooking.Appplication;

public static class ValidationResultExtensions 
{
    public static void Deconstruct(this ValidationResult result, out IList<ValidationFailure> errors, out bool isValid) 
    {
        errors = result.Errors;
        isValid = result.IsValid;
    }

    public static Dictionary<string, string> AsDefaultFormat(this IList<ValidationFailure> result) 
    {
        var defaultFormat = new Dictionary<string, string>();

        foreach(var(code, message) in result) 
            defaultFormat.TryAdd(code, message);
            
        return defaultFormat;
    }
}