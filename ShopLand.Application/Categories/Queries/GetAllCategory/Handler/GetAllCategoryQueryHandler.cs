namespace ShopLand.Application.Categories.Queries.GetAllCategory.Handler;

public sealed class GetAllCategoryQueryHandler(IUnitOfWork uow)
    : IGetAllCategoryQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default)
    {
        var responses = await _uow.Categories.GetAll(request.Page, token);
        if (!responses.Any())
        {
            throw new CategoryNotFoundException();
        }

        return responses;
    }
}