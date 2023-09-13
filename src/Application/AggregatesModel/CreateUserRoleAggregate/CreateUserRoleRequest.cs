using FluentValidation;

namespace EasyBooking.Appplication;

public record CreateUserRoleRequest 
{
    public CreateUserRoleRequest(string value, Guid userId)
    {
        Value = value;
        UserId = userId;
    }

    public string Value { get; set; } = null!;
    public Guid UserId { get; set; }

    public (Dictionary<string, string>, bool) Validate(IValidator<CreateUserRoleRequest> specification) 
    {
        var (errors, valid) = specification.Validate(this);
        return(errors.AsDefaultFormat(), valid);
    }
}
