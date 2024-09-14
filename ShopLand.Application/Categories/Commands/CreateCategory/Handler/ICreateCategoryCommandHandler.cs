namespace ShopLand.Application.Categories.Commands.CreateCategory.Handler;

public interface ICreateCategoryCommandHandler
{
    Task<Guid> HandelAsync(CreateCategoryCommandRequest request, CancellationToken token = default);
}
