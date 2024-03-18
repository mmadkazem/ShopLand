namespace ShopLand.Application.Orders.Commands.CreateOrder.Handler;

public class CreateOrderCommandHandler : ICreateOrderCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IOrderFactory _orderFactory;
    private readonly ICreatedOrderEventHandler _createdOrder;

    public CreateOrderCommandHandler(IUnitOfWork uow, IOrderFactory orderFactory,
        ICreatedOrderEventHandler createdOrder)
    {
        _uow = uow;
        _orderFactory = orderFactory;
        _createdOrder = createdOrder;
    }

    public async Task HandelAsync(CreateOrderCommandRequest request)
    {
        var (userId, requestPayId, cartId,
             authority, refId, street, city, state, postalCode) = request;

        var isExist = await _uow.Users.Any(userId);
        if (!isExist)
        {
            throw new UserNotFoundException();
        }

        var requestPay = await _uow.RequestPays.FindAsync(requestPayId);
        if (requestPay is null)
        {
            throw new RequestPayNotFoundException();
        }
        requestPay.PayOff(authority, refId);

        var order = _orderFactory.Create(userId, requestPayId, street,
             city, state, postalCode);

        var cart = await _uow.Carts.FindAsync(cartId);
        if (cart is null)
        {
            throw new CartNotFoundException();
        }

        foreach (var item in cart.CartItems)
        {
            var product = await _uow.Products.FindAsync(item.ProductId);
            order.AddOrderDetail(product.Id, item.Count, product.Price);
        }
        cart.IsFinished();
        _uow.Orders.Add(order);
        await _uow.SaveAsync();

        await _createdOrder.HandelAsync(userId);
    }
}