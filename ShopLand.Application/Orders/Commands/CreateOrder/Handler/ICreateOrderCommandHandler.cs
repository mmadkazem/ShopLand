namespace ShopLand.Application.Orders.Commands.CreateOrder.Handler;

public interface ICreateOrderCommandHandler
{
    Task HandelAsync(CreateOrderCommandRequest request, CancellationToken token = default);
}
