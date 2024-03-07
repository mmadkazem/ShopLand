namespace ShopLand.Api.Controller.Carts;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartsController(ICartFacade cartFacade)
    : ControllerBase
{
    ICartFacade _cartFacade = cartFacade;

    [HttpPost]
    public async Task<IActionResult> Post
        ([FromBody] AddCartItemCommandRequest request)
    {
        await _cartFacade.AddCartItem.HandelAsync(request);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cart = await _cartFacade.GetCart.HandelAsync(User.UserId());
        return Ok(cart);
    }

    [HttpPut]
    public async Task<IActionResult> Update
        ([FromBody] UpdateCartItemCommandRequest request)
    {
        request.UserId = User.UserId();
        await _cartFacade.UpdateCartItem.HandelAsync(request);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Remove
        ([FromBody] RemoveCartItemCommandRequest request)
    {
        request.UserId = User.UserId();
        await _cartFacade.RemoveCartItem.HandleAsync(request);
        return Ok();
    }
}