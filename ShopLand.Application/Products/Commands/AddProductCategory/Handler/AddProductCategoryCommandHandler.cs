namespace ShopLand.Application.Products.Commands.AddProductCategory.Handler;


public sealed  class AddProductCategoryCommandHandler(IUnitOfWork uow)
    : IAddProductCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(AddProductCategoryCommandRequest request, CancellationToken token = default)
    {
        var product = await _uow.Products.FindAsync(request.ProductId, token)
            ?? throw new ProductNotFoundException();

        var isExist = await _uow.Categories.Any(request.Category, token);
        if (!isExist)
        {
            throw new CategoryNotFoundException();
        }

        product.AddCategory(request.Category);
        await _uow.SaveAsync(token);
    }
}