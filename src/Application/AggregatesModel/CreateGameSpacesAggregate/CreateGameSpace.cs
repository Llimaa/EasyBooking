using EasyBooking.Domain;
using EasyBooking.Infrastructure;
using FluentValidation;

namespace EasyBooking.Appplication;

public class CreateGameSpace : ICreateGameSpace
{
    private readonly IGameSpaceRepository repository;
    private readonly IValidator<CreateGameSpaceRequest> validator;
    private readonly IErrorBagService errorBagService;

    public CreateGameSpace(IGameSpaceRepository repository, IValidator<CreateGameSpaceRequest> validator, IErrorBagService errorBagService)
    {
        this.repository = repository;
        this.validator = validator;
        this.errorBagService = errorBagService;
    }

    public async Task<CreateGameSpaceResponse?> CreateAsync(CreateGameSpaceRequest request, CancellationToken cancellationToken)
    {
        var (errors, valid) = request.Validate(validator);

        if(!valid){
            errorBagService.HandlerError(errors);
            return default;
        }

        var exist = await repository.ExistThisGameSpaceAsync(request.Name, cancellationToken);

        if(exist) 
        {
            errorBagService.HandlerError("Categoria Existe", "Essa Categoria já existe");
            return default;
        }

        var gameSpace = GameSpace.Raise(request.Name, request.EstablishmentId);
        
        await repository.CreateAsync(gameSpace, cancellationToken);
        
        var response = new CreateGameSpaceResponse(gameSpace.Id);
        return response;
    }
}
