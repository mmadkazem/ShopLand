namespace ShopLand.Application.Orders.Commands.CreateOrder.Request;

public readonly record struct CreateOrderCommandRequest
(
    Guid UserId, Guid RequestPayId, Guid CartId, string Authority, long RefId,
    string Street, string City, string State, string PostalCode
)
{
    public static CreateOrderCommandRequest Create(Guid userId, CreateOrderDTO model)
        => new
        (
            userId, model.RequestPayId, model.CartId, model.Authority,
            model.RefId, model.Street, model.City,model.State, model.PostalCode
        );
}

public readonly record struct CreateOrderDTO
(
    Guid RequestPayId, Guid CartId, string Authority, long RefId,
    string Street, string City, string State, string PostalCode
);