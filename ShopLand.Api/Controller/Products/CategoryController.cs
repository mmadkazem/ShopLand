namespace ShopLand.Api.Controller.Products;



[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController(ICategoryFacade categoryFacade)
    : ControllerBase
{
    private readonly ICategoryFacade _categoryFacade = categoryFacade;

    [HttpPost]
    [Authorize(CustomRoles.Admin)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post(CreateCategoryCommandRequest request,
        CancellationToken token = default)
    {
        var id = await _categoryFacade.CreateCategory.HandelAsync(request, token);
        var url = Url.Action(nameof(Get), "Product", new { Id = id }, Request.Scheme);
        return Created(url, true);
    }

    [HttpPut("{Id:guid}")]
    [Authorize(CustomRoles.Admin)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(Guid id, string name,
        CancellationToken token = default)
    {
        await _categoryFacade.UpdateCategory.HandelAsync(new(id, name), token);
        return Ok();
    }

    [HttpGet("{Id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token = default)
    {
        var result = await _categoryFacade.GetCategory.HandelAsync(new(id), token);
        return Ok(result);
    }

    [HttpGet("Page/{Page:int}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<IEnumerable<GetCategoryQueryResponse>>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(int Page,
        CancellationToken token = default)
    {
        var result = await _categoryFacade.GetAllCategory.HandelAsync(new(Page), token);
        return Ok(result);
    }

    [HttpDelete("{Id:guid}")]
    [Authorize(CustomRoles.Admin)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<GetCategoryQueryResponse>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token = default)
    {
        await _categoryFacade.RemoveCategory.HandelAsync(new(id), token);
        return Ok();
    }
}
