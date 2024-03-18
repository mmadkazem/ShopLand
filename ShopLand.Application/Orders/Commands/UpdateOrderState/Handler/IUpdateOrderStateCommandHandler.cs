namespace ShopLand.Application.Orders.Commands.UpdateOrderState.Handler;

public interface IUpdateOrderStateCommandHandler
{
    Task HandelAsync(UpdateOrderStateCommandRequest request);
}
