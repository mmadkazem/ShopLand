namespace ShopLand.Application.Products.Events.ProductRemoved;

public interface IProductRemovedEventHandler
{
    Task HandelAsync(Guid productId, CancellationToken token = default);
}

public class ProductRemovedEventHandler(IUnitOfWork uow)
    : IProductRemovedEventHandler
{
    private readonly IUnitOfWork _uow = uow;
    public async Task HandelAsync(Guid productId, CancellationToken token = default)
    {
        await _uow.Carts.RemoveCartItem(productId, token);
    }
}