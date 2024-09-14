namespace ShopLand.Api.Controller.Products;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController(IProductFacade productFacade)
    : ControllerBase
{
    private readonly IProductFacade _productFacade = productFacade;

    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Authorize(CustomRoles.Admin)]
    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommandRequest request,
        CancellationToken token = default)
    {
        var result = await _productFacade.CreateProduct.HandelAsync(request, token);
        var url = Url.Action(nameof(Get), "Products", new { Id = result }, Request.Scheme);
        return Created(url, true);
    }

    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [HttpPut("{ProductId:guid}")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> Put(Guid productId, UpdateProductDTO model,
        CancellationToken token = default)
    {
        var request = UpdateProductCommandRequest.Create(productId, model);
        await _productFacade.UpdateProduct.HandelAsync(request, token);
        return Ok();
    }

    [ProducesResponseType<IEnumerable<GetAllProductQueryResponse>>((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [HttpGet("Page/{Page:int}")]
    [AllowAnonymous]

    public async Task<IActionResult> Get(int page,
        CancellationToken token = default)
    {
        var responses = await _productFacade.GetAllProduct.HandelAsync(new(page), token);
        return Ok(responses);
    }

    [ProducesResponseType<GetProductQueryResponse>((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [HttpGet("{Id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token = default)
    {
        var products = await _productFacade.GetProduct.HandelAsync(new(id), token);
        return Ok(products);
    }

    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Authorize(CustomRoles.Admin)]
    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> Remove(Guid id,
        CancellationToken token = default)
    {
        await _productFacade.RemoveProduct.HandelAsync(new(id), token);
        return Ok();
    }

    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [HttpPost("{Id:guid}/Category")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> AddCategory(Guid id, Guid categoryId,
        CancellationToken token = default)
    {
        await _productFacade.AddCategory.HandelAsync(new(id, categoryId), token);
        return Ok();
    }

    [HttpDelete("{Id:guid}/Categories/{CategoryId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> RemoveCategory(Guid id, Guid categoryId,
        CancellationToken token = default)
    {
        await _productFacade.RemoveCategory.HandelAsync(new(id, categoryId), token);
        return Ok();
    }
}