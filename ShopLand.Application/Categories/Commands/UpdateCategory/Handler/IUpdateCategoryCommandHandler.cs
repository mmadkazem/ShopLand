namespace ShopLand.Application.Categories.Commands.UpdateCategory.Handler;

public interface IUpdateCategoryCommandHandler
{
    Task HandelAsync(UpdateCategoryCommandRequest request, CancellationToken token = default);
}
