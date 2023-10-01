using FluentValidation;

namespace EasyBooking.Appplication;

public class CategorySpecifications: AbstractValidator<CreateGameSpaceRequest>
{
    public CategorySpecifications()
    {
        RuleFor(_ => _.Name)
            .NotEmpty()
            .WithErrorCode("Nome inválido")
            .WithMessage("propriedade Name é obrigátoria");

        RuleFor(_ => _.EstablishmentId)
            .NotEmpty()
            .Must(ValidateGuid)
            .WithErrorCode("EstablishmentId inválido")
            .WithMessage("propriedade EstablishmentId é obrigátoria e deve ser um guid valido");
    }
    private bool ValidateGuid(Guid id) =>
        Guid.TryParse(id.ToString(), out _);
}