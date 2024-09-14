namespace ShopLand.Application.Carts.Queries.GetCart.Handler;

public class GetCartQueryHandler(IUnitOfWork uow) : IGetCartQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<GetCartQueryResponse> HandelAsync(GetCartQueryRequest request, CancellationToken token = default)
    {
        var cart = await _uow.Carts.FindAsyncByUserId(request.userId, token)
            ?? throw new CartNotFoundException();

        List<GetCartItemQueryResponse> cartItemResponses = [];
        foreach (var item in cart.CartItems)
        {
            var product = await _uow.Products.FindAsync(item.ProductId, token);
            cartItemResponses.Add(item.AsResponse(product));
        }

        return cart.AsResponse(cartItemResponses);
    }
}