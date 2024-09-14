namespace ShopLand.Application.Categories.Commands.RemoveCategory.Handler;

public sealed class RemoveCategoryCommandHandler(IUnitOfWork uow, IRemovedCategoryEventHandler removedCategory)
    : IRemoveCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IRemovedCategoryEventHandler _removedCategory = removedCategory;

    public async Task HandelAsync(RemoveCategoryCommandRequest request, CancellationToken token = default)
    {
        var category = await _uow.Categories.FindAsync(request.Id, token)
            ?? throw new CategoryNotFoundException();

        _uow.Categories.Remove(category);
        await _uow.SaveChangeAsync(token);

        await _removedCategory.HandelAsync(category.Id, token);
    }
}

