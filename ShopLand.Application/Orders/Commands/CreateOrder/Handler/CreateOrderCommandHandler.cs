namespace ShopLand.Application.Orders.Commands.CreateOrder.Handler;

public sealed  class CreateOrderCommandHandler(
    IUnitOfWork uow,
    IOrderFactory orderFactory,
    ICreatedOrderEventHandler createdOrder)
    : ICreateOrderCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IOrderFactory _orderFactory = orderFactory;
    private readonly ICreatedOrderEventHandler _createdOrder = createdOrder;

    public async Task HandelAsync(CreateOrderCommandRequest request, CancellationToken token = default)
    {
        var (userId, requestPayId, cartId, authority, refId, street, city, state, postalCode) = request;

        var isExist = await _uow.Users.Any(userId, token);
        if (!isExist)
        {
            throw new UserNotFoundException();
        }

        var requestPay = await _uow.RequestPays.FindAsync(requestPayId, token)
            ?? throw new RequestPayNotFoundException();

        requestPay.PayOff(authority, refId);

        var order = _orderFactory.Create(userId, requestPayId, street, city, state, postalCode);

        var cart = await _uow.Carts.FindAsync(cartId, token)
            ?? throw new CartNotFoundException();

        foreach (var item in cart.CartItems)
        {
            var product = await _uow.Products.FindAsync(item.ProductId, token);
            order.AddOrderDetail(product.Id, item.Count, product.Price);
        }
        cart.IsFinished();
        _uow.Orders.Add(order);
        await _uow.SaveAsync(token);

        await _createdOrder.HandelAsync(userId, token);
    }
}