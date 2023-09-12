using FluentValidation;

namespace EasyBooking.Domain;

public class User: BaseEntity
{
    public bool Active { get; private set; } 
    public string Name { get; private set; } = null!;
    public string Document { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public List<UserRole> Roles { get; private set; } = null!;

        private void Specify(IValidator<User> specifications)
    {
        var (errors, valid) = specifications.Validate(this);

        Errors = errors.AsDefaultFormat();
        Valid = valid;
    }

    public static User Raise(string name, string document, string email, string hashPassword, IValidator<User> specifications)
    {
        var instance = new User()
        {
            Active = true,
            Name = name,
            Document = document,
            Email = email,
            Password = hashPassword,
        };

        instance.Specify(specifications);
        return instance;
    }
}
