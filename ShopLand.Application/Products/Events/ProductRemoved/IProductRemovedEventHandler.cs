namespace ShopLand.Application.Products.Events.ProductRemoved;

public interface IProductRemovedEventHandler
{
    Task HandelAsync(Guid productId, CancellationToken token = default);
}