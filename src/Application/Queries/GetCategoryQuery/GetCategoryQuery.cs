using EasyBooking.Infrastructure;

namespace EasyBooking.Appplication;

public class GetCategoryQuery : IGetCategoryQuery
{
    private readonly ICategoryRepository repository;
    public GetCategoryQuery(ICategoryRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<GetCategoryResponse>?> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var categories = await repository.GetByEstablishmentIdAsync(id, cancellationToken);
        
        if(categories is null) 
            return default;

        return categories.Select(_ => new GetCategoryResponse(_.Id, _.Name, _.Status, _.EstablishmentId));
    }

    public async Task<GetCategoryResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(id, cancellationToken);
        
        if(category is null) 
            return default;

        return new GetCategoryResponse(category.Id, category.Name, category.Status, category.EstablishmentId);
    }
}
