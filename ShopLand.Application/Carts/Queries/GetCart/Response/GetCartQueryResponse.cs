namespace ShopLand.Application.Carts.Queries.GetCart.Response;

public record GetCartQueryResponse
(
    Guid UserId, bool Finished,
    List<GetCartItemQueryResponse> CartItems
);


public record GetCartItemQueryResponse
(
    Guid CartId, uint Count, uint TotalPrice,
    uint ProductPrice, Guid ProductId
);



public static class Extension
{
    public static GetCartItemQueryResponse AsResponse(this CartItem CartItem, Product product)
        => new
        (
            CartItem.CartId, CartItem.Count,
            product.Price * CartItem.Count,
            product.Price, product.Id
        );
    public static GetCartQueryResponse AsResponse(this Cart Cart, List<GetCartItemQueryResponse> CartItems)
        => new(Cart.UserId, Cart.Finished, CartItems);
}