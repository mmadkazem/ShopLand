namespace ShopLand.Application.Products.Events.ProductUpdated;

public sealed class ProductUpdatedEventHandler(IUnitOfWork uow)
        : IProductUpdatedEventHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(Guid productId, uint productPrice, CancellationToken token = default)
    {
        await _uow.Carts.UpdatedProduct(productId, productPrice, token);
    }
}