namespace ShopLand.Application.Products.Commands.AddProductCategory.Handler;


public sealed class AddProductCategoryCommandHandler(IUnitOfWork uow)
    : IAddProductCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(AddProductCategoryCommandRequest request, CancellationToken token = default)
    {
        var product = await _uow.Products.FindAsync(request.ProductId, token)
            ?? throw new ProductNotFoundException();

        var isExist = await _uow.Categories.Any(request.CategoryId, token);
        if (!isExist)
        {
            throw new CategoryNotFoundException();
        }

        product.AddCategory(request.CategoryId);
        await _uow.SaveChangeAsync(token);
    }
}