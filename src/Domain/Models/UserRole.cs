using FluentValidation;

namespace EasyBooking.Domain;

public class UserRole : BaseEntity
{
    public string Value { get; private set; } = null!;
    public Guid UserId { get; private set; }

    private void Specify(IValidator<UserRole> specifications) 
    {
        var (errors, valid) = specifications.Validate(this);

        Errors = errors.AsDefaultFormat();
        Valid = valid;
    }

    public static UserRole Raise (string value, Guid userId, IValidator<UserRole> validator) 
    {
        var instance = new UserRole() 
        {
            Value = value,
            UserId = userId
        };
        instance.Specify(validator);
        return instance;
    }
}
