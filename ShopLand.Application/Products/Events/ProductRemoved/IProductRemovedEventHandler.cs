namespace ShopLand.Application.Products.Events.ProductRemoved;

public interface IProductRemovedEventHandler
{
    Task HandelAsync(Guid productId);
}

public class ProductRemovedEventHandler(IUnitOfWork uow)
    : IProductRemovedEventHandler
{
    private readonly IUnitOfWork _uow = uow;
    public async Task HandelAsync(Guid productId)
    {
        var cartItems = await _uow.Carts.FindAsyncCartItem(productId);
        _uow.Carts.RemoveCartItem(cartItems);
        await _uow.SaveAsync();
    }
}