namespace ShopLand.Application.Categories.Queries.GetAllCategory.Handler;

public class GetAllCategoryQueryHandler(IUnitOfWork uow) : IGetAllCategoryQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<GetAllCategoryQueryResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default)
    {
        var categories = await _uow.Categories.GetAll(request.Page, token);
        if (!categories.Any())
        {
            throw new CategoryNotFoundException();
        }

        return categories.Select(s => s.AsResponses()).ToList();
    }
}