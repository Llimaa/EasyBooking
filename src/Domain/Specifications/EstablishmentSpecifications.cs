using System.Data;
using EasyBooking.Domain;
using FluentValidation;

namespace EasyBooking.Appplication;

public class EstablishmentSpecifications: AbstractValidator<Establishment> 
{
    public EstablishmentSpecifications()
    {
        RuleFor(_ => _.PhoneNumber)
            .NotEmpty()
            .WithErrorCode("Número inválido")
            .WithMessage("A propriedade PhoneNumber é obrigatória");

        // RuleFor(_ => _.Status)
        //     .NotEmpty()
        //     .WithErrorCode("Status inválido")
        //     .WithMessage("A propriedade Status é obrigatória");

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

        RuleFor(_ => _.Address.Neighborhood)
            .NotEmpty()
            .WithErrorCode("Bairro inválido")
            .WithMessage("A propriedade Address.Neighborhood é obrigatória");

        RuleFor(_ => _.Address.Street)
            .NotEmpty()
            .WithErrorCode("Rua inválida")
            .WithMessage("A propriedade Address.Street é obrigatória");

        RuleFor(_ => _.Address.Number)
            .NotEmpty()
            .WithErrorCode("Número da casa inválido")
            .WithMessage("A propriedade Address.Number é obrigatória");

        RuleFor(_ => _.Address.Zipcode)
            .NotEmpty()
            .WithErrorCode("Cep inválido")
            .WithMessage("A propriedade Address.Zipcode é obrigatória");
    }
}