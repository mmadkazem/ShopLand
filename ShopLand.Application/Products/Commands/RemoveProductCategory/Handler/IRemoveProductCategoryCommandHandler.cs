namespace ShopLand.Application.Products.Commands.RemoveProductCategory.Handler;

public interface IRemoveProductCategoryCommandHandler
{
    Task HandelAsync(RemoveProductCategoryCommandRequest request, CancellationToken token = default);
}
