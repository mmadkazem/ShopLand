namespace ShopLand.Api.Controller.Orders;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController(IOrderFacade orderFacade)
    : ControllerBase
{
    private readonly IOrderFacade _orderFacade = orderFacade;

    [HttpPost]
    public async Task<IActionResult> Post
        ([FromBody] CreateOrderCommandRequest request)
    {
        await _orderFacade.CreateOrder.HandelAsync(request);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update
        ([FromBody] UpdateOrderStateCommandRequest request)
    {
        await _orderFacade.UpdateOrderState.HandelAsync(request);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cart = await _orderFacade.GetOrderByUser.HandelAsync(User.UserId());
        return Ok(cart);
    }

    [HttpGet("{UserId:guid}")]
    public async Task<IActionResult> Get(GetOrderByUserIdQueryRequest request)
    {
        var cart = await _orderFacade.GetOrderByUser.HandelAsync(request);
        return Ok(cart);
    }

    [HttpGet("{Page:int}")]
    public async Task<IActionResult> Get(PageNumberRequest request)
    {
        var cart = await _orderFacade.GetAllOrder.HandelAsync(request);
        return Ok(cart);
    }
}