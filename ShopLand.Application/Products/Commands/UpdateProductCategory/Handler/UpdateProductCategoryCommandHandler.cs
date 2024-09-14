namespace ShopLand.Application.Products.Commands.UpdateProductCategory.Handler;

public class UpdateProductCategoryCommandHandler(IUnitOfWork uow)
    : IUpdateProductCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(UpdateProductCategoryCommandRequest request, CancellationToken token = default)
    {
        var product = await _uow.Products.FindAsync(request.ProductId, token)
            ?? throw new ProductNotFoundException();

        var isExistNew = await _uow.Categories.Any(request.newCategory, token);
        if (!isExistNew)
        {
            throw new CategoryNotFoundException();
        }

        product.UpdateCategory(request.oldCategory, request.newCategory);
        await _uow.SaveAsync(token);
    }
}