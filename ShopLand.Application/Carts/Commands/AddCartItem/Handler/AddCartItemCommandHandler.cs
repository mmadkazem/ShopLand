namespace ShopLand.Application.Carts.Commands.AddCartItem.Handler;

public class AddCartItemCommandHandler : IAddCartItemCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly ICartFactory _cartFactory;

    public AddCartItemCommandHandler(IUnitOfWork uow, ICartFactory cartFactory)
    {
        _cartFactory = cartFactory;
        _uow = uow;
    }

    public async Task HandelAsync(AddCartItemCommandRequest request)
    {
        var (count, productId, userId) = request;

        var cart = await _uow.Carts.FindAsyncByUserId(userId);
        if (cart is null)
        {
            throw new CartNotFoundException();
        }

        var product = await _uow.Products.FindAsync(productId);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        cart.AddCartItem(product.Id, count, product.Inventory);
        await _uow.SaveAsync();
    }
}