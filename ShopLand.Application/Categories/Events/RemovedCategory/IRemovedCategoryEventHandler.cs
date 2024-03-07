namespace ShopLand.Application.Categories.Events.RemovedCategory;

public interface IRemovedCategoryEventHandler
{
    Task HandelAsync(Category category);
}

public class RemovedCategoryEventHandler(IUnitOfWork uow) : IRemovedCategoryEventHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(Category category)
    {
        await _uow.Products.RemoveProductCategories(category.Id);
        await _uow.SaveAsync();
    }
}