using FluentValidation.Results;

namespace EasyBooking.Domain;

public static class ValidationFailureExtensions 
{
    public static void Deconstruct(this ValidationFailure result, out string key, out string value) => 
    (key, value) = (result.ErrorCode, result.ErrorMessage);
}
