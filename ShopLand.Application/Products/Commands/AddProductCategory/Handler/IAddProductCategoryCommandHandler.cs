namespace ShopLand.Application.Products.Commands.AddProductCategory.Handler;

public interface IAddProductCategoryCommandHandler
{
    Task HandelAsync(AddProductCategoryCommandRequest request, CancellationToken token = default);
}
