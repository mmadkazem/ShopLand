namespace ShopLand.Application.Categories.Commands.CreateCategory.Handler;

public class CreateCategoryCommandHandler(IUnitOfWork uow, ICategoryFactory categoryFactory)
    : ICreateCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICategoryFactory _categoryFactory = categoryFactory;

    public async Task<Guid> HandelAsync(CreateCategoryCommandRequest request, CancellationToken token = default)
    {
        var category = _categoryFactory.Create(request.Name);

        _uow.Categories.Add(category);
        await _uow.SaveAsync(token);

        return category.Id;
    }
}