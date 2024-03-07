namespace ShopLand.Application.Carts.Commands.RemoveCartItem.Request;

public record RemoveCartItemCommandRequest(Guid ProductId)
{
    public Guid UserId { get; set; }
}