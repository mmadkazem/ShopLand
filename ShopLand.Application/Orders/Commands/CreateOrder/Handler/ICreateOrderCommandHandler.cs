namespace ShopLand.Application.Orders.Commands.CreateOrder.Handler;

public interface ICreateOrderCommandHandler
{
    Task HandelAsync(CreateOrderCommandRequest request);
}

public class CreateOrderCommandHandler : ICreateOrderCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IOrderFactory _orderFactory;

    public CreateOrderCommandHandler(IUnitOfWork uow, IOrderFactory orderFactory)
    {
        _uow = uow;
        _orderFactory = orderFactory;
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

        await _uow.SaveAsync();

    }
}