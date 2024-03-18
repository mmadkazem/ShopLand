namespace ShopLand.Application.Categories.Commands.RemoveCategory.Handler;

public class RemoveCategoryCommandHandler : IRemoveCategoryCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IRemovedCategoryEventHandler _removedCategory;

    public RemoveCategoryCommandHandler(IUnitOfWork uow,
        IRemovedCategoryEventHandler removedCategory)
    {
        _uow = uow;
        _removedCategory = removedCategory;
    }

    public async Task HandelAsync(RemoveCategoryCommandRequest request)
    {
        var category = await _uow.Categories.FindAsync(request.Id);
        if (category is null)
        {
            throw new CategoryNotFoundException();
        }

        _uow.Categories.Remove(category);
        await _uow.SaveAsync();
        
        await _removedCategory.HandelAsync(category);
    }
}

