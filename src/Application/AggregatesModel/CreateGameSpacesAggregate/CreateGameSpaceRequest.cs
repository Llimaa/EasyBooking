using FluentValidation;

namespace EasyBooking.Appplication;

public record CreateGameSpaceRequest
{
    public string Name { get; set; } = null!;
    public Guid EstablishmentId { get; set; }

    public (Dictionary<string, string> errors, bool valid) Validate(IValidator<CreateGameSpaceRequest> specification) 
    {
        var (errors, valid) = specification.Validate(this);
        return (errors.AsDefaultFormat(), valid);
    }
}
