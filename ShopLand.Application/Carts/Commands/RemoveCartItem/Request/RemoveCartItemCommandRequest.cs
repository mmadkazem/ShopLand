namespace ShopLand.Application.Carts.Commands.RemoveCartItem.Request;

public readonly record struct RemoveCartItemCommandRequest(Guid UserId, Guid ProductId)
{
    public static RemoveCartItemCommandRequest Create(Guid userId, Guid productId)
        => new(userId, productId);
}