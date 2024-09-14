namespace ShopLand.Application.Carts.Commands.UpdateCartItem.Handler;

public interface IUpdateCartItemCommandHandler
{
    Task HandelAsync(UpdateCartItemCommandRequest request, CancellationToken token = default);
}
