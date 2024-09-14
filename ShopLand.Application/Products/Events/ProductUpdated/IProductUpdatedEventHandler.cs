namespace ShopLand.Application.Products.Events.ProductUpdated;


public interface IProductUpdatedEventHandler
{
    Task HandelAsync(Guid productId, uint productPrice, CancellationToken token = default);
}