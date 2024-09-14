namespace ShopLand.Application.Carts.Commands.AddCartItem.Request;


public readonly record struct AddCartItemCommandRequest(Guid UserId, uint Count, Guid ProductId)
{
    public static AddCartItemCommandRequest Create(Guid userId, AddCartItemDTO model)
        => new(userId, model.Count, model.ProductId);
}

public readonly record struct AddCartItemDTO(uint Count, Guid ProductId);
