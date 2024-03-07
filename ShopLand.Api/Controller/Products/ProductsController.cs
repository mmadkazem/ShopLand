namespace ShopLand.Api.Controller.Products;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController(IProductFacade productFacade)
    : ControllerBase
{
    private readonly IProductFacade _productFacade = productFacade;

    [HttpPost]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> Post
        ([FromBody] CreateProductCommandRequest request)
    {
        var result = await _productFacade.CreateProduct.HandelAsync(request);
        var url = Url.Action(nameof(Get), "Products", new { Id = result }, Request.Scheme);
        return Created(url, true);
    }

    [HttpPut("{ProductId:guid}")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> Put
        ([FromBody] UpdateProductCommandRequest request)
    {
        await _productFacade.UpdateProduct.HandelAsync(request);
        return Ok();
    }

    [HttpGet("{Page:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get
        ([FromHeader] PageNumberRequest request)
    {
        var products = await _productFacade
            .GetAllProduct.HandelAsync(request);
        return Ok(products);
    }

    [HttpGet("{ProductId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get
        ([FromHeader] GetProductQueryRequest request)
    {
        var products = await _productFacade
            .GetProduct.HandelAsync(request);
        return Ok(products);
    }

    [HttpDelete("{ProductId:guid}")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> Remove
        ([FromBody] RemoveProductCommandRequest request)
    {
        await _productFacade.RemoveProduct.HandelAsync(request);
        return Ok();
    }

    [HttpPost("{ProductId:guid}/Category")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> AddCategory
        (AddProductCategoryCommandRequest request)
    {
        await _productFacade.AddCategory.HandelAsync(request);
        return Ok();
    }

    [HttpPut("{ProductId:guid}/Category/{CategoryId:guid}")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> UpdateCategory
        (UpdateProductCategoryCommandRequest request)
    {
        await _productFacade.UpdateCategory.HandelAsync(request);
        return Ok();
    }

    [HttpDelete("{ProductId:guid}/Category/{CategoryId:guid}")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> RemoveCategory
        (RemoveProductCategoryCommandRequest request)
    {
        await _productFacade.RemoveCategory.HandelAsync(request);
        return Ok();
    }
}