namespace ShopLand.Application.Carts.Commands.AddCartItem.Request;

public record AddCartItemCommandRequest(uint Count, Guid ProductId, Guid UserId);