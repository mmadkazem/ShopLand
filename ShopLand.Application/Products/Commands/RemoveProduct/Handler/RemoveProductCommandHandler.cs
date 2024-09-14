namespace ShopLand.Application.Products.Commands.RemoveProduct.Handler;

public interface IRemoveProductCommandHandler
{
    Task HandelAsync(RemoveProductCommandRequest request, CancellationToken token = default);
}

public class RemoveProductCommandHandler
    (IUnitOfWork uow,IProductRemovedEventHandler productRemoved)
        : IRemoveProductCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IProductRemovedEventHandler _productRemoved = productRemoved;

    public async Task HandelAsync(RemoveProductCommandRequest request, CancellationToken token = default)
    {
        var product = await _uow.Products.FindAsync(request.productId, token)
            ?? throw new ProductNotFoundException();

        _uow.Products.Remove(product);
        await _uow.SaveAsync(token);
        await _productRemoved.HandelAsync(product.Id, token);
    }
}