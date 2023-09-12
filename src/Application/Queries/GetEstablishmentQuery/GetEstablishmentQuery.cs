using EasyBooking.Infrastructure;

namespace EasyBooking.Appplication;

public class GetEstablishmentQuery : IGetEstablishmentQuery
{
    private readonly IEstablishmentRepository repository;

    public GetEstablishmentQuery(IEstablishmentRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetEstablishmentResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var establishment = await repository.GetByIdAsync(id, cancellationToken);
        
        if(establishment is null) 
            return null;
        
        return new GetEstablishmentResponse(establishment.Id, establishment.Name,establishment.Description,establishment.PhoneNumber, establishment.Status, establishment.Address);
    }
}