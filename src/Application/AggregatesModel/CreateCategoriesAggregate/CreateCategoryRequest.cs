using FluentValidation;

namespace EasyBooking.Appplication;

public record CreateCategoryRequest
{
    public string Name { get; set; } = null!;
    public Guid EstablishmentId { get; set; }

    public (Dictionary<string, string> errors, bool valid) Validate(IValidator<CreateCategoryRequest> specification) 
    {
        var (errors, valid) = specification.Validate(this);
        return (errors.AsDefaultFormat(), valid);
    }
}
