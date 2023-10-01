using EasyBooking.Appplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/weekdays/")]
[ApiVersion("1")]
public class WeekDayController : ControllerBase
{
    private readonly ICreateWeekDay createWeekDay;
    private readonly IFinishWeekDay finishWeekDay;
    private readonly ICancellWeekDay cancellWeekDay;
    private readonly IGetWeekDayQuery getWeekDayQuery;


    public WeekDayController(ICreateWeekDay createWeekDay, IFinishWeekDay finishWeekDay, ICancellWeekDay cancellWeekDay, IGetWeekDayQuery getWeekDayQuery)
    {
        this.createWeekDay = createWeekDay;
        this.finishWeekDay = finishWeekDay;
        this.cancellWeekDay = cancellWeekDay;
        this.getWeekDayQuery = getWeekDayQuery;
    }

    [HttpPost("")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateWeekDay([FromBody] CreateWeekDayRequest request, CancellationToken cancellationToken) 
    {
        var result = await createWeekDay.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result?.Id }, result);
    }

    [HttpPatch("finish/{id:Guid}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateWeekDay(Guid id, CancellationToken cancellationToken) 
    {
        await finishWeekDay.FinishAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPatch("cancell/{id:Guid}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CancellWeekDay(Guid id, CancellationToken cancellationToken) 
    {
        await cancellWeekDay.CancellAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("categories/{id:Guid}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) 
    {
        var result = await getWeekDayQuery.GetByCategoryIdIdAsync(id, cancellationToken);
        return Ok(result);
    }
}
