using EasyBooking.Appplication;
using EasyBooking.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/categories/")]
[ApiVersion("1")]
public class GameSpaceController : ControllerBase
{
    private readonly ICreateGameSpace createGameSpace;
    private readonly IGetGameSpaceQuery getGameSpaceQuery;


    public GameSpaceController(ICreateGameSpace createGameSpace, IGetGameSpaceQuery getGameSpaceQuery)
    {
        this.createGameSpace = createGameSpace;
        this.getGameSpaceQuery = getGameSpaceQuery;
    }

    [HttpPost("")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateRole([FromBody] CreateGameSpaceRequest request, CancellationToken cancellationToken) 
    {
        var result = await createGameSpace.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result?.Id }, result);
    }

    [HttpGet("establishments/{id:Guid}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken) 
    {
        var result = await getGameSpaceQuery.GetByEstablishmentIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) 
    {
        var result = await getGameSpaceQuery.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }
}
