namespace ShopLand.Application.Categories.Commands.CreateCategory.Handler;

public class CreateCategoryCommandHandler : ICreateCategoryCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly ICategoryFactory _categoryFactory;

    public CreateCategoryCommandHandler(IUnitOfWork uow,
        ICategoryFactory categoryFactory)
    {
        _categoryFactory = categoryFactory;
        _uow = uow;
    }

    public async Task<Guid> HandelAsync(CreateCategoryCommandRequest request)
    {
        var category = _categoryFactory.Create(request.Name);

        _uow.Categories.Add(category);
        await _uow.SaveAsync();

        return category.Id;
    }
}