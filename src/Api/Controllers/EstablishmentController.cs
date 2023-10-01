using EasyBooking.Appplication;
using EasyBooking.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/establishments/")]
[ApiVersion("1")]
public class EstablishmentController : ControllerBase
{
    private readonly ICreateEstablishment createEstablishment;
    private readonly IGetEstablishmentQuery establishmentQuery;
    private readonly IErrorBagService errorBag;

    public EstablishmentController(ICreateEstablishment createEstablishment, IGetEstablishmentQuery establishmentQuery, IErrorBagService errorBag)
    {
        this.createEstablishment = createEstablishment;
        this.establishmentQuery = establishmentQuery;
        this.errorBag = errorBag;
    }

    [HttpPost]
    [Authorize(Roles = "admin,user")]
    public async Task<IActionResult> Post([FromBody] CreateEstablishmentRequest request, CancellationToken cancellationToken) 
    {
        var result = await createEstablishment.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result?.Id }, result);
    }

    [HttpGet("{id:Guid}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) 
    {
        var result = await establishmentQuery.GetByIdAsync(id, cancellationToken);

        if(result is null)
            return NotFound();
        
        return Ok(result);
    }

    [HttpGet("")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken) 
    {
        var result = await establishmentQuery.GetAllAsync(cancellationToken);

        if(result is null)
            return NotFound();
        
        return Ok(result);
    }
}
