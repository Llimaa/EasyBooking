using EasyBooking.Appplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/categories/")]
[ApiVersion("1")]
public class CategoryController : ControllerBase
{
    private readonly ICreateCategory createCategory;
    private readonly IGetCategoryQuery getCategoryQuery;


    public CategoryController(ICreateCategory createCategory, IGetCategoryQuery getCategoryQuery)
    {
        this.createCategory = createCategory;
        this.getCategoryQuery = getCategoryQuery;
    }

    [HttpPost("")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateRole([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken) 
    {
        var result = await createCategory.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result?.Id }, result);
    }

    [HttpGet("establishments/{id:Guid}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken) 
    {
        var result = await getCategoryQuery.GetByEstablishmentIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) 
    {
        var result = await getCategoryQuery.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }
}
