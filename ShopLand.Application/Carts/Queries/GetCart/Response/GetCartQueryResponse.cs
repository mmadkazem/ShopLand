namespace ShopLand.Application.Carts.Queries.GetCart.Response;

public record GetCartQueryResponse
(
    Guid UserId, bool Finished,
    IEnumerable<GetCartItemDTO> CartItems
) : IResponse;


public readonly record struct GetCartItemDTO
(
    Guid CartId, uint Count, uint TotalPrice,
    uint ProductPrice, Guid ProductId
);



public static class Extension
{
    public static GetCartItemDTO AsResponse(this CartItem cartItem)
        => new
        (
            cartItem.CartId, cartItem.Count,
            cartItem.TotalPrice,
            cartItem.ProductPrice, cartItem.ProductId
        );
    public static GetCartQueryResponse AsResponse(this Cart cart)
        => new(cart.UserId, cart.Finished, cart.CartItems.Select(c => c.AsResponse()).ToList());
}