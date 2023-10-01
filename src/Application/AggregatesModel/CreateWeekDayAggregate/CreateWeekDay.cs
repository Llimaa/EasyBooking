using EasyBooking.Domain;
using EasyBooking.Infrastructure;
using FluentValidation;

namespace EasyBooking.Appplication;

public class CreateWeekDay : ICreateWeekDay
{
    private readonly IWeekDayRepository repository;
    private readonly IValidator<CreateWeekDayRequest> validator;
    private readonly IErrorBagService errorBagService;

    public CreateWeekDay(IWeekDayRepository repository, IValidator<CreateWeekDayRequest> validator, IErrorBagService errorBagService)
    {
        this.repository = repository;
        this.validator = validator;
        this.errorBagService = errorBagService;
    }

    public async Task<CreateWeekDayResponse?> CreateAsync(CreateWeekDayRequest request, CancellationToken cancellationToken)
    {
        var (errors, valid) = request.Validate(validator);

        if(!valid){
            errorBagService.HandlerError(errors);
            return default;
        }

        var exist = await repository.ExistThisWeekDayAsync(request.Day, cancellationToken);

        if(exist) 
        {
            errorBagService.HandlerError("Dia já Existe", "Essa dia já foi registrado para essa categoria");
            return default;
        }

        var weekDay = WeekDay.Raise(request.Day, request.CategoryId);
        
        await repository.CreateAsync(weekDay, cancellationToken);
        
        var response = new CreateWeekDayResponse(weekDay.Id);
        return response;
    }
}
