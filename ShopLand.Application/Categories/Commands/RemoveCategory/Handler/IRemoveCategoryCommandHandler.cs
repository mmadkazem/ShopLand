namespace ShopLand.Application.Categories.Commands.RemoveCategory.Handler;

public interface IRemoveCategoryCommandHandler
{
    Task HandelAsync(RemoveCategoryCommandRequest request);
}