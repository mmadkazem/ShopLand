namespace ShopLand.Application.Carts.Commands.AddCartItem.Handler;

public interface IAddCartItemCommandHandler
{
    Task HandelAsync(AddCartItemCommandRequest request, CancellationToken token = default);
}
