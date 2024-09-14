namespace ShopLand.Application.Categories.Commands.UpdateCategory.Handler;

public sealed class UpdateCategoryCommandHandler(IUnitOfWork uow)
    : IUpdateCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    public async Task HandelAsync(UpdateCategoryCommandRequest request, CancellationToken token = default)
    {
        var category = await _uow.Categories.FindAsync(request.Id, token)
            ?? throw new CategoryNotFoundException();

        category.UpdateCategoryName(request.Name);
        await _uow.SaveChangeAsync(token);
    }
}