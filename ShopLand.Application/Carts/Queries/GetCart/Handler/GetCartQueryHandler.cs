namespace ShopLand.Application.Carts.Queries.GetCart.Handler;

public class GetCartQueryHandler(IUnitOfWork uow) : IGetCartQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<GetCartQueryResponse> HandelAsync
        (GetCartQueryRequest request)
    {
        var cart = await _uow.Carts.FindAsyncByUserId(request.userId);
        if (cart is null)
        {
            throw new CartNotFoundException();
        }
        List<GetCartItemQueryResponse> cartItemResponses = new();
        foreach (var item in cart.CartItems)
        {
            var product = await _uow.Products.FindAsync(item.ProductId);
            cartItemResponses.Add(item.AsResponse(product));
        }

        return cart.AsResponse(cartItemResponses);
    }
}