namespace ShopLand.Application.Account.Events.AddedUser;

public class AddedUserEventHandler(IUnitOfWork uow, ICartFactory cartFactory) : IAddedUserEventHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICartFactory _cartFactory = cartFactory;

    public async Task HandelAsync(Guid userId, CancellationToken token = default)
    {
        var cart = _cartFactory.Create(userId);
        _uow.Carts.Add(cart);
        await _uow.SaveAsync(token);
    }
}
