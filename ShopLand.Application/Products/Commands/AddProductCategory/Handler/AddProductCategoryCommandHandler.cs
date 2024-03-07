namespace ShopLand.Application.Products.Commands.AddProductCategory.Handler;

public interface IAddProductCategoryCommandHandler
{
    Task HandelAsync(AddProductCategoryCommandRequest request);
}

public class AddProductCategoryCommandHandler(IUnitOfWork uow) : IAddProductCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(AddProductCategoryCommandRequest request)
    {
        var product = await _uow.Products.FindAsync(request.ProductId);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        var isExist = await _uow.Categories.Any(request.Category);
        if (!isExist)
        {
            throw new CategoryNotFoundException();
        }

        product.AddCategory(request.Category);
        await _uow.SaveAsync();
    }
}