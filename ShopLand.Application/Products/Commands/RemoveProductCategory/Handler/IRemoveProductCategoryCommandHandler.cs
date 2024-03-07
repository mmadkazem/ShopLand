using ShopLand.Application.Products.Commands.RemoveProductCategory.Request;

namespace ShopLand.Application.Products.Commands.RemoveProductCategory.Handler;

public interface IRemoveProductCategoryCommandHandler
{
    Task HandelAsync(RemoveProductCategoryCommandRequest request);
}
