using ShopLand.Domain.Orders.Const;

namespace ShopLand.Application.Orders.Commands.UpdateOrderState.Request;
public record UpdateOrderStateCommandRequest(Guid OrderId, OrderState OrderState);