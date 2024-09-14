namespace ShopLand.Application.Products.Commands.RemoveProductCategory.Handler;

public class RemoveProductCategoryCommandHandler(IUnitOfWork uow)
    : IRemoveProductCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(RemoveProductCategoryCommandRequest request, CancellationToken token = default)
    {
        var product = await _uow.Products.FindAsync(request.ProductId, token)
            ?? throw new ProductNotFoundException();

        product.RemoveCategory(request.CategoryId);
        await _uow.SaveAsync(token);
    }
}