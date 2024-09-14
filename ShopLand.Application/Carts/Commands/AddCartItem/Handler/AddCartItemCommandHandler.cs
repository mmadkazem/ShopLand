namespace ShopLand.Application.Carts.Commands.AddCartItem.Handler;

public sealed class AddCartItemCommandHandler(IUnitOfWork uow)
    : IAddCartItemCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(AddCartItemCommandRequest request, CancellationToken token = default)
    {
        var (userId, count, productId) = request;

        var cart = await _uow.Carts.FindAsyncByUserId(userId, token)
            ?? throw new CartNotFoundException();

        var product = await _uow.Products.FindAsync(productId, token)
            ?? throw new ProductNotFoundException();

        cart.AddCartItem(product.Id, count, product.Inventory, product.Price);
        await _uow.SaveChangeAsync(token);
    }
}