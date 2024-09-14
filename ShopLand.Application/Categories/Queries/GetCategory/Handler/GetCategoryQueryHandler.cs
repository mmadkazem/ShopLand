namespace ShopLand.Application.Categories.Queries.GetCategory.Handler;

public sealed class GetCategoryQueryHandler(IUnitOfWork uow)
    : IGetCategoryQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> HandelAsync(GetCategoryQueryRequest request, CancellationToken token = default)
        => await _uow.Categories.Get(request.Id, token)
            ?? throw new CategoryNotFoundException();
}