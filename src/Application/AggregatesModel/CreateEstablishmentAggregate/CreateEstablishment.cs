using EasyBooking.Domain;
using EasyBooking.Infrastructure;
using FluentValidation;

namespace EasyBooking.Appplication;

public class CreateEstablishment : ICreateEstablishment
{
    private readonly IEstablishmentRepository establishmentRepository;
    private readonly IValidator<Establishment> validator;
    private readonly IErrorBagService errorBagService;

    public CreateEstablishment(IValidator<Establishment> validator, IErrorBagService errorBagService, IEstablishmentRepository establishmentRepository)
    {
        this.validator = validator;
        this.errorBagService = errorBagService;
        this.establishmentRepository = establishmentRepository;
    }

    public async Task<CreateEstablishmentResponse?> CreateAsync(CreateEstablishmentRequest request, CancellationToken cancellationToken)
    {
        var address = new Address(request.Neighborhood, request.Street, request.Number, request.Zipcode);

        var establishment = Establishment.Raise(request.PhoneNumber, request.Name, request.Description, address, validator);

        if(!establishment.Valid) 
        {
            errorBagService.HandlerError(establishment.Errors);
            return default;
        }

        var exist = await establishmentRepository.ExistThisEstablishmentAsync(request.Name, cancellationToken);

        if(exist) 
        {
            errorBagService.HandlerError("Establishment Exist", "Existe um estabelecimento com esse nome.");
            return default;
        }

        await establishmentRepository.CreateAsync(establishment, cancellationToken);
        var response = new CreateEstablishmentResponse(establishment.Id);
        return response;
    }

    
}
