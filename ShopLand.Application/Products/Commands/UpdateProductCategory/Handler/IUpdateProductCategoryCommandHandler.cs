namespace ShopLand.Application.Products.Commands.UpdateProductCategory.Handler;

public interface IUpdateProductCategoryCommandHandler
{
    Task HandelAsync(UpdateProductCategoryCommandRequest request);
}

public class UpdateProductCategoryCommandHandler(IUnitOfWork uow)
    : IUpdateProductCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(UpdateProductCategoryCommandRequest request)
    {
        var product = await _uow.Products.FindAsync(request.ProductId);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        var isExistNew = await _uow.Categories.Any(request.newCategory);
        if (!isExistNew)
        {
            throw new CategoryNotFoundException();
        }

        product.UpdateCategory(request.oldCategory, request.newCategory);
        await _uow.SaveAsync();
    }
}