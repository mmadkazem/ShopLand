using ShopLand.Application.Products.Events.ProductRemoved;

namespace ShopLand.Application.Products.Commands.RemoveProduct.Handler;

public interface IRemoveProductCommandHandler
{
    Task HandelAsync(RemoveProductCommandRequest request);
}

public class RemoveProductCommandHandler
    (IUnitOfWork uow,IProductRemovedEventHandler productRemoved)
        : IRemoveProductCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IProductRemovedEventHandler _productRemoved = productRemoved;

    public async Task HandelAsync(RemoveProductCommandRequest request)
    {
        var product = await _uow.Products.FindAsync(request.productId);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        _uow.Products.Remove(product);
        await _uow.SaveAsync();
        await _productRemoved.HandelAsync(product.Id);
    }
}