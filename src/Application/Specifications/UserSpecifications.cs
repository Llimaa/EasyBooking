using FluentValidation;

namespace EasyBooking.Appplication;

public class UserSpecifications: AbstractValidator<CreateUserRequest> 
{
    public UserSpecifications()
    {
        RuleFor(_ => _.Name)
            .NotEmpty()
            .MinimumLength(6)
            .WithErrorCode("Nome inválido")
            .WithMessage("A propriedade Nome é obrigatória e deve conter no minimo 6 caracteres");

        RuleFor(_ => _.Document)
            .NotEmpty()
            .Must(ValidateDocument)
            .WithErrorCode("CPF inválido")
            .WithMessage("A propriedade Documento é obrigátoria e deve conter 11 caracteres");

        RuleFor(_ => _.Email)
            .NotEmpty()
            .EmailAddress()
            .WithErrorCode("Email inválido")
            .WithMessage("A propriedade Email é obrigatória");

        RuleFor(_ => _.Password)
            .NotEmpty()
            .WithErrorCode("Senha inválida")
            .WithMessage("A propriedade Senha é obrigátoria e deve conter no minimo 6 caracteres");
    }

        private bool ValidateDocument(string document) =>
            document.Length == 11 ? true : false;
}
