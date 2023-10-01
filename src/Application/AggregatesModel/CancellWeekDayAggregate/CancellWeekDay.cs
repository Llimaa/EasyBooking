using EasyBooking.Domain;
using EasyBooking.Infrastructure;
using FluentValidation;

namespace EasyBooking.Appplication;

public class CancellWeekDay : ICancellWeekDay
{
    private readonly IWeekDayRepository repository;
    private readonly IValidator<Guid> validator;
    private readonly IErrorBagService errorBagService;

    public CancellWeekDay(IWeekDayRepository repository, IValidator<Guid> validator, IErrorBagService errorBagService)
    {
        this.repository = repository;
        this.validator = validator;
        this.errorBagService = errorBagService;
    }

    public async Task CancellAsync(Guid id, CancellationToken cancellationToken) 
    {
                var (errors, valid) = validator.Validate(id);

        if(!valid){
            errorBagService.HandlerError(errors.AsDefaultFormat());
        }else {
            await repository.ChangeStatusAsync(id, WeekDayStatus.Cancelled, cancellationToken);
        }
    }
}
