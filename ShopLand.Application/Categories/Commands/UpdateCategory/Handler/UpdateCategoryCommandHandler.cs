namespace ShopLand.Application.Categories.Commands.UpdateCategory.Handler;

public class UpdateCategoryCommandHandler(IUnitOfWork uow)
    : IUpdateCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    public async Task HandelAsync(UpdateCategoryCommandRequest request)
    {
        var category = await _uow.Categories.FindAsync(request.Id);
        if (category is null)
        {
            throw new CategoryNotFoundException();
        }
        category.UpdateCategoryName(request.Name);
        await _uow.SaveAsync();
    }
}