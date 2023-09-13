namespace EasyBooking.Appplication;

public interface ICreateCategory 
{
    public Task<CreateCategoryResponse?> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken);
}
