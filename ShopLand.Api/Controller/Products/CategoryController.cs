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
    public async Task<IActionResult> Post
        ([FromBody] CreateCategoryCommandRequest request)
    {
        var result = await _categoryFacade.CreateCategory.HandelAsync(request);
        var url = Url.Action(nameof(Get), "Product", new { Id = result }, Request.Scheme);
        return Created(url, true);
    }

    [HttpPut("{Id:guid}")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> Put
        ([FromBody] UpdateCategoryCommandRequest request)
    {
        await _categoryFacade.UpdateCategory.HandelAsync(request);
        return Ok();
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get
        ([FromHeader] GetCategoryQueryRequest request)
    {
        var result = await _categoryFacade.GetCategory.HandelAsync(request);
        return Ok(result);
    }

    [HttpGet("{Page}")]
    public async Task<IActionResult> Get
        ([FromHeader] PageNumberRequest request)
    {
        var result = await _categoryFacade.GetAllCategory.HandelAsync(request);
        return Ok(result);
    }

    [HttpDelete("{Id:guid}")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> Remove
        ([FromBody] RemoveCategoryCommandRequest request)
    {
        await _categoryFacade.RemoveCategory.HandelAsync(request);
        return Ok();
    }
}
