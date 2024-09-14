namespace ShopLand.Application.Categories.Commands.CreateCategory.Handler;

public sealed class CreateCategoryCommandHandler(IUnitOfWork uow, ICategoryFactory categoryFactory)
    : ICreateCategoryCommandHandler
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICategoryFactory _categoryFactory = categoryFactory;

    public async Task<Guid> HandelAsync(CreateCategoryCommandRequest request, CancellationToken token = default)
    {
        if (await _uow.Categories.Any(request.Name, token))
        {
            throw new CategoryAlreadyExistException();
        }

        var category = _categoryFactory.Create(request.Name);

        _uow.Categories.Add(category);
        await _uow.SaveChangeAsync(token);

        return category.Id;
    }
}