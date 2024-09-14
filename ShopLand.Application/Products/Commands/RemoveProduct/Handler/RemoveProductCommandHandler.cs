namespace ShopLand.Application.Products.Commands.RemoveProduct.Handler;

public sealed class RemoveProductCommandHandler(IUnitOfWork uow,IProductRemovedEventHandler productRemoved)
    : IRemoveProductCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IProductRemovedEventHandler _productRemoved = productRemoved;

    public async Task HandelAsync(RemoveProductCommandRequest request, CancellationToken token = default)
    {
        var product = await _uow.Products.FindAsync(request.ProductId, token)
            ?? throw new ProductNotFoundException();

        _uow.Products.Remove(product);
        await _uow.SaveChangeAsync(token);
        await _productRemoved.HandelAsync(product.Id, token);
    }
}