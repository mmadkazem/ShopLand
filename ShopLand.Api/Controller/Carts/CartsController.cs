namespace ShopLand.Api.Controller.Carts;



[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartsController(ICartFacade cartFacade)
    : ControllerBase
{
    private readonly ICartFacade _cartFacade = cartFacade;

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post(AddCartItemDTO model,
        CancellationToken token)
    {
        var request = AddCartItemCommandRequest.Create(User.UserId(), model);
        await _cartFacade.AddCartItem.HandelAsync(request, token);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<GetCartQueryResponse>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(CancellationToken token = default)
    {
        var cart = await _cartFacade.GetCart.HandelAsync(User.UserId(), token);
        return Ok(cart);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(UpdateCartItemDTO model,
        CancellationToken token = default)
    {
        var request = UpdateCartItemCommandRequest.Create(User.UserId(), model);
        await _cartFacade.UpdateCartItem.HandelAsync(request, token);
        return Ok();
    }

    [HttpDelete("Products/{productId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Remove(Guid productId,
        CancellationToken token = default)
    {
        await _cartFacade.RemoveCartItem.HandleAsync(new(User.UserId(), productId), token);
        return Ok();
    }
}