namespace ShopLand.Application.Orders.Commands.CreateOrder.Request;

public record CreateOrderCommandRequest
    (Guid UserId, Guid RequestPayId, Guid CartId, string Authority, long RefId,
     string Street, string City, string State, string PostalCode);