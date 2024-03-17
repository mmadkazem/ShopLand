using ShopLand.Application.Carts.Commands.UpdateCartItem.Request;

namespace ShopLand.Application.Carts.Commands.UpdateCartItem.Handler;

public interface IUpdateCartItemCommandHandler
{
    Task HandelAsync(UpdateCartItemCommandRequest request);
}
