using EasyBooking.Domain;
using EasyBooking.Infrastructure;
using FluentValidation;

namespace EasyBooking.Appplication;

public class CreateEstablishment : ICreateEstablishment
{
    private readonly IEstablishmentRepository establishmentRepository;
    private readonly IValidator<CreateEstablishmentRequest> validator;
    private readonly IErrorBagService errorBagService;

    public CreateEstablishment(IValidator<CreateEstablishmentRequest> validator, IErrorBagService errorBagService, IEstablishmentRepository establishmentRepository)
    {
        this.validator = validator;
        this.errorBagService = errorBagService;
        this.establishmentRepository = establishmentRepository;
    }

    public async Task<CreateEstablishmentResponse?> CreateAsync(CreateEstablishmentRequest request, CancellationToken cancellationToken)
    {
        var (errors, valid) = request.Validate(validator);

        if(!valid){
            errorBagService.HandlerError(errors);
            return default;
        }

        var address = new Address(request.Neighborhood, request.Street, request.Number, request.Zipcode);
        var establishment = Establishment.Raise(request.PhoneNumber, request.Name, request.Description, address);

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
