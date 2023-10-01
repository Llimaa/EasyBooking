using FluentValidation;

namespace EasyBooking.Appplication;

public class WeekDaySpecifications: AbstractValidator<CreateWeekDayRequest>
{
    public WeekDaySpecifications()
    {
        RuleFor(_ => _.Day)
            .NotEmpty()
            .GreaterThan(DateOnly.FromDateTime(DateTime.Now).AddDays(-1))
            .WithErrorCode("Dia inválido")
            .WithMessage("Data inválida, a data deve ser igual ou maior que o dia de hoje");

        RuleFor(_ => _.CategoryId)
            .NotEmpty()
            .Must(ValidateGuid)
            .WithErrorCode("CategoryId inválido")
            .WithMessage("propriedade CategoryId é obrigátoria e deve ser um guid valido");
    }
    private bool ValidateGuid(Guid id) =>
        Guid.TryParse(id.ToString(), out _);
}