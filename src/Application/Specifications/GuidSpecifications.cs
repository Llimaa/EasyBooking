using FluentValidation;

namespace EasyBooking.Appplication;

public class GuidSpecifications: AbstractValidator<Guid>
{
    public GuidSpecifications()
    {
        RuleFor(_ => _)
            .NotEmpty()
            .Must(ValidateGuid)
            .WithErrorCode("Id inválido")
            .WithMessage("Deve ser um guid valido");
    }
    private bool ValidateGuid(Guid id) =>
        Guid.TryParse(id.ToString(), out _);
}