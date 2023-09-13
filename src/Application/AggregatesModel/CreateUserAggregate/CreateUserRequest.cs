using FluentValidation;

namespace EasyBooking.Appplication;

public record CreateUserRequest 
{
    public string Name {get; set; } = null!;
    public string Document {get; set; } = null!;
    public string Email {get; set; } = null!;
    public string Password {get; set; } = null!;

    public (Dictionary<string, string>, bool) Validate(IValidator<CreateUserRequest> specification) 
    {
        var (errors, valid) = specification.Validate(this);
        return(errors.AsDefaultFormat(), valid);
    }
}