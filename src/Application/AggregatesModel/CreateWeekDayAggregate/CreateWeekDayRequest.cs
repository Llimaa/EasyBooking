using FluentValidation;

namespace EasyBooking.Appplication;

public record CreateWeekDayRequest
{
    public DateOnly Day { get; set; }
    public Guid CategoryId { get; set; }

    public (Dictionary<string, string> errors, bool valid) Validate(IValidator<CreateWeekDayRequest> specification) 
    {
        var (errors, valid) = specification.Validate(this);
        return (errors.AsDefaultFormat(), valid);
    }
}
