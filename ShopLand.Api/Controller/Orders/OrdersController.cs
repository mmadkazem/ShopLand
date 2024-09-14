namespace ShopLand.Api.Controller.Orders;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController(IOrderFacade orderFacade)
    : ControllerBase
{
    private readonly IOrderFacade _orderFacade = orderFacade;

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post(CreateOrderDTO model,
        CancellationToken token = default)
    {
        var request = CreateOrderCommandRequest.Create(User.UserId(), model);
        await _orderFacade.CreateOrder.HandelAsync(request, token);
        return Created();
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid orderId, OrderState state,
        CancellationToken token = default)
    {
        await _orderFacade.UpdateOrderState.HandelAsync(new(orderId, state), token);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<IEnumerable<GetOrderQueryResponse>>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(CancellationToken token = default)
    {
        var cart = await _orderFacade.GetOrderByUserId.HandelAsync(new(User.UserId()), token);
        return Ok(cart);
    }

    [HttpGet("Page/{page:int}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<IEnumerable<GetOrderQueryResponse>>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(int page)
    {
        var cart = await _orderFacade.GetAllOrder.HandelAsync(new(page));
        return Ok(cart);
    }
}