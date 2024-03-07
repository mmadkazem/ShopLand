namespace ShopLand.Application.Carts.Commands.UpdateCartItem.Request;

public record UpdateCartItemCommandRequest
    (CountType CountType, Guid ProductId)
{
    public Guid UserId { get; set; }
}

public enum CountType
{
    Add = 1,
    Low = 2,
}