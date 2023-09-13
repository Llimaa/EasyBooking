using FluentValidation;

namespace EasyBooking.Appplication;

public class EstablishmentSpecifications: AbstractValidator<CreateEstablishmentRequest> 
{
    public EstablishmentSpecifications()
    {
        RuleFor(_ => _.PhoneNumber)
            .NotEmpty()
            .WithErrorCode("Número inválido")
            .WithMessage("A propriedade PhoneNumber é obrigatória");

        RuleFor(_ => _.Name)
            .NotEmpty()
            .MinimumLength(5)
            .WithErrorCode("Nome inválido")
            .WithMessage("A propriedade Nome é obrigatória e deve conter no minimo 5 caracteres");

        RuleFor(_ => _.Description)
            .NotEmpty()
            .MinimumLength(5)
            .WithErrorCode("Descrição inválida")
            .WithMessage("A propriedade Description é obrigatória e deve conter no minimo 5 caracteres");

        RuleFor(_ => _.Neighborhood)
            .NotEmpty()
            .WithErrorCode("Bairro inválido")
            .WithMessage("A propriedade Address.Neighborhood é obrigatória");

        RuleFor(_ => _.Street)
            .NotEmpty()
            .WithErrorCode("Rua inválida")
            .WithMessage("A propriedade Address.Street é obrigatória");

        RuleFor(_ => _.Number)
            .NotEmpty()
            .WithErrorCode("Número da casa inválido")
            .WithMessage("A propriedade Address.Number é obrigatória");

        RuleFor(_ => _.Zipcode)
            .NotEmpty()
            .WithErrorCode("Cep inválido")
            .WithMessage("A propriedade Address.Zipcode é obrigatória");
    }
}