namespace ShopLand.Application.Carts.Commands.AddCartItem.Handler;

public class AddCartItemCommandHandler(IUnitOfWork uow, ICartFactory cartFactory) : IAddCartItemCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICartFactory _cartFactory = cartFactory;

    public async Task HandelAsync(AddCartItemCommandRequest request, CancellationToken token = default)
    {
        var (count, productId, userId) = request;

        var cart = await _uow.Carts.FindAsyncByUserId(userId, token)
            ?? throw new CartNotFoundException();

        var product = await _uow.Products.FindAsync(productId, token)
            ?? throw new ProductNotFoundException();

        cart.AddCartItem(product.Id, count, product.Inventory);
        await _uow.SaveAsync(token);
    }
}