namespace ShopLand.Application.Products.Commands.UpdateProductCategory.Handler;

public interface IUpdateProductCategoryCommandHandler
{
    Task HandelAsync(UpdateProductCategoryCommandRequest request, CancellationToken token = default);
}