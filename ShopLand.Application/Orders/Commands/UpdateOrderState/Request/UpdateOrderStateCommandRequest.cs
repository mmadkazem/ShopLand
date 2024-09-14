namespace ShopLand.Application.Orders.Commands.UpdateOrderState.Request;


public readonly record struct UpdateOrderStateCommandRequest(Guid OrderId, OrderState OrderState);