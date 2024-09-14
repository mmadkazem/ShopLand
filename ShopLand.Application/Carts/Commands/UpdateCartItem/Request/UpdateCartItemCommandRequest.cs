namespace ShopLand.Application.Carts.Commands.UpdateCartItem.Request;

public readonly record struct UpdateCartItemCommandRequest(Guid UserId, CountType CountType, Guid ProductId)
{
    public static UpdateCartItemCommandRequest Create(Guid userId, UpdateCartItemDTO model)
        => new(userId, model.CountType, model.ProductId);
}

public readonly record struct UpdateCartItemDTO(CountType CountType, Guid ProductId);

public enum CountType
{
    Add = 1,
    Low = 2,
}