namespace ShopLand.Application.Carts.Commands.RemoveCartItem.Handler;

public interface IRemoveCartItemCommandHandler
{
    Task HandleAsync(RemoveCartItemCommandRequest request, CancellationToken token = default);
}
