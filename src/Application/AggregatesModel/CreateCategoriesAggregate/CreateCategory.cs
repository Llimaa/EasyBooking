using EasyBooking.Domain;
using EasyBooking.Infrastructure;
using FluentValidation;

namespace EasyBooking.Appplication;

public class CreateCategory : ICreateCategory
{
    private readonly ICategoryRepository repository;
    private readonly IValidator<CreateCategoryRequest> validator;
    private readonly IErrorBagService errorBagService;

    public CreateCategory(ICategoryRepository repository, IValidator<CreateCategoryRequest> validator, IErrorBagService errorBagService)
    {
        this.repository = repository;
        this.validator = validator;
        this.errorBagService = errorBagService;
    }

    public async Task<CreateCategoryResponse?> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var (errors, valid) = request.Validate(validator);

        if(!valid){
            errorBagService.HandlerError(errors);
            return default;
        }

        var exist = await repository.ExistThisCategoryAsync(request.Name, cancellationToken);

        if(exist) 
        {
            errorBagService.HandlerError("Categoria Existe", "Essa Categoria já existe");
            return default;
        }

        var category = Category.Raise(request.Name, request.EstablishmentId);
        
        await repository.CreateAsync(category, cancellationToken);
        
        var response = new CreateCategoryResponse(category.Id);
        return response;
    }
}
