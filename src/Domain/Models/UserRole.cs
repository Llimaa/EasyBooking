using FluentValidation;

namespace EasyBooking.Domain;

public class UserRole : BaseEntity
{
    private UserRole() { }
    private readonly IValidator<UserRole> specifications = null!;

    public UserRole(IValidator<UserRole> specifications)
    {
        this.specifications = specifications;
    }

    public string Value { get; private set; } = null!;
    public Guid UserId { get; private set; }

    private void Specify() 
    {
        var (errors, valid) = specifications.Validate(this);

        Errors = errors.AsDefaultFormat();
        Valid = valid;
    }

    public static UserRole Raise (string value, Guid userId, IValidator<UserRole> validator) 
    {
        var instance = new UserRole(validator) 
        {
            Value = value,
            UserId = userId
        };
        instance.Specify();
        return instance;
    }
}
