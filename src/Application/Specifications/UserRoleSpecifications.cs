using FluentValidation;

namespace EasyBooking.Appplication;

public class UserRoleSpecifications: AbstractValidator<CreateUserRoleRequest>
{
    public UserRoleSpecifications()
    {
        RuleFor(_ => _.Value)
            .NotEmpty()
            .MinimumLength(4)
            .WithErrorCode("Value inválido")
            .WithMessage("propriedade Value é obrigátoria e deve conter no minimo 4 caracteres");

        RuleFor(_ => _.UserId)
            .NotEmpty()
            .Must(ValidateGuid)
            .WithErrorCode("UserId inválido")
            .WithMessage("propriedade UserId é obrigátoria e deve ser um guid valido");
    }
    private bool ValidateGuid(Guid id) =>
        Guid.TryParse(id.ToString(), out _);
}