namespace ShopLand.Application.Account.Events.RemovedUser;

public class RemovedUserEventHandler(IUnitOfWork uow)
    : IRemovedUserEventHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(Guid userId)
    {
        var cart = await _uow.Carts.FindAsyncByUserId(userId);
        _uow.Carts.Remove(cart);
        await _uow.SaveAsync();
    }
}