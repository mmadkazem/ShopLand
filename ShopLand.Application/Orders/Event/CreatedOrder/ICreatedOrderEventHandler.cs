namespace ShopLand.Application.Orders.Event.CreatedOrder;

public interface ICreatedOrderEventHandler
{
    Task HandelAsync(Guid userId, CancellationToken token = default);
}

public class CreatedOrderEventHandler(IUnitOfWork uow)
    : ICreatedOrderEventHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICartFactory _cartFactory = new CartFactory();

    public async Task HandelAsync(Guid userId, CancellationToken token = default)
    {
        var cart = _cartFactory.Create(userId);
        _uow.Carts.Add(cart);
        await _uow.SaveAsync(token);

    }
}