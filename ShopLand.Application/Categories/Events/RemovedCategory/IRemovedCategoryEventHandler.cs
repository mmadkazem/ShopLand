namespace ShopLand.Application.Categories.Events.RemovedCategory;

public interface IRemovedCategoryEventHandler
{
    Task HandelAsync(Guid categoryId, CancellationToken token = default);
}

public class RemovedCategoryEventHandler(IUnitOfWork uow) : IRemovedCategoryEventHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(Guid categoryId,CancellationToken token = default)
    {
        await _uow.Products.RemoveProductCategories(categoryId, token);
    }
}