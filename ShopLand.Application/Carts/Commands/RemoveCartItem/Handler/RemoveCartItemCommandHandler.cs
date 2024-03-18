namespace ShopLand.Application.Carts.Commands.RemoveCartItem.Handler;

public class RemoveCartItemCommandHandler(IUnitOfWork uow)
    : IRemoveCartItemCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandleAsync(RemoveCartItemCommandRequest request)
    {
        var cart = await _uow.Carts.FindAsyncByUserId(request.UserId);
        if (cart is null)
        {
            throw new CartNotFoundException();
        }

        cart.RemoveCartItem(request.ProductId);
        await _uow.SaveAsync();
    }
}