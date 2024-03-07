namespace ShopLand.Application.Account.Events.AddedUser;

public class AddedUserEventHandler : IAddedUserEventHandler
{
    private readonly IUnitOfWork _uow;
    private readonly ICartFactory _cartFactory;

    public AddedUserEventHandler(IUnitOfWork uow, ICartFactory cartFactory)
    {
        _uow = uow;
        _cartFactory = cartFactory;
    }

    public async Task HandelAsync(Guid userId)
    {
        var cart = _cartFactory.Create(userId);
        _uow.Carts.Add(cart);
        await _uow.SaveAsync();
    }
}
