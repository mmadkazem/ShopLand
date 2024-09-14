namespace ShopLand.Application.Carts.Commands.RemoveCartItem.Handler;

public class RemoveCartItemCommandHandler(IUnitOfWork uow)
    : IRemoveCartItemCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandleAsync(RemoveCartItemCommandRequest request, CancellationToken token = default)
    {
        var cart = await _uow.Carts.FindAsyncByUserId(request.UserId, token)
            ?? throw new CartNotFoundException();

        cart.RemoveCartItem(request.ProductId);
        await _uow.SaveAsync(token);
    }
}