using EasyBooking.Infrastructure;

namespace EasyBooking.Appplication;

public class GetWeekDayQuery : IGetWeekDayQuery
{
    private readonly IWeekDayRepository repository;
    public GetWeekDayQuery(IWeekDayRepository repository)
    {
        this.repository = repository;
    }


    public async Task<IEnumerable<GetWeekDayResponse>?> GetByCategoryIdIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await repository.GetByGameSpaceIdAsync(id, cancellationToken);

        if(result is null)
            return default;

        return result.Select(_ => new GetWeekDayResponse(_.Id, _.Day, _.Status));
    }
}
